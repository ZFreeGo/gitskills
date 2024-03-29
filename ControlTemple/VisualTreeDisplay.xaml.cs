﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTemple
{
    /// <summary>
    /// VisualTreeDisplay.xaml 的交互逻辑
    /// </summary>
    public partial class VisualTreeDisplay : Window
    {
        public VisualTreeDisplay()
        {
            InitializeComponent();
        }
        public void ShowVisaulTree(DependencyObject element)
        {
            treeElements.Items.Clear();
            ProcessElement(element, null);
           
        }
        private void ProcessElement(DependencyObject element, TreeViewItem previousItem)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = element.GetType().Name;
            item.IsExpanded = true;

            if (previousItem == null)
            {
                treeElements.Items.Add(item);
            }
            else
            {
                previousItem.Items.Add(item);
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                ProcessElement(VisualTreeHelper.GetChild(element, i), item);
            }
        }
    }
}
