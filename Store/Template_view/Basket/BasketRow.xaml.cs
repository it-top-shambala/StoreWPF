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
    /// Interaction logic for Basket.xaml
    /// </summary>
    /// 

    public partial class BasketRow : UserControl
    {
        public string ProductName { get; set; } // Наименование
        public string ProductArtNumber { get; set; } // ID
        public string ProductImage { get; set; } // Image source
        public string ProductAvailable { get; set; } // Доступно продуктов
        public string ProductPrice { get; set; } // стоимость
        public string ProductCounter { get; set; } // Количество продукта к покупке
        public string ProductAnnotation { get; set; } // Описание продуктов
        
        public BasketRow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        //TODO Обработчики нажатия кнопок строки
    }
}
