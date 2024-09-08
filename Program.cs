using System;
using System.Collections.Generic;

MeList<int> myParty = new();
myParty.Add(1);
myParty.Add(2);
myParty.Add(3);
myParty.Add(4);
myParty.Add(5);
myParty.Add(6);
myParty.Add(7);
myParty.Add(8);
myParty.Add(9);


IEnumerator<int> enr = myParty.GetEnumerator();
while (enr.MoveNext())
{
    Console.WriteLine(enr.Current);
}

enr.Dispose();


class MeList<T>
{
    int _count;
    T[] _items = new T[5];

    public static string Name { get; set; }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        /* post increment count */
        _items[_count++] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }
}
