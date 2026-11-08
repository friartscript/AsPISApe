namespace AsPISApe.Views;

public partial class HomePage
{
	private void ConfigureModalForCreation()
	{
		ModalCloseButton.IsVisible = false;
		ModalBadgeIcon.Text = "★";
		ModalTitleLabel.Text = "Bienvenue !";
		ModalSubtitleLabel.Text = "Créez votre profil pour enregistrer vos points et badges.";
		ModalSubmitButtonLabel.Text = "VALIDER MON PROFIL ➔";
		ModalAvatarHintLabel.Text = "* Photo obligatoire (cliquez pour choisir)";
		ModalAvatarPreview.IsVisible = false;
		ModalAvatarPlaceholder.IsVisible = true;
		AvatarToolsLayout.IsVisible = false;
		ModalErrorLabel.IsVisible = false;
		_selectedTempPhotoPath = null;
		_currentScale = 1.0;
		_currentPanX = 0;
		_currentPanY = 0;
		ApplyAvatarTransform();
	}

	private void ConfigureModalForEdition(Models.UserProfile profile)
	{
		ModalCloseButton.IsVisible = true;
		ModalBadgeIcon.Text = "✎";
		ModalTitleLabel.Text = "Modifier mon profil";
		ModalSubtitleLabel.Text = "Ajustez votre pseudonyme ou votre photo.";
		ModalSubmitButtonLabel.Text = "ENREGISTRER ➔";
		ModalUsernameEntry.Text = profile.Name;
		ModalErrorLabel.IsVisible = false;

		if (!string.IsNullOrEmpty(profile.AvatarPath) && File.Exists(profile.AvatarPath))
		{
			_selectedTempPhotoPath = profile.AvatarPath;
			ModalAvatarPreview.Source = LoadImageNoLock(profile.AvatarPath);
			_currentScale = Math.Max(1.0, profile.AvatarScale);
			_currentPanX = profile.AvatarPanX;
			_currentPanY = profile.AvatarPanY;
			ApplyAvatarTransform();
			ModalAvatarPreview.IsVisible = true;
			ModalAvatarPlaceholder.IsVisible = false;
			AvatarToolsLayout.IsVisible = true;
			ModalAvatarHintLabel.Text = "Glissez l'image pour la centrer • Zoom +/-";
		}
		else
		{
			ConfigureModalForCreation();
			ModalCloseButton.IsVisible = true;
			ModalTitleLabel.Text = "Modifier mon profil";
			ModalSubmitButtonLabel.Text = "ENREGISTRER ➔";
		}
	}

	private void OnHeaderAvatarTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		var profile = _profileService.GetProfile();
		if (profile == null) return;

