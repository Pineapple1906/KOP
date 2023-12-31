﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLibrary1
{
    public partial class MyCheckedListBox : UserControl
    {
        private int checkI = -1;
        private event EventHandler _event;
        public MyCheckedListBox()
        {
            InitializeComponent();
            checkedListBox1.SelectedIndexChanged += (sender, e) => _event?.Invoke(sender, e);
        }
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                _event += value;
            }
            remove
            {
                _event -= value;
            }
        }
        public void AddItem(string text)
        {
            checkedListBox1.Items.Add(text);
        }
        public void CleatItems()
        {
            checkedListBox1.Items.Clear();
        }
        public string SelectedElement
        {
            get
            {
                if (checkedListBox1.SelectedItem == null)
                {
                    return string.Empty;
                }
                return checkedListBox1.SelectedItem.ToString();
            }
            set
            {
                if (checkedListBox1.SelectedItems.Contains(value))
                {
                    checkedListBox1.SelectedItem = value;
                }
                else
                {
                    checkedListBox1.SelectedIndex = -1;
                }
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkI != checkedListBox1.SelectedIndex && checkI != -1)
            {
                checkedListBox1.SetItemChecked(checkI, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }
    }
}
