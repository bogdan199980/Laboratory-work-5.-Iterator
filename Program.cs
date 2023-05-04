using System;
using System.Collections;

namespace IteratorPattern
{
    // Інтерфейс ітератора
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // Клас колекції
    public class MyCollection
    {
        private ArrayList _items = new ArrayList();

        public void AddItem(object item)
        {
            _items.Add(item);
        }

        // Метод, який повертає ітератор для колекції
        public IIterator CreateIterator()
        {
            return new MyIterator(this);
        }

        // Вкладений клас-ітератор
        private class MyIterator : IIterator
        {
            private MyCollection _collection;
            private int _position = -1;

            public MyIterator(MyCollection collection)
            {
                _collection = collection;
            }

            public bool HasNext()
            {
                return _position < _collection._items.Count - 1;
            }

            public object Next()
            {
                _position++;
                return _collection._items[_position];
            }
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection();
            collection.AddItem("Item 1");
            collection.AddItem("Item 2");
            collection.AddItem("Item 3");
            collection.AddItem("Item 4");
            collection.AddItem("Item 5");

            // Отримання ітератора для колекції
            IIterator iterator = collection.CreateIterator();

            // Перебір елементів колекції з використанням ітератора
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }

            Console.ReadKey();
        }
    }
}
