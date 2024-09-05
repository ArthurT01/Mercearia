using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercearia
{

    public partial class Form1 : Form
    {
        double desc;
        double pix = 0.05;
        double cred = 0.05;
        double din = 0.08;
        double valor = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Irrelevante
        }

        //Função para somar
        public void soma()
        {
            
         
            if(chkRefrigerante.Checked)
            {
                valor += 8.90;
            }
            if(chkAzeite.Checked)
            {
                valor += 38.50;
            }
            if(chkBiscoitoDeChocolate.Checked)
            {
                valor += 3.50;
            }
            if(chkLeite.Checked)
            {
                valor += 4.99;
            }
            if(chkMacarrão.Checked)
            {
                valor += 2.30;
            }
            if(chkSucoDeLaranja.Checked)
            {
                valor += 5.75;
            }
            if(chkChocolateAoLeite.Checked)
            {
                valor += 6.50;
            }
            if(chkPãoDeForma.Checked)
            {
                valor += 3.20;
            }
            if(chkArroz.Checked)
            {
                valor += 10.75;
            }
            if(chkFeijão.Checked)
            {
                valor += 9.90;
            }
            if (rdbPix.Checked)
            {
                desc = (pix * valor);
                valor -= desc;

            }
            if(rdbCartãoDeCrédito.Checked)
            {
               desc = (cred * valor);
               valor += desc;     
            }
            if(rdbDinheiro.Checked)
            {
                desc = (din * valor);
                valor -= desc;  
            }
        }
        
        //Função para exibir os produtos comprados pelo o usúario e o valor total da compra
        public void notaFiscal()
        {
            List<CheckBox> chk = new List<CheckBox>();

            chk.Add(chkArroz);
            chk.Add(chkAzeite);
            chk.Add(chkBiscoitoDeChocolate);
            chk.Add(chkChocolateAoLeite);
            chk.Add(chkFeijão);
            chk.Add(chkLeite);
            chk.Add(chkMacarrão);
            chk.Add(chkPãoDeForma);
            chk.Add(chkRefrigerante);
            chk.Add(chkSucoDeLaranja);

            string notaFiscal = "";
            foreach(CheckBox c in chk)
            {
                if(c.Checked)
                {
                    notaFiscal += c.Text + " \n";
                }
            }

            var botao = MessageBox.Show("NOTA FISCAL: \n\n" + notaFiscal+ "\n\nTotal: " + valor.ToString("C"));
            
            if(botao == DialogResult.OK)//Reseta o valor total para não somar o total novo com o anterior
            {
                valor = 0;
                desc = 0;
                chkArroz.Checked = false;
                chkAzeite.Checked = false;
                chkBiscoitoDeChocolate.Checked = false;
                chkChocolateAoLeite.Checked = false;
                chkFeijão.Checked = false;
                chkLeite.Checked = false;
                chkMacarrão.Checked = false;
                chkPãoDeForma.Checked = false;
                chkRefrigerante.Checked = false;
                chkSucoDeLaranja.Checked = false;
                rdbCartãoDeCrédito.Checked = false;
                rdbDinheiro.Checked = false;
                rdbPix.Checked = false;
            }
        }


        private void btnPagar_Click(object sender, EventArgs e)
        {
            //Vê se o usúario selecionou algum produto
            if(!chkAzeite.Checked && !chkArroz.Checked && !chkBiscoitoDeChocolate.Checked && !chkChocolateAoLeite.Checked && !chkFeijão.Checked && !chkLeite.Checked && !chkMacarrão.Checked && !chkPãoDeForma.Checked && !chkRefrigerante.Checked && !chkSucoDeLaranja.Checked)
            {
                MessageBox.Show("Nenhum produto slecionado!");
            }
            else
            {
                //Vê se o usúario selecionou uma forma de pagamento
                if (!rdbCartãoDeCrédito.Checked && !rdbDinheiro.Checked && !rdbPix.Checked)
                {
                    MessageBox.Show("Nenhuma forma de pagamento selecionada!");
                }
                else
                {
                    soma();
                    notaFiscal();
                }
                
            }
           
                
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            chkArroz.Checked = false;
            chkAzeite.Checked = false;
            chkBiscoitoDeChocolate.Checked = false;
            chkChocolateAoLeite.Checked = false;
            chkFeijão.Checked = false;
            chkLeite.Checked = false;
            chkMacarrão.Checked = false;
            chkPãoDeForma.Checked = false;
            chkRefrigerante.Checked = false;
            chkSucoDeLaranja.Checked = false;
            rdbCartãoDeCrédito.Checked = false;
            rdbDinheiro.Checked = false;
            rdbPix.Checked = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

   
}
