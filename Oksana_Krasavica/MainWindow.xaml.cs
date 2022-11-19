using Oksana_Krasavica.Components;
using Oksana_Krasavica.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Oksana_Krasavica
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ToysList.ItemsSource = DbConnection.oksana.Toy.ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh() 
        {
            IEnumerable<Toy> filter = DbConnection.oksana.Toy;
            if (SortCB.SelectedIndex > 0)
            {
                if (SortCB.SelectedIndex == 1)
                {
                    filter =filter.OrderBy(x => x.Cost);
                }
                else if (SortCB.SelectedIndex == 2)
                {
                    filter= filter.OrderByDescending(x => x.Cost);
                }
            }
            
            if (SearchTB.Text.Length > 0)
            {
                filter = filter.Where(x => x.Name.ToLower().StartsWith(SearchTB.Text.ToLower()) || x.Description.ToLower().StartsWith(SearchTB.Text.ToLower()));
            }

            ToysList.ItemsSource = filter.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AdminBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введит пароль", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            PasswordTB.Visibility = Visibility.Visible;
            ChekBTN.Visibility = Visibility.Visible;
        }
        private void ChekBTN_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTB.Text == "0000")
            {
                MessageBox.Show("Вы теперь админ");
                AddBTN.Visibility = Visibility.Visible;
                EditBTN.Visibility = Visibility.Visible;
                RoleTB.Text = "Админ";
            }
            else
            {
                MessageBox.Show("Вы ввели неправльный пароль");
            }
        }

        private void ClientBTN_Click(object sender, RoutedEventArgs e)
        {
            PasswordTB.Visibility = Visibility.Collapsed;
            ChekBTN.Visibility = Visibility.Collapsed;
            AddBTN.Visibility = Visibility.Collapsed;
            EditBTN.Visibility = Visibility.Collapsed;
            RoleTB.Text = "Клиент";
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            new AddEditPage(new Toy());
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            var selSection = (sender as Button).DataContext as Toy;
            new AddEditPage(selSection);
        }
    }
}
