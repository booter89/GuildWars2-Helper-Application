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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : UserControl
    {
        public Character c;
        public List<Tuple<ShareInventoryItem, Item>> sharedInventory;
        public CharacterOverview CharacterUserControl;

        public Inventory(CharacterOverview CUC, List<Tuple<ShareInventoryItem, Item>> SharedInventory)
        {
            InitializeComponent();

            c = new Character();

            this.CharacterUserControl = CUC;

            this.sharedInventory = SharedInventory;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            c = CharacterUserControl.Character;

            setInventoryColumnWidth();

            SharedInventoryIC.ItemsSource = sharedInventory;

            InventoryIC.ItemsSource = c.inventoryItems;

            BagsIC.ItemsSource = c.bagItems;
        }

        private void setInventoryColumnWidth()
        {
            //int columnsWidth = (int)Math.Round(c.inventoryItems.Count() / ((decimal)16));

            int columnsWidth = sharedInventory.Count();

            columnsWidth = columnsWidth * 48 + 8;

            this.InventoryColumn.Width = new GridLength(columnsWidth);
        }
    }
}
