using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //Acces bağlantı dosyaları


namespace Oda_Bilgisi_2
{
    public partial class Form1 : Form
    {
        //Veri Tabanı Değişkenlerini Tanımlama Bölümü
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=otel.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        //DataGridWiev de kayıtları listeleme bölümü
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from oda", baglanti);
            adtr.Fill(ds, "oda");
            dataGridView1.DataSource = ds.Tables["oda"];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                resim.Text = openFileDialog1.FileName;
                

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            resim.Text = pictureBox1.ImageLocation;
            if (sno.Text != "" && musteriadi.Text != "" && musterisoyadi.Text != "" && tc.Text != "" && telefon.Text != "" && yasadigisehir.Text != "" && kisisayisi.Text != "" && odano.Text != "" && giristarihi.Text != "" && cikistarihi.Text != "" && gunsayisi.Text != "" && fiyat.Text != "" && resim.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into oda(s_no,m_adi,m_soyadi,tc,telefon,y_sehir,k_sayisi,oda_no,g_tarihi,c_tarihi,g_sayisi,fiyat,resim) Values ('" + sno.Text + "','" + musteriadi.Text + "','" + musterisoyadi.Text + "','" + tc.Text + "','" + telefon.Text + "','" + yasadigisehir.Text + "','" + kisisayisi.Text + "','" + odano.Text + "','" + giristarihi.Text + "','" + cikistarihi.Text + "','" + gunsayisi.Text + "','" + fiyat.Text + "','" + resim.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
            adtr = new OleDbDataAdapter("SElect *from oda where s_no like '" + sno.Text + "%'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            adtr.Fill(ds, "oda");
            dataGridView1.DataSource = ds.Tables["oda"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete from oda where s_no=" + sno.Text + "";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update oda set m_adi='" + musteriadi.Text + "', m_soyadi='" + musterisoyadi.Text + "', tc='" + tc.Text + "', telefon='" + telefon.Text + "', y_sehir='" + yasadigisehir.Text + "', k_sayisi='" + kisisayisi.Text + "', oda_no='" + odano.Text + "', g_tarihi='" + giristarihi.Text + "', c_tarihi='" + cikistarihi.Text + "', g_sayisi='" + gunsayisi.Text + "', fiyat='" + fiyat.Text + "', resim='" + resim.Text + "' where s_no=" + sno.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            sno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            musteriadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            musterisoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            telefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            yasadigisehir.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kisisayisi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            odano.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            giristarihi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cikistarihi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            gunsayisi.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            fiyat.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            resim.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }
    }
}
