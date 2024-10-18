using Kursovaya1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<Test> test = Utils.db.Tests.ToList();
            TestGrid.ItemsSource = test;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
            TestGrid.SelectedIndex = 0;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            searchClear();
            Test selected = TestGrid.SelectedItem as Test;
            if (selected == null)
            {
                Utils.Error("Выберите запись");
                return;
            }
            if (Utils.DeleteMessageBox("Вы точно хотите удалить эту запись") == MessageBoxResult.Yes)
            {
                Utils.db.Tests.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            searchClear();
            Test selected = TestGrid.SelectedItem as Test;
            if (selected == null)
            {
                Utils.Error("Выберите запись");
                return;
            }
            NavigationService.Navigate(new CreatePage(selected));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            searchClear();
            NavigationService.Navigate(new CreatePage());
        }

        private void searchClear()
        {
            fullNameSearchBox.Text = string.Empty;
            groupSearchBox.Text = string.Empty;
            fromDateSearchBox.SelectedDate = null;
            toDateSearchBox.SelectedDate = null;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> searchFullName = fullNameSearchBox.Text.Split().ToList();
            string searchFirstName = searchFullName[0];
            string searchSecondName = searchFullName.ElementAtOrDefault(1);
            string searchLastName = searchFullName.ElementAtOrDefault(2);
            DateOnly dateFrom = DateOnly.FromDateTime(fromDateSearchBox.SelectedDate ?? DateTime.MinValue);
            DateOnly dateTo = DateOnly.FromDateTime(toDateSearchBox.SelectedDate ?? DateTime.MaxValue);
            List<Test> test = Utils.db.Tests.Where(t => (t.FirstName.Contains(searchFirstName) 
            || t.SecondName.Contains(searchSecondName ?? searchFirstName) 
            || t.LastName.Contains(searchLastName ?? searchFirstName)) && t.Group.Contains(groupSearchBox.Text) 
            && t.Date > dateFrom && t.Date < dateTo).ToList();
            TestGrid.ItemsSource = test;
        }

        private void vedomostBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VedomostPage());
        }
    }
}
