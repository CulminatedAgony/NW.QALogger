using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace NW.QALogger
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        private Color targetColor;
        private int step = 5;
        private string selectedItem;

        public Form1()
        {
            InitializeComponent();

            random = new Random();
            targetColor = GenerateRandomColor();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;

            listBox1.SelectionMode = SelectionMode.One;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an item from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a message in the text box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string webhookUrl = "your_webhook_url_here";

            string reaction = checkBox1.Checked ? "✅" : (checkBox2.Checked ? "❌" : "");
            string content = JsonConvert.SerializeObject(new
            {
                content = " ",
                embeds = new[]
                {
            new
            {
                title = "New Message",
                description = $"Channel: {selectedItem}\nMessage: {textBox1.Text}\nReacted: {reaction}",
                color = 0xFF0000,
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
                }
                else
                {
                    MessageBox.Show("Error sending message: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}