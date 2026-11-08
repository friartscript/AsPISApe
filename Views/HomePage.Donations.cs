namespace AsPISApe.Views;

public partial class HomePage
{
	private const string KofiUrl = "https://ko-fi.com/friartscript";
	private const string BuyMeACoffeeUrl = "https://buymeacoffee.com/friartscript";
	private const string TipeeeUrl = "https://fr.tipeee.com/friartscript";
	private const string PatreonUrl = "https://www.patreon.com/cw/friartscript";

	private async void OnDonationButtonTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		DonationModalOverlay.Opacity = 0;
		DonationModalOverlay.IsVisible = true;
		await DonationModalOverlay.FadeToAsync(1, 160);
	}

	private async void OnCloseDonationModalClicked(object? sender, EventArgs e)
	{
		_soundService.PlayClick();
		await DonationModalOverlay.FadeToAsync(0, 120);
		DonationModalOverlay.IsVisible = false;
	}

	private void OnCloseDonationModalTapped(object? sender, TappedEventArgs? e)
	{
		OnCloseDonationModalClicked(sender, EventArgs.Empty);
	}

	private async void OnOpenKofiTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await OpenExternalLinkAsync(KofiUrl);
	}

	private async void OnOpenBuyMeACoffeeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await OpenExternalLinkAsync(BuyMeACoffeeUrl);
	}

	private async void OnOpenTipeeeTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await OpenExternalLinkAsync(TipeeeUrl);
	}

	private async void OnOpenPatreonTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		await OpenExternalLinkAsync(PatreonUrl);
	}

	private static async Task OpenExternalLinkAsync(string url)
	{
		try
		{
			await Launcher.Default.OpenAsync(new Uri(url));
		}
		catch
		{
		}
	}
}
