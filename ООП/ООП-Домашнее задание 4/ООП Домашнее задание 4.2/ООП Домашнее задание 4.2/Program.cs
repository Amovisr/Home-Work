using ООП_Домашнее_задание_4._2.Building;
using ООП_Домашнее_задание_4._2.BuildingFactory;
class Program
{
    static void Main()
    {
        string building = Console.ReadLine();

        BuildingFactory factory = GetFactory(building);

        IDev membership = factory.GetBuilding();

        Console.WriteLine("\n> Building you've just created: \n");

        Console.WriteLine(
            $"\tBuilding Number:\t\t{membership.BuildingNumber}\n" +
            $"\tBuilding Height:\t{membership.Height}\n" +
            $"\tBuilding Floors:\t{membership.Floor}\n");


        Console.ReadLine();
    }

    private static BuildingFactory GetFactory(string membershipType) =>
     membershipType.ToLower() switch
     {
         "g" => new CreateBuilding(6, 7, 1),
         _ => null
     };
}


//    Console.WriteLine($"  Дом номер:{building2.buildingNumber} \n  Высота Здания: {building2.Height} метров " +
//        $"\n  Количество этажей: {building2.floors} \n  Количество квартир на подъезд:{building2.apartments}  \n  Количество квартир на этаж {building2.flat}");
