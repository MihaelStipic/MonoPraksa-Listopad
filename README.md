# MonoPraksa

Web API za nogometaše i klubove (ASP.NET Core, EF Core, PostgreSQL).

## Pokretanje

1. Kreiraj bazu `PraksaDB` u PostgreSQL-u.
2. U DBeaveru se spoji na tu bazu, otvori SQL editor, učitaj skriptu `PraksaDB/PraksaDB.sql` iz ovog repoa i pokreni je cijelu. Skripta kreira tablice `clubs` i `footballers`. Dijagram baze je u `PraksaDB/PraksaDB.drawio.png`.
3. Postavi connection string u user secrets (ključ je `ConnectionStrings:DefaultConnectionString`):

```
   dotnet user-secrets init --project WebAPI/MonoPraksa/MonoPraksa
   dotnet user-secrets set "ConnectionStrings:DefaultConnectionString" "Host=localhost;Port=5432;Database=PraksaDB;Username=postgres;Password=TVOJA_LOZINKA" --project WebAPI/MonoPraksa/MonoPraksa
```

4. Pokreni aplikaciju:

```
   dotnet run --project WebAPI/MonoPraksa/MonoPraksa
```

## Endpointi

- `GET /Footballers` (opcionalno `?minRating=&name=&playerAge=`), vraća igrače s imenom kluba
- `GET /Footballers/{id}`
- `POST /Footballers`
- `PUT /Footballers/{id}`
- `DELETE /Footballers/{id}`
