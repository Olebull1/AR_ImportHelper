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
using System.Windows.Shapes;

namespace AR_ImportHelper.Views
{
    /// <summary>
    /// Interaction logic for SaveSuccess.xaml
    /// </summary>
    public partial class SaveSuccess : Window
    {
        public SaveSuccess()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
