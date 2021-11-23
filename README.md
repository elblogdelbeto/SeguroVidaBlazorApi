# SeguroVidaBlazorApi
Blazor web app con uso de API que registra empleados y sus beneficiarios de su seguro de vida en SQL server

el proyecto fue creado con Visual Studio 2022 utilizando .NET 6

pasos para correrlo local:

1 - ajustar la cadena de conexion a la de tu base de datos SQL server, en mi caso deje la que instala default Visual studio 2022
"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MaxiTransfers;Integrated Security=True"
el archivo se encuentra en:
\SegurosBlazorApp\Server\appsettings.json

2 - click derecho en la solucion y "restore nugget packages"

3 - correr en el "Project Manager Console" (views->other windows) el comando:  update-database
para crear la base de datos en tu conexion que definiste en el punto 1

4 - correr en tu SQL management Studio los 4 archivos de la carpeta SQL, es para crear los 4 SPS necesarios para los insert/update y deletes.

cualquier duda con mucho gusto pueden escribirme.
