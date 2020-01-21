# stooqDownloader
Uruchamia ściąganie danych ze stooq.pl

# I. Co znajduje się w tym repozytorium
1. Katalog StooqDownloader -Kod w C# dla projektu StooqDownloader - główny plik solucji to StooqDownloader.sln
2. Katalog app - **Aplikacja StooqDownloader (64 bitowa) opublikowana w folderze app**
3. Plik tickers.csv - przykładowy plik tickerów.

# II. Aby ściągnąć dane przy pomocy aplikacji StooqDownloader należy:
1. Ściągnąć
1. Zainstalować ASP.NET Core Runtime 2.2.8 (niestety w tej wersji to niezbędne) - ściągnąć instalator spod adresu https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-2.2.8-windows-hosting-bundle-installer
2. Wejść do folderu aplikacji i otworzyć plik appsettings.json
3. W pliku appssetings.json zmienić wartości parametrów:
    - destDir - ścieżka do folderu, do którego będą kopiowane pliki z danymi. W tej wersji aplikacji podajemy ścieżki z dwoma        backsleshami np. C:\\\\amibroker\\\\tickers\\\\
    - tickersFile - ścieżka do pliku, w którym znajdują się definicje tickerów. Definicje tickerów są w tym pliku oddzielone przecinkami. Przykładowa zawartość pliku: KGH,JSW (plik dla dwóch tickerów). W podstawowych testach wyszło mi że można ściągnąć dane dla 100 tickerów, przy większej ilości do pliku może zostać wpisane "Przekroczony dzienny limit wywolan".
    - startDt - data od której zaczną się dane
    - endDt - data końca danych, domyślnie wszystkie dane będą odczytywane do czasu bieżącego
3. Uruchomić aplikację StooqDownloader.exe. Jeżeli wszystko zostało poprawnie skonfigurowane, i dane są ściągane to w oknie aplikacji powinny się pojawiać nazwy tickerów i dane powinny się ściągać np. do folderu C:\\amibroker\\tickers\\.
Ściągają się dane w kolumnach:
Data,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen
