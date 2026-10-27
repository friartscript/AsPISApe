# 🎓 AsPISApe — L'app qui te fait devenir un as du PISA

> *« L'app qui te fait devenir un as du PISA »*

**AsPISApe** est une application ludo-éducative multiplateforme d'apprentissage, d'entraînement et d'évaluation continue en **Mathématiques** et en **Français** (compréhension de l'écrit), conçue pour faire progresser les apprenants vers les standards d'excellence des épreuves **PISA**.

Son logo officiel et sa mascotte arborent l'**As de pique (`♠`)**, symbole d'excellence et carte maîtresse de l'apprenant.

Développée en **C# avec .NET MAUI**, l'application cible en priorité les supports mobiles (**Android APK**) et ordinateurs (**Windows .exe**).

---

## 🚀 Caractéristiques Clés

- **Progression par Paliers Adaptatifs** : Positionnement précis du niveau réel de l'apprenant à travers des étapes successives vers la maîtrise PISA.
- **Format 9:16 Portrait Forcé** : L'affichage est strictement verrouillé au ratio vertical 9:16 sur toutes les plateformes (mode portrait exclusif sur mobile Android, dimensions fenêtrées verrouillées à 450×800 sur PC Windows). L'application ne bascule jamais en 16:9 paysage.
- **Gestionnaire de Transitions Fluides (FadeIn / FadeOut)** : Toutes les navigations entre écrans sont orchestrées par un service dédié avec fondu enchaîné doux et dynamique.
- **100% Autonome (Zéro Backend)** : Fonctionne intégralement hors-ligne, aucune connexion Internet ni serveur distant n'est requis.
- **Mémoire Interne Locale** : Sauvegarde embarquée du palier atteint, des notions maîtrisées, des scores et de l'historique complet des réponses.
- **Univers Tactile & Pastel** : Interface cartoon 3D inspirée de l'énergie des jeux mobiles modernes (style Supercell) avec une palette pastel douce, contrastée et reposante.

---

## 🏗️ Architecture du Projet

Le projet respecte les principes de **Clean Architecture** et de **Responsabilité Unique (SRP)** avec séparation stricte des logiques :

```text
AsPISApe/
├── Models/                         # Structures de données pures
│   └── UserProfile.cs              # Modèle de profil apprenant (pseudo, chemin photo, score)
├── Services/                       # Moteurs logiques et services transverses
│   ├── INavigationService.cs       # Contrat d'orchestration de la navigation
│   ├── NavigationService.cs        # Gestionnaire de transitions animées FadeIn / FadeOut
│   ├── ISoundService.cs            # Contrat global de synthèse et gestion des effets sonores
│   ├── SoundService.cs             # Moteur audio procédural C# 100% natif (zéro fichier externe)
│   ├── IProfileService.cs          # Contrat de persistance locale du profil utilisateur
│   └── ProfileService.cs           # Gestionnaire de stockage local (JSON, photo, score avec espaces)
├── Views/                          # Écrans et interfaces XAML
│   ├── WelcomePage.xaml (.cs)      # Page d'accueil : pluie de particules, mascotte carte As de pique, bouton Commencer
│   └── HomePage.xaml (.cs)         # Écran Home : en-tête profil persistant, bouton central rond As de pique pulsant, modale profil
├── Platforms/                      # Adaptations natives
│   ├── Android/                    # MainActivity verrouillée en ScreenOrientation.Portrait
│   └── Windows/                    # Configuration native Windows App SDK / WinUI 3 (fenêtre verrouillée 450x800)
├── Resources/                      # Ressources graphiques partagées
│   ├── Fonts/                      # Polices vectorielles (OpenSans)
│   ├── Styles/                     # Dictionnaires de ressources épurés (Colors.xaml, Styles.xaml)
│   ├── AppIcon/ & Splash/          # Icônes et écrans de lancement pastel
│   └── Images/ & Raw/              # Médias et fichiers embarqués
├── App.xaml (.cs)                  # Point de contrôle du ratio 9:16 (fenêtre 450x800) et pile de navigation
├── MauiProgram.cs                  # Enregistrement des services (IoC / DI) et configuration de l'application
└── AsPISApe.csproj                 # Déclaration multi-cibles .NET 10 sans dépendances inutiles
```

### Détail des Modules

1. **`Services/ProfileService`** :
   - Persistance 100% autonome et hors-ligne du profil apprenant dans le stockage interne de l'appareil (`profile.json` et photo copiée localement sous `avatar_user.png`).
   - Sauvegarde sécurisée sans verrouillage de fichier (évite toute violation de partage lors de la mise à jour du profil avec la même image).
   - Gestion des coordonnées de recadrage d'avatar : niveau de zoom (`AvatarScale`) et décalages panoramiques (`AvatarPanX`, `AvatarPanY`).
   - Validation stricte et sécurisée du pseudonyme : non vide, 3 à 24 caractères, caractères autorisés (alphanumérique, tirets, underscores), exclusion ferme des balises ou chevrons d'injection (`<` et `>`).
   - Formatage conforme des points avec séparateurs d'espaces : `"0"`, `"1 000"`, `"10 000"`, `"1 000 000"`.
   - Initialisation du score à 0 point pour tout nouvel utilisateur.

