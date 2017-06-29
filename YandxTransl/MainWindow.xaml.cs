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

namespace YandxTransl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            textBox.setText(box.Text);
        }

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {
            box2.Text = textBox.getSelectedText();
        }
    }
}
