/*
 * 1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель. Предусмотреть конструктор. 
 * Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. Переопределить метод ToString() для вывода дроби. 
 * Определить операторы преобразования типов между типом дробь,float, int. Определить операторы *, /, %
 */

var r1 = new RationalNumber(1, 2);
var r2 = new RationalNumber(2, 3);
var r3 = r1 + r2;
var r4 = r2 - r3;
var r5 = r3 * r4;
var r6 = r4 > r5;
var r7 = r1 != r2;
var r8 = r2 == r3;
Console.WriteLine($"Сложение:{r3} Вычитание:{r4} Умножение:{r5} Сравнение:{r6} {r7} {r8}");
class RationalNumber
{
    private int _simbol;
    private int _numerator;
    private int _denominator;
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("В знаменателе не может быть нуля");
        }

        _numerator = numerator;
        _denominator = denominator;
        if (numerator * denominator < 0)
        {
            this._simbol = -1;
        }
        else
        {
            this._simbol = 1;
        }
    }


    private static int getGreatestCommonDivisor(int a, int b)//НОД - Наибольший делитель
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    private static int getLeastCommonMultiple(int a, int b)// наименьшее общее кратное
    {
        return a * b / getGreatestCommonDivisor(a, b);
    }
    private static RationalNumber Operations(RationalNumber a, RationalNumber b, Func<int, int, int> operation)
    {
        // Наименьшее общее кратное знаменателей
        int leastCommonMultiple = getLeastCommonMultiple(a._denominator, b._denominator);
        // Дополнительный множитель к первой дроби
        int additionalMultiplierFirst = leastCommonMultiple / a._denominator;
        // Дополнительный множитель ко второй дроби
        int additionalMultiplierSecond = leastCommonMultiple / b._denominator;

        int operationResult = operation(a._numerator * additionalMultiplierFirst * a._simbol,
b._numerator * additionalMultiplierSecond * b._simbol);

        return new RationalNumber(operationResult, a._denominator * additionalMultiplierFirst);
    }
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        return Operations(a, b, (int x, int y) => x + y);
    }
    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        return Operations(a, b, (int x, int y) => x - y);
    }
    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        return Operations(a, b, (int x, int y) => x * y);
    }
    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        return a * b.GetReverse();
    }
    private RationalNumber GetReverse()
    {
        return new RationalNumber(this._denominator * this._simbol, this._numerator);
    }
    public bool Equals(RationalNumber that)
    {
        RationalNumber a = this.Reduce();
        RationalNumber b = that.Reduce();
        return a._numerator == b._numerator &&
        a._denominator == b._denominator &&
        a._simbol == b._simbol;
    }
    // Переопределение метода Equals
    public override bool Equals(object obj)
    {
        bool result = false;
        if (obj is RationalNumber)
        {
            result = this.Equals(obj as RationalNumber);
        }
        return result;
    }
    // Переопределение метода GetHashCode
    public override int GetHashCode()
    {
        return this._simbol * (this._numerator * this._numerator + this._denominator * this._denominator);
    }
    //Перегрузка оператора "Равенство" для двух дробей
    public static bool operator ==(RationalNumber a, RationalNumber b)
    {

        Object aAsObj = a as Object;
        Object bAsObj = b as Object;
        if (aAsObj == null || bAsObj == null)
        {
            return aAsObj == bAsObj;
        }
        return a.Equals(b);
    }

    // Перегрузка оператора "Неравенство" для двух дробей
    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public RationalNumber Reduce()
    {
        RationalNumber result = this;
        int greatestCommonDivisor = getGreatestCommonDivisor(this._numerator, this._denominator);
        result._numerator /= greatestCommonDivisor;
        result._denominator /= greatestCommonDivisor;
        return result;
    }

    private int CompareTo(RationalNumber that)
    {
        if (this.Equals(that))
        {
            return 0;
        }
        RationalNumber a = this.Reduce();
        RationalNumber b = that.Reduce();
        if (a._numerator * a._simbol * b._denominator > b._numerator * b._simbol * a._denominator)
        {
            return 1;
        }
        return -1;
    }
    // Перегрузка оператора ">" для двух дробей
    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.CompareTo(b) > 0;
    }

// Перегрузка оператора "<" для двух дробей
     public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.CompareTo(b) < 0;
    }
    // Перегрузка оператора ">=" для двух дробей
    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a.CompareTo(b) >= 0;
    }
    // Перегрузка оператора "<=" для двух дробей
    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a.CompareTo(b) <= 0;
    }
    public override string ToString()
    {
        if (this._numerator == 0)
        {
            return "0";
        }
        string result;
        if (this._simbol < 0)
        {
            result = "-";
        }
        else
        {
            result = "";
        }
        if (this._numerator == this._denominator)
        {
            return result + "1";
        }
        if (this._denominator == 1)
        {
            return result + this._numerator;
        }
        return result + this._numerator + "/" + this._denominator;
    }







}
