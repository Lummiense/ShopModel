using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class ProductForBuyer
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        /// <summary>
        /// Product`s production date.
        /// </summary>
        /// <summary>
        /// Is product available for order now or not?
        /// </summary>
        public bool Availability { get; set; }
        /// <summary>
        /// Product manufacturer.
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// Product picture.
        /// </summary>
        public string ProductPicture { get; set; }
    }
}
