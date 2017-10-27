using Enhanced_Guild_Wars_2.Entities;
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

namespace Enhanced_Guild_Wars_2.User_Controls
{
    /// <summary>
    /// Interaction logic for AccountOverview.xaml
    /// </summary>
    public partial class AccountOverview : UserControl
    {
        public string ImagePath = @"..\..\Assets\Images\";
        public MainWindow P;

        public AccountOverview(MainWindow parent)
        {
            InitializeComponent();

            this.P = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.CharacterOverviewIC.ItemsSource = P.account.Characters;
        }

        private void CharcherUC_Click(object sender, RoutedEventArgs e)
        {
            this.P.RemoveUserControl();

            Button b = sender as Button;

            Grid grid = b.Content as Grid;

            Character character = grid.DataContext as Character;

            string characterName = character.name;

            var charUC = this.P.CharacterUserControls.Where(x => x.Character.name == characterName).Select(x => x).ToList();

            this.P.MainUC.Children.Add(charUC.First());

            Grid.SetColumn(charUC.First(), 0);

            Grid.SetRow(charUC.First(), 0);
        }
    }
}
