using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremierLeagueManagerApp
{
    public partial class Form1 : Form
    {
        private Label lblTeamInfo;

        public Form1()
        {
            InitializeComponent();

            // Initialize lblTeamInfo here
            lblTeamInfo = new Label
            {
                Location = new System.Drawing.Point(10, 10), // Example position
                Size = new System.Drawing.Size(200, 30),     // Example size
                Text = "Loading..."
            };
            this.Controls.Add(lblTeamInfo); // Add the label to the form

            // Assign the event handler correctly
            this.Btn1Clicks.Click += new System.EventHandler(this.Btn1Click);
        }

        public async Task<string> GetTeamInfoAsync()
        {
            var client = new HttpClient();
            var requestUrl = "https://fantasy.premierleague.com/api/bootstrap-static/";
            var response = await client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async void Btn1Click(object sender, EventArgs e)
        {
            try
            {
                string teamInfo = await GetTeamInfoAsync();
                lblTeamInfo.Text = teamInfo; // Display the fetched data in lblTeamInfo
            }
            catch (Exception ex)
            {
                lblTeamInfo.Text = "Error fetching data: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
