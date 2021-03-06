﻿using System;
using System.Windows.Forms;
using UIA.Extensions;

namespace WindowsForms
{
    public partial class MainFormWindow : Form
    {
        public MainFormWindow()
        {
            InitializeComponent();
            numericUpDown1.AsRangeValue();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxLabel.Text = checkBox.Checked ? "checkBox is on" : "checkBox is off";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = "Option 1 selected";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonLabel.Text = "Option 2 selected";
        }

        private void radioButtonReset_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButtonLabel.Text = "No option selected";
        }

        private void FruitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fruitsLabel.Text = FruitsComboBox.Text;
        }

        private void nextFormButton_Click(object sender, EventArgs e)
        {
            var form = new DataEntryForm();
            form.Show();
        }

        private void buttonButton_Click(object sender, EventArgs e)
        {
            var buttonForm = new SimpleElementsForm();
            buttonForm.Show();
        }

        private void automatableMonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private int _clickCount;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Text = string.Format("{0} (clicked {1} times)", linkLabel1.Name, ++_clickCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new DataGridViewForm().Show();
        }

        private void toggleMultiSelect_Click(object sender, EventArgs e)
        {
            FruitListBox.SelectionMode = (FruitListBox.SelectionMode == SelectionMode.One)
                                             ? SelectionMode.MultiExtended
                                             : SelectionMode.One;
        }

        private void FruitListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fruitsLabel.Text = FruitListBox.SelectedItem.ToString();
        }
    }
}
