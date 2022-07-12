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
    public partial class Grafics : Form
    {
        public Grafics()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ElectionStatic;Integrated Security=True");
        private void Grafics_Load(object sender, EventArgs e)
        {
            // Get Town Name For Choose Town ComboBox
            sqlConnection.Open();
            SqlCommand command1 = new SqlCommand("Select TownName from Communities", sqlConnection);

            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                chooseTownBox.Items.Add(reader1[0]);
            }
            sqlConnection.Close();

            //Get Total Vote for Grafics
            sqlConnection.Open();
            SqlCommand command2 = new SqlCommand("Select SUM(Community1), SUM(Community2), SUM(Community3), SUM(Community4), SUM(Community5) From Communities", sqlConnection);
            
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                chart1.Series["Communities"].Points.AddXY("Com 1", reader2[0]);
                chart1.Series["Communities"].Points.AddXY("Com 2", reader2[1]);
                chart1.Series["Communities"].Points.AddXY("Comy 3", reader2[2]);
                chart1.Series["Communities"].Points.AddXY("Com 4", reader2[3]);
                chart1.Series["Communities"].Points.AddXY("Com 5", reader2[4]);

            }
            sqlConnection.Close();
            
        }

        private void chooseTownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From Coummunities where TownName=@p1", sqlConnection);
            command.Parameters.AddWithValue("@p1", chooseTownBox.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                progressBar1.Value = int.Parse(reader[2].ToString());
                progressBar2.Value = int.Parse(reader[3].ToString());
                progressBar3.Value = int.Parse(reader[4].ToString());
                progressBar4.Value = int.Parse(reader[5].ToString());
                progressBar5.Value = int.Parse(reader[6].ToString());

                lbl1.Text = reader[2].ToString();
                lbl2.Text = reader[3].ToString();
                lbl3.Text = reader[4].ToString();
                lbl4.Text = reader[5].ToString();
                lbl5.Text = reader[6].ToString();
            }
        }
    }
}
