using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТЗ_ООП
{
    public class Menu
    {
        public string Print = MenuText();

       
        private static string MenuText() //Начальное меню файлового менеджера
        {
           string text = "> Список доступных команд :\n  ls dir - Пейджинг" +
                " Папок  \n  rm dir - Удаление папки (папка должна быть пустая)\n  cp dir Создание Папки \n  ls - Пейджинг \n  cp - Копирование файлов \n  rm - Удаление Файлов" +
                "\n  back - Вернуться в это меню из других комманд";

           return text;
        }

    }
}
