﻿using System;
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
using System.ComponentModel;
using System.Threading;
using Enhanced_Guild_Wars_2.Utilities;

namespace Enhanced_Guild_Wars_2.User_Controls
{
    /// <summary>
    /// Interaction logic for TradingPost.xaml
    /// </summary>
    public partial class TradingPost : UserControl
    {
        private BackgroundWorker worker = new BackgroundWorker();
        public UserActivityHook activity;

        public MainWindow parent;
        public List<Item> items;

        public TradingPost(MainWindow parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.items = new List<Item>();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            getItemInformation();

            ItemsToBuy.ItemsSource = this.items.OrderByDescending(s => s.commerce.profit);
        }

        public void getItemInformation()
        {
            List<int> itemIds = new List<int>();            
            List<Commerce> commerce = new List<Commerce>();
            List<CommerceListings> commerceListings = new List<CommerceListings>();

            itemIds = Concrete.Constants.Item.getIds();

            string ids = String.Join(",", itemIds);


            string urlBeginning = @"https://api.guildwars2.com/v2/items?ids=";

            List<string> URLitemIds = new List<string>();

            URLitemIds = API.getURLsWithIdsList(urlBeginning, itemIds);
            
            foreach(string url in URLitemIds)
            {
                var result = API.getNonScalarValue<Item>(url);

                foreach (Item i in result)
                {
                    this.items.Add(i);
                }
            }
            

            urlBeginning = @"https://api.guildwars2.com/v2/commerce/prices?ids=";

            List<string> CommercePricesUrls = new List<string>();

            CommercePricesUrls = API.getURLsWithIdsList(urlBeginning, itemIds);

            foreach (string url in CommercePricesUrls)
            {
                var result = API.getNonScalarValue<Commerce>(url);

                foreach (Commerce c in result)
                {
                    commerce.Add(c);
                }
            }
            

            urlBeginning = @"https://api.guildwars2.com/v2/commerce/listings?ids=";

            List<string> CommerceListingUrls = new List<string>();

            CommerceListingUrls = API.getURLsWithIdsList(urlBeginning, itemIds);

            foreach (string url in CommerceListingUrls)
            {
                var result = API.getNonScalarValue<CommerceListings>(url);

                foreach (CommerceListings cl in result)
                {
                    commerceListings.Add(cl);
                }
            }


            foreach (Item i in this.items)
            {
                i.commerce = commerce.Where(x => x.id == i.id).Select(x => x).ToList().First();

                i.listings = commerceListings.Where(x => x.id == i.id).Select(x => x).ToList().First();

                i.commerce.calculate();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            activity = new UserActivityHook();

            activity.OnMouseActivity += new System.Windows.Forms.MouseEventHandler(MouseMoved);
            activity.KeyDown += new System.Windows.Forms.KeyEventHandler(MyKeyDown);
            activity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(MyKeyPress);
            activity.KeyUp += new System.Windows.Forms.KeyEventHandler(MyKeyUp);

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += (o, ea) =>
            {
                List<Item> sortedItems = new List<Item>();

                sortedItems = items.Where(x => x.commerce.profit > .15).Select(x => x).ToList();

                int quanitity = 4;

                foreach (Item weapon in sortedItems)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    Automation.PlaceBuyOrder(weapon.name, quanitity);
                }
            };

            worker.ProgressChanged += (o, ea) =>
            {
                
            };

            worker.RunWorkerCompleted += (o, ea) =>
            {
                if (ea.Error != null)
                {
                    
                }
                else
                {
                    
                }
            };

            worker.RunWorkerAsync();

        }

        public void MouseMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (this.running == true)
            //{
            //    Mouse.Capture(this);
            //    Point pointToWindow = Mouse.GetPosition(this);
            //    Point pointToScreen = PointToScreen(pointToWindow);
            //    mouseTab.xLabel.Content = pointToScreen.X.ToString();
            //    mouseTab.yLabel.Content = pointToScreen.Y.ToString();
            //    Mouse.Capture(null);
            //}
        }

        public void MyKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            List<string> keyClicks = new List<string>();

            keyClicks.Add(e.KeyData.ToString());

            List<string> AltF1 = new List<string>() { "Escape" };

            if (keyClicks.Contains(AltF1[0]))
            {
                worker.CancelAsync();
            }
        }

        public void MyKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        }

        public void MyKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //keyClicks.Remove(e.KeyData.ToString());
        }

        public void DataGridRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            Item itemRow = new Item();

            itemRow = row.DataContext as Item;

            CommerceListing CLUC = new CommerceListing(itemRow);

            CommerceListingUC.Children.Clear();

            CommerceListingUC.Children.Add(CLUC);

            //Grid.SetColumn(CLUC, 0);

            //Grid.SetRow(CLUC, 0);


        }

    }
}
