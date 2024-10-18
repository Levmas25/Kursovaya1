using Kursovaya1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovaya1
{
    class Utils
    {
        public static DatabaseContext db = new DatabaseContext();

        public static void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static MessageBoxResult DeleteMessageBox(string message)
        {
            return MessageBox.Show(message, "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
