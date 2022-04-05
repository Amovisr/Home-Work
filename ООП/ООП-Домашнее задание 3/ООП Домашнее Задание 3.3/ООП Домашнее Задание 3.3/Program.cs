/* Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес.
 * Разделителем между ФИО и адресом электронной почты является 
 * символ &: Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru
 * Сформировать новый файл, содержащий список адресов электронной почты.
 * Предусмотреть метод, выделяющий из строки адрес почты. Методу в качестве параметра передается символьная строка s
 * , e-mail возвращается в той же строке s: public void SearchMail (ref string s).
*/

char[] delimiterChars = { ' ', ',', ':', '\t' ,'&'};

string namesAndMails = "Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru";

string[] splitedWords = namesAndMails.Split(delimiterChars);

foreach (string words in splitedWords)
{
    if (words.Contains('@'))
    {
        string foundedMails = words;

        File.AppendAllText("mails.txt", $"{foundedMails} ");

        
    }

}
