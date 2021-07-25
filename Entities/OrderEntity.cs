using System;
using System.Collections.Generic;

namespace ShopApi.Entities
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

        /// <summary>
        /// Товар, который добавляется в корзину.
        /// </summary>        
        public List <ProductEntity> ProductCart
        {
            set => ProductCart.Add(_product);
            get => ProductCart;
        }
        
        /// <summary>
        /// Продавец, которому принадлежит товар.
        /// </summary>
        public ShopEntity Shop { get; set; }

        /// <summary>
        /// Сумма заказа.
        /// </summary>        
        public decimal TotalPrice 
        {           
            set => _totalPrice += _product.Price;
            get => _totalPrice;
        }
        
        /// <summary>
        /// Статус заказа.
        /// </summary>
        public string OrderStatus { get; set; }
        
        public bool IsActive { get; set;}
        
        private ProductEntity _product;
        private decimal _totalPrice;

    }
}
