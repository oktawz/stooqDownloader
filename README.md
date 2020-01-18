# stooqDownloader
Uruchamia ściąganie danych ze stooq.pl

# I. Co znajduje się w tym repozytorium
1. Kod w C# dla projektu StooqDownloader - główny plik solucji to StooqDownloader.sln
2. **Aplikacja StooqDownloader (64 bitowa) opublikowana w folderze app**

# II. Aby ściągnąć dane przy pomocy aplikacji StooqDownloader należy:
1. Wejść do folderu aplikacji i otworzyć plik appsettings.json
2. W pliku appssetings.json zmienić wartości parametrów:
    - destDir - ścieżka do folderu, do którego będą kopiowane pliki z danymi. W tej wersji aplikacji podajemy ścieżki z dwoma        backsleshami np. C:\\\\amibroker\\\\tickers\\\\
    - tickersFile - ścieżka do pliku, w którym znajdują się definicje tickerów. Definicje tickerów są w tym pliku oddzielone przecinkami. Przykładowa zawartość pliku: KGH,JSW (plik dla dwóch tickerów). W podstawowych testach wyszło mi że można ściągnąć dane dla 100 tickerów, przy większej ilości do pliku może zostać wpisane "Przekroczony dzienny limit wywolan".
    - startDt - data od której zaczną się dane
    - endDt - data końca danych, domyślnie wszystkie dane będą odczytywane do czasu bieżącego
3. Uruchomić aplikację StooqDownloader.exe. Jeżeli wszystko zostało poprawnie skonfigurowane, i dane są ściągane to w oknie aplikacji powinny się pojawiać nazwy tickerów i dane powinny się ściągać np. do folderu C:\\amibroker\\tickers\\.
Ściągają się dane w kolumnach:
Data,Otwarcie,Najwyzszy,Najnizszy,Zamkniecie,Wolumen
