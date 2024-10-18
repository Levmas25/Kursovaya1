using Kursovaya1.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya1
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        bool edit = false;
        Test test;
        public CreatePage(Test test = null)
        {
            InitializeComponent();
            if (test != null)
            {
                edit = true;
                this.test = test;
            }
            else
            {
                fullName.Text = string.Empty;
                date.SelectedDate = DateTime.Now;
                this.test = new Test();
            }
            main.DataContext = this.test;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (group.Text == string.Empty || discipline.Text == string.Empty || !date.SelectedDate.HasValue || mark.Text == string.Empty
                || fullName.Text == string.Empty)
            {
                Utils.Error("еблан до конца все заполни");
                return;
            }
            if (!Int32.TryParse(mark.Text, out int value)) {
                Utils.Error("конченный,оценка это число");
                return;
            }
            if (Int32.Parse(mark.Text) < 2 || Int32.Parse(mark.Text) > 5)
            {
                Utils.Error("Еблан такой нет оценки");
                return;
            }
            Regex nameRegex = new Regex(@"^[А-Яа-я]+\s[А-Яа-я]+(\s[А-Яа-я]+)?$");
            Regex groupRegex = new Regex(@"^[А-Яа-я0-9-]+$");
            Regex disciplineRegex = new Regex(@"^[а-яА-Я\s]+$");
            if (!nameRegex.IsMatch(fullName.Text) || !groupRegex.IsMatch(group.Text) || !disciplineRegex.IsMatch(discipline.Text))
            {
                Utils.Error("Неверный формат данных");
                return;
            }
            if (!edit)
            {
                List<string> FullName = fullName.Text.ToString().Split().ToList();
                if (FullName.Count < 2)
                {
                    Utils.Error("Введите имя и фамилию студента");
                    return;
                }
                test.FirstName = FullName[1];
                test.SecondName = FullName[0];
                test.LastName = FullName.ElementAtOrDefault(2);
                test.Date = DateOnly.FromDateTime(date.SelectedDate.Value);
                Utils.db.Tests.Add(test);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void fullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                saveBtn_Click(sender, e);
            }
        }
    }
}
