using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//prueba numero 2

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        Queue<string> q = new Queue<string>();
        string[] Musics = new string[1000];
        int cont;
        string a;


        public Form1()
        {
            InitializeComponent();
            // Hacer la ventana cuadrada (mismo ancho que alto)
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Para que no se pueda redimensionar
            this.MaximizeBox = false; // Deshabilitar el botón de maximizar

            // Panel para la barra superior personalizada
            Panel topBar = new Panel();
            topBar.BackColor = Color.FromArgb(45, 45, 48); // Color oscuro como VS
            topBar.Dock = DockStyle.Top;
            topBar.Height = 40;

            // Título en la barra
            Label titleLabel = new Label();
            titleLabel.Text = "";
            titleLabel.ForeColor = Color.White;
            titleLabel.Dock = DockStyle.Left;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Padding = new Padding(10, 0, 0, 0);
            titleLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Botones de control
            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.White;
            btnClose.Dock = DockStyle.Right;
            btnClose.Width = 40;
            btnClose.Click += (s, e) => this.Close();

            // Botón de maximizar (visible pero no funcional)
            Button btnMaximize = new Button();
            btnMaximize.Text = "□";
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.ForeColor = Color.White;
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.Width = 40;
            btnMaximize.Click += (s, e) => { /* Intencionalmente vacío */ };

            Button btnMinimize = new Button();
            btnMinimize.Text = "_";
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.Width = 40;
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Añadir controles a la barra superior
            topBar.Controls.Add(btnMinimize);
            topBar.Controls.Add(btnMaximize);
            
            topBar.Controls.Add(btnClose);
            topBar.Controls.Add(titleLabel);

            // Añadir barra al formulario
            this.Controls.Add(topBar);

            // Quitar bordes nativos para mejor control
            this.FormBorderStyle = FormBorderStyle.None;

            // Implementación correcta para mover la ventana
            Point dragStart = Point.Empty;
            bool dragging = false;

            topBar.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragStart = new Point(e.X, e.Y);
                    dragging = true;
                }
            };

            topBar.MouseMove += (s, e) =>
            {
                if (dragging)
                {
                    Point newLocation = this.PointToScreen(new Point(e.X - dragStart.X, e.Y - dragStart.Y));
                    this.Location = newLocation;
                }
            };

            topBar.MouseUp += (s, e) =>
            {
                dragging = false;
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }
          

            catch (System.IndexOutOfRangeException) {

                MessageBox.Show("Select a Song", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.stop();
        }

        private void pausebtn_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();

        }

        private void resumebtn_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.play();

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK) 
            {
                for (int i = 0; i < open.FileNames.LongLength; i++)
                {
                    if (Ltb_Musics.Items.Contains(open.FileNames.GetValue(i)) == false)
                    {
                        var r = open.SafeFileNames.GetValue(i);
                        a = Convert.ToString(r);
                        q.Enqueue(a);
                        Musics[cont] = open.FileNames.GetValue(i).ToString();
                        cont += 1;
                       
                    }
                }
                Ltb_Musics.Items.Clear();
                foreach (string id in q)
                {
                    Ltb_Musics.Items.Add(id);
                }

                if (Ltb_Musics.SelectedIndex < 0)
                {
                    Ltb_Musics.SetSelected(0, true);
                     //MessageBox.Show("Song Successfully Added", "Test Case 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

          
        }

        private void Ltb_Musics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fastforwardbtn_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.fastForward();
          //  MessageBox.Show("Song Successfully Added", "Test Case 1", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void TimerTick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = volumeScroll.Value;

        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            if (Ltb_Musics.SelectedIndex != 0) {

                Ltb_Musics.SetSelected(Ltb_Musics.SelectedIndex - 1, true);
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
            }
            else
            {
                Ltb_Musics.SelectedIndex = Ltb_Musics.Items.Count-1;
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {     
            if (Ltb_Musics.SelectedIndex != Ltb_Musics.Items.Count - 1)
            {
                Ltb_Musics.SetSelected(Ltb_Musics.SelectedIndex + 1, true);
                    Player.URL = Musics[Ltb_Musics.SelectedIndex];
                    timer1.Start();                
            }
            else 
            {
                Ltb_Musics.SelectedIndex = 0;
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }



        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Ltb_Musics.SetSelected(0, true);
            Player.URL = Musics[Ltb_Musics.SelectedIndex];
         //   MessageBox.Show("Song Successfully Added", "Test Case 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void endbtn_Click(object sender, EventArgs e)
        {
            Ltb_Musics.SetSelected(Ltb_Musics.Items.Count - 1, true);
            Player.URL = Musics[Ltb_Musics.SelectedIndex];
        }

        private void lblduration_Click(object sender, EventArgs e)
        {

        }


        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private void Timer_Click(object sender, EventArgs e)
        {

        }

        private void lbl_duration_Click(object sender, EventArgs e)
        {

        }

        private void Player_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerTick.Checked == true && lbltime.Text != "" && Convert.ToInt32(lbltime.Text.Replace(":", "")) 
                == Convert.ToInt32(lblduration.Text.Replace(":", "")) - 2)
            {
                Random random = new Random();
                Ltb_Musics.SetSelected(random.Next(Ltb_Musics.Items.Count), true);
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
            }

            lbltime.Text = Player.Ctlcontrols.currentPositionString;
            lblduration.Text = Player.currentMedia.durationString;

        }

        private void shuffle_Click(object sender, EventArgs e)
        {

        }

        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            String[] arr = q.ToArray();
            if (e.newState == 8)
            {             
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        Ltb_Musics.SelectedIndex = Ltb_Musics.SelectedIndex + 1;
                    }


                catch (System.ArgumentOutOfRangeException)
                    {

                        Ltb_Musics.SelectedIndex = 0;
                    }

                  

                    Player.URL = Musics[Ltb_Musics.SelectedIndex];
                    timer1.Start();
                }));
            }
        }

        private void sortbtn_Click(object sender, EventArgs e)
        {
            String[] arr = q.ToArray();// Displaying the elements in array 
            bool swap;
            string temp; //change this too

            do
            {
                swap = false;

                for (int index = 0; index < (arr.Length - 1); index++)
                {
                    if (string.Compare(arr[index], arr[index + 1]) < 0) 
                    {
                        //swap
                        temp = arr[index];
                        arr[index] = arr[index + 1];
                        arr[index + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap == true);

            Ltb_Musics.Items.Clear();

            for (int t = 0; t < arr.Length; t++) {
                Ltb_Musics.Items.Add(arr[t]);
            }

            if (Ltb_Musics.SelectedIndex < 0)
            {
                Ltb_Musics.SetSelected(0, true);
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            Ltb_Musics.Items.Clear();
            q.Clear();


            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {

                for (int i = 0; i < open.FileNames.LongLength; i++)
                {

                    if (Ltb_Musics.Items.Contains(open.FileNames.GetValue(i)) == false)
                    {
                        var r = open.SafeFileNames.GetValue(i);
                        a = Convert.ToString(r);
                        q.Enqueue(a);

                        Musics[cont] = open.FileNames.GetValue(i).ToString();

                        cont += 1;

                    }
                }

                foreach (string id in q)
                {
                    Ltb_Musics.Items.Add(id);
                }

                if (Ltb_Musics.SelectedIndex < 0)
                {

                    Ltb_Musics.SetSelected(0, true);

                }
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //     Ltb_Musics.Sorted = true;

            String[] arr = q.ToArray();
            // Displaying the elements in array 

            bool swap;
            string temp; //change this too

            do
            {
                swap = false;

                for (int index = 0; index < (arr.Length - 1); index++)
                {
                    if (string.Compare(arr[index + 1], arr[index]) < 0) 
                    {
                        //swap

                        temp = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = temp;
                        swap = true;
                    }
                }

            } while (swap == true);

            Ltb_Musics.Items.Clear();

            for (int t = 0; t < arr.Length; t++)
            {

                Ltb_Musics.Items.Add(arr[t]);

            }
            /*

            if (Ltb_Musics.SelectedIndex < 0)
            {

                Ltb_Musics.SetSelected(0, true);

            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String[] arr = q.ToArray();
            String search = searchtxt.Text;

            var items = (from a in arr
                         where a.StartsWith(search)
                         select a).ToArray<String>();

            Ltb_Musics.Items.Clear();
            Ltb_Musics.Items.AddRange(items);


        
       }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }


            catch (System.IndexOutOfRangeException)
            {

                MessageBox.Show("Select a Song", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (Ltb_Musics.SelectedIndex != 0)
            {

                Ltb_Musics.SetSelected(Ltb_Musics.SelectedIndex - 1, true);
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
            }
            else
            {
                Ltb_Musics.SelectedIndex = Ltb_Musics.Items.Count - 1;
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (Ltb_Musics.SelectedIndex != Ltb_Musics.Items.Count - 1)
            {
                Ltb_Musics.SetSelected(Ltb_Musics.SelectedIndex + 1, true);
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }
            else
            {
                Ltb_Musics.SelectedIndex = 0;
                Player.URL = Musics[Ltb_Musics.SelectedIndex];
                timer1.Start();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();
        }

        private void TimerTick_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Ltb_Musics_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
