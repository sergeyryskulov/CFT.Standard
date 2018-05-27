@for /F "tokens=1 eol=" %%i in (test.txt) do (
C:/windows/explorer.exe %%i
ping -n 5 127.0.0.1 >nul
)