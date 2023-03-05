namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (Audio audios in MediaScanner.Audios)
            {
                listBox1.Items.Add(audios.title);
            }
        }
    }
}