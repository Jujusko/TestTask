using DBLay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestTask.ViewModel;

namespace TestTask.View
{
    /// <summary>
    /// Interaction logic for ItemHelper.xaml
    /// </summary>
    public partial class ItemHelper : Window
    {
        AppDbContext dbContext;
        public ItemHelper(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            var a = ((ItemHelperVM)DataContext);
            a.db = dbContext;
            a.Init(this);
            //((ItemHelperVM)DataContext).db = dbContext;
            //((ItemHelperVM)DataContext).SetDbRef();
        }
    }
}
