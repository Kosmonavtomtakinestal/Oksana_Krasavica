using Oksana_Krasavica.Components;
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
using System.Windows.Shapes;

namespace Oksana_Krasavica.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        Toy toy;
        public AddEditPage(Toy _toy)
        {
            InitializeComponent();
            toy = _toy;
            DataContext = toy;
        }
    }
}
