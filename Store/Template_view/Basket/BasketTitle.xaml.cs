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
    /// Interaction logic for BasketTitle.xaml
    /// </summary>
    public partial class BasketTitle : UserControl
    {
        public string ID { get; set; }
        public DateTime DateTime { get; set; }
        public BasketTitle()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        //TODO Заполнение заголовка формы
    }
}
