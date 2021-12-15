using System;
using System.Collections.Generic;
using System.Data;
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

namespace PRC9_V9
{
    //Заполнить таблицу с учебной литературой с полями: название, автор, издательство, кол-во страниц.Вывести результат на экран.Вывести список книг заданногоиздательства.
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Book[] _books = new Book[10];
        private int _enumerator; //счетчик

        private void AddBook_Click(object sender, RoutedEventArgs e) //добавление информации о книге
        {
            try
            {
                _books[_enumerator] = new Book($"{title.Text}", $"{author.Text}", $"{bookHouse.Text}", int.Parse(numberOfPages.Text));
                _enumerator++;
                dataGrid.ItemsSource = ToDataTable(_books).DefaultView;

            }
            catch (FormatException)
            {
                MessageBox.Show("Данные были введены некорректно!");
            }
        }

        private static DataTable ToDataTable(Book[] books) //таблица
        {
            var table = new DataTable();

            table.Columns.Add("Название", typeof(string));
            table.Columns.Add("Автор", typeof(string));
            table.Columns.Add("Издательство", typeof(string));
            table.Columns.Add("Кол-во страниц", typeof(int));

            for (int i = 0; i < books.Length; i++)
            {
                var row = table.NewRow();
                row.ItemArray = new object[] { books[i].Title, books[i].Author, books[i].BookHouse, books[i].NumberOfPages };
                table.Rows.Add(row);
            }
            return table;
        }

        private void FindBooks_Click(object sender, RoutedEventArgs e) //вывод информации о книге
        {
            for (int i = 0; i < _books.Length; i++)
            {
                if (_books[i].BookHouse == Publisher.Text)
                {
                    FoundedBooks.Items.Add(_books[i].Title);
                }
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Мишин Д.А. ИСП-34", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
