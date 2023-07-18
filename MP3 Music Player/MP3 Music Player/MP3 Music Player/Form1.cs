using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace MP3_Music_Player
{
    public partial class Form1 : Form
    {

        private List<string> musicFiles;
        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            musicFiles = new List<string>();
            player = new SoundPlayer();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            // Formun ekranın ortasında konumlanması için gereken hesaplamaları yap
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            // Formun konumunu güncelle
            this.Location = new Point(x, y);

            //-------------------------------------------

            // Formun adını değiştir
            this.Text = "MP3 Music Player";

            //-------------------------------------------

            // Müzik dosyalarını listeye yükle
            LoadMusicFiles();
        }

        private void LoadMusicFiles()
        {
            string musicDirectory = @"C:\sounds\Folder"; // Müzik dosyalarının bulunduğu dizin
            string[] files = Directory.GetFiles(musicDirectory, "*.mp3"); // Sadece MP3 dosyalarını yükle (İsteğe bağlı)

            musicFiles.AddRange(files);
            listBox1.DataSource = musicFiles; // Listbox'a müzik dosyalarını ata
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Listbox'ta seçili olan müzik dosyasını oynat
            string selectedMusic = listBox1.SelectedItem.ToString();
            player.SoundLocation = selectedMusic;
            player.Play();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Oynat düğmesine basıldığında seçili müziği oynat
            if (listBox1.SelectedItem != null)
            {
                player.Play();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                player.Stop(); // Müziği duraklatmak için Stop yöntemini kullan
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                player.Play(); // Duraklatılan müziği tekrar başlatmak için Play yöntemini kullan
            }
        }
    }

}
