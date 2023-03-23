using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prroxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDatabase database = new DatabaseProxy(false);

            database.Query("SELECT * FROM users"); // 
            database.Query("INSERT INTO users (name, email) VALUES ('example', 'example@example.com')"); 

            IDatabase databaseAdmin = new DatabaseProxy(true);

            databaseAdmin.Query("SELECT * FROM users"); 
            databaseAdmin.Query("INSERT INTO users (name, email) VALUES ('example', 'example@example.com')"); 
        }
    }
}
