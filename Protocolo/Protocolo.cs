// ************************************************************************
// Práctica 07 - Gestión de Versiones e Integración Continua (GitHub)
// Xavier Espinel
// Fecha de realización: 11/06/2025
// Fecha de entrega: 17/06/2025

// Resultados:
// * Se creó una cuenta en Learn Microsoft y GitHub, cumpliendo con los requisitos iniciales.
// * Se realizó el curso de introducción a GitHub y el tutorial de clonación de repositorios con Visual Studio 2022.
// * Se clonó correctamente el repositorio desde GitHub y se integró con un proyecto en Visual Studio.
// * Se modificaron clases clave como `Protocolo`, `Cliente` y `Servidor` para implementar métodos como `HazOperación` y `ResolverPedido`.
// * Se cargaron los cambios al repositorio siguiendo el flujo recomendado con Visual Studio.

// Conclusiones:
// * Se comprendió el uso de GitHub como herramienta de control de versiones y su integración con Visual Studio.
// * La modificación de clases y la reestructuración del código permitió aplicar conceptos de encapsulamiento y modularidad.
// * La sincronización entre el entorno local y el repositorio remoto fortaleció las prácticas de trabajo colaborativo.
// * Se identificó la importancia de documentar y comentar adecuadamente los cambios realizados en el código fuente.

// Recomendaciones:
// * Usar ramas para desarrollar nuevas funcionalidades sin afectar la rama principal.
// * Realizar commits frecuentes con mensajes descriptivos para facilitar el seguimiento del historial de cambios.
// * Implementar workflows de integración continua para validar automáticamente el código.
// * Fomentar el uso de issues y pull requests como mecanismos de revisión y control de calidad en proyectos colaborativos.
// ************************************************************************

using System.Linq;

namespace Protocolo
{
    public class Pedido
    {
        public string Comando { get; set; }
        public string[] Parametros { get; set; }

        public static Pedido Procesar(string mensaje)
        {
            var partes = mensaje.Split(' ');
            return new Pedido
            {
                Comando = partes[0].ToUpper(),
                Parametros = partes.Skip(1).ToArray()
            };
        }

        public override string ToString()
        {
            return $"{Comando} {string.Join(" ", Parametros)}";
        }
    }

    public class Respuesta
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }

        public override string ToString()
        {
            return $"{Estado} {Mensaje}";
        }
    }

}
