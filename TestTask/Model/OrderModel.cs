using DBLay.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Helpers;

namespace TestTask.Model
{
    public class OrderModel : MyNotifyPropChanged
    {
        public ObservableCollection<RowInOrderModel> _rowInOrder = new();
        public ObservableCollection<RowInOrderModel> RowInOrder
        {
            get => _rowInOrder;
            set => SetProperty(ref _rowInOrder, value);
        }

        private DateTime _tranzactionDate;
        public DateTime TranzactionDate
        {
            get => _tranzactionDate;
            set => SetProperty(ref _tranzactionDate, value);
        }

        private int _sum;
        public int Sum
        {
            get => _sum;
            set => SetProperty(ref _sum, value);
        }

        public OrderModel(Orders or)
        {
            RowInOrder = new(or.Rows.Select(x => new RowInOrderModel(x)).ToList());
            _tranzactionDate = or.TranzactionDate;
            Sum = RowInOrder.Sum(x => x.SumCost);
        }

        public OrderModel(OrderModel other)
        {
            TranzactionDate = other.TranzactionDate;
            RowInOrder = other.RowInOrder;
            Sum = other._rowInOrder.Sum(x => x.Amount * x.OneItemCost);
        }
        public OrderModel()
        {
            RowInOrder = new();
        }
    }
}
