using System.Text;

namespace AsPISApe.Services;

public class SoundService : ISoundService
{
	private static readonly byte[] HoverBuffer = GenerateSoftTone(920, 800, 45, 0.55, 0.18);
	private static readonly byte[] ClickBuffer = GenerateSoftTone(560, 400, 85, 0.85, 0.25);
	private static readonly byte[] SelectBuffer = GenerateSoftTone(660, 780, 65, 0.70, 0.22);
	private static readonly byte[] ErrorBuffer = GenerateSoftTone(290, 220, 150, 0.75, 0.20);
	private static readonly byte[] PageTurnBuffer = GenerateSoftTone(360, 240, 80, 0.50, 0.15);
	private static readonly byte[] SuccessBuffer = GenerateChord([523.25, 659.25, 783.99], 100, 0.75);
	private static readonly byte[] LevelUpBuffer = GenerateChord([523.25, 659.25, 783.99, 1046.50], 110, 0.75);

#if WINDOWS
	[System.Runtime.InteropServices.DllImport("winmm.dll", EntryPoint = "PlaySoundA", SetLastError = true)]
	private static extern bool PlaySound(byte[]? pszSound, IntPtr hmod, uint fdwSound);

	private const uint SND_ASYNC = 0x0001;
	private const uint SND_MEMORY = 0x0004;
	private const uint SND_NODEFAULT = 0x0002;

	private static void PlayWindows(byte[] buffer)
	{
		try
		{
			if (!PlaySound(buffer, IntPtr.Zero, SND_ASYNC | SND_MEMORY | SND_NODEFAULT))
			{
				var stream = new System.IO.MemoryStream(buffer);
				using var player = new System.Media.SoundPlayer(stream);
				player.Play();
			}
		}
		catch
		{
			try
			{
				System.Media.SystemSounds.Asterisk.Play();
			}
			catch
			{
			}
		}
	}
#endif

	public static ISoundService? Current { get; private set; }

	public SoundService()
	{
		Current = this;
	}

	public static void Hover() => Current?.PlayHover();
	public static void Click() => Current?.PlayClick();
	public static void Select() => Current?.PlaySelect();
	public static void Success() => Current?.PlaySuccess();
	public static void Error() => Current?.PlayError();
	public static void LevelUp() => Current?.PlayLevelUp();
	public static void PageTurn() => Current?.PlayPageTurn();

	public void PlayHover() => PlayBuffer(HoverBuffer);

	public void PlayClick()
	{
		PlayBuffer(ClickBuffer);
		TryHapticFeedback(HapticFeedbackType.Click);
	}

	public void PlaySelect() => PlayBuffer(SelectBuffer);
	public void PlaySuccess() => PlayBuffer(SuccessBuffer);
	public void PlayError() => PlayBuffer(ErrorBuffer);
	public void PlayLevelUp() => PlayBuffer(LevelUpBuffer);
	public void PlayPageTurn() => PlayBuffer(PageTurnBuffer);

	private static void PlayBuffer(byte[] buffer)
	{
#if WINDOWS
		PlayWindows(buffer);
#elif ANDROID
		PlayAndroid(buffer);
#endif
	}

	private static void TryHapticFeedback(HapticFeedbackType type)
	{
		try
		{
			HapticFeedback.Default.Perform(type);
		}
		catch
		{
		}
	}

	private static byte[] GenerateSoftTone(double startFreq, double endFreq, int durationMs, double volume, double overtone)
	{
		const int sampleRate = 44100;
		var sampleCount = sampleRate * durationMs / 1000;
		var dataSize = sampleCount * sizeof(short);
		var buffer = new byte[44 + dataSize];
		WriteWavHeader(buffer, dataSize, sampleRate);

		var attackSamples = Math.Min(sampleCount / 4, sampleRate * 7 / 1000);
		var phase = 0.0;
		for (var i = 0; i < sampleCount; i++)
		{
			var progress = (double)i / sampleCount;
			var freq = startFreq + ((endFreq - startFreq) * progress);
			phase += 2.0 * Math.PI * freq / sampleRate;

			var attack = i < attackSamples ? Math.Sin(Math.PI * 0.5 * i / attackSamples) : 1.0;
			var decay = Math.Exp(-progress * 6.5);
			var wave = (Math.Sin(phase) * (1.0 - overtone)) + (Math.Sin(phase * 2.0) * overtone);
			var sample = (short)(wave * attack * decay * volume * short.MaxValue);

			var offset = 44 + (i * 2);
			buffer[offset] = (byte)(sample & 0xFF);
			buffer[offset + 1] = (byte)((sample >> 8) & 0xFF);
		}

		return buffer;
	}

