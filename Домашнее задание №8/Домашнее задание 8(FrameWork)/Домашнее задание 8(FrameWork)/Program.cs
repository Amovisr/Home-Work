using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Домашнее_задание_8_FrameWork_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hailUser = Properties.Settings.Default.HailUser;

            Console.WriteLine($"{hailUser}") //Приветствие 
                ;
            if (string.IsNullOrEmpty(Properties.Settings.Default.FirstName))
            {
                Console.WriteLine("Введите ваше Имя: ");

                Properties.Settings.Default.FirstName = Convert.ToString(Console.ReadLine());/*Имя*/

                Console.WriteLine("Введите вашу Фамилияю: ");

                Properties.Settings.Default.LastName = Console.ReadLine();/*Фамилия*/

                Console.WriteLine("Введите ваш Возраст: ");

                Properties.Settings.Default.Age = Int32.Parse(Console.ReadLine());/*Возраст*/

                Console.WriteLine("Укажите ваш род деятельности: ");

                Properties.Settings.Default.Job = Console.ReadLine();/*Работа*/

                Properties.Settings.Default.Save();

            }
            else //Ввод уже записанных данных
            {
                string firstName = Properties.Settings.Default.FirstName;

                string lastName = Properties.Settings.Default.LastName;

                int userAge = Properties.Settings.Default.Age;

                string userJob = Properties.Settings.Default.Job;

                Console.WriteLine($"{firstName} {lastName}\nВозраст: {userAge}\nРод деятельности: {userJob}");
            }





            Console.ReadKey();

        }
    }
}
