## Proyecto Domicilios con .NET y Entity Frameworks
**G59-03 ciclo 3 MisionTIC2022**
####
![Image text](/ElGordo.App/ElGordo.App.Frontend/wwwroot/img/misiontic2022.png)

## Implementación

Ejecutar ***dotnet build*** en dominio y persistencia

Ejecutar desde la capa de Persistencia.

```bash
dotnet ef database update --startup-project ..\ElGordo.App.Consola\
```
Esto genera la base de datos con los estados por defecto para Productos, Facturas y Pedidos, al igual que un usuario **admin** con password **admin** para ingresar al panel de control.

## Módulo Cliente

URL: https://localhost:5001/

![Image text](/ElGordo.App/ElGordo.App.Frontend/wwwroot/img/Cliente.png)

## Módulo Administrador

URL: https://localhost:5001/Admin

![Image text](/ElGordo.App/ElGordo.App.Frontend/wwwroot/img/Admin.png)
