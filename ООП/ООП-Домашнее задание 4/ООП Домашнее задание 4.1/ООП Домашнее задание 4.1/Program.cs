Building building = new Building();
{
    building.buildingNumber = building.GetIndividualNumber();
    building.floors = 8;
    building.flat = 4;
    Console.WriteLine($"  Дом номер:{building.buildingNumber} \n  Высота Здания: {building.Height} метров " +
        $"\n  Количество этажей: {building.floors} \n  Количество квартир на подъезд:{building.apartments}  \n  Количество квартир на этаж {building.flat}");
}
Building building2 = new Building();
{
    building2.buildingNumber = building2.GetIndividualNumber();
    building2.floors = 7;
    building2.flat = 3;
    Console.WriteLine($"  Дом номер:{building2.buildingNumber} \n  Высота Здания: {building2.Height} метров " +
        $"\n  Количество этажей: {building2.floors} \n  Количество квартир на подъезд:{building2.apartments}  \n  Количество квартир на этаж {building2.flat}");
}

class Building
{
  public int buildingNumber
    {
        get { return GetIndividualNumber(); }
        set { id = value; }
    }
    public static int id = 1;
    public int GetIndividualNumber()
    {

        return id++;
    }
    public int floors { get; set; }

    public int flat { get; set; }
    public int apartments
    {
        get { return ApartamentsCalculate(); }
        set { ApartamentsCalculate(); }
    }

    public int ApartamentsCalculate()
    {
        
        int apartments = floors * flat;
        return apartments;
    }
    public int entrances { get; set; }

    public int Height
    {
        get { return HeightCalculate(); }
        set { HeightCalculate(); }

    }
    public int HeightCalculate()
    {
        int height = floors * 3;

        return height; 
    }

}