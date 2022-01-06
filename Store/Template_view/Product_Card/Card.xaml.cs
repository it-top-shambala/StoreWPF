using DataModelLib;
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

namespace Store.Template_view.Product_Card
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    /// 
    public partial class Card : UserControl
    {
        public string ProductName { get; set; } // Наименование
        public string ProductArtNumber { get; set; } // ID
        public string ProductImage { get; set; } // Image source
        public string ProductAvailable { get; set; } // Доступно продуктов
        public string ProductPrice { get; set; } // стоимость
        public string ProductCounter { get; set; } // Количество продуктов
        public string ProductAnnotation { get; set; } // Описание продуктов

        public Card()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public Card(Product product)
        {
            InitializeComponent();
            this.ProductName = product.Name;
            this.ProductArtNumber = product.Id.ToString();
            //this.ProductImage = product.Image;
            this.ProductAvailable = product.Amount.ToString();
            this.ProductPrice = product.Price.ToString();
            this.ProductAnnotation = product.Annotation;
            this.ProductCounter = "0";
            this.DataContext = this;
        }

        private void Button_ProductCountKey_Reduce_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(TextBox_ProductCounter.Text) > 0)
            {
                TextBox_ProductCounter.Text = (Convert.ToInt32(TextBox_ProductCounter.Text) - 1).ToString();
            }
        }

        private void Button_ProductCountKey_Increase_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ProductCounter.Text = (Convert.ToInt32(TextBox_ProductCounter.Text) + 1).ToString();
        }

        private void TextBox_ProductCounter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Button_ProductCountKey_Cancel_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ProductCounter.Text = "0";
        }
    }
}
