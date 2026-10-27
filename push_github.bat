@echo off
chcp 65001 > nul
title Envoi AsPISApe vers GitHub

echo ===================================================
echo       ENVOI DU PROJET AsPISApe VERS GITHUB
echo ===================================================
echo.

cd /d "%~dp0"

echo Verification de l'etat des fichiers...
git status -s
echo.

set /p MSG="Message du commit (Appuyez sur Entree pour message auto) : "
if "%MSG%"=="" set MSG=Mise a jour projet AsPISApe (%date% %time%)

echo.
echo [1/3] Ajout des modifications...
git add .

echo [2/3] Validation locale (commit)...
git commit -m "%MSG%"

echo [3/3] Envoi vers GitHub (origin main)...
git push origin main

echo.
echo ===================================================
if %ERRORLEVEL% equ 0 (
    echo [SUCCES] Projet synchronise sur GitHub avec succes !
) else (
    echo [INFO/ATTENTION] Termine (verifiez les messages ci-dessus).
)
echo ===================================================
echo.
pause
