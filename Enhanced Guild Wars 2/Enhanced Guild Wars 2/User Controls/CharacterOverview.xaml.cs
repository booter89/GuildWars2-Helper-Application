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
    /// Interaction logic for CharacterOverview.xaml
    /// </summary>
    public partial class CharacterOverview : UserControl
    {
        public MainWindow ParentWindow;
        public Character Character = new Character();
        public Inventory InventoryUC;
        public Equipment EquipmentUC;

        public CharacterOverview(MainWindow parent, Character c)
        {
            InitializeComponent();

            this.InventoryUC = new Inventory(this, parent.account.SharedInventoryItems);
            this.EquipmentUC = new Equipment();

            this.ParentWindow = parent;

            Character = c;

            this.CharacterUC.DataContext = c;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMainUC(InventoryUC);
            //setInventoryColumnWidth();
        }

        private void EquipmentUC_Click(object sender, RoutedEventArgs e)
        {
            UpdateMainUC(EquipmentUC);
        }

        private void InventoryUC_Click(object sender, RoutedEventArgs e)
        {
            UpdateMainUC(InventoryUC);
        }

        public void RemoveUserControl()
        {
            CharacterMainUC.Children.Clear();
        }

        public void UpdateMainUC(UserControl userControl)
        {
            RemoveUserControl();

            CharacterMainUC.Children.Add(userControl);

            Grid.SetColumn(userControl, 0);

            Grid.SetRow(userControl, 0);
        }
    }
}
