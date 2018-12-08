using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.ShowDialog();

            localhost.Servico service = new localhost.Servico();

            System.IO.FileStream fileStream = System.IO.File.Open(openFile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            byte[] arquivoByte = new byte[fileStream.Length];

            fileStream.Read(arquivoByte, 0, Convert.ToInt32(fileStream.Length));

            fileStream.Close();

           String resultado = service.UploadArquivo(openFile.SafeFileName, arquivoByte);

           MessageBox.Show(resultado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            localhost.Servico service = new localhost.Servico();

            byte[] arquivo = service.DownloadArquivo(textBox1.Text);


            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = textBox1.Text;
            saveFileDialog.ShowDialog();

            System.IO.File.WriteAllBytes(saveFileDialog.FileName, arquivo);
        }
    }
}
