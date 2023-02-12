using DBLay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Helpers;

namespace TestTask.Model
{
    public class RowInOrderModel : MyNotifyPropChanged
    {
        private ItemModel _item;
        public ItemModel Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                SetProperty(ref _amount, value);
                ChangeSumCost();
            }
        }

        private int _sumCost;
        public int SumCost
        {
            get => _sumCost;
            set => SetProperty(ref _sumCost, value);
        }

        private int _oneItemCost;
        public int OneItemCost
        {
            get => _oneItemCost;
            set
            {
                SetProperty(ref _oneItemCost, value);
                ChangeSumCost();
            }
        }

        public RowInOrderModel(RowInOrder row)
        {
            Item = new ItemModel(row.item.Name, row.item.IsHidden, row.item.Id);
            _oneItemCost = row.OneItemCost;
            Amount = row.Amount;
            SumCost = row.OneItemCost * row.Amount;
        }
        public RowInOrderModel(ItemModel item)
        {
            Item = item;
        }

        private void ChangeSumCost()
        {
            SumCost = _amount * _oneItemCost;
        }
    }
}
