using Домашнее_задание__6;

var graph = new Graph();
var v1 = new Vertex(1);
var v2 = new Vertex(2);
var v3 = new Vertex(3);
var v4 = new Vertex(4);
var v5 = new Vertex(5);
var v6 = new Vertex(6);
var v7 = new Vertex(7);

graph.VertexAdd(v1);
graph.VertexAdd(v2);
graph.VertexAdd(v3);
graph.VertexAdd(v4);
graph.VertexAdd(v5);
graph.VertexAdd(v6);
graph.VertexAdd(v7);

graph.AddEdge(v1, v2);
graph.AddEdge(v1, v3);
graph.AddEdge(v3, v4);
graph.AddEdge(v2, v5);
graph.AddEdge(v2, v6);

GetMatr(graph);


Console.WriteLine();
Console.WriteLine();

GetVertex(graph, v1);
GetVertex(graph, v2);
GetVertex(graph, v3);
GetVertex(graph, v4);

Console.WriteLine(graph.Wave(v1, v5));
Console.WriteLine(graph.Wave(v4, v2));

static void GetVertex(Graph graph, Vertex vertex)
{
    Console.Write(vertex.Number + ":");

    foreach (var v in graph.GetVertexList(vertex))
    {
        Console.Write($"{v.Number}, ");
    }
}


static void GetMatr(Graph graph)
{
    var matrix = graph.GetMatrix();

    for (int i = 0; i < graph.VertexCount; i++)
    {
        Console.Write(i + 1);
        for (int j = 0; j < graph.VertexCount; j++)
        {
            Console.Write($" | {matrix[i, j]} |");
        }
        Console.WriteLine();

    }
    Console.WriteLine("___________________________________");

    for (int i = 0; i < graph.VertexCount; i++)
    {
        Console.Write($"|   {i + 1}|");
    }
}
