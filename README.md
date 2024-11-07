# zaznamnik_porad
BCSH2 semestrální práce UPCE FEI 2024

**téma a)**
 Evidenční nástroj pro správu, průběh a ukládání programu porad se záznamem hlasování.

Jednoduchá aplikace, která umužní uživateli promítat na jakém bodu jednání je aktuálně porada. Jednotlivé body se dají v průběhu různě upravovat, a kromě názvu bodu mohou obsahovat i další text - zda li to daný bod vyžaduje. Administrátorské GUI není součástí "prezentovaného" okna, tzn. že člověk co zpravuje danou poradu může ovládat co je aktuálně promítáno, bez toho aby byl promítaný obsah jakkoliv omezen uživatelským GUI. Součástí aplikace je i uložení dané aplikace do databáze, kde se uloží:
 - kdo byl na poradě
 - jaké byli body programu
 - jestli pro daný bod programu bylo vytvořeno hlasování
 - a pokud proběhlo hlasovaní, tak kdo pro co hlasoval

## Podmínky: 
    práce je realizována s využitím jazyka C# a .NET
    práce nevyužívá externí knihovny (pokud nejsou předem schváleny vyučujícím na základě domluvy)
    aplikace je napsána v souladu s „coding guidelines“ a „naming conventions“ podle jazyka C#
    práce je vypracována samostatně studentem (resp. studenty – výjimky dle specifikace níže) a není založena na cizím kódu
    
    práce je postavena na jedné z následujících platforem:
    a) WPF + MVVM architektura (akceptována je i varianta s Avalonia UI + MVVM)
    b) ASP.NET + MVC architektura
    c) Android/iOS aplikace s využitím .NET MAUI

    GUI aplikace s možností zadávat, prohlížet, editovat údaje
    minimálně 3 typy entit (relací) propojené vhodnými relacemi
    data ukládána pomocí embedded databáze
Pro databázi byla zvolena knihovna ![SQLite](https://learn.microsoft.com/cs-cz/dotnet/standard/data/sqlite/?tabs=netcore-cli)

#### Minimální funkcionality zadané při zadávání:
- Osoby mohou hlasovat pro dane body programu v celkovém programu schuze.
- Aplikace ukládá, kolik lidí hlasuje pro daný bod programu s časovým razítkem.

## Databáze:

Databáze má v základu 4 tabulky `Osoby`, `Bod_programu`, `program` a `hlasování`.








