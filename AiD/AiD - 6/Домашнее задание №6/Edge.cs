namespace Домашнее_задание__6
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weght = 1)
        {
            From = from;
            To = to;
            Weight = weght;
        }

        public override string ToString()
        {
            return $"{From} {To}";
        }
    }
}
