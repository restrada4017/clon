-- preparacion para ejecutar comandos
1. ejecutar : dotnet tool install --global dotnet-ef
https://docs.microsoft.com/en-us/ef/core/cli/dotnet

dotnet ef --project "D:\Universidad\ProyectoGrado\CodigoV2\WebApi.Adn\ADN.Data\ADN.Data.csproj" dbcontext scaffold "Server=TORREJANUS;Database=AdnDB;User Id=sa;Password=Colombia9.;" Microsoft.EntityFrameworkCore.SqlServer -o ToMove -n "ADN.Domain.Entities" --context-dir Data -c "DbADNContext" -f --no-onconfiguring


