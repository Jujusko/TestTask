using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLay.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public DateTime TranzactionDate { get; set; }
        public virtual ICollection<RowInOrder>? Rows { get; set; }
    }
}
