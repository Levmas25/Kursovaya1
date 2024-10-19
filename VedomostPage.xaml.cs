using Kursovaya1.Models;
using Microsoft.IdentityModel.Tokens;
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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;

namespace Kursovaya1
{
    /// <summary>
    /// Логика взаимодействия для VedomostPage.xaml
    /// </summary>
    public partial class VedomostPage : Page
    {
        public VedomostPage()
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            List<string> groups = Utils.db.Tests.Select(t => t.Group).Distinct().ToList();
            List<string> disciplines = Utils.db.Tests.Select(t => t.Discipline).Distinct().ToList();

            groupComboBox.ItemsSource = groups;
            disciplineComboBox.ItemsSource = disciplines;

            groupComboBox.SelectedIndex = 0;
            disciplineComboBox.SelectedIndex = 0;
            dateDatePicker.SelectedDate = DateTime.Now;
        }

        public void GetStudents(string group, DateOnly date, string discipline)
        {
            List<Test> students = Utils.db.Tests.Where(t => t.Group == group && t.Discipline == discipline && t.Date == date).ToList();

            if (students.IsNullOrEmpty())
            {
                Utils.Error("Не найдено студентов по выбранным данным.");
                return;
            }

            CreateVedomost(students);
        }

        public void CreateVedomost(List<Test> students)
        {
            string pdfPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Vedomost.pdf");

            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, fs);

                document.Open();

                string fontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf"); // Update this to a TTF file that supports Cyrillic
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font utf8Font = new Font(baseFont, 12);
                Font titleutf8Font = new Font(baseFont, 24);
                Font infoutf8Font = new Font(baseFont, 18);

                // Title
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph($"Ведомость", 
                    titleutf8Font);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new iTextSharp.text.Paragraph("\n")); // Add some space

                document.Add(new Phrase($"Дисциплина {disciplineComboBox.SelectedItem.ToString()}\n", infoutf8Font));
                document.Add(new Phrase($"Группа {groupComboBox.SelectedItem.ToString()}\n", infoutf8Font));
                document.Add(new Phrase($"Дата {DateOnly.FromDateTime(dateDatePicker.SelectedDate ?? DateTime.MinValue).ToString("d")}\n", infoutf8Font));

                // Create a table with 4 columns
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100; // Set the table width to 100%

                // Add table header
                table.AddCell(new Phrase("ФИО", utf8Font));
                table.AddCell(new Phrase("Оценка", utf8Font));
                table.AddCell(new Phrase("Подпись", utf8Font));

                // Add rows for each student
                foreach (var student in students)
                {
                    table.AddCell(new Phrase(student.FullName, utf8Font));
                    table.AddCell(new Phrase(student.Mark.ToString(), utf8Font));
                    table.AddCell(new Phrase(string.Empty));
                }

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();
            }
            System.Windows.Forms.MessageBox.Show($"PDF created successfully at: {pdfPath}");
        }

        private void createVedomost_Click(object sender, RoutedEventArgs e)
        {
            string group = groupComboBox.SelectedItem.ToString();
            string discipline = disciplineComboBox.SelectedItem.ToString();
            DateOnly date = DateOnly.FromDateTime(dateDatePicker.SelectedDate ??  DateTime.MinValue);

            if (string.IsNullOrEmpty(group) || string.IsNullOrEmpty(discipline) || date == DateOnly.MinValue)
            {
                Utils.Error("Выберите данные");
                return;
            }

            GetStudents(group, date, discipline);
            NavigationService.GoBack();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
