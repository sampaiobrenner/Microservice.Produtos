@echo off

ECHO ----------------------------------------------------
ECHO Exclusao de pastas bin e obj dos projetos C#!
ECHO (ignorando pastas node_modules)
ECHO ----------------------------------------------------

ECHO.

for /d /r . %%d in (bin obj) do @if exist "%%d" CALL :removerPasta %%d
goto end

:removerPasta
SET Caminho=%1
IF "%Caminho%"=="%Caminho:node_modules=%" (
    RD /s/q "%Caminho%"
    ECHO Excluido "%Caminho%"
)
goto :eof

:end

ECHO.
ECHO ----------------------------------------------------
ECHO Concluido!
ECHO ----------------------------------------------------

PAUSE