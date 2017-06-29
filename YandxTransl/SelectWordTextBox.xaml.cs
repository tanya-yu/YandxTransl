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
    /// Логика взаимодействия для SelectWordTextBox.xaml
    /// </summary>
    public partial class SelectWordTextBox : UserControl
    {
        public SelectWordTextBox()
        {
            InitializeComponent();
        }

        protected string _text;
        protected Brush selectionColor = Brushes.Aqua;

        public string getText()
        {
            return _text;
        }

        public void setText(string text)
        {
            _text = text;
            updateText();
        }

        protected void updateText()
        {
            clearWords();
            string[] words = WordUtils.splitIntoWords(_text);
            foreach(string word in words)
            {
                addWord(word+" ");
            }
        }

        protected void clearWords()
        {
            panel.Children.Clear();
        }

        protected void addWord(string word)
        {
            TextBlock block = new TextBlock();
            block.Text = word;
            block.MouseDown += Block_MouseDown;
            panel.Children.Add(block);
        }

        protected void Block_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock block = sender as TextBlock;
            block.Background = block.Background==null ? selectionColor : null;
            OnSelectionChanded(new EventArgs());
        }

        public string getSelectedText()
        {
            string resut = "";
            foreach(object o in panel.Children)
            {
                TextBlock block = o as TextBlock;
                if (selectionColor.Equals(block.Background))
                    resut += block.Text;
            }
            return resut;
        }

        public event EventHandler SelectionChanged;
        /// <summary>
        /// After word was selected or unselected
        /// </summary>
        /// <param name="e">Temporarily simple EventArgs</param>
        protected virtual void OnSelectionChanded(EventArgs e)
        {
            SelectionChanged.Invoke(this, e);
        }

    }
}
