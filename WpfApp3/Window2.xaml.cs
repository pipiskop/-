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
using System.Windows.Shapes;
using WpfApp3.ichiDataSetTableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        genreTableAdapter gen = new genreTableAdapter();
        public Window2()
        {

            InitializeComponent();
            genre.ItemsSource = gen.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void NameGive_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                gen.InsertQuery(Convert.ToInt32(ID_GENRE.Text), GENRE.Text);
                genre.ItemsSource = gen.GetData();
            }
            catch {
                MessageBox.Show("Вы ввели не число");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (genre.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали сторку!");
                return;
            }
            else {
                object id = (genre.SelectedItem as DataRowView).Row[0];
                gen.DeleteQuery(Convert.ToInt32(id));
                genre.ItemsSource = gen.GetData();
            }
        }
    }
}
