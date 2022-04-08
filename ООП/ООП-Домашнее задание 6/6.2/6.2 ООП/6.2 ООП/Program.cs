
/** Создать класс Figure для работы с геометрическими фигурами.
* В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
* Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый). 
* Метод вывода на экран должен выводить состояние всех полей объекта.
* Создать класс Point (точка) как потомок геометрической фигуры. Создать класс Circle (окружность) как потомок точки. 
* В класс Circle добавить метод, который вычисляет площадь окружности. 
* Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника. 
* Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
* 
* 
*/
PrintMenu();
static void PrintMenu()
{
    Console.WriteLine("Меню: Приветсвую вы начнете с прямоугонльника чтобы поменять фигуру напишите exit");
    Console.WriteLine("Cмена 'Цвета' : Red , Green , Blue ");
    Console.WriteLine("Сделать фигуру видимым и не видимым : Visiable/Invisiable");
    Console.WriteLine("Передвижение фигуры по положительным X и Y 'right'/'up' ");
    Console.WriteLine("Передвижение фигуры по отрицательным X и Y 'left'/'down' ");
    Console.WriteLine("Напишите 'Menu' чтобы вызвать это меню");


}
Rectangle rectangle = new Rectangle()
{

};
Circle circle = new Circle()
{

};

abstract class Point : Figure
{

}
class Circle : Point
{

    public Circle()
    {
        Console.WriteLine("Теперь вы перешли к фигуре : Круг");
        Console.WriteLine("Введите радиус круга");
        double r = Convert.ToDouble(Console.ReadLine());
        double perimeter = 2 * Math.PI * r;
        double area = Math.PI * Math.Pow(r, 2); //area = 3.14 * r * r;
        Console.WriteLine($"Площадь круга = {area}");
        _ = FigureSettings();
    }
}
class Rectangle : Point
{
    private double _x1 = ReadDouble("\nВы в прямоугольникe! введите точки прямоуголинка по кардинатам X/Y \nВведите значение x: ");
    private double _y1 = ReadDouble("Введите значение y: ");
    private double _x2 = ReadDouble("Введите значение x: ");
    private double _y2 = ReadDouble("Введите значение y: ");

    public Rectangle()
    {
        double x1 = _x1;
        double y1 = _y1;
        double x2 = _x2;
        double y2 = _y2;
        double width = Math.Abs(x1 - x2);
        double height = Math.Abs(y1 - y2);
        double P = 2 * (width + height);
        double S = width * height;
        Console.WriteLine($"Площадь прямоугольника = {S}");
        Console.Write(">:");
        _ = FigureSettings();
    }
    static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }


}

class Figure
{
    public int x, y;
    public string figureColor { get; set; }
    public FigureStatus status { get; set; }
    public string FigureSettings()
    {
        string set = Console.ReadLine();
        if (set != null) { return "";}
            
        while (set != "exit")
        {
            Console.WriteLine($"Статус фигуры :\n Цвет:{figureColor}\n Видимость фигуры:{status}\n Место положение по x/y  X:[{x}] Y:[{y}]");
            Console.Write(">: ");
            switch (set)
            {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    figureColor = "Red";
                    Console.Clear();
                    Console.WriteLine($"Установлен Краснный цвет !");
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    figureColor = "Blue";
                    Console.Clear();
                    Console.WriteLine($"Установлен Синий цвет !");
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    figureColor = "Green";
                    Console.Clear();
                    Console.WriteLine($"Установлен Зеленый цвет !");
                    break;
                case "Visible":
                    status = FigureStatus.Visible;
                    Console.WriteLine("Фигура видима");
                    break;
                case "Invisible":
                    status = FigureStatus.Invisible;
                    Console.WriteLine("Фигура не видима");
                    break;
                    //case "Menu":
                    //    PrintMenu();
                    break;
                case "right":
                    x++;
                    break;
                case "left":
                    x--;
                    break;
                case "up":
                    y++;
                    break;
                case "down":
                    y--;
                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;


            }

        }
        return "BIBOBA";
    }
}
[Flags]

public enum FigureStatus
{
    Visible = 1,
    Invisible = 2,
}