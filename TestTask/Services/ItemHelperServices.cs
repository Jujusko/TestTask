using DBLay;
using DBLay.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Model;

namespace TestTask.Services
{
    public class ItemHelperServices
    {
        private AppDbContext _db;

        public ItemHelperServices(AppDbContext db)
        {
            _db = db;
        }

        public ObservableCollection<ItemModel> GetItems()
        {
            var items = _db.Items.ToList();
            var result = items.Select(x => new ItemModel(x.Name, x.IsHidden, x.Id)).ToList();
            ObservableCollection<ItemModel> values = new(result);
            return values;
        }

        public void AddItem(ItemModel item)
        {
            Items newItem = new();
            newItem.IsHidden = false;
            newItem.Name = item.Name;

            _db.Items.Add(newItem);
            _db.SaveChanges();
        }

        public void ChangeVisibility(ObservableCollection<ItemModel> items)
        {
            var itemsDb = _db.Items.ToList();

            itemsDb.ForEach(x => x.IsHidden = (items.Single(s => s.Id == x.Id)).IsHidden);

            _db.SaveChanges();
        }
    }
}
