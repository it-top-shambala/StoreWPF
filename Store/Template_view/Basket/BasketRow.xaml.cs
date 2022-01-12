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
        public DataModelLib.OrderRow OrderRow { get; set; }

        //public string RowNumber { get; set; } //  номер строки
        //public string ProductName { get; set; } // Наименование
        //public string ProductArtNumber { get; set; } // ID
        //public string ProductImage { get; set; } // Image source
        //public string ProductAvailable { get; set; } // Доступно продуктов
        //public string ProductPrice { get; set; } // стоимость
        //public string ProductCounter { get; set; } // Количество продукта к покупке
        //public string ProductAnnotation { get; set; } // Описание продуктов
        
        public BasketRow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void InitRow()
        {
            Label_RowNumber.Content = OrderRow.RowNumber.ToString();
            Label_ProductName.Content = OrderRow.Product.Name;
            Label_ProductCounter.Content = OrderRow.Product.Amount;

            TextBox_RowAmount.Text = OrderRow.RowAmount.ToString();

            Label_ProductPrice.Content = OrderRow.Product.Price;
            Label_RowCost.Content = OrderRow.GetRowCost().ToString();
        }
        //TODO Обработчики нажатия кнопок строки
    }
}
