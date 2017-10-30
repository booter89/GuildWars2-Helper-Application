using System;
using System.Collections.Generic;
using System.ComponentModel;
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
//using System.Windows.Shapes;//
using Enhanced_Guild_Wars_2.Entities;
using Enhanced_Guild_Wars_2.User_Controls;
using Enhanced_Guild_Wars_2.Utilities;
using Newtonsoft.Json;
using System.IO;

namespace Enhanced_Guild_Wars_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool running = false;
        public bool accountLoaded = false;

        public UserActivityHook activity;
        public Account account;

        public TradingPost tradingPostTab;
        public Status StatusTab;
        public KeyBoardAndMouse mouseTab;
        public AccountOverview accountOverviewTap;
        public List<CharacterOverview> CharacterUserControls = new List<CharacterOverview>();
        public List<MenuItem> CharacterMenuItems = new List<MenuItem>();

        public MainWindow()
        {
            InitializeComponent();

            account = new Account();
            accountOverviewTap = new AccountOverview(this);
            StatusTab = new Status(this);
            mouseTab = new KeyBoardAndMouse(this);
            tradingPostTab = new TradingPost(this);

            UpdateMainUC(StatusTab);

            UpdateStatus("Status User Control Displayed.");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //activity = new UserActivityHook();

            //activity.OnMouseActivity += new System.Windows.Forms.MouseEventHandler(MouseMoved);
            //activity.KeyDown += new System.Windows.Forms.KeyEventHandler(MyKeyDown);
            //activity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(MyKeyPress);
            //activity.KeyUp += new System.Windows.Forms.KeyEventHandler(MyKeyUp);

            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            UpdateStatus(String.Format("Pulling Account Information From GuildWars2.com"));

            BackgroundWorker worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;

            worker.DoWork += (o, ea) =>
            {
                account.getAccountInformation();
                account.getAccountItems();
                account.pairItems();
            };

            worker.ProgressChanged += (o, ea) =>
            {
                UpdateStatus(ea.UserState.ToString());
            };

            worker.RunWorkerCompleted += (o, ea) =>
            {
                accountLoaded = true;

                if (ea.Error != null)
                {
                    UpdateStatus("Error");
                }
                else
                {
                    UpdateStatus(String.Format("Account Information pulled Successfully!"));
                }

                foreach (Character c in account.Characters)
                {
                    CharacterUserControls.Add(new CharacterOverview(this, c));

                    MenuItem menuItem = new MenuItem();

                    menuItem.Header = "_" + c.name;

                    Image icon = new Image();

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    string uriString = Path.GetFullPath(@"..\..\Assets\Images\" + c.smallPNG);
                    bitmap.UriSource = new Uri(uriString, UriKind.Absolute);
                    bitmap.EndInit();

                    icon.Source = bitmap;

                    menuItem.Icon = icon;

                    menuItem.Click += chacterUCButton_Click;

                    CharacterMenuItems.Add(menuItem);
                }

                UpdateMainUC(accountOverviewTap);

                CharacterMenu.ItemsSource = CharacterMenuItems;
            };

            worker.RunWorkerAsync();
        }



        public void UpdateStatus(string status, bool error = false)
        {
            ListBoxItem item = new ListBoxItem();

            string updateLine = String.Format("{0}\t{1}", DateTime.Now.ToString(), status);

            item.Foreground = error ? Brushes.Red : Brushes.WhiteSmoke;

            item.Content = updateLine;

            var StatusBox = (ListBox)StatusTab.FindName("StatusBox");

            StatusBox.Items.Add(item);
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;

            UpdateStatus(String.Format("{0} Button Pressed.", m.Header.ToString()));

            UpdateMainUC(StatusTab);

            UpdateStatus(String.Format("{0} User Control Displayed.", m.Header.ToString()));
        }

        private void MousePosition_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;

            UpdateStatus(String.Format("{0} Button Pressed.", m.Header.ToString()));

            UpdateMainUC(mouseTab);

            UpdateStatus(String.Format("{0} User Control Displayed.", m.Header.ToString()));
        }

        private void chacterUCButton_Click(object sender, RoutedEventArgs e)
        {
            //Button b = sender as Button;
            MenuItem b = sender as MenuItem;

            //string characterName = b.Content.ToString();
            string characterName = b.Header.ToString();

            characterName = characterName.Replace("_", "");

            UpdateStatus(String.Format("{0} Button Pressed.", characterName));

            var charUC = CharacterUserControls.Where(x => x.Character.name == characterName).Select(x => x).ToList();

            UpdateMainUC(charUC.First());

            UpdateStatus(String.Format("{0} User Control Displayed.", characterName));
        }

        private void AccountOverviewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (accountLoaded)
            {
                UpdateMainUC(accountOverviewTap);
            }
        }

        public void RemoveUserControl()
        {
            MainUC.Children.Clear();
        }

        public void UpdateMainUC(UserControl userControl)
        {
            RemoveUserControl();

            MainUC.Children.Add(userControl);

            Grid.SetColumn(userControl, 0);

            Grid.SetRow(userControl, 0);
        }

        private void TradingPost_Click(object sender, RoutedEventArgs e)
        {
            if (accountLoaded)
            {
                UpdateMainUC(tradingPostTab);
            }
        }

        //public void MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (this.running == true)
        //    {
        //        Mouse.Capture(this);
        //        Point pointToWindow = Mouse.GetPosition(this);
        //        Point pointToScreen = PointToScreen(pointToWindow);
        //        mouseTab.xLabel.Content = pointToScreen.X.ToString();
        //        mouseTab.yLabel.Content = pointToScreen.Y.ToString();
        //        Mouse.Capture(null);
        //    }
        //}

        //public List<string> keyClicks = new List<string>();

        //public void MyKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    keyClicks.Add(e.KeyData.ToString());

        //    List<string> AltF1 = new List<string>() { "Escape" };

        //    if (keyClicks.Contains(AltF1[0]))
        //    {
        //        if (this.running == true)
        //        {
        //            this.running = false;
        //        }
        //        else
        //        {
        //            this.running = true;
        //        }
        //    }
        //}

        //public void MyKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //}

        //public void MyKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    keyClicks.Remove(e.KeyData.ToString());
        //}
    }
}
