using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//prueba

namespace MusicPlayer
{
    public partial class Letras : Form
    {


        Queue<string> q = new Queue<string>();
        string[] Musics = new string[1000];
        int cont;
        string a;


        public Letras()
        {
            InitializeComponent();

            spotifyListView.MouseClick += SpotifyListView_MouseClick;
            spotifyListView.DoubleClick += SpotifyListView_DoubleClick;
            // Crear PictureBox para la imagen del álbum
            albumArtBox.BringToFront();

            spotifyListView.OwnerDraw = true;
            spotifyListView.DrawColumnHeader += (s, e) => e.DrawDefault = false;
            spotifyListView.DrawItem += (s, e) =>
            {
                e.DrawDefault = false;
                e.Graphics.FillRectangle(
                    e.Item.Selected ? new SolidBrush(Color.FromArgb(70, 70, 70)) :
                                     new SolidBrush(spotifyListView.BackColor),
                    e.Bounds);
                e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.White,
                                    new Rectangle(e.Bounds.X + 10, e.Bounds.Y,
                                                 e.Bounds.Width - 10, e.Bounds.Height));
            };

            // Asegurar de que el ListView este en el frente
            spotifyListView.BringToFront();

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

        private void addbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Archivos de audio|*.mp3;*.wav;*.wma";

            if (open.ShowDialog() == DialogResult.OK)
            {
                spotifyListView.BeginUpdate(); // Para mejor rendimiento

                foreach (string filePath in open.FileNames)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    if (!spotifyListView.Items.Cast<ListViewItem>().Any(item => item.Text.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                    {
                        q.Enqueue(fileName);
                        Musics[cont] = filePath;
                        cont++;

                        var item = new ListViewItem(fileName);
                        spotifyListView.Items.Add(item);
                    }
                }

                spotifyListView.EndUpdate();

                if (spotifyListView.Items.Count > 0 && spotifyListView.SelectedItems.Count == 0)
                {
                    spotifyListView.Items[0].Selected = true;
                    spotifyListView.EnsureVisible(0);
                }
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = volumeScroll.Value;

        }

        private void Player_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerTick.Checked == true && lbltime.Text != "" && Convert.ToInt32(lbltime.Text.Replace(":", ""))
                == Convert.ToInt32(lblduration.Text.Replace(":", "")) - 2)
            {
                Random random = new Random();
                int newIndex = random.Next(spotifyListView.Items.Count);
                spotifyListView.Items[newIndex].Selected = true;
                Player.URL = Musics[newIndex];
            }

