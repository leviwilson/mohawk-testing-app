using System;
using System.Windows.Forms;
using FizzWare.NBuilder;

namespace WindowsForms
{
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            var dataSource = new BindingSource();
            foreach (var person in Builder<DataEntryForm.Person>.CreateListOfSize(50).Build())
            {
                dataSource.Add(person);
            }

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataSource;
        }
    }
}
