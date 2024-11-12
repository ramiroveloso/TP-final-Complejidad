using System; // Importa el espacio de nombres System, que incluye excepciones
using System.Collections.Generic; // Importa el espacio de nombres para listas genéricas

namespace tpfinal // Declara el espacio de nombres tpfinal
{
    // Definición de la clase MinHeap
    public class MinHeap
    {
        // Lista para almacenar los elementos de tipo Proceso en la estructura de min-heap
        private List<Proceso> heap;

        // Constructor de la clase MinHeap, inicializa la lista de procesos
        public MinHeap()
        {
            heap = new List<Proceso>();
        }

        // Propiedad de solo lectura que devuelve el número de elementos en el heap
        public int Count => heap.Count;

        // Método para insertar un nuevo proceso en el min-heap
        public void Insert(Proceso proceso)
        {
            heap.Add(proceso); // Agrega el proceso al final de la lista
            HeapifyUp(heap.Count - 1); // Ajusta la posición del elemento agregado
        }

        // Método para extraer el elemento mínimo (raíz) del min-heap
        public Proceso ExtractMin()
        {
            // Lanza una excepción si el heap está vacío
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

            Proceso min = heap[0]; // Guarda el elemento mínimo
            heap[0] = heap[heap.Count - 1]; // Mueve el último elemento a la raíz
            heap.RemoveAt(heap.Count - 1); // Elimina el último elemento

            // Si aún hay elementos en el heap, ajusta la posición del elemento en la raíz
            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return min; // Devuelve el elemento mínimo extraído
        }

        // Método auxiliar para mantener la propiedad del min-heap al subir un elemento
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2; // Calcula el índice del nodo padre
                // Si el elemento actual no es menor que su padre, se detiene el bucle
                if (heap[index].tiempo >= heap[parentIndex].tiempo) break;

                Swap(index, parentIndex); // Intercambia el elemento actual con su padre
                index = parentIndex; // Actualiza el índice al del padre
            }
        }

        // Método auxiliar para mantener la propiedad del min-heap al bajar un elemento
        private void HeapifyDown(int index)
        {
            int smallest = index; // Inicializa el índice del elemento más pequeño como el índice actual

            while (true)
            {
                int left = 2 * index + 1; // Índice del hijo izquierdo
                int right = 2 * index + 2; // Índice del hijo derecho

                // Comprueba si el hijo izquierdo es menor que el elemento actual
                if (left < heap.Count && heap[left].tiempo < heap[smallest].tiempo)
                    smallest = left;

                // Comprueba si el hijo derecho es menor que el menor actual
                if (right < heap.Count && heap[right].tiempo < heap[smallest].tiempo)
                    smallest = right;

                // Si el elemento actual es el menor, sale del bucle
                if (smallest == index) break;

                Swap(index, smallest); // Intercambia el elemento actual con el menor
                index = smallest; // Actualiza el índice actual
            }
        }

        // Método para intercambiar dos elementos en el heap
        private void Swap(int i, int j)
        {
            Proceso temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Método GetAt para obtener el elemento en un índice dado
        public Proceso GetAt(int index)
        {
            // Lanza una excepción si el índice está fuera del rango
            if (index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            return heap[index]; // Devuelve el elemento en el índice especificado
        }
        public int GetHeight() // Método para calcular la altura del MinHeap
        {
            return (int)Math.Floor(Math.Log2(heap.Count + 1));
        }
        public List<Proceso> GetElements() => new List<Proceso>(heap);

    }

    // Definición de la clase MaxHeap
    public class MaxHeap
    {
        // Lista para almacenar los elementos de tipo Proceso en la estructura de max-heap
        private List<Proceso> heap;

        // Constructor de la clase MaxHeap, inicializa la lista de procesos
        public MaxHeap()
        {
            heap = new List<Proceso>();
        }

        // Propiedad de solo lectura que devuelve el número de elementos en el heap
        public int Count => heap.Count;

        // Método para insertar un nuevo proceso en el max-heap
        public void Insert(Proceso proceso)
        {
            heap.Add(proceso); // Agrega el proceso al final de la lista
            HeapifyUp(heap.Count - 1); // Ajusta la posición del elemento agregado
        }

        // Método para extraer el elemento máximo (raíz) del max-heap
        public Proceso ExtractMax()
        {
            // Lanza una excepción si el heap está vacío
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

            Proceso max = heap[0]; // Guarda el elemento máximo
            heap[0] = heap[heap.Count - 1]; // Mueve el último elemento a la raíz
            heap.RemoveAt(heap.Count - 1); // Elimina el último elemento

            // Si aún hay elementos en el heap, ajusta la posición del elemento en la raíz
            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return max; // Devuelve el elemento máximo extraído
        }

        // Método auxiliar para mantener la propiedad del max-heap al subir un elemento
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2; // Calcula el índice del nodo padre
                // Si el elemento actual no es mayor que su padre, se detiene el bucle
                if (heap[index].prioridad <= heap[parentIndex].prioridad) break;

                Swap(index, parentIndex); // Intercambia el elemento actual con su padre
                index = parentIndex; // Actualiza el índice al del padre
            }
        }

        // Método auxiliar para mantener la propiedad del max-heap al bajar un elemento
        private void HeapifyDown(int index)
        {
            int largest = index; // Inicializa el índice del elemento más grande como el índice actual

            while (true)
            {
                int left = 2 * index + 1; // Índice del hijo izquierdo
                int right = 2 * index + 2; // Índice del hijo derecho

                // Comprueba si el hijo izquierdo es mayor que el elemento actual
                if (left < heap.Count && heap[left].prioridad > heap[largest].prioridad)
                    largest = left;

                // Comprueba si el hijo derecho es mayor que el mayor actual
                if (right < heap.Count && heap[right].prioridad > heap[largest].prioridad)
                    largest = right;

                // Si el elemento actual es el mayor, sale del bucle
                if (largest == index) break;

                Swap(index, largest); // Intercambia el elemento actual con el mayor
                index = largest; // Actualiza el índice actual
            }
        }

        // Método para intercambiar dos elementos en el heap
        private void Swap(int i, int j)
        {
            Proceso temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Método GetAt para obtener el elemento en un índice dado
        public Proceso GetAt(int index)
        {
            // Lanza una excepción si el índice está fuera del rango
            if (index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            return heap[index]; // Devuelve el elemento en el índice especificado
        }
        public int GetHeight() // Método para calcular la altura del MaxHeap
        {
            return (int)Math.Floor(Math.Log2(heap.Count + 1));
        }
        public List<Proceso> GetElements() => new List<Proceso>(heap);

    }
}