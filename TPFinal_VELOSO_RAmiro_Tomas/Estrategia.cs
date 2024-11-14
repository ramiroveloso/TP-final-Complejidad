
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Numerics;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {

        public string Consulta1(List<Proceso> datos)
        {
            // Construimos las Heaps según los métodos dados.
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            // Insertamos los procesos en ambas Heaps
            foreach (var proceso in datos)
            {
                minHeap.Insert(proceso);
                maxHeap.Insert(proceso);
            }

            // Obtenemos las hojas de la MinHeap (ShortesJobFirst) y MaxHeap (PreemptivePriority)
            List<Proceso> hojasMinHeap = ObtenerHojas(minHeap);
            List<Proceso> hojasMaxHeap = ObtenerHojas(maxHeap);

            // Creamos el resultado en formato de texto
            string resultado = "Hojas de MinHeap (ShortesJobFirst):\n";
            foreach (var hoja in hojasMinHeap)
            {
                resultado += $"Proceso: {hoja.nombre}, Prioridad: {hoja.prioridad}, TiempoCPU: {hoja.tiempo}\n";
            }
            resultado += "Hojas de MaxHeap (PreemptivePriority):\n";
            foreach (var hoja in hojasMaxHeap)
            {
                resultado += $"Proceso: {hoja.nombre}, Prioridad: {hoja.prioridad}, TiempoCPU: {hoja.tiempo}\n";
            }
            return resultado;
        }

        // Método auxiliar para obtener las hojas de una Heap
        private List<Proceso> ObtenerHojas(dynamic heap)
        {
            List<Proceso> hojas = new List<Proceso>();
            int n = heap.Count;
            // Las hojas son los nodos desde la posición n/2 hasta el final de la lista
            for (int i = n / 2; i < n; i++)
            {
                hojas.Add(heap.GetAt(i));  // Usamos el metodo GetAt en tanto para MinHeap como para MaxHeap
            }
            return hojas;
        }

        public String Consulta2(List<Proceso> datos)
        {
            //string resutl = "- Retornar la altura de las Heaps creadas. ";

            //return resutl;
            //  - Retornar la altura de las Heaps creadas. 

            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();

            // Insertamos todos los procesos en ambas heaps
            foreach (Proceso proceso in datos)
            {
                minHeap.Insert(proceso);
                maxHeap.Insert(proceso);
            }

            // Calculamos las alturas de ambas heaps y formamos el resultado
            int minHeapHeight = minHeap.GetHeight();
            int maxHeapHeight = maxHeap.GetHeight();

            return $"Altura del MinHeap: {minHeapHeight}, Altura del MaxHeap: {maxHeapHeight}";
        }

        public String Consulta3(List<Proceso> datos)
        {
            //string resutl = "- Retornar un texto con la disposición de los elementos en cada nivel de las Heaps.";

            //return resutl;
            //- Retornar un texto con la disposición de los elementos en cada nivel de las Heaps. 
            // Obtener los elementos con sus niveles de cada heap
            // Método que calcula los niveles de los elementos en una heap y retorna un texto con los procesos por nivel

            // Método auxiliar para obtener los datos de los procesos por niveles

                Dictionary<int, List<Proceso>> niveles = new Dictionary<int, List<Proceso>>();

                // Agrupar los procesos por niveles
                for (int i = 0; i < datos.Count; i++)
                {
                    int nivel = (int)Math.Floor(Math.Log2(i + 1));  // Calcular el nivel del índice actual
                    if (!niveles.ContainsKey(nivel))//si existen elementos en el nivel
                    {
                        niveles[nivel] = new List<Proceso>(); //crea una lista de procesos en ese nivel
                    }
                    niveles[nivel].Add(datos[i]);//agrega los procesos de forma iterativa en el nivel
                }

                // Crear la cadena de resultados por nivel
                string resultado = $" Datos por Niveles:";
                foreach (var nivel in niveles)
                {
                    resultado += $"\n  Nivel {nivel.Key}:";
                    foreach (var proceso in nivel.Value)
                    {
                        resultado += $" {proceso}";
                    }
                }

                return resultado;
        }

        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
            //- Insertar cada proceso en la MinHeap en función del tiempo de uso de la CPU. 
            // se crea una minHeap
            // a la  que se le insertan procesos de manera iterativa
            // la minheap tomara el valor del tiempo de usa como determinante para cumplir su propiedad de orden

            //-Extraer los procesos en orden ascendente y añadirlos a la lista `collected`. 
            // se eliminan iterativamente elementos de la minHeap y colocan en la lista 
            //resultando una lista ordenada segun tiempo de uso de la cpu de menor a mayor
    
            // Crear una MinHeap para almacenar los procesos de menor a mayor tiempo de CPU
            MinHeap minHeap = new MinHeap();

            // Insertar cada proceso en la MinHeap
            foreach (Proceso proceso in datos)
            {
                minHeap.Insert(proceso);
            }

            // Extraer cada proceso del MinHeap y agregarlo a la lista collected
            while (minHeap.Count > 0)
            {
                collected.Add(minHeap.ExtractMin()); // Extrae el proceso con menor tiempo de CPU y lo agrega a la lista resultante
            }

        }

        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
            //-Insertar cada proceso en la MaxHeap en función de su prioridad. 
            // se crea una maxHeap 
            // a la que se le insertan procesos de manera iterativa
            // la maxHeap tomara el valor de prioridad como determinante de para cumplir su propiedad de orden

            //-Extraer los procesos en orden descendente y añadirlos a la lista `collected`
            // se eliminan iterativamente elementos de la maxHeap y colocan en la lista collected
            // resultando una lista ordenada de procesos segun su prioridad de mayor a menor

            // Crear una MaxHeap para almacenar los procesos de mayor a menor prioridad
            MaxHeap maxHeap = new MaxHeap();

            // Insertar cada proceso en la MaxHeap
            foreach (Proceso proceso in datos)
            {
                maxHeap.Insert(proceso);
            }

            // Extraer cada proceso de la MaxHeap y agregarlo a la lista collected
            while (maxHeap.Count > 0)
            {
                collected.Add(maxHeap.ExtractMax()); // Extrae el proceso con mayor prioridad y lo agrega a la lista resultante
            }
        }

    }
}