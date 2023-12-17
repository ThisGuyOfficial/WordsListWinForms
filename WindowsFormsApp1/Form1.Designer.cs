using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Threading;

namespace wf
{

    partial class Form1
    {
        private const string dllPath = @"C:\Users\drago\source\repos\WindowsFormsApp1\WindowsFormsApp1\CppDll.dll";

        [DllImport(dllPath)] private static extern IntPtr mainTaskCreate();
        [DllImport(dllPath)] private static extern IntPtr mainTaskRead(IntPtr A);
        [DllImport(dllPath)] private static extern IntPtr mainTaskCountMatches(IntPtr A);
        [DllImport(dllPath)] private static extern IntPtr mainTaskSave(IntPtr A);

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Drawing.Font LargeFont = new System.Drawing.Font("Arial", 14);

            pbNew = new PictureBox();
            pbNew.Width=60;
            pbNew.Height=60;
            pbNew.Image = System.Drawing.Image.FromFile("new.png");

            pbOpen = new PictureBox();
            pbOpen.Width=60;
            pbOpen.Height=60;
            pbOpen.Image = System.Drawing.Image.FromFile("open.png");
            
            pbAbout = new PictureBox();
            pbAbout.Width=60;
            pbAbout.Height=60;
            pbAbout.Image = System.Drawing.Image.FromFile("about.png");

            pbExit = new PictureBox();
            pbExit.Width=60;
            pbExit.Height=60;
            pbExit.Image = System.Drawing.Image.FromFile("exit.png");
            
            this.openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            openFileDialog1.Title = "Supported only text files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            this.saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.Title = "Supported only text files";

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = ColorTranslator.FromHtml("#1f1f1f");
            this.MinimumSize = new Size(650, 550);


            this.newFileLabel = new System.Windows.Forms.Label();
            this.openFileLabel = new System.Windows.Forms.Label();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.exitProgrammLabel = new System.Windows.Forms.Label();

            this.newFileLabel.Text = "Создать новый файл";
            this.newFileLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
            this.newFileLabel.Font = LargeFont;
            this.newFileLabel.Width = 200; this.newFileLabel.Height = 25;
            this.newFileLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3-60);
            this.Controls.Add(this.newFileLabel);
            pbNew.Location = new Point(this.newFileLabel.Location.X-70, this.newFileLabel.Location.Y-20);
            this.Controls.Add(this.pbNew);

