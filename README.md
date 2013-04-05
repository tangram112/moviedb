moviedb - projekt zaliczeniowy indywidualny
=======

####Jak wdrożyć projekt na [AppHarbor] ( https://appharbor.com/ )

1. Założyć konto na [AppHarbor]( https://appharbor.com/ ) <br />
2. Po zalogowaniu utworzyć nową aplikację <br />
3. Zakładam że nowa aplikacja jest już pod kontrolą [GITa] ( https://github.com/ ) więc
wystarczy przesłać ją do repozytorium na [AppHarbor]( https://appharbor.com/ ). <br />
<b>informujemy GITa o nowym repozytorium na AppHarbor:</b> <br />
git remote add appharbor https://user@appharbor.com/aplikacja.git <br />
<b>wysyłamy projekt do wdrożenia</b> <br />
git push appharbor master<br />
4. Dodać do projektu bazę danych SQL-serwer oraz ustwić jej alias connection string

Po chwili, jeśli nasz projekt kompiluje się bezbłędnie, możemy już korzystać z aplikacji uruchamianej wprost 
z serwera AppHarbor.

####Uruchamianie na ulubionym systemie Linux

Część dotycząca przenoszenia na AppHarbor i deployowania będzie taka sama jak w poprzednim punkcie. <br />
Co zaś dotyczy lokalnego kompilowania ( a trzeba pamiętać że aplikacja jest napisana w języku C# ) nie
mam informacji jak to zrobić w MONO i czy jest to możliwe.

