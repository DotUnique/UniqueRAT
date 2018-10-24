using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace Server
{
    public partial class Form1 : Form
    {
        private static int _PORT = 100;
        public static TcpListener _listener = new TcpListener(IPAddress.Any, _PORT);
        static TcpClient _client = default(TcpClient);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private static void Server()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
            try
            {
                _listener.Start();
                MessageBox.Show("Server Started");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

            while (true)
            {
                try
                {
                    _client = _listener.AcceptTcpClient();
                    byte[] receivedBuffer = new byte[1024];
                    NetworkStream stream = _client.GetStream();
                    stream.Read(receivedBuffer, 0, receivedBuffer.Length);

                    string msg = Encoding.ASCII.GetString(receivedBuffer, 0, receivedBuffer.Length);
                    MessageBox.Show(msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            }).Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