2. **`Services/SoundService`** :
   - Moteur audio procédural C# 100% natif, autonome et sans aucun fichier audio externe (.wav/.mp3).
   - Synthèse acoustique douce avec rampe d'attaque progressive en cosinus (zéro craquement), harmoniques chaudes (timbre marimba/goutte d'eau) et atténuation exponentielle feutrée.
   - Catalogue de sons doux disponibles :
     - `PlayHover()` : *Goutte d'eau feutrée* (920➔800 Hz, 38 ms, 22% vol) — survol délicat de souris.
     - `PlayClick()` : *Pop boisé marimba* (540➔420 Hz, 65 ms, 38% vol) — validation tactile douce et immédiate.
     - `PlaySelect()` : *Tintement pastel* (660➔780 Hz, 50 ms, 30% vol) — sélection de case/option.
     - `PlaySuccess()` : *Carillon céleste* (arpège majeur 3 notes Do-Mi-Sol : 523, 659, 784 Hz, 240 ms) — bonne réponse.
     - `PlayError()` : *Note feutrée* (290➔220 Hz, 130 ms, 32% vol) — erreur non-punitive et rassurante.
     - `PlayLevelUp()` : *Fanfare pastel* (arpège 4 notes Do-Mi-Sol-Do : 523, 659, 784, 1046 Hz, 320 ms) — palier franchi.
     - `PlayPageTurn()` : *Glissando feutré* (360➔240 Hz, 80 ms, 20% vol) — changement d'écran soyeux.
   - Lecture asynchrone ultra-fluide via `System.Media.SoundPlayer` pré-chargé en mémoire vive sur Windows et `Android.Media.AudioTrack` PCM 16-bit + retour haptique sur Android.
   - Accessible partout via `ISoundService` ou l'API statique globale (`SoundService.Click()`, `SoundService.Hover()`, etc.).

3. **`Services/NavigationService`** :
   - Reçoit la référence de la pile de navigation de l'application (`INavigation`).
   - `NavigateToAsync(Page target)` : Déclenche l'estompage progressif de la page active (`FadeToAsync(0, 160)`), insère la nouvelle page à opacité nulle, puis applique le fondu d'apparition (`FadeToAsync(1, 220)`).
   - `NavigateBackAsync()` : Effectue le retour en arrière avec le même fondu enchaîné propre.
   - Protégé contre les doubles-clics concurrents via un verrou d'état `_isNavigating`.

4. **`Views/WelcomePage`** :
   - **Pluie animée dynamique en arrière-plan** : Moteur de particules organiques et fluides (60 fps) où chaque élément possède sa propre vitesse, sa phase de départ et son amplitude de dérive sinusoïdale (trajectoires courbes non-rectilignes). Les éléments ne tombent jamais en bloc. Dès qu'un symbole franchit le bas de l'écran, il est immédiatement supprimé de la mémoire/canvas et un nouvel élément est généré au sommet avec une syllabe française ou une formule mathématique aléatoire, une couleur pastel dédiée et une taille propre.
   - **Logo & Titre** : Animation élastique à l'ouverture (*spring scale & bounce*), mascotte sous forme de carte à jouer **As de pique** (`A♠`), titre imposant "AsPISApe" et slogan officiel "L'app qui te fait devenir un as du PISA".
   - **Bouton d'action unifié** : Composant unique galbé (`RoundRectangle 24`) avec dégradé pastel vertical (`#7BC6F7` vers `#4A9FE2`), liseré de brillance supérieure, ombre colorée diffuse (`#4A9FE2`) et retour tactile immédiat (`ScaleToAsync(0.96)`).

5. **`Views/HomePage`** :
   - **En-tête de profil universel** : Avatar circulaire avec la photo de l'apprenant (recadrée, centrée et zoomée), pseudonyme en typographie cartoon sombre, badge de palier ("PALIER 1") et capsule de points avec étoile dorée (affichant `"0 pts"` au départ puis `"1 000"`, `"10 000"`, `"1 000 000"`).
   - **Bouton central As de pique (`♠`)** :
     - Bouton rond tactile 3D sans aucun texte, centré parfaitement en largeur et en hauteur.
     - Animation de pulsation lente et continue (*breathing pulse* à 60 fps) accompagnée d'un halo lumineux respirant (`AceButtonHalo`).
     - Cercle vectoriel parfait à 360° avec liseré contrasté `#2C3445`, dégradé pastel doux et As de pique en relief (`#2C3445` avec ombre pastel `#6CB4EE`).
     - Déclenchement d'un son procédural net et franc au clic (`SoundService.PlayClick()`) et effet d'enfoncement élastique tactile (`ScaleTo(0.92)`).
     - Aucun bouton direct Maths ou Français ni bouton de retour, centrage total de l'attention sur la carte maîtresse.
   - **Modale de profil bi-mode (Création & Édition)** :
     - *Première visite* : S'affiche automatiquement à la première ouverture ("Bienvenue !"), création obligatoire avec pseudonyme et photo, bouton de fermeture masqué.
     - *Édition / Clic sur l'avatar du header* : Ouvre l'éditeur de profil ("Modifier mon profil") avec bouton de fermeture "✕", pré-remplissage du pseudonyme et de la photo actuelle, et possibilité de modifier le pseudo sans erreur.
     - *Éditeur d'avatar interactif (Zoom & Pan)* : Permet de déplacer l'image par glisser-déposer (pan avec la souris ou au doigt), de zoomer avec les gestes tactiles (pinch) ou les boutons dédiés (`–` et `+`), de réinitialiser le cadrage (`⟲`) et de changer de cliché (`Changer`).

---

## 🎯 Cibles de Déploiement

- **Android (APK)** : Format portrait mobile 9:16 natif.
- **Windows (.exe)** : Application de bureau WinUI 3 calibrée et verrouillée en ratio 9:16 (450×800).

