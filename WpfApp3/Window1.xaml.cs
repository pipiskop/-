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
    public partial class Window1 : Window
    {

        authorTableAdapter aut = new authorTableAdapter();
        public Window1()
        {

            InitializeComponent();
            author.ItemsSource = aut.GetData();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void author_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NameGive_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                aut.InsertQuery(Convert.ToInt32(ID_AUT.Text), nameis.Text, SURN.Text);
                author.ItemsSource = aut.GetData();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
                if (author.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали сторку!");
                    return;
                }
                else
                {
                    object id = (author.SelectedItem as DataRowView).Row[0];
                    aut.DeleteQuery(Convert.ToInt32(id));
                    author.ItemsSource = aut.GetData();

                }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
