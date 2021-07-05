using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class Buyer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public int PhoneNumber { get; set; }
    }
}