		ConfigureModalForEdition(profile);
		ProfileModalOverlay.Opacity = 1;
		ProfileModalOverlay.IsVisible = true;
	}

	private async void OnModalCloseClicked(object? sender, EventArgs e)
	{
		_soundService.PlayClick();
		await ProfileModalOverlay.FadeToAsync(0, 160);
		ProfileModalOverlay.IsVisible = false;
	}

	private void OnModalCloseTapped(object? sender, TappedEventArgs? e)
	{
		OnModalCloseClicked(sender, EventArgs.Empty);
	}

	private async void OnOverlayBackgroundTapped(object? sender, TappedEventArgs? e)
	{
		if (!_profileService.HasProfile()) return;
		_soundService.PlayClick();
		await ProfileModalOverlay.FadeToAsync(0, 160);
		ProfileModalOverlay.IsVisible = false;
	}

	private void OnAvatarContainerTapped(object? sender, TappedEventArgs e)
	{
		if (!ModalAvatarPreview.IsVisible)
		{
			OnPickPhotoTapped(sender, e);
		}
	}

	private async void OnPickPhotoTapped(object? sender, TappedEventArgs e)
	{
		_soundService.PlayClick();
		try
		{
			var file = await FilePicker.Default.PickAsync(new PickOptions
			{
				PickerTitle = "Choisir une photo de profil",
				FileTypes = FilePickerFileType.Images
			});

			if (file == null) return;

			var tempPath = Path.Combine(FileSystem.CacheDirectory, $"picked_{Guid.NewGuid():N}.png");
			using (var src = await file.OpenReadAsync())
			using (var dst = File.Create(tempPath))
			{
				await src.CopyToAsync(dst);
			}

			_selectedTempPhotoPath = tempPath;
			ModalAvatarPreview.Source = LoadImageNoLock(tempPath);
			_currentScale = 1.0;
			_currentPanX = 0;
			_currentPanY = 0;
			ApplyAvatarTransform();
			ModalAvatarPreview.IsVisible = true;
			ModalAvatarPlaceholder.IsVisible = false;
			AvatarToolsLayout.IsVisible = true;
			ModalAvatarHintLabel.Text = "Glissez l'image pour la centrer • Zoom +/-";
			ModalErrorLabel.IsVisible = false;
			_soundService.PlaySelect();
		}
		catch
		{
			ModalErrorLabel.Text = "Impossible de charger cette image.";
			ModalErrorLabel.IsVisible = true;
		}
	}

	private void OnAvatarPanUpdated(object? sender, PanUpdatedEventArgs e)
	{
		if (string.IsNullOrEmpty(_selectedTempPhotoPath)) return;

		switch (e.StatusType)
		{
			case GestureStatus.Started:
				_panStartX = _currentPanX;
				_panStartY = _currentPanY;
				break;

			case GestureStatus.Running:
				var maxPan = Math.Max(20.0, 48.0 * (_currentScale - 0.7));
				_currentPanX = Math.Clamp(_panStartX + e.TotalX, -maxPan, maxPan);
				_currentPanY = Math.Clamp(_panStartY + e.TotalY, -maxPan, maxPan);
				ApplyAvatarTransform();
				break;
		}
	}

	private void OnAvatarPinchUpdated(object? sender, PinchGestureUpdatedEventArgs e)
	{
		if (string.IsNullOrEmpty(_selectedTempPhotoPath)) return;

		if (e.Status == GestureStatus.Running)
		{
			_currentScale = Math.Clamp(_currentScale * e.Scale, 1.0, 3.5);
			ApplyAvatarTransform();
		}
	}

	private void OnZoomInTapped(object? sender, TappedEventArgs e)
	{
		if (string.IsNullOrEmpty(_selectedTempPhotoPath)) return;
		_soundService.PlayClick();
		_currentScale = Math.Clamp(_currentScale + 0.25, 1.0, 3.5);
		ApplyAvatarTransform();
	}

	private void OnZoomOutTapped(object? sender, TappedEventArgs e)
	{
		if (string.IsNullOrEmpty(_selectedTempPhotoPath)) return;
		_soundService.PlayClick();
		_currentScale = Math.Clamp(_currentScale - 0.25, 1.0, 3.5);
		ApplyAvatarTransform();
	}

	private void OnResetCropTapped(object? sender, TappedEventArgs e)
	{
		if (string.IsNullOrEmpty(_selectedTempPhotoPath)) return;
		_soundService.PlayClick();
		_currentScale = 1.0;
		_currentPanX = 0;
		_currentPanY = 0;
		ApplyAvatarTransform();
	}

	private void ApplyAvatarTransform()
	{
		var maxPan = Math.Max(20.0, 48.0 * (_currentScale - 0.7));
		_currentPanX = Math.Clamp(_currentPanX, -maxPan, maxPan);
		_currentPanY = Math.Clamp(_currentPanY, -maxPan, maxPan);
		ModalAvatarPreview.Scale = _currentScale;
		ModalAvatarPreview.TranslationX = _currentPanX;
		ModalAvatarPreview.TranslationY = _currentPanY;
	}

	private static ImageSource? LoadImageNoLock(string path)
	{
		try
		{
			if (!File.Exists(path)) return null;
			var bytes = File.ReadAllBytes(path);
			return ImageSource.FromStream(() => new MemoryStream(bytes));
		}
		catch
		{
			return null;
		}
	}

	private async void OnSubmitProfileTapped(object? sender, TappedEventArgs e)
	{
		var name = ModalUsernameEntry.Text?.Trim();
		if (!_profileService.IsValidUsername(name))
		{
			_soundService.PlayError();
			ModalErrorLabel.Text = "Nom invalide : 3 à 24 caractères, pas de < ou >.";
			ModalErrorLabel.IsVisible = true;
			return;
		}

		if (string.IsNullOrEmpty(_selectedTempPhotoPath) || !File.Exists(_selectedTempPhotoPath))
		{
			_soundService.PlayError();
			ModalErrorLabel.Text = "Photo obligatoire : cliquez sur le cercle pour choisir.";
			ModalErrorLabel.IsVisible = true;
			return;
		}

		var success = await _profileService.SaveProfileAsync(name!, _selectedTempPhotoPath, _currentScale, _currentPanX, _currentPanY);
		if (!success)
		{
			_soundService.PlayError();
			ModalErrorLabel.Text = "Erreur lors de l'enregistrement du profil.";
			ModalErrorLabel.IsVisible = true;
			return;
		}

		_soundService.PlaySuccess();
		UpdateHeaderWithProfile();
		await ProfileModalOverlay.FadeToAsync(0, 160);
		ProfileModalOverlay.IsVisible = false;
	}
}
