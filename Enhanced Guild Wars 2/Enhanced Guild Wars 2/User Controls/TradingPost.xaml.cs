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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Enhanced_Guild_Wars_2.Entities;
using Enhanced_Guild_Wars_2.Routines;
using System.Reflection;

namespace Enhanced_Guild_Wars_2.User_Controls
{
    /// <summary>
    /// Interaction logic for TradingPost.xaml
    /// </summary>
    public partial class TradingPost : UserControl
    {
        public MainWindow parent;
        public List<CommerceListings> items;

        public TradingPost(MainWindow parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.items = new List<CommerceListings>();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            getItemInformation();
        }

        public void getItemInformation()
        {
            string ids = String.Join(",", Concrete.Constants.Item.AXE_ITEM_IDS);

            string resource = @"http://api.guildwars2.com/v2/commerce/listings?ids=";

            string url = String.Format("{0}{1}", resource, ids);

            var items = API.getNonScalarValue<CommerceListings>(url);
        }
    }
}
