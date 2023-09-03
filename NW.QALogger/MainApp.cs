using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NW.QALogger
{
    public partial class MainApp : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private Color targetColor;
        private int step = 5;
        private string selectedItem;
        private bool resetConfirmedCount = false;

        public MainApp()
        {
            InitializeComponent();

            random = new Random();
            targetColor = GenerateRandomColor();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;

            listBox1.SelectionMode = SelectionMode.One;

            DateTime currentDate = DateTime.Now;
            DateTime lastDate = Properties.Settings.Default.LastDate;

            if (currentDate.Date.Day == 1 && currentDate.Date != lastDate.Date)
            {
                Properties.Settings.Default.ConfirmedCount = 0;
                Properties.Settings.Default.QARequestCount = 0;
            }

            textBox2.Text = Properties.Settings.Default.UserName;
            button2.Click += new EventHandler(this.button2_Click);

            Properties.Settings.Default.LastDate = currentDate.Date;
            Properties.Settings.Default.Save();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Color currentColor = label1.ForeColor;
            int r = MoveTowards(currentColor.R, targetColor.R);
            int g = MoveTowards(currentColor.G, targetColor.G);
            int b = MoveTowards(currentColor.B, targetColor.B);

            label1.ForeColor = Color.FromArgb(r, g, b);

            if (currentColor == targetColor)
            {
                targetColor = GenerateRandomColor();
            }
        }

        private Color GenerateRandomColor()
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private int MoveTowards(int current, int target)
        {
            if (current < target)
            {
                return Math.Min(current + step, target);
            }
            else if (current > target)
            {
                return Math.Max(current - step, target);
            }
            else
            {
                return current;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                selectedItem = listBox1.SelectedItem.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Please select only one option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Please select only one option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox2.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //nothing here :)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //nothing here :)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //nothing here :)
        }

        private string previousMessageLink = "";

        private async void button1_Click(object sender, EventArgs e)
        {
            if (resetConfirmedCount)
            {
                resetConfirmedCount = false;
                return;
            }

            if (!checkBox3.Checked)
            {
                if (selectedItem == null)
                {
                    MessageBox.Show("Please select in which channel it is located.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Please enter a link to the message of the request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!checkBox3.Checked && textBox1.Text != previousMessageLink)
            {
                Properties.Settings.Default.ConfirmedCount++;
            }

            string webhookUrl = "https://discord.com/api/webhooks/1147200680537362495/wP5JtVwOsoFyo5j_LkdfPzReZojzTNLng-u6w1Ep4QAvWWqsnf1TS48IhyhGk0s-Fdvi";

            string reaction = checkBox1.Checked ? "✅" : (checkBox2.Checked ? "❌" : "");

            Properties.Settings.Default.UserName = textBox2.Text;
            Properties.Settings.Default.Save();

            string title = "Logged-Ticket";
            string description = $"Channel: {selectedItem}\nReacted: {reaction}";
            string footerText = $"Confirmed: {Properties.Settings.Default.ConfirmedCount}";

            if (checkBox3.Checked)
            {
                title = "QA-Request";
                description = $"Reacted: {reaction}";
                footerText = $"Confirmed QA requests: {Properties.Settings.Default.QARequestCount}";
                Properties.Settings.Default.QARequestCount++;
            }

            string content = JsonConvert.SerializeObject(new
            {
                content = " ",
                embeds = new[]
                {
            new
            {
                author = new
                {
                    name = $"Logged by: {Properties.Settings.Default.UserName}"
                },
                title = title,
                description = description,
                url = textBox1.Text,
                color = 0xFF0000,
                footer = new
                {
                    text = footerText
                }
            }
        }
            });

            using (HttpClient client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(webhookUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Message sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    previousMessageLink = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Error sending message: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConfirmedCount = 0;
            Properties.Settings.Default.Save();
            resetConfirmedCount = true;
        }
    }
}