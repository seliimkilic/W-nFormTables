using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CevikMetalForm.Models.db;

namespace CevikMetalForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using var db = new CevikDBContext();

            var tablo = from st in db.SistemTablos
                        join u in db.UrunTablos on st.UrunId equals u.Id
                        join s in db.StokTablos on st.StokId equals s.Id
                        join p in db.PersonelTablos on st.PersonelId equals p.Id
                        join f in db.FirmaTablos on st.FirmaId equals f.Id
                        select new
                        {
                            UrunId = u.Id,
                            UrunAd = u.UrunAdı,
                            UrunMarka = u.UrunMarka,
                            UrunFiyat = u.UrunFiyatı,
                            UrunTipi = u.UrunTıpı,
                            StokAdet = s.StokAdeti,
                            Personel = p.PersonelAdSoyad,
                            Firma = f.Musteri,
                            SatınAlınanMiktar = st.SatınAlınanMiktar,
                            OdenenMiktar = st.OdenenMiktar
                        };

            if (tablo !=null)
            {
                if (tablo.Count()>0)
                {
                    dataGridView1.DataSource = tablo.ToList();
                    

                }
                else
                {
                    MessageBox.Show("Veri Bulunamadı");
                }

            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                
                if (dataGridView1.Rows[i].Cells["UrunTipi"].Value.ToString()=="Tedarik")
                {
                    dataGridView1.Rows[i].Cells["UrunTipi"].Style.BackColor=Color.Red;
                    dataGridView1.Rows[i].Cells["urunTipi"].Style.ForeColor=Color.White;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["UrunTipi"].Style.BackColor=Color.Green;
                    dataGridView1.Rows[i].Cells["UrunTipi"].Style.ForeColor=Color.Orange;
                }
            }
        }
    }
}
