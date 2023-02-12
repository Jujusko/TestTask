using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Helpers;

namespace TestTask.Model
{
    public class ItemModel : MyNotifyPropChanged
    {

        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private bool _isHidden;
        public bool IsHidden
        {
            get => _isHidden;
            set => SetProperty(ref _isHidden, value);
        }
        public ItemModel(string name, bool isHidden, int id)
        {
            _name = name;
            _isHidden = isHidden;
            Id = id;
        }
    }
}
