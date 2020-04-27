using LibrarieModele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problema;
using NivelAccesDate;
using System.Collections;
using System.Text.RegularExpressions;

namespace AutomobileForms
{
    public partial class GestiuneAutomobileForm : Form
    {

        NivelAccesDate.IStocareData adminAutomobile = Problema.StocareFactory.GetAdministratorStocare();
        int NumarMasini = 0;
        int nrmasini;
        int ok = 0;
        int opt;
        Optiuni op;
        Automobile[] masini = new Automobile[100];
        

        private bool isCollapsed;
        public GestiuneAutomobileForm()
        {
            InitializeComponent();
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            masini = adminAutomobile.GetAutomobile(out nrmasini);
            NumarMasini = nrmasini;
            guna2TextBox11.ReadOnly = true;
            guna2TextBox12.ReadOnly = true;
            guna2TextBox13.ReadOnly = true;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel4.Text = "";
            if(ok!=1)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                foreach(Automobile s in masina)
                {
                    bunifuCustomLabel4.Text = bunifuCustomLabel4.Text + s.afisareconsola() + "\n";
                }

            }
            
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel4.Text = "";
            ok = 0;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            int ok = 1;
            if(guna2TextBox1.Text.Length<=1 || guna2TextBox1.Text.Length >= 25)
            {
                ok = 0;
                labeleroare.Text = labeleroare.Text + "Marca invalida!" + "\n";
            }
            if (guna2TextBox2.Text.Length <= 1 || guna2TextBox2.Text.Length >= 25)
            {
                ok = 0;
                labeleroare.Text = labeleroare.Text + "Marca invalida!" + "\n";
            }
            if (guna2TextBox3.Text.Length <= 1 || guna2TextBox3.Text.Length >= 25)
            {
                ok = 0;
                labeleroare.Text = labeleroare.Text + "Culoare invalida!" + "\n";
            }
            if (guna2TextBox4.Text.Length <= 1 || guna2TextBox4.Text.Length >= 25)
            {
                ok = 0;
                labeleroare.Text = labeleroare.Text + "Pret invalid!" + "\n";
            }
            if (guna2TextBox5.Text.Length < 1 || guna2TextBox5.Text.Length > 1)
            {
                ok = 0;
                labeleroare.Text = labeleroare.Text + "Clasa de buget invalida!" + "\n";
            }
            if(ok==0)
            {
                labeleroare.Text = labeleroare.Text + "Resetati si introduceti din nou";
            }
            if (ok == 1)
            {
                Automobile s = new Automobile(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, Convert.ToInt64(guna2TextBox4.Text), Convert.ToInt32(guna2TextBox5.Text));
                masini[NumarMasini] = s;
                Random rand = new Random();
                for (int i = 0; i < rand.Next(1, 5); i++)
                {
                    masini[NumarMasini].Opt = masini[NumarMasini].Opt | (Optiuni)Convert.ToInt32(rand.Next(1, 16));
                }
                NumarMasini++;
                adminAutomobile.AddAutomobil(masini, NumarMasini);
                label7.Text = "Comanda realizata cu succes!";
            }
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
            labeleroare.Text = "";
            label7.Text = "";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Height += 10;
                if (panel1.Size==panel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panel1.Height -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void dropdownmenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            label10.Text = "";
            label10.Text = "Marca:";
            opt = 1;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            label10.Text = "";
            label10.Text = "Model:";
            opt = 2;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            label10.Text = "";
            label10.Text = "Culoare:";
            opt = 3;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            label10.Text = "";
            label10.Text = "Pret:";
            opt = 4;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            label10.Text = "";
            label10.Text = "Clasa de buget:";
            opt = 5;
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "";
            if (opt==1)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();              
                string marc = guna2TextBox6.Text;
                marc = Regex.Replace(marc, @"\s", "");
                int k = 0;
                foreach (Automobile s in masina)
                {
                    s.Marca = Regex.Replace(s.Marca, @"\s", "");
                    if (s.Marca==marc)
                    {
                        bunifuCustomLabel5.Text =bunifuCustomLabel5.Text+ s.afisareconsola()+"\n";
                        k = 1;
                    }
                }
                if (k == 0)
                  bunifuCustomLabel5.Text = "Nu sunt optiuni disponibile!";                
            }
            if (opt == 2)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                string mod = guna2TextBox6.Text;
                mod = Regex.Replace(mod, @"\s", "");
                int k = 0;
                foreach (Automobile s in masina)
                {
                    s.Model = Regex.Replace(s.Model, @"\s", "");
                    if (s.Model == mod)
                    {
                        bunifuCustomLabel5.Text = bunifuCustomLabel5.Text + s.afisareconsola() + "\n";
                        k = 1;
                    }
                }
                if (k == 0)
                    bunifuCustomLabel5.Text = "Nu sunt optiuni disponibile!";
            }
            if (opt == 3)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                string cul = guna2TextBox6.Text;
                cul = Regex.Replace(cul, @"\s", "");
                int k = 0;
                foreach (Automobile s in masina)
                {
                    s.Culoare = Regex.Replace(s.Culoare, @"\s", "");
                    if (s.Culoare == cul)
                    {
                        bunifuCustomLabel5.Text = bunifuCustomLabel5.Text + s.afisareconsola() + "\n";
                        k = 1;
                    }
                }
                if (k == 0)
                    bunifuCustomLabel5.Text = "Nu sunt optiuni disponibile!";
            }
            if (opt == 4)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                string pret = guna2TextBox6.Text;
                pret = Regex.Replace(pret, @"\s", "");
                int pr = Convert.ToInt32(pret);
                int k = 0;
                foreach (Automobile s in masina)
                {             
                    if (s.Pret<=pr)
                    {
                        bunifuCustomLabel5.Text = bunifuCustomLabel5.Text + s.afisareconsola() + "\n";
                        k = 1;
                    }
                }
                if (k == 0)
                    bunifuCustomLabel5.Text = "Nu sunt optiuni disponibile!";
            }
            if (opt == 5)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                string buget = guna2TextBox6.Text;
                buget = Regex.Replace(buget, @"\s", "");
                ClasaBuget bg = (ClasaBuget)Convert.ToInt32(buget);
                int k = 0;
                foreach (Automobile s in masina)
                {
                    if (s.BugetClass == bg)
                    {
                        bunifuCustomLabel5.Text = bunifuCustomLabel5.Text + s.afisareconsola() + "\n";
                        op = s.Opt;
                        k = 1;
                    }
                }
                if (k == 0)
                    bunifuCustomLabel5.Text = "Nu sunt optiuni disponibile!";
            }
            guna2TextBox6.Text = "";
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel6.Text = "";
            guna2TextBox7.Text = Regex.Replace(guna2TextBox7.Text, @"\s", "");
            guna2TextBox8.Text = Regex.Replace(guna2TextBox8.Text, @"\s", "");
            int k = 0;
            if (guna2TextBox7.Text != "" && guna2TextBox8.Text != "")
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                foreach (Automobile s in masina)
                {
                    s.Marca = Regex.Replace(s.Marca, @"\s", "");
                    s.Model = Regex.Replace(s.Model, @"\s", "");
                    if (s.Marca.Equals(guna2TextBox7.Text) && s.Model.Equals(guna2TextBox8.Text))
                    {
                        bunifuCustomLabel6.Text = s.afisareconsola();
                        op = s.Opt;
                        guna2TextBox11.ReadOnly = false;
                        guna2TextBox12.ReadOnly = false;
                        guna2TextBox13.ReadOnly = false;
                        k = 1;
                       
                    }
                    else 
                        if(k==0)
                        bunifuCustomLabel6.Text = "Inregistrare inexistenta";
                }
            }
            else
                bunifuCustomLabel6.Text = "Completati toate campurile!";
        }

        private void guna2CircleButton7_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel8.Text = "";
            bunifuCustomLabel7.Text = "";
            int ok = 1;
           
            if (guna2TextBox11.Text.Length <= 1 || guna2TextBox11.Text.Length >= 25)
            {
                ok = 0;
                bunifuCustomLabel8.Text = bunifuCustomLabel8.Text + "Culoare invalida!" + "\n";
            }
            if (guna2TextBox12.Text.Length <= 1 || guna2TextBox12.Text.Length >= 25)
            {
                ok = 0;
                bunifuCustomLabel8.Text = bunifuCustomLabel8.Text + "Pret invalid!" + "\n";
            }
            if (guna2TextBox13.Text.Length < 1 || guna2TextBox13.Text.Length > 1)
            {
                ok = 0;
                bunifuCustomLabel8.Text = bunifuCustomLabel8.Text + "Clasa de buget invalida!" + "\n";
            }
            
            if (ok == 1 ) 
            {
                Automobile s = new Automobile();
                guna2TextBox7.Text = Regex.Replace(guna2TextBox7.Text, @"\s", "");
                s.Marca = guna2TextBox7.Text;
                guna2TextBox8.Text = Regex.Replace(guna2TextBox8.Text, @"\s", "");
                s.Model = guna2TextBox8.Text;
                guna2TextBox11.Text = Regex.Replace(guna2TextBox11.Text, @"\s", "");
                s.Culoare = guna2TextBox11.Text;
                guna2TextBox12.Text = Regex.Replace(guna2TextBox12.Text, @"\s", "");
                s.Pret = Convert.ToInt64(guna2TextBox12.Text);
                guna2TextBox13.Text = Regex.Replace(guna2TextBox13.Text, @"\s", "");
                int bugetc = Convert.ToInt32(guna2TextBox13.Text);
                ClasaBuget buget = (ClasaBuget)bugetc;
                s.BugetClass = buget;
                s.Opt = op;             
                adminAutomobile.UpdateAutomobil(s);
                bunifuCustomLabel7.Text = "Actualizare cu succes!";
            }
            else
                bunifuCustomLabel7.Text="Resetati si incercati din nou!";
        }

        private void guna2CircleButton8_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel8.Text = "";
            bunifuCustomLabel7.Text = "";
            bunifuCustomLabel6.Text = "";
            guna2TextBox11.Text = "";
            guna2TextBox12.Text = "";
            guna2TextBox13.Text = "";
            
        }

        private void guna2CircleButton9_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel6.Text = "";
            guna2TextBox7.Text = "";
            guna2TextBox8.Text = "";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton10_Click(object sender, EventArgs e)
        {
            guna2TextBox9.Text = Regex.Replace(guna2TextBox9.Text, @"\s", "");
            guna2TextBox10.Text = Regex.Replace(guna2TextBox10.Text, @"\s", "");
            int k = 0;
            int counter = 0;
            if (guna2TextBox9.Text != "" && guna2TextBox10.Text != "")
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                foreach (Automobile s in masina)
                {                  
                    s.Model = Regex.Replace(s.Model, @"\s", "");
                    if (s.Model.Equals(guna2TextBox9.Text)&&counter==0)
                    {
                        bunifuCustomLabel9.Text =  "Marca: " +s.Marca + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Model: "+s.Model + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Culoare: "+s.Culoare + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Pret: " + Convert.ToString(s.Pret) + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Clasa buget: " + Convert.ToString(s.BugetClass) + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Optiuni: " + Convert.ToString(s.Opt) + "\n";
                        counter++;
                        k = 1;

                    }
                    if (s.Model.Equals(guna2TextBox9.Text) && counter == 1)
                    {
                        bunifuCustomLabel10.Text = "Marca: " + s.Marca + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Model: " + s.Model + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Culoare: " + s.Culoare + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Pret: " + Convert.ToString(s.Pret) + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Clasa buget: " + Convert.ToString(s.BugetClass) + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Optiuni: " + Convert.ToString(s.Opt) + "\n";
                        k = 1;

                    }
                    if (s.Model.Equals(guna2TextBox10.Text) && counter == 0)
                    {
                        bunifuCustomLabel9.Text = "Marca: " + s.Marca + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Model: " + s.Model + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Culoare: " + s.Culoare + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Pret: " + Convert.ToString(s.Pret) + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Clasa buget: " + Convert.ToString(s.BugetClass) + "\n";
                        bunifuCustomLabel9.Text = bunifuCustomLabel9.Text + "Optiuni: " + Convert.ToString(s.Opt) + "\n";
                        counter++;
                        k = 1;
                    }
                    if (s.Model.Equals(guna2TextBox10.Text) && counter == 1)
                    {
                        bunifuCustomLabel10.Text =  "Marca: " + s.Marca + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Model: " + s.Model + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Culoare: " + s.Culoare + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Pret: " + Convert.ToString(s.Pret) + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Clasa buget: " + Convert.ToString(s.BugetClass) + "\n";
                        bunifuCustomLabel10.Text = bunifuCustomLabel10.Text + "Optiuni: " + Convert.ToString(s.Opt) + "\n";
                        k = 1;
                    }
                }
                if (k == 0)
                    bunifuCustomLabel11.Text = "Inregistrare inexistenta";
            }
            else
                bunifuCustomLabel11.Text = "Completati toate campurile!";
        }

        private void guna2CircleButton11_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel10.Text = "";
            bunifuCustomLabel11.Text = "";
            bunifuCustomLabel9.Text = "";
            guna2TextBox9.Text = "";
            guna2TextBox10.Text = "";
        }

        private void guna2CircleButton12_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel4.Text = "";
            if (ok != 1)
            {
                ArrayList masina = adminAutomobile.GetAutomobile();
                foreach (Automobile s in masina)
                {
                    bunifuCustomLabel4.Text = bunifuCustomLabel4.Text + s.afisareconsolalei() + "\n";
                }

            }
        }
    }
}
