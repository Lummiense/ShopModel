using System.Collections.Generic;

namespace ShopApi.Model
{
    public class Cart
    {
        public Cart(ProductForBuyer product)
        {
            _product = product;
        }
        
        /// <summary>
        /// Покупатель, который оформляет заказ.
        /// </summary>
        public Buyer Buyer { get; set; }
        
        /// <summary>
        /// Товар, который добавляется в корзину.
        /// </summary>        
        public List<ProductForBuyer> ProductCart
        {
            set => ProductCart.Add(_product);
            get => ProductCart;
        }
        
        /// <summary>
        /// Продавец, которому принадлежит товар.
        /// </summary>
        public ShopForBuyers Shop { get; set; }
        
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
        
        private ProductForBuyer _product;
        private decimal _totalPrice;
    }
}