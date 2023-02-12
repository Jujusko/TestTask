using DBLay;
using DBLay.Entities;
using Microsoft.Extensions.DependencyInjection;
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
using TestTask.View;

namespace TestTask.ViewModel
{
    public class MainWindowVM : MyNotifyPropChanged
    {

        MainWindowService service;
        public Window window;

        public void Init(Window window)
        {
            this.window = window;
            service = new(db);
            Items = service.GetAllItems();

            Orders = service.GetAllOrders();
        }


        public AppDbContext db;

        private DateTime _dateForOrder = DateTime.Now;
        public DateTime DateForOrder
        {
            get => _dateForOrder;
            set => SetProperty(ref _dateForOrder, value);
        }

        private bool _isCanAddOrder = false;
        public bool IsCanAddOrder
        {
            get => _isCanAddOrder;
            set => SetProperty(ref _isCanAddOrder, value);
        }
        


        public ObservableCollection<ItemModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        private ObservableCollection<ItemModel> _items;


        private OrderModel _concreteOrder = new();
        public OrderModel ConcreteOrder
        {
            get => _concreteOrder;
            set => SetProperty(ref _concreteOrder, value);
        }
        
        public ObservableCollection<OrderModel> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }
        private ObservableCollection<OrderModel> _orders;


        private ItemModel _selectedItem;
        public ItemModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private OrderModel _concreteModel;
        public OrderModel ConcreteModel 
        {
            get => _concreteModel;
            set => SetProperty(ref _concreteModel, value);
        }
        private RelayCommand _changeWindow;
        public RelayCommand ChangeWindow
        {
            get
            {
                return _changeWindow ??
                  (_changeWindow = new RelayCommand(obj =>
                  {
                      ItemHelper item = new(db);
                      item.Show();
                      window.Close();
                  }));
            }
        }

        private RelayCommand _addItemToOrder;
        public RelayCommand AddItemToOrder
        {
            get
            {
                return _addItemToOrder ??
                  (_addItemToOrder = new RelayCommand(obj =>
                  {
                      if (SelectedItem != null)
                      {
                          IsCanAddOrder = true;
                          ConcreteOrder._rowInOrder.Add(new RowInOrderModel(SelectedItem));
                      }
                  }));
            }
        }


        private RelayCommand _addNewOrder;
        public RelayCommand AddNewOrder
        {
            get
            {
                return _addNewOrder ??
                  (_addNewOrder = new RelayCommand(obj =>
                  {
                      DBLay.Entities.Orders s = new();
                      s.TranzactionDate = DateForOrder;
                      db.Orders.Add(s);
                      List<RowInOrder> test = new();
                      foreach(var c in ConcreteOrder.RowInOrder)
                      {
                        RowInOrder row = new();

                          row.Order = s;
                          row.OneItemCost = c.OneItemCost;
                          row.item = db.Items.Single(x => x.Id == c.Item.Id);
                          row.Amount = c.Amount;
                          test.Add(row);
                          s.Sum += row.Amount * row.OneItemCost;
                      }
                      s.Rows = test;
                      db.Orders.Add(s);
                      db.SaveChanges();
                      Orders.Add(new OrderModel(ConcreteOrder));
                      ClearOrder();
                      IsCanAddOrder = false;
                  }));
            }
        }
        private RelayCommand _clearOrderCommand;
        public RelayCommand ClearOrderCommand
        {
            get
            {
                return _clearOrderCommand ??
                  (_clearOrderCommand = new RelayCommand(obj =>
                  {
                      ClearOrder();
                  }));
            }
        }

        private void ClearOrder()
        {
            ConcreteOrder = new();
        }
    }
}
