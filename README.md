
# Prueba Tecnica

En este docuemnto indico la manera de poder implementar el desarrollo y respondo las preguntas planteadas en el documento de la prueba

## Preguntas

1. Describe how you would profile and optimize a slow-running query in an ASP.NET Core application.

R/ para mi una consulta lenta podria ser un get sin where, que tenga que traer una gran cantidad de datos, en el caso de que no se pueda implementar un where por reglas de negocio utilizaria la paginacion en el query para reducir los tiempos de respuesta.

2. ¿Cuáles son algunos problemas de rendimiento comunes en las aplicaciones .NET y cómo solucionarlos?

R/
Consultas a la base de datos ineficientes: Considera la posibilidad de utilizar índices adecuados y optimizar las consultas SQL
Falta de monitoreo y/o métricas: Implementa un sistema de monitoreo como Application Insights, Serilog para obtener métricas y logs que te permitan identificar y resolver problemas.
Dependencias innecesarias: Revisar y eliminar dependencias que no sean esenciales.

3. Explique el concepto de middleware en ASP.NET Core

R/ Un middleware es un fragmento de codigo que se ejecuta antes o despues de ser llamado algun endpoint, con el objetivo de unificar logs de errores, generar logs de los llamados a la api, etc.

4. Describe cómo implementarías la autenticación y autorización en esta API.

R/ La manera correcta seria por medio de tokens, se debe registrar un usuario y despues iniciar sesion, al momento de iniciar una sesion se le devuelve un token a ese usuario que debe enviar por medio de los Headers para poder ser validado en la api y asi pode acceder a los endpoints a los que tiene permiso.



# Instalacion

se debe clonar el proyecto, despues de esto, ir a la ruta: WebApi, DI, Infrastructure y al archivo DependencyInjection, ahi se debe agregar la cadena de conexion.

Se debe abrir MySql Workbench el query .sql que se encuentra en la ruta raiz de la github con el nombre: Prueba_Tecnica.sql

