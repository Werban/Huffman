using System.Collections.Generic;

namespace Huffman
{
    internal class PriorityQueue<T>
    {
        int size;
        SortedDictionary<int, Queue<T>> storage;//SortedDictionary для хранения элементов очереди в порядке их приоритета

        public PriorityQueue()
        {
            storage = new SortedDictionary<int, Queue<T>>();
            size = 0;
        }

        public int Size() => size; //метод для возврата размера очереди

        public void Enqueue(int priority, T item)//метод для добавления элемента в очередь с указанным приоритетом.
        {
            //Если в SortedDictionary еще нет ключа с таким приоритетом,
            //создается новая очередь для элементов с этим приоритетом.
            //Затем элемент добавляется в соответствующую очередь, и размер очереди увеличивается.
            if (!storage.ContainsKey(priority))
                storage.Add(priority, new Queue<T>());
            storage[priority].Enqueue(item);
            size++;
        }

        public T Dequeue()//получение элемента из приоритетной очереди
        {
            if (size == 0)
                throw new System.Exception("Queue is empty");
            size--;
            foreach (Queue<T> q in storage.Values)
                if (q.Count > 0)
                    return q.Dequeue();
            throw new System.Exception("Queue error");
        }
    }
}