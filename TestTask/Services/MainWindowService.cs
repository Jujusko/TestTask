using DBLay;
using DBLay.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Services
{
    public class MainWindowService
    {
        private AppDbContext _db;

        public MainWindowService(AppDbContext db)
        {
            _db = db;
        }

        public ObservableCollection<ItemModel> GetAllItems()
        {
            var rawItems = _db.Items.Where(x => !x.IsHidden);
            var items = rawItems.Select(x => new ItemModel(x.Name, x.IsHidden, x.Id)).ToList();

            ObservableCollection<ItemModel> result = new ObservableCollection<ItemModel>(items);
            
            return result;
        }

        public ObservableCollection<OrderModel> GetAllOrders()
        {
            var rawItems = _db.Orders.Include(x => x.Rows).ThenInclude(c => c.item).ToList();

            var result = rawItems.Select(x => new OrderModel(x)).ToList();

            return new ObservableCollection<OrderModel>(result);
        }

        public void AddOrder(OrderModel order)
        {
            Orders orderToDb = new();
            orderToDb.TranzactionDate = DateTime.Now;

            foreach(var o in order.RowInOrder)
            {
                RowInOrder row = new();
                row.Order = orderToDb;
                row.OneItemCost = o.OneItemCost;
                row.item = new Items() { IsHidden = false, Name = o.Item.Name, Id = o.Item.Id };
            }
            _db.Orders.Add(orderToDb);
            _db.SaveChanges();
        }
    }
}
