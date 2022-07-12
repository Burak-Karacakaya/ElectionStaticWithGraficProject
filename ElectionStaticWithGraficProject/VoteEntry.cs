using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ElectionStaticWithGraficProject
{
    

    public partial class Election : Form
    {
        public Election()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ElectionStatic;Integrated Security=True");

        private void btnVoteEntry_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("insert into Communities(TownName, Community1, Community2, Community3, Community4, Community5) values (@p1, @p2, @p3, @p4, @p5, @p6)", sqlConnection);
            command.Parameters.AddWithValue("@p1", townName.Text);
            command.Parameters.AddWithValue("@p2", txt1.Text);
            command.Parameters.AddWithValue("@p3", txt2.Text);
            command.Parameters.AddWithValue("@p4", txt3.Text);
            command.Parameters.AddWithValue("@p5", txt4.Text);
            command.Parameters.AddWithValue("@p6", txt5.Text);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Vote Entry Success.");



        }

        private void btnGrafics_Click(object sender, EventArgs e)
        {
            Grafics grafics = new Grafics();
            grafics.Show();
        }

       
    }
}
