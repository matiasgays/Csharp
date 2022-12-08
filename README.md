# C#

Repositorio correspondiente al curso de C# de CoderHouse

## Requisitos

Tener instalado [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/) y [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

## Trabajo Final

### DB

Abrir Microsoft SQL Server e ingresar la siguiente informacion:

Server Name:`sql.bsite.net\MSSQL2016`

Login: `matias_c#`

Password: `TWG3zHLuFZ8fc@9`
    
*Base de datos creada en [Freeasphosting](https://freeasphosting.net/)*

### Front_End

Abrir la carpeta con Visual Studio Code y correr el programa con la sentencia:

```
npm start
```

### Back_End


Abrir el archivo `WebAPI.sln` con Visual Studio y correr el programa. 

#### API y EndPoints

| API                           |Metodo  |   End point          |
| :---------------------------- | :----- | :------------------- |
| Inicio de sesion              | GET    | User/LogIn?username={userName}&password={password}                                 |
| Traer usuarios                | GET    | User                 |
| Traer usuario                 | GET    | User/{userName}      |
| Nuevo usuario                 | POST   | User                 |
| Actualizar usuario            | PUT    | User                 |
| Eliminar usuario              | DELETE | User                 |
| Traer productos               | GET    | Product              |
| Traer producto                | GET    | Product/{userId}     |
| Nuevo producto                | POST   | Product              |
| Actualizar producto           | PUT    | Product              |
| Eliminar producto             | DELETE | Product              |
| Traer productos vendidos      | GET    | ProductSold          |
| Traer producto vendido        | GET    | ProductSold/{id}     |
| Nuevo producto vendido        | POST   | ProductSold          |
| Actualizar producto vendido   | PUT    | ProductSold          |
| Eliminar producto vendido     | DELETE | ProductSold          |
| Traer ventas                  | GET    | Sale                 |
| Traer venta                   | GET    | Sale/{id}            |
| Nueva venta                   | POST   | Sale                 |
| Actualizar venta              | PUT    | Sale                 |
| Eliminar venta                | DELETE | Sale                 |

*Validar con Swagger/Postman*
