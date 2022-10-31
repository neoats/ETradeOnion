using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public Customer Customer { get; set; }
        public  List<Product> Products { get; set; }
    }
}
