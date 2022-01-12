using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelLib
{
    public class ObsColOrder
    {
        public ObservableCollection<OrderRow> Order { get; set; }

        public ObsColOrder()
        {
            Order = new ObservableCollection<OrderRow>();
        }

        //TODO Функция проверки новый продукт в карзине или повтор
        public bool IsNewRow(Product Product)
        {
            //  Проверка есть ли в карзине такой товар
            //  Если есть вернёт истину, если такой товар есть вернёт ложь 
            var NewRow = true;

            if (Order.Count != 0)
            {
                foreach (var orderRow in Order)
                {
                    if (orderRow.Product.Id == Product.Id)
                    {
                        NewRow = false;
                        break;
                    }
                }
            }
            return NewRow;
        }

        public void AddProductToOrder(Product Product, int AmountToOrder)
        {
            //  Добавление продуктов в карзину
            if (AmountToOrder > 0)
            {
                if (IsNewRow(Product))
                {
                    Order.Add(new OrderRow { Product = Product, RowAmount = AmountToOrder });
                }
                else
                {
                    foreach (var orderRow in Order)
                    {
                        if (orderRow.Product.Id == Product.Id)
                        {
                            orderRow.RowAmount += AmountToOrder;
                            break;
                        }
                    }
                }
            }
        }

        public void RemProductFromOrder(Product Product)
        {
            //  Удаляет продукт из карзины
            foreach (var orderRow in Order)
            {
                if (orderRow.Product.Id == Product.Id)
                {
                    Order.Remove(orderRow);
                    break;
                }
            }
        }

        public double GetOrderCost()
        {
            //  Функция расчета стоимости всей карзины
            double OrderCost = 0.0;
            foreach (var orderRow in Order)
            {
                OrderCost += orderRow.GetRowCost();
            }
            return Math.Round(OrderCost, 2);
        }

        public int GetOrderCount()
        {
            return Order.Count();
        }

        //TODO Функия совершения покупки
    }
}
