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

namespace Jeans.Common.WPFApp.Views
{
    /// <summary>
    /// SimpleStackView.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleStackView : Window
    {
        public SimpleStackView()
        {
            InitializeComponent();
        }

        private void ColumnDefinition_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        //private void chkLongText_Checked(object sender, RoutedEventArgs e)
        //{
        //    btnPrev.Content = "<- Go to the Previous Window";
        //    btnNext.Content = "Go to the Next Window ->";
        //}

        //private void chkLongText_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    btnPrev.Content = "Prev";
        //    btnNext.Content = "Next";
        //}
    }
}
