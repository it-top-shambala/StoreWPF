using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Store
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitGrid(2, 4);
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
                    var card = CreateCard();
                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);

                    Body.Children.Add(card);
                }
            }
        }

        private StackPanel CreateCard()
        {
            var cardImage = new Image();
            cardImage.Source = new BitmapImage(new Uri(@"D:\YandexDisk\Академия ШАГ\WPF_Windows Forms\WPF_App\StoreWPF\Store\img\product.jpg"));

            var card = new StackPanel();

            card.Orientation = Orientation.Vertical;

            card.Children.Add(cardImage);
            card.Children.Add(CreateCardAmount());
            card.Children.Add(CreateCardAnnotation("Product name"));

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
                Content = content
            };

            return button;
        }

        private Label CreateCardAmountLabel()
        {
            var label = new Label
            {
                Content = "0"
            };

            return label;
        }
    }
}