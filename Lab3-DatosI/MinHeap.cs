using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_DatosI
{
    internal class MinHeap
    {
        private List<Customer> heap;

        public MinHeap()
        {
            heap = new List<Customer>();
        }

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        private void Swap(int i, int j)
        {
            Customer temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void MinHeapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int smallest = i;

            if (left < heap.Count && heap[left].Budget > heap[smallest].Budget)
                smallest = left;

            if (right < heap.Count && heap[right].Budget > heap[smallest].Budget)
                smallest = right;

            if (smallest != i)
            {
                Swap(i, smallest);
                MinHeapify(smallest);
            }
        }

        public void Insert(Customer customer)
        {
            heap.Add(customer);
            int i = heap.Count - 1;

            while (i > 0 && heap[i].Budget > heap[Parent(i)].Budget)
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public Customer ExtractMax()
        {
            if (heap.Count == 0)
                return null;

            Customer max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            MinHeapify(0);

            return max;
        }
    }
}
