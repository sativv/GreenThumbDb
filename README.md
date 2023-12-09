## Sammanfattning & analys GreenGarden
(FilePath behöver möjligtvis ändras för KeyManager)

I detta projektet har jag skapat en applikation där användaren kan lägga till olika plantor tillsammans med kopplade skötselråd samt möjligheten att lägga till dessa i sin egna trädgårdslista.

När man skapar en ny användare så tar jag fram en lista av alla existerande användare och jämför vad användaren har skrivit in så att inte två konton kan ha samma användarnamn. Användarens lösenord krypteras i databasen och kräver en speciell nyckel för att kunna läsas, denna skapas i min KeyManager-klass. När man sedan skriver in sin information för att logga in så kollar jag samma lista igen för att se om kontot existerar och om lösenordet stämmer. Det slutade med att hela min validering för användare blev väldigt nestad och jag hade gjort det på ett annorlunda sätt om jag skulle göra om det. Exempelvis så skulle jag kunna skapa en metod i mitt userRepository som hämtar en lista av användare som tar emot ett användarnamn sedan validerar kontot och returnerar en bool. 

När man väl har loggat in i appen så skickas man vidare till ett fönster där din personliga trädgårdslista visas, denna kan fyllas genom att gå vidare till ett annat fönster (PlantWindow) som visar alla plantor som tidigare lagts till utav alla användare. Här kan man även använda sig utav en textbox som filtrerar listan av plantor beroende på vad man skriver in. Om man väljer att lägga till en planta till sin trädgård så skapas ett GardenPlant objekt som är mitt joint-table som består utav gradenid och plantid. Sedan visas detta i trädgården genom att ta fram alla gardenPlants som har samma gardenid som användarens id. 

Jag valde att använda mig utav unit of work som mitt repository patterns då det är det jag är mest bekväm med, men i efterhand hade jag kombinerat det med generic repository eftersom jag fick repetera väldigt många  CRUD-metoder som var i princip identiska i varje repository. 

Sättet jag skickar vidare min användare till alla fönster efter att man har loggat in kunde jag simplifierat genom att använda en usermanager som sätts till användaren som loggar in istället för att jag ska  behöva skicka vidare det till varje fönster. 

Återigen så måste jag bli bättre på att skapa min felhantering som try/catch block istället för massor av if checkar då det oftast kräver mindre kod och blir mindre nesting.