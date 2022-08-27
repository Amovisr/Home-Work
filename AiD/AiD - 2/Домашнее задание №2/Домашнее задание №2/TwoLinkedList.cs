using ElementNode;
using System.Collections;

namespace Домашнее_задание__2;

public class TwoLinkedList : IEnumerable, ILinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }
    public int Count { get; set; }

    public TwoLinkedList() { }

    public TwoLinkedList(int data)
    {

        var item = new Node(data);
        Head = item;
        Tail = item;
        Count = 1;
    }


    public void AddNode(int data)//Добавление узла
    {
        var item = new Node(data);
        if (Count == 0)
        {
            Head = item;
            Tail = item;
            Count = 1;
        }

        Tail.NextNode = item;
        item.PrevNode = Tail;
        Tail = item;
        Count++;
    }
    public Node FindNode(int searchValue)// ищет элемент по его значению
    {
        var findNode = Head;
        while (findNode.Data != null)
        {
            if (findNode.Data.Equals(searchValue))
            {
                return findNode;
            }
            findNode = findNode.NextNode;
        }

        return findNode;
    }

    public void RemoveNode(int data)//Удаление узла 
    {
        var current = Head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                current.PrevNode.NextNode = current.NextNode;
                current.NextNode.PrevNode = current.PrevNode;
                Count--;
                return;
            }

            current = current.NextNode;

        }
    }
    public void GetCount()// Показывает количество узлов
    {
        Console.WriteLine($"Количество Нодов : {Count - 1}");
    }
    public void AddNodeAfter(Node node, int data) // Добавление узла после определенного нода 
    {
        Node newNode = new Node(data);

        if (node.NextNode != null)
        {
            Node tempNode = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = tempNode;
            tempNode.PrevNode = newNode;
            newNode.PrevNode = node;
            Count++;
            return;
        }

        node = node.NextNode;



    }
    public void RemoveNode(Node node)// удаляет указанный элемент
    {

                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
                Count--;
                return;

    }


    public IEnumerator GetEnumerator() //Счет узлов и для последующего вывода через foreach
    {
        var current = Head;
        while (current != null)
        {
            yield return current;
            current = current.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}
public interface ILinkedList
{
    void GetCount(); // возвращает количество элементов в списке
    void AddNode(int value); // добавляет новый элемент списка
    void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
    void RemoveNode(int index); // удаляет элемент по порядковому номеру
    void RemoveNode(Node node); // удаляет указанный элемент
    Node FindNode(int searchValue); // ищет элемент по его значению
}
