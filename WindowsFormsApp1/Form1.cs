using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Yukle();

        }

        private void Yukle()
        {
            listBox1.Items.Clear();
            //shipper select 
            NorthwindEntities db = new NorthwindEntities();
            foreach (Shipper item in db.Shippers.ToList())
            {
                listBox1.Items.Add(item);
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            db.Categories.Add(new Category()
            {
                CategoryName = "hedebidi midi",
                Description = "asdasdasd",
                AktifMi = false
            });

            db.Shippers.Add(new Shipper()
            {
                CompanyName = textBox1.Text,
                Phone = maskedTextBox1.Text
            });
            MessageBox.Show(db.SaveChanges() > 0 ? "eklendi" : "hata oluştu");
            Yukle();
            Temizle();

        }

        private void Temizle()
        {
            textBox1.Text = maskedTextBox1.Text = string.Empty;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //update    where 

            NorthwindEntities db = new NorthwindEntities();
            var deger = db.Shippers.Where(a => a.ShipperID == tiklanilanShipper.ShipperID).SingleOrDefault();

            deger.CompanyName = textBox1.Text;
            deger.Phone = maskedTextBox1.Text;
            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("guncellendi.");
                Yukle();
                Temizle();
            }
            else
            {
                MessageBox.Show("hata var");
                Temizle();
            }


        }
        Shipper tiklanilanShipper;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region MyRegion
            // //object   boxing unboxing 

            // //Boxing
            // object veri = 52.5M;
            // //unboxing
            // var deger01 = (decimal)veri;
            //var deger2 = deger01 + 2M;

            // object veri55 = "melike";


            // object ver02 = 88.0f;
            // object veri03 = new Shipper(); 
            #endregion

            tiklanilanShipper = listBox1.SelectedItem as Shipper;

            textBox1.Text = tiklanilanShipper.CompanyName;
            maskedTextBox1.Text = tiklanilanShipper.Phone;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {

                Shipper dbDekiShipper = db.Shippers.Find(tiklanilanShipper.ShipperID);
                db.Shippers.Remove(dbDekiShipper);
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Silindi");
                    Yukle(); Temizle();
                }
                else
                {
                    MessageBox.Show("hata var"); Temizle();
                }
            }
        }
    }
}
