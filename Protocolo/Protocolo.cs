// ************************************************************************
// Práctica 07 - Unificación de lógica de comunicación en la clase Protocolo
// Xavier Espinel / Solange Ramos
// Fecha de realización: 17/06/2025
// Fecha de entrega: 21/06/2025
//
// Resultados:
// * Se implementó correctamente la clase Protocolo para encapsular tanto los mensajes de tipo Pedido como Respuesta.
// * Se centralizó la lógica de análisis y generación de comandos, facilitando su uso desde Cliente y Servidor.
// * El método Pedido.Procesar permite interpretar el mensaje recibido y convertirlo en un objeto estructurado.
// * La solución compila sin errores y cumple con el paradigma petición-respuesta mediante sockets TCP.
//
// Conclusiones:
// * Separar la lógica de comunicación en clases específicas mejora la escalabilidad y el mantenimiento del código.
// * La encapsulación de Pedido y Respuesta favorece la reutilización del código en ambos extremos de la comunicación.
// * Esta arquitectura permite una posible extensión futura hacia formatos de serialización como JSON o XML.
//
// Recomendaciones:
// * Añadir validaciones adicionales en Procesar para manejar entradas vacías o incorrectas.
// * Implementar logs en cada conversión de mensaje para facilitar la depuración en tiempo de ejecución.
// * Mantener el patrón modular y documentado en futuras prácticas donde se incluyan más tipos de mensajes.
// ************************************************************************

using System.Linq;

namespace Protocolo
{
    // Clase que representa un pedido del cliente al servidor.
    public class Pedido
    {
        // Propiedad que almacena el comando solicitado (por ejemplo: SUMAR, RESTAR).
        public string Comando { get; set; }

        // Lista de parámetros asociados al comando, separados por espacio.
        public string[] Parametros { get; set; }

        // Método estático que recibe una cadena cruda y la convierte en un objeto Pedido.
        public static Pedido Procesar(string mensaje)
        {
            // Divide el mensaje en partes separadas por espacio.
            var partes = mensaje.Split(' ');

            // Devuelve una instancia de Pedido con el primer elemento como comando y el resto como parámetros.
            return new Pedido
            {
                Comando = partes[0].ToUpper(), // Convierte el comando a mayúsculas por consistencia.
                Parametros = partes.Skip(1).ToArray() // Toma el resto como parámetros.
            };
        }

        // Representación en texto del objeto Pedido, útil para enviar de vuelta como cadena.
        public override string ToString()
        {
            return $"{Comando} {string.Join(" ", Parametros)}";
        }
    }

    // Clase que representa la respuesta del servidor al cliente.
    public class Respuesta
    {
        // Indica el estado del resultado (por ejemplo: OK, ERROR).
        public string Estado { get; set; }

        // Contiene el mensaje de respuesta asociado al estado.
        public string Mensaje { get; set; }

        // Devuelve la representación en texto del objeto Respuesta.
        public override string ToString()
        {
            return $"{Estado} {Mensaje}";
        }
    }
}

