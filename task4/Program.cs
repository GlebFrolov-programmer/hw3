﻿using static System.Console;

Deque<int> deque = new();

Write("->");
string cmd = ReadLine();

while (cmd != "stop")
{
    switch (cmd)
    {
        case "add first":
            Write("--->");
            cmd = ReadLine();
            if (int.TryParse(cmd, out int fVal))
            {
                deque.AddFirst(fVal);
                break;
            }

            WriteLine("incorrect value");
            break;
        case "add last":
            Write("--->");
            cmd = ReadLine();
            if (int.TryParse(cmd, out int lVal))
            {
                deque.AddLast(lVal);
                break;
            }

            WriteLine("incorrect value");
            break;
        case "search":
            Write("--->");
            cmd = ReadLine();
            if (int.TryParse(cmd, out int sVal))
            {
                int[] resArr = deque.Search(sVal);
                for (int i = 0; i < resArr.Length; i++)
                {
                    Write((i == 0 ? "" : ";") + resArr[i]);
                }

                WriteLine();
                break;
            }

            WriteLine("incorrect value");
            break;
        case "remove at":
            Write("--->");
            cmd = ReadLine();
            if (int.TryParse(cmd, out int iVal))
            {
                WriteLine(deque.RemoveAt(iVal) == 0 ? "ok" : "error");
                break;
            }

            WriteLine("incorrect value");
            break;
        case "remove":
            Write("--->");
            cmd = ReadLine();
            if (int.TryParse(cmd, out int eVal))
            {
                WriteLine(deque.Remove(eVal) == 0 ? "ok" : "error");
                break;
            }

            WriteLine("incorrect value");
            break;
        case "remove first":
            WriteLine(deque.RemoveFirst() == 0 ? "ok" : "error");
            break;
        case "remove last":
            WriteLine(deque.RemoveLast() == 0 ? "ok" : "error");
            break;
        case "print":
            deque.Print();
            break;
        case "size":
            WriteLine(deque.Size());
            break;
        default:
            WriteLine("unsupported command");
            break;
    }

    Write("->");
    cmd = ReadLine();
}


public class DoublyNode<T>
{
    public DoublyNode(T data, DoublyNode<T> prev = null, DoublyNode<T> next = null)
    {
        Data = data;
        Previous = prev;
        Next = next;
    }

    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}

public class Deque<T>
{
    private DoublyNode<T> firstEl;
    private DoublyNode<T> lastEl;
    private int size;

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    public Deque()
    {
        firstEl = null;
        lastEl = null;
        size = 0;
    }


    public void AddFirst(T elem)
    {
        // если двусвязный список пуст
        if (size == 0)
        {
            firstEl = new DoublyNode<T>(elem);
            lastEl = firstEl;
            size++;
            return;
        }

        DoublyNode<T> tmpDN = new DoublyNode<T>(data: elem, next: firstEl);
        firstEl.Previous = tmpDN;
        firstEl = tmpDN;
        size++;
    }

    public void AddLast(T elem)
    {
        // если двусвязный список пуст
        if (size == 0)
        {
            firstEl = new DoublyNode<T>(elem);
            lastEl = firstEl;
            size++;
            return;
        }

        DoublyNode<T> tmpDN = new DoublyNode<T>(data: elem, prev: lastEl);
        lastEl.Next = tmpDN;
        lastEl = tmpDN;
        size++;
    }
    public int RemoveFirst()
    {
        if (size == 0)
        {
            return -1;
        }

        if (size == 1)
        {
            firstEl = lastEl = null;
            size--;
            return 0;
        }

        firstEl = firstEl.Next;
        firstEl.Previous = null;
        size--;

        return 0;
    }

    public int RemoveLast()
    {
        if (size == 0)
        {
            return -1;
        }

        if (size == 1)
        {
            firstEl = lastEl = null;
            size--;
            return 0;
        }

        lastEl = lastEl.Previous;
        lastEl.Next = null;
        size--;

        return 0;
    }

    public int[] Search(T elem)
    {
        // если в двусвязном списке нет элементов
        if (size == 0)
        {
            return null;
        }

        string indStr = "";
        DoublyNode<T> curEl = firstEl;
        DoublyNode<T> searchEl = new(elem);

        // если искомый элемент указывает на null
        if (searchEl.Data == null)
        {
            return null;
        }

        for (int i = 0; i < size; i++)
        {
            if (curEl.Data != null && searchEl.Data.Equals(curEl.Data))
            {
                indStr += (indStr == "" ? "" : " ") + i;
            }

            curEl = curEl.Next;
        }

        int[] indArr = indStr.Split().Select(s => int.Parse(s)).ToArray();
        return indArr;
    }

    public int Size()
    {
        return size;
    }

    public void Print()
    {
        if (size == 0)
        {
            WriteLine();
            return;
        }

        DoublyNode<T> curEl = firstEl;
        do
        {
            WriteLine(curEl.Data == null ? "" : curEl.Data.ToString());

            if (curEl.Next != null)
            {
                curEl = curEl.Next;
            }
            else
            {
                break;
            }
        } while (true);
    }

    public void PrintAt(int index)
    {
        // если индекс меньше нуля или если размер двусвязного списка не строго меньше индекса
        if (index < 0 || size <= index)
        {
            WriteLine();
            return;
        }

        DoublyNode<T> searchEl = firstEl;

        for (int i = 0; i < index; i++)
        {
            searchEl = searchEl.Next;
        }

        WriteLine(searchEl.Data == null ? "" : searchEl.Data.ToString());
    }

    public int RemoveAt(int index)
    {
        // если индекс меньше нуля или если размер двусвязного списка не строго меньше индекса
        if (index < 0 || size <= index)
        {
            return -1;
        }

        // если размер двусвязного списка равен единице
        if (size == 1)
        {
            firstEl = lastEl = null;
            size--;
            return 0;
        }

        // если индекс совпадает с началом двусвязного списка
        if (index == 0)
        {
            return RemoveFirst();
        }

        // если индекс совпадает с концом двусвязного списка
        if (index == size - 1)
        {
            return RemoveLast();
        }

        DoublyNode<T> searchEl = firstEl;

        // дойти до элемента с индексом index
        for (int i = 0; i < index; i++)
        {
            searchEl = searchEl.Next;
        }

        DoublyNode<T> prev = searchEl.Previous;
        DoublyNode<T> next = searchEl.Next;

        prev.Next = next;
        next.Previous = prev;
        size--;

        return 0;
    }

    public int Remove(T elem)
    {
        // если в двусвязном нет элементов
        if (size == 0)
        {
            return -1;
        }

        DoublyNode<T> curEl = firstEl;
        int index = 0;
        DoublyNode<T> prevEl = null, nextEl = null;
        int retVal = -1;

        // пока не пройдены все элементы двусвязного списка
        while (index < size)
        {
            // если найден элемент для удаления
            if (curEl.Data.Equals(elem))
            {
                // элемент находится в начале двусвязного списка
                if (index == 0)
                    RemoveFirst();
                // элемент находится в конце двусвязного списка
                else if (index == size - 1)
                {
                    RemoveLast();
                }
                // все остальные случаи
                else
                {
                    prevEl = curEl.Previous;
                    nextEl = curEl.Next;
                    prevEl.Next = nextEl;
                    nextEl.Previous = prevEl;
                    size--;
                }

                // отметить, что хотя бы один элемент был удалён
                retVal = 0;
                curEl = curEl.Next;
                continue;
            }

            // индекс инкрементируется только в том случае, если элемент не был удалён
            curEl = curEl.Next;
            index++;
        }

        return retVal;
    }
}