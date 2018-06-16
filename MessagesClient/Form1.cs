using MessagesClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagesClient
{
    public partial class Form1 : Form
    {
        HttpClient client;
        const string apiUrl = "http://localhost:51985/api/MessageDict";
        List<MessageModel> messagesList;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
            messagesList = new List<MessageModel>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshListAsync("/GetAllDict");
        }

        private async Task RefreshListAsync(string action)
        {
            var uri = new Uri(string.Format(apiUrl + action, String.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                messagesList = JsonConvert.DeserializeObject<List<MessageModel>>(content);
                listBox1.DataSource = messagesList.Select(x => x.recipient).ToList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var message = messagesList.Where(x => x.recipient == listBox1.SelectedItem.ToString()).FirstOrDefault();
            label7.Text = message.id.ToString();
            textBox1.Text = message.recipient;
            textBox2.Text = message.content;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchAsync();
        }

        private async Task SearchAsync()
        {
            var body = new MessageModel();

            if (!String.IsNullOrEmpty(textBox3.Text))
                body.recipient = textBox3.Text;

            if (!String.IsNullOrEmpty(textBox4.Text))
                body.content = textBox4.Text;

            var uri = new Uri(string.Format(apiUrl + "/search", string.Empty));

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<MessageModel>>(responseContent);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"TodoItem successfully saved.");
            }

            listBox1.DataSource = result.ToList();
        }
    }
}
