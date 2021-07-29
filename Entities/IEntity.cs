using System;

namespace ShopApi.Entities
{
    public interface IEntity
    {
        //TODO: Добавить автоматическое назначение уникального Id
        uint Id { get; set; }
        bool IsActive { get; set; }
    }
}
