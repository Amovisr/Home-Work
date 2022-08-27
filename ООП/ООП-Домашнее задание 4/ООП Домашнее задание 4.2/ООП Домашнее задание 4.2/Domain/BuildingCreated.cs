namespace ООП_Домашнее_задание_4._2.Building
{
    internal class BuildingCreated : IDev
    {

        private readonly int _buildingNumber;
        private readonly int _height;
        private readonly int _floors;
        private readonly int _flat;
        private readonly int _entrances;
        private readonly int _apartaments;
        public BuildingCreated()
        { 
            _buildingNumber = buildingNumber;
            _height = height;
            _floors = floors;
            _flat = flat;
            _entrances = entrances;
            _apartaments = apartaments;
        }
        private int buildingNumber
        {
            get { return GetIndividualNumber(); }
            set { id = value; }
        }
        private static int id = 1;
        private int GetIndividualNumber()
        {

            return id++;
        }
        private int floors { get; set; }

        private int flat { get; set; }
        private int apartaments
        {
            get { return ApartamentsCalculate(); }
            set { ApartamentsCalculate(); }
        }

        private int ApartamentsCalculate()
        {

            int apartments = floors * flat;
            return apartments;
        }
        private int entrances { get; set; }

        private int height
        {
            get => HeightCalculate();
            set => HeightCalculate();

        }
        private int HeightCalculate()
        {
            int heightCalc = floors * 3;

            return heightCalc;
        }
        
        public int BuildingNumber => _buildingNumber;
        public int Height => _height;
        public int Floor => _floors;
        public int Flat => _flat;
        public int Entrances => _entrances;
        public int Apartaments => _apartaments;




    }


}
