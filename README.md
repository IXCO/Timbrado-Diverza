# Timbrado-Diverza
Servicio de timbrado para facturación con diverza. Base de la estructura, __NO__ operativo.

## Descripción

Esta es la base del desarrollo para generar una petición de timbrado o cancelación con el PAC de Diverza. 
En esta versión se utiliza una interfaz grafica para que el usuario pueda usarlo localmente.

## Requerimientos

### Sistema

- Windows 7 en adelante.

### Adicionales

- Tener servicio de timbre fiscal vigente con Diverza y sus credenciales de acceso.
- Contar con archivos XML ya generados.

## Funcionalidad

1. Timbre de CFDi's con o sin complemento de nomina.
2. Cancelación de CFDi's.

## Como usar

- Entrar a la clase __Program__ e indicar credenciales.
```C#
private static string token ="mitokenobtenidodediverza";
private static string urlTimbrado = "urlejemplo.com";
private static string urlCancelacion = "urlejemplo.com";
```
- Generar y correr.

### Notas
Se recomienda iniciar con el ambiente de pruebas que provee Diverza.

*Mundo Inmobiliario S.A*
