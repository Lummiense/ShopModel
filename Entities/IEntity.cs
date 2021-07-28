using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public interface IEntity
    {
        //TODO: Добавить автоматическое назначение уникального Id
        uint Id { get; set; }
        bool IsActive { get; set; }
    }
}
