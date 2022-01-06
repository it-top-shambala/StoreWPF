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

namespace Store.Template_view.Basket
{
    /// <summary>
    /// Interaction logic for BasketFooter.xaml
    /// </summary>
    public partial class BasketFooter : UserControl
    {
        public BasketFooter()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //TODO Обработчик кнопок
    }
}
