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

namespace Enhanced_Guild_Wars_2.User_Controls
{
    /// <summary>
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        public MainWindow ParentWindow;

        public Status(MainWindow parent)
        {
            InitializeComponent();

            this.ParentWindow = parent;

        }
    }
}
