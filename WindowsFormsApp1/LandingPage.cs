using RestAPI.Classes;
using System; 
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LandingPage : Form
    {

        public LandingPage()
        {
            InitializeComponent();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public async void GetFilteredNews(object sender, EventArgs e)
        {
            var collector = new DataCollector();
            var authorName = textBox1.Text;
            if(authorName == null)
            {
                var data = await collector.GetData();
                dataGridView1.DataSource = data;
            }
            else
            {
                var data = await collector.GetFilteredNews(authorName);
                dataGridView1.DataSource = data;
            }
        }

        private async void LandingPage_Load(object sender, EventArgs e)
        {
            var collector = new DataCollector();
            var data = await collector.GetData();
            dataGridView1.DataSource = data;
        }
    }
}
