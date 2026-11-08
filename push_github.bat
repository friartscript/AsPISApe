@echo off
chcp 65001 >nul
cd /d "e:\Documents perso\0000Site internet\DEV\AsPISApe"

echo ==========================================
echo    AsPISApe - Commit ^& Push vers GitHub
echo ==========================================
echo.

git branch -M main
git remote remove origin 2>nul
git remote add origin https://github.com/friartscript/AsPISApe.git

echo 1. Verification des fichiers...
git status --short

echo.
echo 2. Ajout des fichiers modifies...
git add .

echo.
echo 3. Creation du commit...
git commit -m "Feat: Header enrichi, moteur de jeu 5 questions crescendo et anti-seche"

echo.
echo 4. Envoi vers GitHub (branche main)...
git push -u origin main

echo.
if %errorlevel% equ 0 (
    echo [SUCCES] Projet envoye sur GitHub avec succes !
) else (
    echo [INFO] Si une invite d'authentification GitHub s'ouvre, validez-la.
)

echo.
pause