            lbltime.Text = Player.Ctlcontrols.currentPositionString;
            lblduration.Text = Player.currentMedia.durationString;

        }

        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                // Reproducir siguiente canción al terminar la actual
                BeginInvoke(new Action(() =>
                {
                    if (spotifyListView.Items.Count > 0)
                    {
                        int newIndex = spotifyListView.SelectedIndices[0] + 1;
                        if (newIndex >= spotifyListView.Items.Count) newIndex = 0;

                        spotifyListView.Items[newIndex].Selected = true;
                        PlaySelectedSong(newIndex);
                    }
                }));
            }
            else if (e.newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Actualizar UI cuando comienza la reproducción
                BeginInvoke(new Action(() =>
                {
                    iconButton1.IconChar = FontAwesome.Sharp.IconChar.Pause;
                }));

            }
        }

        private void sortbtn_Click(object sender, EventArgs e)
        {
            String[] arr = q.ToArray();
            bool swap;
            string temp;

            do
            {
                swap = false;
                for (int index = 0; index < (arr.Length - 1); index++)
                {
                    if (string.Compare(arr[index], arr[index + 1]) < 0)
                    {
                        temp = arr[index];
                        arr[index] = arr[index + 1];
                        arr[index + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap == true);

            spotifyListView.Items.Clear();
            foreach (string item in arr)
            {
                spotifyListView.Items.Add(item);
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

            spotifyListView.Items.Clear();

            for (int t = 0; t < arr.Length; t++)
            {

                spotifyListView.Items.Add(arr[t]);

            }
            /*

            if (Ltb_Musics.SelectedIndex < 0)
            {

                Ltb_Musics.SetSelected(0, true);

            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchtxt.Text.ToLower();

            foreach (ListViewItem item in spotifyListView.Items)
            {
                item.Selected = false;
                item.BackColor = spotifyListView.BackColor;

                if (item.Text.ToLower().Contains(searchText))
                {
                    item.BackColor = Color.FromArgb(60, 60, 60);
                }
            }

            // Seleccionar el primer resultado si hay coincidencias
            var firstMatch = spotifyListView.Items.Cast<ListViewItem>()
                                                .FirstOrDefault(item => item.Text.ToLower().Contains(searchText));
            if (firstMatch != null)
            {
                firstMatch.Selected = true;
                spotifyListView.EnsureVisible(firstMatch.Index);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (spotifyListView.Items.Count == 0) return;

            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Player.Ctlcontrols.pause();
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.Play;
            }
            else
            {
                PlaySelectedSong(spotifyListView.SelectedIndices[0]);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (spotifyListView.Items.Count == 0) return;

            int newIndex = spotifyListView.SelectedIndices[0] - 1;
            if (newIndex < 0) newIndex = spotifyListView.Items.Count - 1;

            spotifyListView.Items[newIndex].Selected = true;
            PlaySelectedSong(newIndex);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (spotifyListView.Items.Count == 0) return;

            int newIndex = spotifyListView.SelectedIndices[0] + 1;
            if (newIndex >= spotifyListView.Items.Count) newIndex = 0;

            spotifyListView.Items[newIndex].Selected = true;
            PlaySelectedSong(newIndex);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Play; // Cambiar icono de play
        }

        private void TimerTick_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void UpdateAlbumArt(string filePath)
        {
            try
            {
                var file = TagLib.File.Create(filePath);
                var picture = file.Tag.Pictures.FirstOrDefault();

                if (picture != null)
                {
                    using (var ms = new MemoryStream(picture.Data.Data))
                    {
                        var originalImage = Image.FromStream(ms);

                        // Crear una nueva imagen con fondo negro manteniendo la relación de aspecto
                        var squareImage = new Bitmap(albumArtBox.Width, albumArtBox.Height);
                        using (var g = Graphics.FromImage(squareImage))
                        {
                            g.Clear(Color.Black);

                            // Calcular relación de aspecto
                            float ratio = Math.Min(
                                (float)albumArtBox.Width / originalImage.Width,
                                (float)albumArtBox.Height / originalImage.Height);

                            int newWidth = (int)(originalImage.Width * ratio);
                            int newHeight = (int)(originalImage.Height * ratio);

                            // Centrar la imagen
                            int x = (albumArtBox.Width - newWidth) / 2;
                            int y = (albumArtBox.Height - newHeight) / 2;

                            g.DrawImage(originalImage, x, y, newWidth, newHeight);
                        }

                        // Asignar la nueva imagen
                        if (albumArtBox.Image != null)
                            albumArtBox.Image.Dispose();

                        albumArtBox.Image = squareImage;
                    }
                }
                else
                {
                    // Imagen por defecto centrada
                    albumArtBox.Image = Properties.Resources.default_album;
                    albumArtBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch
            {
                albumArtBox.Image = Properties.Resources.default_album;
                albumArtBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        private void PlaySelectedSong(int index)
        {
            if (index < 0 || index >= Musics.Length || string.IsNullOrEmpty(Musics[index]))
            {
                MessageBox.Show("No hay canción seleccionada o la ruta es inválida.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Player.URL = Musics[index];
                Player.Ctlcontrols.play();
                timer1.Start();

                // Actualizar el estado del botón de play/pause
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.Pause;

                // Actualizar la imagen del álbum si tienes esa funcionalidad
                if (albumArtBox != null)
                {
                    UpdateAlbumArt(Musics[index]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reproducir la canción: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SpotifyListView_MouseClick(object sender, MouseEventArgs e)
        {
            // Obtener el item que fue clickeado
            var hitTest = spotifyListView.HitTest(e.Location);

            if (hitTest.Item != null)
            {
                // Reproducir la canción seleccionada
                int selectedIndex = hitTest.Item.Index;
                spotifyListView.Items[selectedIndex].Selected = true;
                PlaySelectedSong(selectedIndex);
            }
        }
        private void SpotifyListView_DoubleClick(object sender, EventArgs e)
        {
            if (spotifyListView.SelectedItems.Count > 0)
            {
                int selectedIndex = spotifyListView.SelectedIndices[0];
                PlaySelectedSong(selectedIndex);
            }
        }

        private void spotifyListView_Click(object sender, EventArgs e)
        {
            if (spotifyListView.SelectedItems.Count > 0)
            {
                // Pequeño retraso para evitar reproducir al seleccionar con el teclado
                Task.Delay(100).ContinueWith(_ =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        PlaySelectedSong(spotifyListView.SelectedIndices[0]);
                    });
                });
            }
        }
    }
}
