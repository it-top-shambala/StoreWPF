using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelLib
{
    public class OrderRow
    {
        public Product Product { get; set; }
        public int RowAmount { get; set; }

        //TODO Функция расчета стоимости строки
        public double GetCost()
        {
            //  Возвращает стоимость строки
            return Math.Round(Product.Price*RowAmount, 2);
            //  String.Format("0.00")
            //  ToString("0.00")
        }
    }
}
