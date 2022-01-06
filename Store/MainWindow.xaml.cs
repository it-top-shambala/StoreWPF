using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DataModelLib;
using DbConnectionLib;

namespace Store
{
    public partial class MainWindow : Window
    {
        #region Values

        public static ObsColOrder Order;
        public static ObservableCollection<Product>? Products;

        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            InitValue();
        }
        #endregion

        #region Init
        private void InitValue()
        {
            Order = new ObsColOrder();
            Products = new ObservableCollection<Product>(new DataBaseLib.DataBase().GetAllProducts());
        }
        #endregion

        #region Shop

        private void CreateListCards()
        {
            if (Products.Count > 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    WrapPanel_Showcase.Children.Add(new Template_view.Product_Card.Card(Products[i]));
                }
            }
            else
            {
                foreach (var item in Products)
                {
                    WrapPanel_Showcase.Children.Add(new Template_view.Product_Card.Card(item));
                }
            }
        }

        //TODO Изменить вызов витрины продуктов - привязать к кнопке МАГАЗИН
        //TODO Вызов карзины (загрузить Заголовок+Сроки заказа+Подвал заказа.
        //TODO Добавить админку (ввод реквизитов подключения - ручной, из файла, сохранить в файл)

        #endregion

        #region Basket
        private void CreateListOrder()
        {
            //  Корзина
            //  Заголовок корзины
            WrapPanel_Showcase.Children.Add(new Template_view.Basket.BasketTitle());
            //  Строки корзины

            //  Подвал корзины
            //WrapPanel_Showcase.Children.Add(new Template_view.Basket.BasketFooter());
        }
        #endregion

        #region Button
        private void Button_ShowStore_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel_Showcase.Children.Clear();
            //WrapPanel_Showcase.Orientation = Orientation.Horizontal;
            CreateListCards();
        }
        private void Button_ShowBasket_Click(object sender, RoutedEventArgs e)
        {
            //if (Order.GetOrderCount() > 0)
            {
                WrapPanel_Showcase.Children.Clear();
                //WrapPanel_Showcase.Orientation = Orientation.Vertical;

                CreateListOrder();
            }
        }
        #endregion

        #region Temp

        //private void InitGrid(int amountRows, int amountColumns)
        //{
        //    Grid_Body.RowDefinitions.Clear();
        //    Grid_Body.ColumnDefinitions.Clear();

        //    for (int i = 0; i < amountRows; i++)
        //    {
        //        Grid_Body.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        //    }

        //    for (int j = 0; j < amountColumns; j++)
        //    {
        //        Grid_Body.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        //    }

        //    for (int i = 0; i < amountRows; i++)
        //    {
        //        for (int j = 0; j < amountColumns; j++)
        //        {
        //            var card = CreateCard(new Product());
        //            Grid.SetRow(card, i);
        //            Grid.SetColumn(card, j);

        //            Grid_Body.Children.Add(card);
        //        }
        //    }
        //}

        //private StackPanel CreateCard(Product product)
        //{
        //    var cardImage = new Image
        //    {
        //        Source = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\img\product.jpg")) //TODO Добавить путь к изображению скаченному с FTP
        //    };

        //    var card = new StackPanel
        //    {
        //        Orientation = Orientation.Vertical
        //    };

        //    card.Children.Add(cardImage);
        //    card.Children.Add(CreateCardAmount());
        //    card.Children.Add(CreateCardAnnotation(product.Annotation));

        //    return card;
        //}

        //private Label CreateCardAnnotation(string annotation)
        //{
        //    var label = new Label
        //    {
        //        Content = annotation
        //    };

        //    return label;
        //}

        //private StackPanel CreateCardAmount()
        //{
        //    var cardAmount = new StackPanel
        //    {
        //        Orientation = Orientation.Horizontal
        //    };

        //    cardAmount.Children.Add(CreateCardAmountButton("-"));
        //    cardAmount.Children.Add(CreateCardAmountLabel());
        //    cardAmount.Children.Add(CreateCardAmountButton("+"));

        //    return cardAmount;
        //}

        //private Label CreateCardAmountLabel()
        //{
        //    var label = new Label
        //    {
        //        Content = "0",
        //    };
        //    return label;
        //}

        //private Button CreateCardAmountButton(string content)
        //{
        //    var button = new Button
        //    {
        //        Content = content,
        //    };
        //    button.Click += Button_CardAmount_OnClick;
        //    return button;
        //}
        //    private void Button_CardAmount_OnClick(object sender, RoutedEventArgs e)
        //    {
        //        var content = ((Button)sender).Content.ToString();
        //        var product = ((Label)((StackPanel)((StackPanel)((Button)sender).Parent).Parent).Children[2]).Content
        //            .ToString();

        //        switch (content)
        //        {
        //            case "-":
        //                ReduceFromOrder(product);
        //                break;
        //            case "+":
        //                AddToOrder(product);
        //                break;
        //        }

        //((Label)((StackPanel)((Button)sender).Parent).Children[1]).Content = AmountProduct(product);

        //        Button_Basket.Content = Order.Count > 0 ? $"Корзина ({Order.Count})" : "Корзина";
        //    }


        //private bool IsNewLine(string product)
        //{
        //    // Проверяет - это новый товар в корзине? 
        //    return Order.All(line => line.ProductName != product);
        //}

        //private void AddToOrder(string product)
        //{
        //    if (IsNewLine(product))
        //    {
        //        Order.Add(new OrderRow { ProductName = product, RowAmount = 1 });
        //    }
        //    else
        //    {
        //        foreach (var orderLine in Order)
        //        {
        //            if (orderLine.ProductName != product) continue;

        //            orderLine.RowAmount++;
        //            break;
        //        }
        //    }
        //}

        //private void ReduceFromOrder(string product)
        //{
        //    if (IsNewLine(product)) return;

        //    foreach (var orderLine in Order)
        //    {
        //        if (orderLine.ProductName == product && orderLine.RowAmount > 1)
        //        {
        //            orderLine.RowAmount--;
        //        }
        //        else
        //        {
        //            Order.Remove(orderLine);
        //            break;
        //        }
        //    }
        //}

        //private void Button_Basket_Click(object sender, RoutedEventArgs e)
        //{
        //    var basket = new WindowBasket();

        //    basket.Show();
        //}

        //private int AmountProduct(string product)
        //{
        //    return !IsNewLine(product)
        //        ? (from orderLine in Order where orderLine.ProductName == product select orderLine.RowAmount)
        //        .FirstOrDefault()
        //        : 0;
        //}

        //TODO Переместить в админку
        private void Button_CreateDbConnectionTemplate_Click(object sender, RoutedEventArgs e)
        {
            var template = new DbConnection
            {
                Server = "myServerAddress",
                Database = "myDataBase",
                Uid = "myUsername",
                Pwd = "myPassword"
            };

            var fileConnection = Environment.CurrentDirectory + @"\db_connection.json";

            if (template.SerializeJson(fileConnection))
            {
                MessageBox.Show(
                    $"Успешное создание шаблонного файла JSON для подключения к БД\n" +
                    $"Шаблонный файл: {fileConnection}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion

    }
}