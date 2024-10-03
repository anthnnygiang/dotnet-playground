using System;
using System.Collections.Generic;

namespace dotnet_playground;

/* Basic implementation of Generic List */
public class MeList<T>
{
    int _count;
    T[] _items = new T[4];

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
