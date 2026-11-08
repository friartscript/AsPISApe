@echo off
setlocal EnableDelayedExpansion
chcp 65001 >nul
cd /d "%~dp0"

echo ======================================================================
echo    AsPISApe - Synchronisation Git et Envoi vers GitHub
echo ======================================================================
echo.

where git >nul 2>&1
if !ERRORLEVEL! equ 0 goto GitFound

if exist "C:\Program Files\Git\cmd\git.exe" (
    set "PATH=C:\Program Files\Git\cmd;!PATH!"
    goto GitFound
)
if exist "C:\Program Files\Git\bin\git.exe" (
    set "PATH=C:\Program Files\Git\bin;!PATH!"
    goto GitFound
)
if exist "%LOCALAPPDATA%\Programs\Git\cmd\git.exe" (
    set "PATH=%LOCALAPPDATA%\Programs\Git\cmd;!PATH!"
    goto GitFound
)
if exist "C:\Program Files (x86)\Git\cmd\git.exe" (
    set "PATH=C:\Program Files (x86)\Git\cmd;!PATH!"
    goto GitFound
)

echo [ERREUR] Git n'a pas ete trouve sur votre machine ou dans le PATH.
echo Veuillez installer Git for Windows : https://git-scm.com/download/win
echo.
pause
exit /b 1

:GitFound
echo [1/4] Configuration de la branche principale et du remote origin...
git branch -M main
git remote remove origin 2>nul
git remote add origin https://github.com/friartscript/AsPISApe.git

echo.
echo [2/4] Indexation des fichiers...
git add .

echo.
echo [3/4] Creation du commit...
set "COMMIT_MSG=feat: Avancement AsPISApe - Banques d'exercices et modules"
git commit -m "%COMMIT_MSG%"

echo.
echo [4/4] Envoi vers GitHub (git push -u origin main)...
git push -u origin main

echo.
if !ERRORLEVEL! equ 0 (
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

echo.
pause
