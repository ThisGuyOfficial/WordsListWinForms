using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf
{

    public partial class Form1 : Form
    {
        private bool textChanged;
        private TextBox tB1;
        private Label newFileLabel;
        private Label openFileLabel;
        private Label exitProgrammLabel;
        private Label aboutLabel;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;

        private Button saveFile;
        private Button mainTask;
        private Button closeTask;

        private FileStream fstream2;
        private FileStream fstream3;

        private PictureBox pbNew;
        private PictureBox pbOpen;
        private PictureBox pbAbout;
        private PictureBox pbExit;
        
        
        public Form1()
        {
            InitializeComponent();
        }


    }

}
