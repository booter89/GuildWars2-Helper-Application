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

namespace Enhanced_Guild_Wars_2.User_Controls
{
    /// <summary>
    /// Interaction logic for CommerceListing.xaml
    /// </summary>
    public partial class CommerceListing : UserControl
    {
        public CommerceListings CL = new CommerceListings();

        public CommerceListing(Item i)
        {
            InitializeComponent();

            CL = i.listings;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Buy b in CL.buys)
            {
                b.calculate();
            }

            foreach (Sell s in CL.sells)
            {
                s.calculate();
            }

            CommerceListingBuyDataGrid.ItemsSource = CL.buys;

            CommerceListingSellDataGrid.ItemsSource = CL.sells;
        }
    }
}
