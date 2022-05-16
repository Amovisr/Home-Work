using ООП_Домашнее_задание_4._2.Building;

namespace ООП_Домашнее_задание_4._2.BuildingFactory
{
    internal class CreateBuilding : BuildingFactory
    {
        private int _buildingNumber;
        private readonly int _height;
        private readonly int _floors;
        private readonly int _flat;
        private readonly int _entrances;
        private readonly int _apartaments;

        public CreateBuilding(int floors, int flat, int entrances)
        {
            _floors = floors;
            _flat = flat;
            _entrances = entrances;
        }
        public override IDev GetBuilding()
        {
            BuildingCreated building = new BuildingCreated()
            {
                
            };
            return building;
        }

    }
}
