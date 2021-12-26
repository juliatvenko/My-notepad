using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourthWindowsFormsApp
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        //menuStrip1
        //File
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmMDIChild MDIChildNew = new fmMDIChild(); // створити нову форму
            MDIChildNew.MdiParent = this; // вказати батьківську форму
            MDIChildNew.Show(); // показати новостворену форму
            MDIChildNew.Text = "Window " + MDIchildFormNumber++;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    RichBox.LoadFile(openFileDialog.FileName);
            }
            else
            {
                fmMDIChild MDIChildNew = new fmMDIChild(); // створити нову форму
                MDIChildNew.MdiParent = this; // вказати батьківську форму
                MDIChildNew.Show(); // показати новостворену форму
                MDIChildNew.Text = "Window " + MDIchildFormNumber++;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "RichText Files (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    RichBox.SaveFile(saveFileDialog.FileName);
                }                   
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "RichText Files (*.rtf)|*.rtf|Txt Files (*.txt)|*.txt|Doc Files (*.docx)|*.docx|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    RichBox.SaveFile(saveFileDialog.FileName);
                }                    
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) //якщо є хоча б одне активне дочірнє вікно
            {
                ActiveMdiChild.Close();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren) //для кожного дочірнього вікна
                childForm.Close();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //View
        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible == true)//якщо панель інструментів видима, то при кліку
            {
                toolStrip1.Visible = false;
                toolbarToolStripMenuItem.Checked = false;
            }
            else
            {
                toolStrip1.Visible = true;
                toolbarToolStripMenuItem.Checked = true;
            }
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        //Edit
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Undo(); // "повертання" на крок назад із частиною тексту
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Redo(); // "повертання" на крок вперед із частиною тексту
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Cut(); //  вирізати виділену частину тексту
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Copy(); // копіювання виділеної частини тексту
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Paste(); //  вставити виділену частину тексту
            }
        }

        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
                //Викликаємо вікно провідника
                OpenFileDialog opfd = new OpenFileDialog();
                //Встановлюємо обмеження на розширення вибраного файлу
                opfd.Filter = "JPG|*.jpg|JPEG|*.jpeg";
                //Запам'ятовуємо робочий каталог провідника(за допомогою символа @ ігноруємо символи екранування \)
                opfd.InitialDirectory = @"C:\Users\User\Pictures\Saved Pictures";
                //Якщо вибрали зображення, то
                if (opfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Відкриваємо зображення у pictureBox1
                    pictureBox1.Image = Image.FromFile(opfd.FileName);
                    //Розтягуємо зображення на весь pictureBox1
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }            
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                string[] words = textBox1.Text.Split(' ');//Розділити стрічку на слова-масиви 
                foreach (string word in words)
                {
                    int startIndex = 0;
                    while (startIndex < RichBox.TextLength)
                    {
                        int wordStartIndex = RichBox.Find(word, startIndex, RichTextBoxFinds.WholeWord); //знайти такий індекс, від якого починається дане словолучення
                        if (wordStartIndex != -1) //якщо в тексті є таке словосполучення, то
                        {
                            //Підсвітити текст жовтим
                            RichBox.SelectionStart = wordStartIndex;
                            RichBox.SelectionLength = word.Length;
                            RichBox.SelectionBackColor = Color.Yellow;
                        }
                        else
                            break;
                        startIndex += wordStartIndex + word.Length;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                string find = textBox1.Text.Trim(); //"вирізати" текст з textBox1 
                string replace = textBox2.Text.Trim(); //"вирізати" текст з textBox2
                string newText = RichBox.Text.Replace(find, replace);
                RichBox.Text = newText;
            }
        }

        //Format
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                if (activeChild != null)
                {
                    RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                    RichBox.Font = fontDialog1.Font;
                }
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                if (activeChild != null)
                {
                    RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                    RichBox.SelectionColor = colorDialog1.Color;
                }
            }
        }

        //Window
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade); //упорядкувати усі дочірні вікна каскадом
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
             LayoutMdi(MdiLayout.TileHorizontal);//упорядкувати дочірні вікна по горизонталі
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);//упорядкувати дочірні вікна по вертикалі
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);//відображення дочірніх вікон у вигляді іконок
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren) // для всіх дочірніх вікон
                childForm.WindowState = FormWindowState.Minimized; // виконати мінімізацію
        }
        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren) // для всіх дочірніх вікон
                childForm.WindowState = FormWindowState.Maximized; // виконати максимізацію
        }

        //About
        int aboutFormFlag;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutFormFlag == 0)
            {
                aboutFormFlag++;
                fmAbout fmAbout = new fmAbout();
                fmAbout.MdiParent = this;
                using (fmAbout aboutForm = new fmAbout())
                {
                    aboutForm.ShowDialog(this);//ShowDialog робить форму модальною 
                }
            }
        }

        //toolStrip1
        public int MDIchildFormNumber = 1;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fmMDIChild MDIChildNew = new fmMDIChild(); // створити нову форму
            MDIChildNew.MdiParent = this; // вказати батьківську форму
            MDIChildNew.Show(); // показати новостворену форму
            MDIChildNew.Text = "Window " + MDIchildFormNumber++;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    RichBox.LoadFile(openFileDialog.FileName);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    RichBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Undo(); // "повертання" на крок назад із частиною тексту
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Redo(); // "повертання" на крок вперед із частиною тексту
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Cut(); //  вирізати виділену частину тексту
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Copy(); // копіювання виділеної частини тексту
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild; // доступ до активного дочірнього вікна
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl; // доступ до RichTextBox
                RichBox.Paste(); //  вставити виділену частину тексту
            }
        }
         
        //toolstrip2
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.Font = new Font(RichBox.Font, FontStyle.Bold);//закреслений текст 
            }

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.Font = new Font(RichBox.Font, FontStyle.Italic);//текст курсивом
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.Font = new Font(RichBox.Font, FontStyle.Underline);//підкреслений текст
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox RichBox = (RichTextBox)activeChild.ActiveControl;
                RichBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }
        //Timer and statusStrip
        private void timer1_Tick(object sender, EventArgs e)
        {
            //відображення поточного часу
            DateTime datetime = DateTime.Now;
            this.toolStripStatusLabel1.Text = datetime.ToString();
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                //відображення назви активного дочірнього вікна
                string text = activeChild.Text;
                this.toolStripStatusLabel2.Text = text.ToString();
                //синхронізація головного меню зі станом програми
                this.saveAsToolStripMenuItem.Enabled = true;
                this.saveToolStripMenuItem.Enabled = true;
                this.closeToolStripMenuItem.Enabled = true;
                this.closeAllToolStripMenuItem.Enabled = true;
                this.fontToolStripMenuItem.Enabled = true;
                this.colorToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Enabled = true;
                this.redoToolStripMenuItem.Enabled = true;
                this.cutToolStripMenuItem.Enabled = true;
                this.copyToolStripMenuItem.Enabled = true;
                this.pasteToolStripMenuItem.Enabled = true;
                this.insertImageToolStripMenuItem.Enabled = true;
                this.searchToolStripMenuItem.Enabled = true;
                this.replaceToolStripMenuItem.Enabled = true;
                this.cascadeToolStripMenuItem.Enabled = true;
                this.tileHorizontalToolStripMenuItem.Enabled = true;
                this.tileVerticalToolStripMenuItem.Enabled = true;
                this.arrangeIconsToolStripMenuItem.Enabled = true;
                this.minimizeAllToolStripMenuItem.Enabled = true;
                this.maximizeAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.saveAsToolStripMenuItem.Enabled = false;
                this.saveToolStripMenuItem.Enabled = false;
                this.closeToolStripMenuItem.Enabled = false;
                this.closeAllToolStripMenuItem.Enabled = false;
                this.fontToolStripMenuItem.Enabled = false;
                this.colorToolStripMenuItem.Enabled = false;
                this.undoToolStripMenuItem.Enabled = false;
                this.redoToolStripMenuItem.Enabled = false;
                this.cutToolStripMenuItem.Enabled = false;
                this.copyToolStripMenuItem.Enabled = false;
                this.pasteToolStripMenuItem.Enabled = false;
                this.insertImageToolStripMenuItem.Enabled = false;
                this.searchToolStripMenuItem.Enabled = false;
                this.replaceToolStripMenuItem.Enabled = false;
                this.cascadeToolStripMenuItem.Enabled = false;
                this.tileHorizontalToolStripMenuItem.Enabled = false;
                this.tileVerticalToolStripMenuItem.Enabled = false;
                this.arrangeIconsToolStripMenuItem.Enabled = false;
                this.minimizeAllToolStripMenuItem.Enabled = false;
                this.maximizeAllToolStripMenuItem.Enabled = false;
            }
        }
        private void fmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}