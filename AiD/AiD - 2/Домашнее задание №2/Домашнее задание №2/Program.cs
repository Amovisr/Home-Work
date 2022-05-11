using Домашнее_задание__2;

var twoLinkList = new TwoLinkedList();

twoLinkList.AddNode(2);
twoLinkList.AddNode(3);
twoLinkList.AddNode(4);
twoLinkList.AddNode(10);
twoLinkList.AddNodeAfter(twoLinkList.FindNode(10), 500);
twoLinkList.RemoveNode(twoLinkList.FindNode(10));
twoLinkList.RemoveNode(500);

twoLinkList.GetCount();
foreach (var node in twoLinkList)
{
    Console.WriteLine(node);
}
