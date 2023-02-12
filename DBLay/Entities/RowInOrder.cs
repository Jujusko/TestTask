using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLay.Entities
{
    public class RowInOrder
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int OneItemCost { get; set; }
        public virtual Items? item { get; set; }
        public virtual Orders? Order { get; set; }

    }
}
