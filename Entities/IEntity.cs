using System;

namespace ShopApi.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsActive { get; set; }
    }
}
