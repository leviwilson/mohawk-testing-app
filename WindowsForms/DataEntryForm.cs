using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FizzWare.NBuilder;

namespace WindowsForms
{
    public partial class DataEntryForm : Form
    {
        private RandomGenerator _generator;

        public DataEntryForm()
        {
            InitializeComponent();
        }

        private void closeDataEntryFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm(this);
            personForm.Show();
        }

        public void addPerson(String personName, String dateOfBirth)
        {
            ListViewItem newItem = new ListViewItem(personName);
            newItem.SubItems.Add(dateOfBirth);
            personListView.Items.Add(newItem);
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in personListView.SelectedItems)
            {
                personListView.Items.Remove(item);
            }
        }

        public class Person
        {
            public string Name { get; set; }  
            public string DateOfBirth { get; set; }  
            public string State { get; set; }  
        }

        private RandomGenerator generator
        {
            get
            {
                if (null == _generator)
                {
                    _generator = new RandomGenerator();
                }

                return _generator;
            }
        }

        private string RandomName
        {
            get { return generator.Phrase(6) + " " + generator.Phrase(8); }
        }

        private string RandomDate
        {
            get { return generator.DateTime().ToShortDateString(); }
        }

        private string RandomState
        {
            get { return generator.Phrase(50).Substring(0, 2).ToUpper(); }
        }


        private void addLotsOfThings_Click(object sender, EventArgs e)
        {
            var people = Builder<Person>
                .CreateListOfSize(50)
                .All()
                .With(x => x.Name = RandomName)
                .With(x => x.DateOfBirth = RandomDate)
                .With(x => x.State = RandomState)
                .Build();

            foreach(var person in people)
            {
                var personItem = new ListViewItem(person.Name);
                personItem.SubItems.Add(person.DateOfBirth);
                personItem.SubItems.Add(person.State);
                personListView.Items.Add(personItem);
            }
        }

    }
}