	private static byte[] GenerateChord(double[] notes, int noteDurationMs, double volume)
	{
		const int sampleRate = 44100;
		var samplesPerNote = sampleRate * noteDurationMs / 1000;
		var totalSamples = samplesPerNote * notes.Length;
		var dataSize = totalSamples * sizeof(short);
		var buffer = new byte[44 + dataSize];
		WriteWavHeader(buffer, dataSize, sampleRate);

		var attackSamples = samplesPerNote / 5;
		for (var n = 0; n < notes.Length; n++)
		{
			var freq = notes[n];
			var phase = 0.0;
			for (var i = 0; i < samplesPerNote; i++)
			{
				var progress = (double)i / samplesPerNote;
				phase += 2.0 * Math.PI * freq / sampleRate;

				var attack = i < attackSamples ? Math.Sin(Math.PI * 0.5 * i / attackSamples) : 1.0;
				var decay = Math.Exp(-progress * 4.5);
				var wave = (Math.Sin(phase) * 0.82) + (Math.Sin(phase * 2.0) * 0.18);
				var sample = (short)(wave * attack * decay * volume * short.MaxValue);

				var offset = 44 + ((n * samplesPerNote + i) * 2);
				buffer[offset] = (byte)(sample & 0xFF);
				buffer[offset + 1] = (byte)((sample >> 8) & 0xFF);
			}
		}

		return buffer;
	}

	private static void WriteWavHeader(byte[] buffer, int dataSize, int sampleRate)
	{
		Encoding.ASCII.GetBytes("RIFF").CopyTo(buffer, 0);
		BitConverter.GetBytes(36 + dataSize).CopyTo(buffer, 4);
		Encoding.ASCII.GetBytes("WAVEfmt ").CopyTo(buffer, 8);
		BitConverter.GetBytes(16).CopyTo(buffer, 16);
		BitConverter.GetBytes((short)1).CopyTo(buffer, 20);
		BitConverter.GetBytes((short)1).CopyTo(buffer, 22);
		BitConverter.GetBytes(sampleRate).CopyTo(buffer, 24);
		BitConverter.GetBytes(sampleRate * 2).CopyTo(buffer, 28);
		BitConverter.GetBytes((short)2).CopyTo(buffer, 32);
		BitConverter.GetBytes((short)16).CopyTo(buffer, 34);
		Encoding.ASCII.GetBytes("data").CopyTo(buffer, 36);
		BitConverter.GetBytes(dataSize).CopyTo(buffer, 40);
	}


#if ANDROID
	private static void PlayAndroid(byte[] wavBytes)
	{
		Task.Run(() =>
		{
			try
			{
				const int headerOffset = 44;
				var pcmSize = wavBytes.Length - headerOffset;
				if (pcmSize <= 0) return;

				var attributes = new Android.Media.AudioAttributes.Builder()!
					.SetUsage(Android.Media.AudioUsageKind.AssistanceSonification)!
					.SetContentType(Android.Media.AudioContentType.Sonification)!
					.Build()!;

				var format = new Android.Media.AudioFormat.Builder()!
					.SetChannelMask(Android.Media.ChannelOut.Mono)!
					.SetEncoding(Android.Media.Encoding.Pcm16bit)!
					.SetSampleRate(44100)!
					.Build()!;

				var track = new Android.Media.AudioTrack.Builder()!
					.SetAudioAttributes(attributes)!
					.SetAudioFormat(format)!
					.SetBufferSizeInBytes(pcmSize)!
					.SetTransferMode(Android.Media.AudioTrackMode.Static)!
					.Build()!;

				if (track == null) return;
				track.Write(wavBytes, headerOffset, pcmSize);
				track.Play();
				ReleaseTrackDelayed(track);
			}
			catch
			{
			}
		});
	}

	private static void ReleaseTrackDelayed(Android.Media.AudioTrack track)
	{
		Task.Delay(350).ContinueWith(_ =>
		{
			try
			{
				track.Stop();
				track.Release();
			}
			catch
			{
			}
		});
	}
#endif
}
