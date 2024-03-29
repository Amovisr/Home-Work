﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Определить интерфейс IСoder, который полагает методы поддержки шифрования
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
namespace ООП_Домашнее_задание_7
{
    public interface ICoder
    {
        public string Encode();
        public string Decode();


    }
}
