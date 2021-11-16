using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Store
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<OrderLine> Order;
        public MainWindow()
        {
            InitializeComponent();
            InitGrid(2, 4);

            Order = new ObservableCollection<OrderLine>();

        }

        private void InitGrid(int amountRows, int amountColumns)
        {
            Body.HorizontalAlignment = HorizontalAlignment.Center;
            Body.VerticalAlignment = VerticalAlignment.Center;

            Body.RowDefinitions.Clear();
            Body.ColumnDefinitions.Clear();

            for (int i = 0; i < amountRows; i++)
            {
                Body.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            for (int j = 0; j < amountColumns; j++)
            {

                Body.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            for (int i = 0; i < amountRows; i++)
            {
                for (int j = 0; j < amountColumns; j++)
                {
                    var card = CreateCard($"Product {i},{j}");
                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);

                    Body.Children.Add(card);
                }
            }
        }

        private StackPanel CreateCard(string productName)
        {
            var cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@"C:\Users\Курицын Алексей\YandexDisk\Академия ШАГ\WPF_Windows Forms\WPF_App\StoreWPF\Store\img\product.jpg"));

            var card = new StackPanel();

            card.Orientation = Orientation.Vertical;

            card.Children.Add(cardImage);
            card.Children.Add(CreateCardAmount());
            card.Children.Add(CreateCardAnnotation(productName));

            return card;
        }

        private Label CreateCardAnnotation(string annotation)
        {
            var label = new Label
            {
                Content = annotation
            };

            return label;
        }

        private StackPanel CreateCardAmount()
        {
            var cardAmount = new StackPanel();
            cardAmount.Orientation = Orientation.Horizontal;

            cardAmount.Children.Add(CreateCardAmountButton("-"));
            cardAmount.Children.Add(CreateCardAmountLabel());
            cardAmount.Children.Add(CreateCardAmountButton("+"));

            return cardAmount;
        }

        private Button CreateCardAmountButton(string content)
        {
            var button = new Button
            {
                Content = content,

            };
            button.Click += Button_CardAmount_OnClick;

            return button;
        }

        private void Button_CardAmount_OnClick(object sender, RoutedEventArgs e)
        {
            var content = ((Button)sender).Content.ToString();

            var temp = ((Label)((StackPanel)((Button)sender).Parent).Children[1]).Content.ToString();

            var product = ((Label)((StackPanel)((StackPanel)(((Button)sender).Parent)).Parent).Children[2]).Content.ToString();

            var res = int.TryParse(temp, out var amount);

            if (!res)
            {
                StatusBar.Content = "Ошибка";
                return;
            }

            switch (content)
            {
                case "-":
                    --amount;
                    ReduceFromOrder(product);
                    break;
                case "+":
                    ++amount;
                    AddToOrder(product);
                    break;
            }
            if (amount >= 0)
            {
                ((Label)((StackPanel)((Button)sender).Parent).Children[1]).Content = amount.ToString();
            }

            Button_Basket.Content = (Order.Count > 0) ? $"Корзина ({Order.Count})":"Корзина";
        }

        private Label CreateCardAmountLabel()
        {
            var label = new Label
            {
                Content = "0"
            };

            return label;
        }

        private bool isNewLine(string product)
        {
            // Проверяет - это новый товар в корзине? 
            bool newLine = true;
            foreach (var line in Order)
            {
                if (line.ProductName == product)
                {
                    newLine = false;
                    break;
                }
            }
            return newLine;
        }

        private void AddToOrder(string product)
        {
            if (isNewLine(product))
            {
                Order.Add(new OrderLine { ProductName = product, ProductAmount = 1 });
            }
            else
            {
                foreach (var line in Order)
                {
                    if (line.ProductName == product)
                    {
                        line.ProductAmount++;
                    }
                }
            }
        }

        private void ReduceFromOrder(string product)
        {
            if (!isNewLine(product))
            {
                foreach (var line in Order)
                {
                    if (line.ProductName == product && line.ProductAmount>1)
                    {
                        line.ProductAmount--;
                    }
                    else
                    {
                        Order.Remove(line);
                        break;
                    }
                }
            }
        }

        private void Button_Basket_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Order.Count.ToString());
        }
    }
}