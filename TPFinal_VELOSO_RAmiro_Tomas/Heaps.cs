using System; // Importa el espacio de nombres System, que incluye excepciones
using System.Collections.Generic; // Importa el espacio de nombres para listas gen�ricas

namespace tpfinal // Declara el espacio de nombres tpfinal
{
    // Definici�n de la clase MinHeap
    public class MinHeap
    {
        // Lista para almacenar los elementos de tipo Proceso en la estructura de min-heap
        private List<Proceso> heap;

        // Constructor de la clase MinHeap, inicializa la lista de procesos
        public MinHeap()
        {
            heap = new List<Proceso>();
        }

        // Propiedad de solo lectura que devuelve el n�mero de elementos en el heap
        public int Count => heap.Count;

        // M�todo para insertar un nuevo proceso en el min-heap
        public void Insert(Proceso proceso)
        {
            heap.Add(proceso); // Agrega el proceso al final de la lista
            HeapifyUp(heap.Count - 1); // Ajusta la posici�n del elemento agregado
        }

        // M�todo para extraer el elemento m�nimo (ra�z) del min-heap
        public Proceso ExtractMin()
        {
            // Lanza una excepci�n si el heap est� vac�o
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

            Proceso min = heap[0]; // Guarda el elemento m�nimo
            heap[0] = heap[heap.Count - 1]; // Mueve el �ltimo elemento a la ra�z
            heap.RemoveAt(heap.Count - 1); // Elimina el �ltimo elemento

            // Si a�n hay elementos en el heap, ajusta la posici�n del elemento en la ra�z
            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return min; // Devuelve el elemento m�nimo extra�do
        }

        // M�todo auxiliar para mantener la propiedad del min-heap al subir un elemento
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2; // Calcula el �ndice del nodo padre
                // Si el elemento actual no es menor que su padre, se detiene el bucle
                if (heap[index].tiempo >= heap[parentIndex].tiempo) break;

                Swap(index, parentIndex); // Intercambia el elemento actual con su padre
                index = parentIndex; // Actualiza el �ndice al del padre
            }
        }

        // M�todo auxiliar para mantener la propiedad del min-heap al bajar un elemento
        private void HeapifyDown(int index)
        {
            int smallest = index; // Inicializa el �ndice del elemento m�s peque�o como el �ndice actual

            while (true)
            {
                int left = 2 * index + 1; // �ndice del hijo izquierdo
                int right = 2 * index + 2; // �ndice del hijo derecho

                // Comprueba si el hijo izquierdo es menor que el elemento actual
                if (left < heap.Count && heap[left].tiempo < heap[smallest].tiempo)
                    smallest = left;

                // Comprueba si el hijo derecho es menor que el menor actual
                if (right < heap.Count && heap[right].tiempo < heap[smallest].tiempo)
                    smallest = right;

                // Si el elemento actual es el menor, sale del bucle
                if (smallest == index) break;

                Swap(index, smallest); // Intercambia el elemento actual con el menor
                index = smallest; // Actualiza el �ndice actual
            }
        }

        // M�todo para intercambiar dos elementos en el heap
        private void Swap(int i, int j)
        {
            Proceso temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // M�todo GetAt para obtener el elemento en un �ndice dado
        public Proceso GetAt(int index)
        {
            // Lanza una excepci�n si el �ndice est� fuera del rango
            if (index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            return heap[index]; // Devuelve el elemento en el �ndice especificado
        }
        public int GetHeight() // M�todo para calcular la altura del MinHeap
        {
            return (int)Math.Floor(Math.Log2(heap.Count + 1));
        }
        public List<Proceso> GetElements() => new List<Proceso>(heap);

    }

    // Definici�n de la clase MaxHeap
    public class MaxHeap
    {
        // Lista para almacenar los elementos de tipo Proceso en la estructura de max-heap
        private List<Proceso> heap;

        // Constructor de la clase MaxHeap, inicializa la lista de procesos
        public MaxHeap()
        {
            heap = new List<Proceso>();
        }

        // Propiedad de solo lectura que devuelve el n�mero de elementos en el heap
        public int Count => heap.Count;

        // M�todo para insertar un nuevo proceso en el max-heap
        public void Insert(Proceso proceso)
        {
            heap.Add(proceso); // Agrega el proceso al final de la lista
            HeapifyUp(heap.Count - 1); // Ajusta la posici�n del elemento agregado
        }

        // M�todo para extraer el elemento m�ximo (ra�z) del max-heap
        public Proceso ExtractMax()
        {
            // Lanza una excepci�n si el heap est� vac�o
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

            Proceso max = heap[0]; // Guarda el elemento m�ximo
            heap[0] = heap[heap.Count - 1]; // Mueve el �ltimo elemento a la ra�z
            heap.RemoveAt(heap.Count - 1); // Elimina el �ltimo elemento

            // Si a�n hay elementos en el heap, ajusta la posici�n del elemento en la ra�z
            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return max; // Devuelve el elemento m�ximo extra�do
        }

        // M�todo auxiliar para mantener la propiedad del max-heap al subir un elemento
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2; // Calcula el �ndice del nodo padre
                // Si el elemento actual no es mayor que su padre, se detiene el bucle
                if (heap[index].prioridad <= heap[parentIndex].prioridad) break;

                Swap(index, parentIndex); // Intercambia el elemento actual con su padre
                index = parentIndex; // Actualiza el �ndice al del padre
            }
        }

        // M�todo auxiliar para mantener la propiedad del max-heap al bajar un elemento
        private void HeapifyDown(int index)
        {
            int largest = index; // Inicializa el �ndice del elemento m�s grande como el �ndice actual

            while (true)
            {
                int left = 2 * index + 1; // �ndice del hijo izquierdo
                int right = 2 * index + 2; // �ndice del hijo derecho

                // Comprueba si el hijo izquierdo es mayor que el elemento actual
                if (left < heap.Count && heap[left].prioridad > heap[largest].prioridad)
                    largest = left;

                // Comprueba si el hijo derecho es mayor que el mayor actual
                if (right < heap.Count && heap[right].prioridad > heap[largest].prioridad)
                    largest = right;

                // Si el elemento actual es el mayor, sale del bucle
                if (largest == index) break;

                Swap(index, largest); // Intercambia el elemento actual con el mayor
                index = largest; // Actualiza el �ndice actual
            }
        }

        // M�todo para intercambiar dos elementos en el heap
        private void Swap(int i, int j)
        {
            Proceso temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // M�todo GetAt para obtener el elemento en un �ndice dado
        public Proceso GetAt(int index)
        {
            // Lanza una excepci�n si el �ndice est� fuera del rango
            if (index < 0 || index >= heap.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            return heap[index]; // Devuelve el elemento en el �ndice especificado
        }
        public int GetHeight() // M�todo para calcular la altura del MaxHeap
        {
            return (int)Math.Floor(Math.Log2(heap.Count + 1));
        }
        public List<Proceso> GetElements() => new List<Proceso>(heap);

    }
}