using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class Cart
    {
        /// <summary>
        /// Покупатель, который оформляет заказ.
        /// </summary>
        public Buyer _buyer { get; set; }
        private ProductForBuyer _product;
        /// <summary>
        /// Товар, который добавляется в корзину.
        /// </summary>        
        public List<ProductForBuyer> _productCart
        {
            set
            {
                _productCart.Add(_product);
            }
            get
            {
                return _productCart;
            }
        }
        /// <summary>
        /// Продавец, которому принадлежит товар.
        /// </summary>
        public ShopForBuyers _shop { get; set; }
        private decimal _totalPrice;
        /// <summary>
        /// Сумма заказа.
        /// </summary>        
        public decimal TotalPrice
        {
            set
            {
                _totalPrice += _product.Price;
            }
            get
            {
                return _totalPrice;
            }
        }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public string OrderStatus { get; set; }
    }
}
