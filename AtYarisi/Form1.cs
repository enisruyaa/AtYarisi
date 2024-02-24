using AtYarisi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random hileYakalanmaSansi = new Random();
        Random arkaPlan = new Random();
        Random mafyaSansi = new Random();
        decimal OyunBakiyesi = 500, BankaBakiyesi = 500, bahis = 0, yatirilacakPara;

        int arkaPlanSayisi, kimeBahisYapildi, turSayaci;

        bool oyunBasladiMi, bankadanParaCekildiMi;
        At Golge = new At();
        At Gunbatimi = new At();
        At Ruzgar = new At();

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            try
            {
                bankadanParaCekildiMi = false;
                decimal cekilecekPara = Convert.ToDecimal(txtMiktar.Text);
                if (cekilecekPara > OyunBakiyesi)
                {
                    MessageBox.Show("Oyun İçerisinde Yeterli Paranız Yok");
                }
                else
                {
                    BankaBakiyesi += cekilecekPara;
                    OyunBakiyesi -= cekilecekPara;
                    lblOyun.Text = OyunBakiyesi.ToString();
                    lblBanka.Text = BankaBakiyesi.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            try
            {
                bankadanParaCekildiMi = true;
                yatirilacakPara = Convert.ToDecimal(txtMiktar.Text);
                if (yatirilacakPara > BankaBakiyesi)
                {
                    MessageBox.Show(" Banka Hesabınızda Yeterli Para Yok");
                }
                else
                {
                    BankaBakiyesi -= yatirilacakPara;
                    OyunBakiyesi += yatirilacakPara;
                    lblOyun.Text = OyunBakiyesi.ToString();
                    lblBanka.Text = BankaBakiyesi.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGolge_Click(object sender, EventArgs e)
        {
            decimal yatirilanBahisMiktari = Convert.ToDecimal(txtBahisMiktari.Text);
            if (yatirilanBahisMiktari > OyunBakiyesi)
            {
                MessageBox.Show("Oyun İçerisindeki Bakiyeniz Yetersiz");
            }
            else
            {
                kimeBahisYapildi = 1;
                turSayaci = 0;
                OyunBakiyesi -= yatirilanBahisMiktari;
                lblOyun.Text = OyunBakiyesi.ToString();
                bahis = yatirilanBahisMiktari;
            }
        }

        private void btnGunBatimi_Click(object sender, EventArgs e)
        {
            decimal yatirilanBahisMiktari = Convert.ToDecimal(txtBahisMiktari.Text);
            if (yatirilanBahisMiktari > OyunBakiyesi)
            {
                MessageBox.Show("Oyun İçerisindeki Bakiyeniz Yetersiz");
            }
            else
            {
                kimeBahisYapildi = 2;
                OyunBakiyesi -= yatirilanBahisMiktari;
                lblOyun.Text = OyunBakiyesi.ToString();
                bahis = yatirilanBahisMiktari;
            }
        }

        private void btnRuzgar_Click(object sender, EventArgs e)
        {
            decimal yatirilanBahisMiktari = Convert.ToDecimal(txtBahisMiktari.Text);
            if (yatirilanBahisMiktari > OyunBakiyesi)
            {
                MessageBox.Show("Oyun İçerisindeki Bakiyeniz Yetersiz");
            }
            else
            {
                kimeBahisYapildi = 3;
                OyunBakiyesi -= yatirilanBahisMiktari;
                lblOyun.Text = OyunBakiyesi.ToString();
                bahis = yatirilanBahisMiktari;
            }
        }

        private void pbGolge_MouseEnter(object sender, EventArgs e)// Bu kısım hile kısmı eğer oyun başladıysa adam mousesini ata getirecek ve at hızlanacak  %80 ihtimalle yakalanma şansı var yakalanırsa da cüzdanındaki tüm bakiye sıfırlanacak
        {
            if (oyunBasladiMi == true) // Oyun Başladıysa kodumuz çalışacak
            {
                pbGolge.Left += 200;
                if (hileYakalanmaSansi.Next(1, 3) == 1)
                {
                    MessageBox.Show("Hile Tepit Edildi \n Tüm Paranıza El Konuldu");
                    OyunBakiyesi = 0;
                    lblOyun.Text = OyunBakiyesi.ToString();
                }
            }
        }

        private void pbGunBatimi_MouseEnter(object sender, EventArgs e)
        {
            if (oyunBasladiMi == true) // Oyun Başladıysa kodumuz çalışacak
            {
                pbGunBatimi.Left += 200;
                if (hileYakalanmaSansi.Next(1, 3) == 1)
                {
                    MessageBox.Show("Hile Tepit Edildi \n Tüm Paranıza El Konuldu");
                    OyunBakiyesi = 0;
                    lblOyun.Text = OyunBakiyesi.ToString();
                }
            }
        }

        private void pbRuzgar_MouseEnter(object sender, EventArgs e)
        {
            if (oyunBasladiMi == true) // Oyun Başladıysa kodumuz çalışacak
            {
                pbRuzgar.Left += 200;
                if (hileYakalanmaSansi.Next(1, 3) == 1)
                {
                    MessageBox.Show("Hile Tepit Edildi \n Tüm Paranıza El Konuldu");
                    OyunBakiyesi = 0;
                    lblOyun.Text = OyunBakiyesi.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblOyun.Text = OyunBakiyesi.ToString();
            lblBanka.Text = BankaBakiyesi.ToString();
            lblSakatlanma.Text = "  ";
        }

        public void GolgeKazanincaUygula()
        {
            if (pbGolge.Right >= lblFinish.Left)
            {
                if (kimeBahisYapildi == 1)
                {
                    ///int randomMafya = mafyaSansi.Next(1,11);
                    if (Convert.ToInt32(mafyaSansi.Next(1, 11)) == 1)
                    {
                        int sonBakiye = Convert.ToInt32(lblOyun.Text) - Convert.ToInt32(txtBahisMiktari.Text);
                        lblOyun.Text = sonBakiye.ToString();
                    }
                    if (BackColor == Color.ForestGreen)
                    {
                        bahis += (bahis * 40) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else if (BackColor == Color.White)
                    {
                        bahis += (bahis * 60) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else
                    {
                        bahis += (bahis * 60) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                }



                timer1.Stop();
                oyunBasladiMi = false;
                DialogResult dr = MessageBox.Show("Yarış'ı Gölge Kazandı!! \n Tekrar Oynamak İster Misiniz ? ", "Gölge Yandı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {

                    arkaPlanSayisi = arkaPlan.Next(1, 4);
                    switch (arkaPlanSayisi)
                    {
                        case 1: // Arka plan rengi kahve rengi olacak ve gün batımı favori at olacak
                            BackColor = Color.Brown;
                            ForeColor = Color.White;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbGunBatimi.Left = Gunbatimi.Hizi.Next(6, 21); // favori olduğu için hızı arttı                   
                            break;

                        case 2: // Arla plan rengi beyaz olacak ve Rüzgar favori at olacak
                            BackColor = Color.White;
                            ForeColor = Color.Black;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbRuzgar.Left = Ruzgar.Hizi.Next(6, 21);
                            break;

                        case 3: // Arka plan rengi yeşil olacak ve Gölge favori at olacak
                            BackColor = Color.ForestGreen;
                            pbGolge.Left = Golge.Hizi.Next(6, 21);
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            break;
                    }

                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void GunBatimiKazanincaUygula()
        {
            if (pbGunBatimi.Right >= lblFinish.Left) // Kahvrenginde favori
            {
                if (kimeBahisYapildi == 2)
                {
                    mafyaSansi.Next(1, 11); // mafyanın gelme olasılığını %10 yaptık

                    if (Convert.ToInt32(mafyaSansi.Next(1, 11)) == 1)
                    {
                        int sonBakiye = Convert.ToInt32(lblOyun.Text) - Convert.ToInt32(txtBahisMiktari.Text);
                        lblOyun.Text = sonBakiye.ToString();
                    }

                    if (BackColor == Color.ForestGreen)
                    {
                        bahis += (bahis * 60) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else if (BackColor == Color.White)
                    {
                        bahis = (bahis * 60) / 100 + bahis;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else
                    {
                        bahis += (bahis * 40) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                }


                timer1.Stop();
                oyunBasladiMi = false;
                DialogResult dr = MessageBox.Show("Yarısı Günbatımı kazanarak günü ismine layık bir şekilde sonlandırdı", "Günbattı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {

                    arkaPlanSayisi = arkaPlan.Next(1, 4);
                    switch (arkaPlanSayisi)
                    {
                        case 1: // Arka plan rengi kahve rengi olacak ve gün batımı favori at olacak
                            BackColor = Color.Brown;
                            ForeColor = Color.White;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbGunBatimi.Left = Gunbatimi.Hizi.Next(6, 21); // favori olduğu için hızı arttı                   
                            break;

                        case 2: // Arla plan rengi beyaz olacak ve Rüzgar favori at olacak
                            BackColor = Color.White;
                            ForeColor = Color.Black;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbRuzgar.Left = Ruzgar.Hizi.Next(6, 21);
                            break;

                        case 3: // Arka plan rengi yeşil olacak ve Gölge favori at olacak
                            BackColor = Color.ForestGreen;
                            pbGolge.Left = Golge.Hizi.Next(6, 21);
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            break;
                    }

                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public void RuzgarKazanincaUygula()
        {
            if (pbRuzgar.Right >= lblFinish.Left && pbGunBatimi.Right < pbRuzgar.Right && pbGolge.Right < pbRuzgar.Right)
            {
                if (kimeBahisYapildi == 3)
                {
                    mafyaSansi.Next(1, 11); // mafyanın gelme olasılığını %10 yaptık

                    if (Convert.ToInt32(mafyaSansi.Next(1, 11)) == 1)
                    {
                        int sonBakiye = Convert.ToInt32(lblOyun.Text) - Convert.ToInt32(txtBahisMiktari.Text);
                        lblOyun.Text = sonBakiye.ToString();
                    }

                    if (BackColor == Color.ForestGreen)
                    {
                        bahis += (bahis * 60) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else if (BackColor == Color.White)
                    {
                        bahis += (bahis * 40) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                    else
                    {
                        bahis += (bahis * 60) / 100;
                        OyunBakiyesi += bahis;
                        lblOyun.Text = OyunBakiyesi.ToString();
                        kimeBahisYapildi = 0;
                    }
                }



                timer1.Stop();
                oyunBasladiMi = false;
                DialogResult dr = MessageBox.Show("Yarısı Rüzgar kazandı!!!\nTekrar oynamak ister misiniz?", "Rüzgar esti", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {

                    arkaPlanSayisi = arkaPlan.Next(1, 4);
                    switch (arkaPlanSayisi)
                    {
                        case 1: // Arka plan rengi kahve rengi olacak ve gün batımı favori at olacak
                            BackColor = Color.Brown;
                            ForeColor = Color.White;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbGunBatimi.Left = Gunbatimi.Hizi.Next(6, 21); // favori olduğu için hızı arttı                   
                            break;

                        case 2: // Arla plan rengi beyaz olacak ve Rüzgar favori at olacak
                            BackColor = Color.White;
                            ForeColor = Color.Black;
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            pbRuzgar.Left = Ruzgar.Hizi.Next(6, 21);
                            break;

                        case 3: // Arka plan rengi yeşil olacak ve Gölge favori at olacak
                            BackColor = Color.ForestGreen;
                            pbGolge.Left = Golge.Hizi.Next(6, 21);
                            pbGolge.Left = pbRuzgar.Left = pbGunBatimi.Left = 0;
                            break;
                    }

                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Golge.Resmi = pbGolge;
            Gunbatimi.Resmi = pbGunBatimi;
            Ruzgar.Resmi = pbRuzgar;
            pbGolge.Left += Golge.Hizi.Next(5, 20);
            pbGunBatimi.Left += Gunbatimi.Hizi.Next(5, 20);
            pbRuzgar.Left += Ruzgar.Hizi.Next(5, 20);
            GunBatimiKazanincaUygula();
            GolgeKazanincaUygula();
            RuzgarKazanincaUygula();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (bankadanParaCekildiMi == true)
            {
                turSayaci++;
                Text = turSayaci.ToString();
                if (turSayaci == 10)
                {
                    MessageBox.Show("lütfen ödeme yapın \n Eğer ödeme yapmazsanız 2 tur sonra hesabınızdan para çekilecek");
                }
                else if (turSayaci >= 12)
                {
                    yatirilacakPara += yatirilacakPara * 5 / 100;
                    decimal faizliPara = yatirilacakPara;
                    decimal sonOyunBakiyesi = Convert.ToDecimal(lblOyun.Text) - faizliPara;
                    lblOyun.Text = sonOyunBakiyesi.ToString();
                    lblBanka.Text += sonOyunBakiyesi.ToString();
                }
            }
            timer1.Start();
            oyunBasladiMi = true;
        }

    }
}
