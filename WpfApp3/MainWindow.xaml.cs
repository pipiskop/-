using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.ichiDataSetTableAdapters;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        knigiTableAdapter book = new knigiTableAdapter();
        public MainWindow()

        {
            InitializeComponent();
            knigi.ItemsSource = book.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                book.InsertQuery(Convert.ToInt32(ID_BOOk.Text), BookName.Text, Convert.ToInt32(ID_AUT.Text), Convert.ToInt32(ID_GENRE.Text));
                knigi.ItemsSource = book.GetData();
            }
            catch
            {
                MessageBox.Show("Вы ввели не число");
            }
        }

        private void BookName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ID_BOOk_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            if (knigi.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали сторку!");
                return;
            }
            else
            {
                object id = (knigi.SelectedItem as DataRowView).Row[0];
                book.DeleteQuery(Convert.ToInt32(id));
                knigi.ItemsSource = book.GetData();

            }
        }
    }
}