            this.openFileLabel.Text = "Открыть файл";
            this.openFileLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
            this.openFileLabel.Font = LargeFont;
            this.openFileLabel.Width = 200; this.openFileLabel.Height = 25;
            this.openFileLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 40);
            this.Controls.Add(this.openFileLabel);
            pbOpen.Location = new Point(this.openFileLabel.Location.X-70, this.openFileLabel.Location.Y-20);
            this.Controls.Add(this.pbOpen);

            this.aboutLabel.Text = "О программе";
            this.aboutLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
            this.aboutLabel.Font = LargeFont;
            this.aboutLabel.Width = 200; this.aboutLabel.Height = 25;
            this.aboutLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 140);
            this.Controls.Add(this.aboutLabel);
            pbAbout.Location = new Point(this.aboutLabel.Location.X-70, this.aboutLabel.Location.Y-20);
            this.Controls.Add(this.pbAbout);

            this.exitProgrammLabel.Text = "Выйти из программы";
            this.exitProgrammLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
            this.exitProgrammLabel.Font = LargeFont;
            this.exitProgrammLabel.Width = 200; this.exitProgrammLabel.Height = 25;
            this.exitProgrammLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 240);
            this.Controls.Add(this.exitProgrammLabel);
            pbExit.Location = new Point(this.exitProgrammLabel.Location.X-70, this.exitProgrammLabel.Location.Y-20);
            this.Controls.Add(this.pbExit);

            this.tB1 = new System.Windows.Forms.TextBox();
            this.tB1.Hide();

            

            this.SuspendLayout();
            this.tB1.AcceptsReturn = true;
            this.tB1.AcceptsTab = true;
            this.tB1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tB1.Multiline = true;
            this.tB1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB1.Width = this.Width * 3 / 4;
            this.tB1.BackColor = ColorTranslator.FromHtml("#8b8b8b");
            this.tB1.TextChanged += new EventHandler(tb_textChanged);
            this.Controls.Add(this.tB1);
            this.Text = "TextBox Example";
            this.ResumeLayout(false);
            this.PerformLayout();


            this.saveFile = new Button();
            this.saveFile.Text = "Сохранить";
            this.saveFile.Font = LargeFont;
            this.saveFile.ForeColor = ColorTranslator.FromHtml("#AAAAAA");
            this.saveFile.Width = (this.Width -this.tB1.Width-25);
            this.saveFile.Height = 50;
            this.saveFile.Location = new Point(this.tB1.Right + 5, this.Height -160);
            this.saveFile.Hide();
            this.saveFile.Click += new EventHandler(saveFile_Click);   
            this.Controls.Add(this.saveFile);

            this.closeTask = new Button();
            this.closeTask.Text = "Закрыть";
            this.closeTask.Font = LargeFont;
            this.closeTask.ForeColor = ColorTranslator.FromHtml("#AAAAAA");
            this.closeTask.Width = (this.Width - this.tB1.Width - 25);
            this.closeTask.Height = 50;
            this.closeTask.Location = new Point(this.tB1.Right + 5, this.Height - 100);
            this.closeTask.Hide();
            this.closeTask.Click += new EventHandler(closeFile_Click);
            this.Controls.Add(this.closeTask);

            this.mainTask = new Button();
            this.mainTask.Text = "Обработать";
            this.mainTask.Font = LargeFont;
            this.mainTask.ForeColor = ColorTranslator.FromHtml("#AAAAAA");
            this.mainTask.Width = (this.Width - this.tB1.Width - 25);
            this.mainTask.Height = 50;
            this.mainTask.Location = new Point(this.tB1.Right + 5, 10);
            this.mainTask.Hide();
            this.mainTask.Click += new EventHandler(mainTask_Click);
            this.Controls.Add(this.mainTask);

            this.newFileLabel.Click += new System.EventHandler(newFileLabel_Click);
            this.newFileLabel.MouseDown += new MouseEventHandler(labelNew_Down);
            this.newFileLabel.MouseUp += new MouseEventHandler(labelNew_Up);
            this.newFileLabel.MouseEnter += new EventHandler(newFileLabel_MouseOver);
            this.newFileLabel.MouseLeave += new EventHandler(newFileLabel_MouseLeave);

            this.pbNew.MouseEnter += new EventHandler(newFileLabel_MouseOver);
            this.pbNew.MouseLeave += new EventHandler(newFileLabel_MouseLeave);
            this.pbNew.MouseDown += new MouseEventHandler(labelNew_Down);
            this.pbNew.MouseUp += new MouseEventHandler(labelNew_Up);
            this.pbNew.Click += new System.EventHandler(newFileLabel_Click);

            this.openFileLabel.Click += new System.EventHandler(openFileLabel_Click);
            this.openFileLabel.MouseDown += new MouseEventHandler(labelOpen_Down);
            this.openFileLabel.MouseUp += new MouseEventHandler(labelOpen_Up);
            this.openFileLabel.MouseEnter += new EventHandler(openFileLabel_MouseOver);
            this.openFileLabel.MouseLeave += new EventHandler(openFileLabel_MouseLeave);

            this.pbOpen.MouseEnter += new EventHandler(openFileLabel_MouseOver);
            this.pbOpen.MouseLeave += new EventHandler(openFileLabel_MouseLeave);
            this.pbOpen.Click += new System.EventHandler(openFileLabel_Click);
            this.pbOpen.MouseDown += new MouseEventHandler(labelOpen_Down);
            this.pbOpen.MouseUp += new MouseEventHandler(labelOpen_Up);

            this.aboutLabel.Click += new System.EventHandler(aboutFileLabel_Click);
            this.aboutLabel.MouseDown += new MouseEventHandler(labelAbout_Down);
            this.aboutLabel.MouseUp += new MouseEventHandler(labelAbout_Up);
            this.aboutLabel.MouseEnter += new EventHandler(aboutFileLabel_MouseOver);
            this.aboutLabel.MouseLeave += new EventHandler(aboutFileLabel_MouseLeave);

            this.pbAbout.MouseEnter += new EventHandler(aboutFileLabel_MouseOver);
            this.pbAbout.MouseLeave += new EventHandler(aboutFileLabel_MouseLeave);
            this.pbAbout.Click += new System.EventHandler(aboutFileLabel_Click);
            this.pbAbout.MouseDown += new MouseEventHandler(labelAbout_Down);
            this.pbAbout.MouseUp += new MouseEventHandler(labelAbout_Up);

            this.exitProgrammLabel.Click += new System.EventHandler(exitFileLabel_Click);
            this.exitProgrammLabel.MouseDown += new MouseEventHandler(labelExit_Down);
            this.exitProgrammLabel.MouseUp += new MouseEventHandler(labelExit_Up);
            this.exitProgrammLabel.MouseEnter += new EventHandler(exitFileLabel_MouseOver);
            this.exitProgrammLabel.MouseLeave += new EventHandler(exitFileLabel_MouseLeave);

            this.pbExit.MouseEnter += new EventHandler(exitFileLabel_MouseOver);
            this.pbExit.MouseLeave += new EventHandler(exitFileLabel_MouseLeave);   
            this.pbExit.Click += new System.EventHandler(exitFileLabel_Click);
            this.pbExit.MouseDown += new MouseEventHandler(labelExit_Down);
            this.pbExit.MouseUp += new MouseEventHandler(labelExit_Up); 

            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }


        

        async private void mainTask_Click(object sender, EventArgs e)
        {


            //using (var fstream = File.CreateText("WordsList.txt"))
            //{
            //    fstream.Write(tB1.Text);
            //}
            if (File.Exists("WordsList.txt")) File.Delete("WordsList.txt");
            if (File.Exists("ResultPairs.txt")) File.Delete("ResultPairs.txt");

            FileStream fstream = new FileStream("WordsList.txt", FileMode.Create);
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(this.tB1.Text);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                textChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            finally
            {
                fstream.Close();
            }

            tB1.Text = "Содержимое файла обработано, результат сохранен в файл ResultPairs.txt";
            tB1.AppendText(Environment.NewLine);


           // Thread.Sleep(5000);

            
                IntPtr a = mainTaskCreate();
                mainTaskRead(a);
                mainTaskCountMatches(a);
                mainTaskSave(a);
            

            //System.IO.File.Delete("WordsList.txt");

            //tB1.Clear();
            
            //FileStream fstream0 = new FileStream("ResultPairs.txt", FileMode.Open);
            //try
            //{
            //    byte[] buffer = new byte[fstream0.Length];
            //    await fstream0.ReadAsync(buffer, 0, buffer.Length);
            //    this.tB1.Text += Encoding.Default.GetString(buffer);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //}
            //finally
            //{
            //    fstream0.Close();
            //}


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.tB1.Width = this.Width * 3 / 4;
            this.newFileLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3-60);
            this.openFileLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 40);
            this.aboutLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 140);
            this.exitProgrammLabel.Location = new Point(this.Width * 2 / 3, this.Height / 3 + 240);
            this.saveFile.Width = (this.Width - this.tB1.Width - 25);
            this.saveFile.Location = new Point(this.tB1.Right + 5, this.Height - 160 );
            this.closeTask.Width = (this.Width - this.tB1.Width - 25);
            this.closeTask.Location = new Point(this.tB1.Right + 5, this.Height - 100);
            this.mainTask.Width = (this.Width - this.tB1.Width - 25);
            this.mainTask.Location = new Point(this.tB1.Right + 5, 10);
            this.pbNew.Location = new Point(this.newFileLabel.Location.X-70, this.newFileLabel.Location.Y-20);
            this.pbOpen.Location = new Point(this.openFileLabel.Location.X-70, this.openFileLabel.Location.Y-20);
            this.pbAbout.Location = new Point(this.aboutLabel.Location.X-70, this.aboutLabel.Location.Y-20);
            this.pbExit.Location = new Point(this.exitProgrammLabel.Location.X-70, this.exitProgrammLabel.Location.Y-20);
        }

        private void tb_textChanged(object sender, EventArgs e) 
        {
            textChanged = true;


            if (saveFileDialog1.FileName != string.Empty)
            {
                this.Text = saveFileDialog1.FileName + " - unsaved";
            }
            else if (openFileDialog1.FileName != string.Empty)
            {
                this.Text = openFileDialog1.FileName + " - unsaved";
            }
            else
            {
                this.Text = " - unsaved";
            }
        }
       
        async private void saveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.FileName == string.Empty && openFileDialog1.FileName==string.Empty)
            {
                if(DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    FileStream fstream = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    try
                    {
                        byte[] buffer = Encoding.Default.GetBytes(this.tB1.Text);
                        await fstream.WriteAsync(buffer, 0, buffer.Length);
                        textChanged = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                    finally
                    {
                        fstream.Close();
                    }
                    this.Text = saveFileDialog1.FileName;
                }
            }
            else
            {
                if (saveFileDialog1.FileName != string.Empty)
                {
                    fstream2 = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    this.Text = saveFileDialog1.FileName;
                }
                else if (openFileDialog1.FileName != string.Empty)
                {
                    fstream2 = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
                    this.Text = openFileDialog1.FileName;
                }

                try
                {
                    byte[] buffer = Encoding.Default.GetBytes(this.tB1.Text);
                    await fstream2.WriteAsync(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                finally
                {
                    fstream2.Close();
                }
                textChanged = false;
            }
            textChanged = false;
        }
        async private void closeFile_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                DialogResult DR = MessageBox.Show("Save changes", "", MessageBoxButtons.YesNoCancel);
                if ( DR == DialogResult.Yes)
                {
                    if (saveFileDialog1.FileName == string.Empty && openFileDialog1.FileName == string.Empty) saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != string.Empty)
                    {
                        fstream3 = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                        this.Text = saveFileDialog1.FileName;
                    }
                    if (openFileDialog1.FileName != string.Empty)
                    {
                        fstream3 = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
                        this.Text = openFileDialog1.FileName;
                    }
                    try
                    {
                        byte[] buffer = Encoding.Default.GetBytes(this.tB1.Text);
                        await fstream3.WriteAsync(buffer, 0, buffer.Length);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                    finally
                    {
                        fstream3.Close();
                    }
                    this.openFileLabel.Show();
                    this.newFileLabel.Show();
                    this.aboutLabel.Show();
                    this.exitProgrammLabel.Show();
                    this.pbNew.Show();
                    this.pbOpen.Show();
                    this.pbAbout.Show();
                    this.pbExit.Show();
                    this.tB1.Hide();
                    this.saveFile.Hide();
                    this.closeTask.Hide();
                    this.mainTask.Hide();
                    this.tB1.Text = string.Empty;
                    textChanged = false;
                    this.Text = string.Empty;
                }
                if ( DR == DialogResult.No)
                {
                    
                    this.openFileLabel.Show();
                    this.newFileLabel.Show();
                    this.aboutLabel.Show();
                    this.exitProgrammLabel.Show();
                    this.pbNew.Show();
                    this.pbOpen.Show();
                    this.pbAbout.Show();
                    this.pbExit.Show();
                    this.tB1.Hide();
                    this.saveFile.Hide();
                    this.closeTask.Hide();
                    this.mainTask.Hide();
                    this.tB1.Text = string.Empty;
                    textChanged = false;
                    this.Text = string.Empty;
                }
            }
            else
            {
                this.openFileLabel.Show();
                this.newFileLabel.Show();
                this.aboutLabel.Show();
                this.exitProgrammLabel.Show();
                this.pbNew.Show();
                this.pbOpen.Show();
                this.pbAbout.Show();
                this.pbExit.Show();
                this.tB1.Hide();
                this.saveFile.Hide();
                this.closeTask.Hide();
                this.mainTask.Hide();
                this.tB1.Text = string.Empty;
                textChanged = false;
                this.Text = string.Empty;
            }
            
        }
        private void newFileLabel_MouseOver(object sender, EventArgs e)
        { this.newFileLabel.Font = new System.Drawing.Font (newFileLabel.Font, newFileLabel.Font.Style ^ FontStyle.Underline); this.Cursor = Cursors.Hand; }
        private void newFileLabel_MouseLeave(object sender, EventArgs e)
        { this.newFileLabel.Font = new System.Drawing.Font (newFileLabel.Font, newFileLabel.Font.Style ^ FontStyle.Underline); this.Cursor = Cursors.Default; }
        private void newFileLabel_Click(object sender, EventArgs e)
        { 
            this.Text = string.Empty;
            this.newFileLabel.ForeColor = ColorTranslator.FromHtml("#888888");
            this.openFileLabel.Hide();
            this.newFileLabel.Hide();
            this.aboutLabel.Hide();
            this.exitProgrammLabel.Hide();
            this.pbNew.Hide();
            this.pbOpen.Hide();
            this.pbAbout.Hide();
            this.pbExit.Hide();
            this.tB1.Show();
            this.saveFile.Show();
            this.closeTask.Show();
            this.mainTask.Show();
            textChanged = false;
        }

        private void labelNew_Down(object sender, EventArgs e)
        { this.newFileLabel.Location = new Point(this.newFileLabel.Location.X + 1, this.newFileLabel.Location.Y + 1); }
        private void labelNew_Up(object sender, EventArgs e)
        {
            this.newFileLabel.Location = new Point(this.newFileLabel.Location.X - 1, this.newFileLabel.Location.Y - 1);
            this.newFileLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
        }

        private void openFileLabel_MouseOver(object sender, EventArgs e)
        { this.openFileLabel.Font = new System.Drawing.Font (openFileLabel.Font, openFileLabel.Font.Style ^ FontStyle.Underline); this.Cursor = Cursors.Hand; }
        private void openFileLabel_MouseLeave(object sender, EventArgs e)
        { this.openFileLabel.Font = new System.Drawing.Font (openFileLabel.Font, openFileLabel.Font.Style ^ FontStyle.Underline); this.Cursor = Cursors.Default; }
        async private void openFileLabel_Click(object sender, EventArgs e)
        {
            this.openFileLabel.ForeColor = ColorTranslator.FromHtml("#888888");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                            FileStream fstream = File.OpenRead(openFileDialog1.FileName);
                            try
                            {
                                byte[] buffer = new byte[fstream.Length];
                                await fstream.ReadAsync(buffer, 0, buffer.Length);
                                this.tB1.Text += Encoding.Default.GetString(buffer);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                            }
                            finally
                            {
                                fstream.Close();
                            }

                this.openFileLabel.Hide();
                this.newFileLabel.Hide();
                this.aboutLabel.Hide();
                this.exitProgrammLabel.Hide();
                this.pbNew.Hide();
                this.pbOpen.Hide();
                this.pbAbout.Hide();
                this.pbExit.Hide();
                this.tB1.Show();
                this.saveFile.Show();
                this.closeTask.Show();
                this.mainTask.Show();
                textChanged = false;
                this.Text = openFileDialog1.FileName;
            }
        }

        private void labelOpen_Down(object sender, EventArgs e)
        { this.openFileLabel.Location = new Point(this.openFileLabel.Location.X + 1, this.openFileLabel.Location.Y + 1); }
        private void labelOpen_Up(object sender, EventArgs e)
        {
            this.openFileLabel.Location = new Point(this.openFileLabel.Location.X - 1, this.openFileLabel.Location.Y - 1);
            this.openFileLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
        }

        private void aboutFileLabel_MouseOver(object sender, EventArgs e)
        { this.aboutLabel.Font = new System.Drawing.Font (aboutLabel.Font, aboutLabel.Font.Style ^ FontStyle.Underline); this.Cursor = Cursors.Hand; }
        private void aboutFileLabel_Click(object sender, EventArgs e)
        {
            this.aboutLabel.ForeColor = ColorTranslator.FromHtml("#888888");
            Form aboutWindow = new AboutForm();
            aboutWindow.ShowDialog();
        }
        private void labelAbout_Down(object sender, EventArgs e)
        { this.aboutLabel.Location = new Point(this.aboutLabel.Location.X + 1, this.aboutLabel.Location.Y + 1); }
        private void labelAbout_Up(object sender, EventArgs e)
        {
            this.aboutLabel.Location = new Point(this.aboutLabel.Location.X - 1, this.aboutLabel.Location.Y - 1);
            this.aboutLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
        }
        private void aboutFileLabel_MouseLeave(object sender, EventArgs e)
        { this.Cursor = Cursors.Default; this.aboutLabel.Font = new System.Drawing.Font (aboutLabel.Font, aboutLabel.Font.Style ^ FontStyle.Underline); }
        private void exitFileLabel_MouseOver(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.exitProgrammLabel.Font = new System.Drawing.Font (exitProgrammLabel.Font, exitProgrammLabel.Font.Style ^ FontStyle.Underline);
        }
        private void exitFileLabel_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.exitProgrammLabel.Font = new System.Drawing.Font (exitProgrammLabel.Font, exitProgrammLabel.Font.Style ^ FontStyle.Underline);
        }
        private void exitFileLabel_Click(object sender, EventArgs e)
        {
            this.exitProgrammLabel.ForeColor = ColorTranslator.FromHtml("#888888");

            if (DialogResult.OK == MessageBox.Show("Terminate session?", "Quit", MessageBoxButtons.OKCancel))
            {
                this.Close();
            }
        }
        private void labelExit_Down(object sender, EventArgs e)
        { this.exitProgrammLabel.Location = new Point(this.exitProgrammLabel.Location.X + 1, this.exitProgrammLabel.Location.Y + 1); }
        private void labelExit_Up(object sender, EventArgs e)
        {
            this.exitProgrammLabel.Location = new Point(this.exitProgrammLabel.Location.X - 1, this.exitProgrammLabel.Location.Y - 1);
            this.exitProgrammLabel.ForeColor = ColorTranslator.FromHtml("#0078d4");
        }


        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.tB1.Visible == false)
                {
                    if (DialogResult.OK == MessageBox.Show("Terminate session?", "Quit", MessageBoxButtons.OKCancel))
                    {
                        this.Close();
                    }
                }
                else 
                {
                    if (!textChanged)
                    {
                        this.openFileLabel.Show();
                        this.newFileLabel.Show();
                        this.aboutLabel.Show();
                        this.exitProgrammLabel.Show();
                        this.pbNew.Show();
                        this.pbOpen.Show();
                        this.pbAbout.Show();
                        this.pbExit.Show();
                        this.tB1.Hide();
                        this.saveFile.Hide();
                        this.closeTask.Hide();
                        this.mainTask.Hide();
                        this.tB1.Text = string.Empty;
                        textChanged = false;
                        this.Text = string.Empty;
                    }
                    else 
                    {
                        closeFile_Click(sender, e);
                    }
                }
            }
            if (e.Control && e.KeyCode == Keys.O && this.tB1.Visible == false)
            {
                MessageBox.Show("OpenFile dialog");
            }
            if (e.Control && e.KeyCode == Keys.N && this.tB1.Visible == false)
            {
                MessageBox.Show("FileCreation dialog");
            }
        }
        #endregion
    }

}

