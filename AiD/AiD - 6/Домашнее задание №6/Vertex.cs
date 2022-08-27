namespace Домашнее_задание__6
{
    class Vertex
    {
        public int Number { get; set; }
        public bool visited { get; set; }
        public Vertex(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }



    }
}
