addMigration:
	dotnet ef migrations add $(name) -s ./TFE.Presentation.WebApi -p ./TFE.Persistence/ 

remove:
	dotnet ef migrations remove -s ./TFE.Presentation.WebApi -p ./TFE.Persistence/ 

update:
	dotnet ef database update -s ./TFE.Presentation.WebApi -p ./TFE.Persistence/
