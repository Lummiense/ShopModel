using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class ProductForBuyer
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        /// <summary>
        /// Дата производства товара.
        /// </summary>
        public DateTime ProductionDate { get; set; }
        //Наличие товара
        public bool Availability { get; set; }       
        /// <summary>
        /// Изображение товара.
        /// </summary>
        public string ProductPicture { get; set; }
    }
}
