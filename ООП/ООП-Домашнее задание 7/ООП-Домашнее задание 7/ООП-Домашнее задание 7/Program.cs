using ООП_Домашнее_задание_7;
/*
Определить интерфейс IСoder, который полагает методы поддержки шифрования
строк. В интерфейсе объявляются два метода Encode() и Decode(),
используемые для шифрования и дешифрования строк. Создать класс ACoder,
реализующий интерфейс ICoder. Класс шифрует строку посредством сдвига
каждого символа на одну «алфавитную» позицию выше. (В результате такого
сдвига буква А становится буквой Б). Создать класс BCoder, реализующий
интерфейс ICoder. Класс шифрует строку, выполняя замену каждой буквы,
стоящей в алфавите на i-й позиции, на букву того же регистра, расположенную в
алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на
букву Э. Написать программу, демонстрирующую функционирование классов).
*/
var text = Console.ReadLine();

var ACoder = new ACoder(text);

Console.WriteLine($"{nameof(text)} =  {text}");
Console.WriteLine($"ACoder.Encode= {ACoder.Encode()}");
Console.WriteLine($"ACoder.Decode= {ACoder.Decode()}");
var BCoder = new BCoder(text);

Console.WriteLine($"{nameof(text)} =  {text}");
Console.WriteLine($"BCoder.Encode= {BCoder.Encode()}");
Console.WriteLine($"BCoder.Decode= {BCoder.Decode()}");

Console.ReadKey();
public class ACoder : ICoder
{
    private readonly char[] _inputCharArray;

    public ACoder(string inputString)
    {
        _inputCharArray = inputString.ToCharArray();
    }

    public string Decode()
    {
        for (int i = 0; i < _inputCharArray.Length; i++)
        {
            _inputCharArray[i] = (char)(_inputCharArray[i] - 1);
        }

        return string.Concat(_inputCharArray);
    }

    public string Encode()
    {
        for (int i = 0; i < _inputCharArray.Length; i++)
        {
            _inputCharArray[i] = (char)(_inputCharArray[i] + 1);
        }

        return string.Concat(_inputCharArray);
    }

}
public class BCoder : ICoder
{
    private readonly Dictionary<char, Tuple<int, int>> _letters = new Dictionary<char, Tuple<int, int>>();//  символ, начальный диапазон, конечный 

    private readonly char[] _inputCharArray;

    private const int _rAlphabetLength = 32;
    private const int _eAlphabetLength = 26;

    public BCoder(string inputString)
    {
        _inputCharArray = inputString.ToCharArray();

        for (int i = 0; i < _rAlphabetLength; i++)
        {
            _letters.Add((char)(1072 + i), new Tuple<int, int>(1072, 1072 + _rAlphabetLength - 1));
            _letters.Add((char)(1040 + i), new Tuple<int, int>(1040, 1040 + _rAlphabetLength - 1));

            if (i < _eAlphabetLength)
            {
                _letters.Add((char)(97 + i), new Tuple<int, int>(97, 97 + _eAlphabetLength - 1));
                _letters.Add((char)(65 + i), new Tuple<int, int>(65, 65 + _eAlphabetLength - 1));
            }
        }
    }

    public string Encode()
    {
        for (int i = 0; i < _inputCharArray.Length; i++)
        {
            if (_letters.ContainsKey(_inputCharArray[i]))
            {
                var el = _letters[_inputCharArray[i]];
                _inputCharArray[i] = (char)(el.Item2 - (_inputCharArray[i] - el.Item1));
            }
            else
            {
                _inputCharArray[i] = _inputCharArray[i];
            }
        }
        return string.Concat(_inputCharArray);
    }
    public string Decode()
    {

        for (int i = 0; i < _inputCharArray.Length; i++)
        {
            if (_letters.ContainsKey(_inputCharArray[i]))
            {
                var el = _letters[_inputCharArray[i]];
                _inputCharArray[i] = (char)(el.Item2 - (_inputCharArray[i] - el.Item1));
            }
            else
            {
                _inputCharArray[i] = _inputCharArray[i];
            }

        }
        return string.Concat(_inputCharArray);
    }
}