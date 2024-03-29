﻿namespace Домашнее_задание__6
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();
        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;
        public void VertexAdd(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }
        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];
            foreach (var edge in Edges)
            {
                var row = edge.From.Number - 1;
                var col = edge.To.Number - 1;
                matrix[row, col] = edge.Weight;
            }

            return matrix;
        }
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();
            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }
        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>();

            list.Add(start);

            for (var i = 0; i < list.Count; i++)
            {
                var vertex = list[i];

                foreach (var v in GetVertexList(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }

            }

            return list.Contains(finish);
        }

    }
}
