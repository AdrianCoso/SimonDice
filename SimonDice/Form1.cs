using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonDice
{
    public partial class Form1 : Form
    {
        
        int ControlSencuencia = 0;
        Random NumeroAleatorio;
        int tiempo=600;
        List<int> SimonDice = new List<int>();
        bool Hablando = false;

        public Form1()
        {
            InitializeComponent();
            NumeroAleatorio = new Random();
            
        }
        public void IniciarJuego() {
            Thread.Sleep(tiempo);
            Hablando = true;
            foreach (int ParteActiva in SimonDice)
            {

                switch (ParteActiva)
                {
                    case 0:
                        p_0.Image = Properties.Resources.a_on;
                        Thread.Sleep(300);
                        p_0.Image = Properties.Resources.a;

                        break;
                    case 1:
                        p_1.Image = Properties.Resources.b_on;
                        Thread.Sleep(300);
                        p_1.Image = Properties.Resources.b;
                        break;
                    case 2:
                        p_2.Image = Properties.Resources.d_on;
                        Thread.Sleep(300);
                        p_2.Image = Properties.Resources.d;
                        break;
                    case 3:
                        p_3.Image = Properties.Resources.c_on;
                        Thread.Sleep(300);
                        p_3.Image = Properties.Resources.c;
                        break;
                }
              
                ReproducirMusica(ParteActiva);
            }
            Thread.Sleep(tiempo);
            Hablando = false;
            
        }
        public void VerificarBotonPresionado(int ValorBoton) {
            if (Hablando || SimonDice.Count == 0) return;
            if (SimonDice[ControlSencuencia] == ValorBoton) ControlSencuencia++;
            else {
                MessageBox.Show("Tu Record Final es:" + SimonDice.Count);
                ControlSencuencia = 0;
                SimonDice.RemoveRange(0, SimonDice.Count);
                //SimonDice = new List<int>();
                Hablando = false;
               
            }
            if(ControlSencuencia>=SimonDice.Count){
                
                ControlSencuencia = 0;
                SimonDice.Add(NumeroAleatorio.Next(0, 4));
                Thread.Sleep(1000);
                new Thread(IniciarJuego).Start();
            }
            lbl_puntaje.Text = SimonDice.Count.ToString();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            SimonDice.Add(NumeroAleatorio.Next(0, 4));
            new Thread(IniciarJuego).Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void p_0_Click(object sender, EventArgs e)
        {
            String Presionado = ((PictureBox)sender).Name;
            string[] NumeroBoton = Presionado.Split('_');
            VerificarBotonPresionado(Convert.ToInt32( NumeroBoton[1]));
        }

        

        private void p_0_MouseDown(object sender, MouseEventArgs e)
        {
            p_0.Image = Properties.Resources.a_on;
            ReproducirMusica(0);
        }

        private void p_0_MouseUp(object sender, MouseEventArgs e)
        {
            p_0.Image = Properties.Resources.a;
        }

        private void p_1_MouseDown(object sender, MouseEventArgs e)
        {
            p_1.Image = Properties.Resources.b_on;
            ReproducirMusica(1);
        }

        private void p_1_MouseUp(object sender, MouseEventArgs e)
        {
            p_1.Image = Properties.Resources.b;
        }

        private void p_2_MouseDown(object sender, MouseEventArgs e)
        {
            p_2.Image = Properties.Resources.d_on;
            ReproducirMusica(2);
        }

        private void p_2_MouseUp(object sender, MouseEventArgs e)
        {
            p_2.Image = Properties.Resources.d;
        }

        private void p_3_MouseDown(object sender, MouseEventArgs e)
        {
            p_3.Image = Properties.Resources.c_on;
            ReproducirMusica(3);
        }

        private void p_3_MouseUp(object sender, MouseEventArgs e)
        {
            p_3.Image = Properties.Resources.c;
        }
        public void ReproducirMusica(int sound) {

            SoundPlayer sndplayr;
            switch (sound)
            {
                case 0:
                    sndplayr = new SoundPlayer(Properties.Resources.pong1);
                    break;

                case 1:
                    sndplayr = new SoundPlayer(Properties.Resources.pong2);
                    break;

                case 2:
                    sndplayr = new SoundPlayer(Properties.Resources.pong3);
                    break;

                case 3:
                    sndplayr = new SoundPlayer(Properties.Resources.pong4);
                    break;

                default:
                    sndplayr = new SoundPlayer(Properties.Resources.pong1);
                    break;
            }
            
            sndplayr.Play();
        }

        private void cursorMano(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cursorFlecha(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
