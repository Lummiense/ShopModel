using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class OrderEntity : IEntity
    {
        /// <summary>
        /// Номер заказа.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Покупатель, который оформляет заказ.
        /// </summary>
        public UserEntity User { get; set; }
        private ProductEntity _product;
        /// <summary>
        /// Товар, который добавляется в корзину.
        /// </summary>        
        public List <ProductEntity> ProductCart
        {
            set
            {
                ProductCart.Add(_product);
            }
            get
            {
                return ProductCart;
            }
        }
        /// <summary>
        /// Продавец, которому принадлежит товар.
        /// </summary>
        public ShopEntity Shop { get; set; }
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
        public bool IsActive { get; set;}
    }
}
