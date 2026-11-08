@echo off
chcp 65001 >nul
cd /d "e:\Documents perso\0000Site internet\DEV\AsPISApe"

echo ======================================================================
echo    AsPISApe — Synchronisation Git & Envoi vers GitHub (Branche main)
echo ======================================================================
echo.

git --version >nul 2>&1
if %errorlevel% neq 0 (
    echo [ERREUR] Git n'est pas installe ou n'est pas accessible dans le PATH.
    echo.
    pause
    exit /b 1
)

echo [1/5] Configuration de la branche et du remote origin...
git branch -M main
git remote remove origin 2>nul
git remote add origin https://github.com/friartscript/AsPISApe.git

echo.
echo [2/5] Verification des fichiers modifies...
git status --short

echo.
echo [3/5] Indexation des fichiers...
git add .

echo.
echo [4/5] Creation du commit...
git diff-index --quiet HEAD -- 2>nul
if %errorlevel% equ 0 (
    echo [INFO] Aucun changement detecte depuis le dernier commit.
) else (
    git commit -m "Feat(Banks): Ajout Lot A.11 (Sujets 47 a 55 Echelles, Vitesses, Fonctions affines et lineaires) en 2 fichiers modulaires < 130 lignes"
    if %errorlevel% equ 0 (
        echo [OK] Commit effectue avec succes !
    ) else (
        echo [ATTENTION] Erreur ou commit deja a jour.
    )
)

echo.
echo [5/5] Envoi vers GitHub (git push -u origin main)...
git push -u origin main

echo.
if %errorlevel% equ 0 (
    echo ======================================================================
    echo  [SUCCES] Le code et la documentation sont a jour sur GitHub !
    echo ======================================================================
) else (
    echo ======================================================================
    echo  [INFO] Envoi en attente ou invite d'authentification requise.
    echo  Si votre navigateur ou Windows Credential Manager s'ouvre,
    echo  veuillez autoriser l'acces a votre compte GitHub friartscript.
    echo ======================================================================
)

copy /y "%~f0" "C:\Users\kevin\Desktop\push_AsPISApe.bat" >nul 2>&1

echo.
pause
