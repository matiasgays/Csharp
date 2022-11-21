use [matias_c#]
go
-- Consulta 1: traer los datos del usuario que tiene como nombre de usuario tcasazza
select * 
from Usuario
where NombreUsuario = 'tcasazza' 
go

-- Consulta 2: buscar un usuario y una contraseña específica; si los 2 no coinciden que no traiga nada.
-- Probar un caso poniendo ambos campos bien y probar poniendo un caso mal.

select u.NombreUsuario, u.Contraseña 
from Usuario u
where NombreUsuario = 'tcasazza'
and Contraseña = 'SoyErnestoPerez'
go

select u.NombreUsuario, u.Contraseña 
from Usuario u
where NombreUsuario = 'eperez'
and Contraseña = 'SoyErnestoPerez'
go

-- Consulta 3: traer todos los productos cargados por el usuario que tiene ID = 1

select p.Descripciones,u.Nombre, u.Apellido, p.IdUsuario
from Producto p
join Usuario u
on p.IdUsuario = u.Id
where u.Id = 1
go

-- Consulta 4: realizar un Insert que inserte un nuevo usuario con todos sus datos

insert into Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail)
values ('Matias','Gays','matiasgays','aguanteCoder','matiasgays@gmail.com')
go

select * from Usuario
go

-- Consulta 5: realizar un Insert que inserte un producto nuevo a su tabla

insert into Producto (Descripciones,Costo,PrecioVenta, Stock, IdUsuario)
values ('crocs',900, 1800, 32, 3)
go

select * from Producto

-- Consulta 6: cambiar la contraseña del usuario Tobias

update Usuario
set Contraseña = 'nuevaContraseniaTobi'
where Id = 1
go

select * from Usuario
go

-- Consulta 7: eliminar el usuario con apellido Perez

delete from Usuario
where Apellido = 'Perez'
go

select * from Usuario
go

-- Consulta 8: poner en 0 el stock de los buzos en la tabla producto

update Producto
set Stock = 0
where Descripciones = 'Buzo'
go

select * from Producto

-- Consulta 9: eliminar el producto “Musculosa”

delete from Producto
where Descripciones = 'Musculosa'
go

select * from Producto
go

-- Consulta 10: obtener los nombres de usuarios que cargaron los productos

select distinct u.Nombre, u.Apellido
from Producto p 
join Usuario u
on p.IdUsuario = u.Id
go

select * from Usuario
go

-- Consulta 11: obtener todos los productos vendidos

select * from ProductoVendido
go

select p.Descripciones
from Producto p 
join ProductoVendido pv
on p.Id = pv.IdProducto
go

-- Consulta 12: Obtener ventas mayores a 10000 de los productos que terminan con “ina”. 
-- Si la consulta retorna vacía, agregar más productos y ventas para que esta traiga datos

select * from ProductoVendido
go

insert into Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
values ('Caldo de gallina', 200, 550, 25, 3)
go

insert into Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
values ('Caldo de gallina', 200, 550, 5, 3)
go

insert into ProductoVendido (Stock,IdProducto,IdVenta)
values (22,9,3)
go

insert into ProductoVendido (Stock,IdProducto,IdVenta)
values (3,9,3)
go

select p.Descripciones, pv.Stock, pv.IdVenta
from Producto p 
join ProductoVendido pv
on p.Id = pv.IdProducto
where p.PrecioVenta*pv.Stock > 10000
and p.Descripciones like '%ina'
go

-- Consulta 13: Insertar la venta de 20 productos “Aceite de Girasol Cocinera” con precio de venta de 500 y de compra de 350 cada uno

insert into Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)
values ('Aceite de Girasol Cocinera',350,500,20,3)
go

insert into ProductoVendido (Stock,IdProducto,IdVenta)
values (20,8,2)
go

update Producto
set Stock = 0
where Descripciones = 'Aceite de Girasol Cocinera'
go

select * from Producto
go

select * from ProductoVendido
go
