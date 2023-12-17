using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Runtime.InteropServices.ComTypes;


namespace wf
{

    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();

            }


        }
        private void InitializeComponent()
        {
            Font LargeFont = new Font("Arial", 14);

            this.tB = new TextBox();
            tB.Font = LargeFont;
            tB.Text = "Программа создана в рамках реализации тестовой задачи, описание исходных условий и ожидемых результатов работы программы:";
            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "Постановка задачи:";
            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "Посчитать количество появлений каждого слова в текстовом файле и вывести в";
            tB.Text += "текстовый файл результаты парами «слово» – «количество» в отсортированном порядке в соответствии с установленными требованиями. \n";
            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "Входные данные: \n";
            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "• Текстовый файл с названием WordsList.txt, расположенный в директории \n";
            tB.Text += "исполняемой программы, состоящий из множества слов.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "• Слово может состоять из строчных и прописных букв только английского \n";
            tB.Text += "алфавита, всё остальное разделители.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "• Размер слова не превышает 50 символов.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "• Размер файла не ограничен, т.е. нельзя заранее выделить массив слов.\n"; tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "Выходные данные:\n"; tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "• Результирующий файл с названием ResultPairs.txt, расположенный в директории исполняемой программы, содержащий результаты парами «слово» –\n";
            tB.Text += "«количество».\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "• «Слова» в результирующем файле должны быть отсортированы по количеству появлений (первичный признак) и в алфавитном порядке (вторичный \n";
            tB.AppendText(Environment.NewLine);
            tB.Text += "признак).\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "• Лог-файл, содержащий сообщения об ошибках и записи об успешной генерации результирующего файла.\n"; tB.AppendText(Environment.NewLine);
            tB.AppendText(Environment.NewLine);
            tB.Text += "Ограничения:\n"; tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "● Использовать простой линейный список, написанный вручную.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "● Структура данных должна быть максимально простой.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "● Использовать стандартные инструменты языка без применения внешних \n"; tB.AppendText(Environment.NewLine);
            tB.Text += "библиотек.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "● Использовать конструкции обработки исключений при работе с файлами.\n"; tB.AppendText(Environment.NewLine);
            tB.Text += "● Приветствуется создание простейшего интерфейса UI для операций с файлами и отображения результатов (статистики).\n";

            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "Предлагаемые технологии:\n";
            tB.AppendText(Environment.NewLine); tB.AppendText(Environment.NewLine);
            tB.Text += "1) SDK: Visual Studio, Qt Creator, VS Code. \n"; tB.AppendText(Environment.NewLine);
            tB.Text += "2) Programming language: C++, C#, Python\n"; tB.AppendText(Environment.NewLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = ColorTranslator.FromHtml("#2b2b2b");
            this.MinimumSize = new Size(550, 400);

            this.tB.AcceptsReturn = true;
            this.tB.BackColor = ColorTranslator.FromHtml("#2b2b2b");
            this.tB.ForeColor = ColorTranslator.FromHtml("#AAAAAA");
            this.tB.AcceptsTab = true;
            this.tB.ReadOnly = true;
            this.tB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB.SelectionLength = 0;
            this.tB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tB.Multiline = true;
            this.tB.KeyDown += new KeyEventHandler(AboutForm_KeyDown);
            this.Controls.Add(tB);




        }
    }
}