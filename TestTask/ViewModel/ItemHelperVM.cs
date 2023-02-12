using DBLay;
using DBLay.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTask.Helpers;
using TestTask.Model;
using TestTask.Services;

namespace TestTask.ViewModel
{
    public class ItemHelperVM : MyNotifyPropChanged
    {
        public AppDbContext db;
        private ItemHelperServices service;
        private Window win;

        public ItemHelperVM()
        {

        }

        public void Init(Window win)
        {
            this.win = win;
            service = new(db);
            Items = service.GetItems();
        }

        private ObservableCollection<ItemModel> _items;
        public ObservableCollection<ItemModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private string _itemName;
        public string Name
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        private RelayCommand _addItem;
        public RelayCommand AddItem
        {
            get
            {
                return _addItem ??
                  (_addItem = new RelayCommand(obj =>
                  {

                      Items s = new();
                      s.Name = Name;
                      s.IsHidden = false;


                      db.Items.Add(s);
                      db.SaveChanges();
                  }));
            }
        }

        private RelayCommand _addItemC;
        public RelayCommand AddItemC
        {
            get
            {
                return _addItemC ??
                  (_addItem = new RelayCommand(obj =>
                  {
                      service.ChangeVisibility(Items);
                      MainWindow w = new(db);
                      w.Show();
                      win.Close();
                  }));
            }
        }
    }
}
