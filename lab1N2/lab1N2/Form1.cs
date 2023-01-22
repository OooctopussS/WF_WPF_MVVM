using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1N2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "FTP-client";
            this.Icon = Properties.Resources.ftp;
            this.Size = new Size(919, 584);

            MenuStrip menuStrip = Create_MenuStrip();

            ToolStrip menuToolStrip1 = Create_ToolStrip1();

            ToolStrip menuToolStrip2 = Create_ToolStrip2();

            TabControl tabControl = Create_TabControl();

            SplitContainer splContainer1 = Create_SplitContainer();


            this.MainMenuStrip = menuStrip;

            this.Controls.Add(splContainer1);
            this.Controls.Add(tabControl);
            this.Controls.Add(menuToolStrip2);
            this.Controls.Add(menuToolStrip1);
            this.Controls.Add(menuStrip);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private MenuStrip Create_MenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip()
            {
                Dock = DockStyle.Top,
                BackColor = SystemColors.ControlLight
            };

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem editingMenu = new ToolStripMenuItem("Editing");
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("View");

            List<String> fileItems = new List<String>
            {
                "File1", "File2", "File3"
            };

            List<String> editingItems = new List<String>
            {
                "Editing1", "Editing2", "Editing3"
            };

            List<String> viewItems = new List<String>
            {
                "View1", "View2", "View3"
            };

            List<String> menuItems = new List<String>
            {
                "Broadcast", "Server", "Bookmarks", "Support"
            };

            foreach (String items in fileItems)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);

                fileMenu.DropDownItems.Add(item);

                item.Click += new EventHandler(Item_Click);
            }

            foreach (String items in editingItems)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);

                editingMenu.DropDownItems.Add(item);

                item.Click += new EventHandler(Item_Click);
            }

            foreach (String items in viewItems)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);

                viewMenu.DropDownItems.Add(item);

                item.Click += new EventHandler(Item_Click);
            }
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(editingMenu);
            menuStrip.Items.Add(viewMenu);

            foreach (String items in menuItems)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);

                menuStrip.Items.Add(item);

                item.Click += new EventHandler(Item_Click);
            }

            return menuStrip;
        }

        private ToolStrip Create_ToolStrip1()
        {
            ToolStrip menuToolStrip = new ToolStrip()
            {
                Dock = DockStyle.Top,
                GripStyle = 0,
                BackColor = SystemColors.Control

            };

            ToolStripSplitButton serverSplitButton = new ToolStripSplitButton(Properties.Resources.servers);
            ToolStripSeparator separator1 = new ToolStripSeparator();
            ToolStripButton button1 = new ToolStripButton(Properties.Resources.file);
            ToolStripButton button2 = new ToolStripButton(Properties.Resources.left);
            ToolStripButton button3 = new ToolStripButton(Properties.Resources.right);
            ToolStripButton button4 = new ToolStripButton(Properties.Resources.horizontalTrade);
            ToolStripSeparator separator2 = new ToolStripSeparator();
            ToolStripButton button5 = new ToolStripButton(Properties.Resources.trade);
            ToolStripButton button6 = new ToolStripButton(Properties.Resources.tradeSettings);
            ToolStripButton button7 = new ToolStripButton(Properties.Resources.krest);
            ToolStripButton button8 = new ToolStripButton(Properties.Resources.filekrest);
            ToolStripButton button9 = new ToolStripButton(Properties.Resources.filegalka);
            ToolStripSeparator separator3 = new ToolStripSeparator();
            ToolStripButton button10 = new ToolStripButton(Properties.Resources.sepFiles);
            ToolStripButton button11 = new ToolStripButton(Properties.Resources.fileLupa);
            ToolStripButton button12 = new ToolStripButton(Properties.Resources.tradeFiles);
            ToolStripButton button13 = new ToolStripButton(Properties.Resources.binokl);
            menuToolStrip.Items.Add(serverSplitButton);
            menuToolStrip.Items.Add(separator1);
            menuToolStrip.Items.Add(button1);
            menuToolStrip.Items.Add(button2);
            menuToolStrip.Items.Add(button3);
            menuToolStrip.Items.Add(button4);
            menuToolStrip.Items.Add(separator2);
            menuToolStrip.Items.Add(button5);
            menuToolStrip.Items.Add(button6);
            menuToolStrip.Items.Add(button7);
            menuToolStrip.Items.Add(button8);
            menuToolStrip.Items.Add(button9);
            menuToolStrip.Items.Add(separator3);
            menuToolStrip.Items.Add(button10);
            menuToolStrip.Items.Add(button11);
            menuToolStrip.Items.Add(button12);
            menuToolStrip.Items.Add(button13);

            for (int i = 0; i < menuToolStrip.Items.Count; i++)
            {
                menuToolStrip.Items[i].Click += new EventHandler(Item_Click);
            }

            return menuToolStrip;
        }

        private ToolStrip Create_ToolStrip2()
        {
            ToolStrip menuToolStrip = new ToolStrip()
            {
                Dock = DockStyle.Top,
                GripStyle = 0,
                BackColor = SystemColors.ControlLight
            };

            ToolStripLabel label1 = new ToolStripLabel()
            {
                Text = "Хост:",
            };
            ToolStripTextBox textBox1 = new ToolStripTextBox()
            {
                Text = "host.org",
            };

            ToolStripLabel label2 = new ToolStripLabel()
            {
                Text = "Имя пользователя:",
            };
            ToolStripTextBox textBox2 = new ToolStripTextBox()
            {
                Text = "anonymous",
            };

            ToolStripLabel label3 = new ToolStripLabel()
            {
                Text = "Пароль",
            };
            ToolStripTextBox textBox3 = new ToolStripTextBox();

            ToolStripLabel label4 = new ToolStripLabel()
            {
                Text = "Порт:",
            };
            ToolStripTextBox textBox4 = new ToolStripTextBox()
            {
                Text = "2222",
            };

            ToolStripSplitButton connectSplitButton = new ToolStripSplitButton()
            {
                Text = "Быстрое соединение"
            };

            connectSplitButton.Click += new EventHandler(Item_Click);

            menuToolStrip.Items.Add(label1);
            menuToolStrip.Items.Add(textBox1);
            menuToolStrip.Items.Add(label2);
            menuToolStrip.Items.Add(textBox2);
            menuToolStrip.Items.Add(label3);
            menuToolStrip.Items.Add(textBox3);
            menuToolStrip.Items.Add(label4);
            menuToolStrip.Items.Add(textBox4);
            menuToolStrip.Items.Add(connectSplitButton);

            return menuToolStrip;
        }

        private TabControl Create_TabControl()
        {
            TabControl tabControl = new TabControl()
            {
                Dock = DockStyle.Bottom,
                Alignment = TabAlignment.Bottom,
                Height = 120
            };

            TabPage tabPage1 = new TabPage("Неудавшиеся передачи");

            ListView listView_TabControl1 = new ListView()
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                GridLines = true
            };
            listView_TabControl1.Columns.Add("Сервер/Локальные файлы", 200);
            listView_TabControl1.Columns.Add("Направление");
            listView_TabControl1.Columns.Add("Файл на сервере", 100);
            listView_TabControl1.Columns.Add("Размер");
            listView_TabControl1.Columns.Add("Приоритет");
            listView_TabControl1.Columns.Add("Состояние", 200);

            ListView listView_TabControl2 = new ListView()
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                GridLines = true
            };
            listView_TabControl2.Columns.Add("Сервер/Локальные файлы", 200);
            listView_TabControl2.Columns.Add("Направление");
            listView_TabControl2.Columns.Add("Файл на сервере", 100);
            listView_TabControl2.Columns.Add("Размер");
            listView_TabControl2.Columns.Add("Приоритет");
            listView_TabControl2.Columns.Add("Состояние", 200);

            ListView listView_TabControl3 = new ListView()
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                GridLines = true
            };
            listView_TabControl3.Columns.Add("Сервер/Локальные файлы", 200);
            listView_TabControl3.Columns.Add("Направление");
            listView_TabControl3.Columns.Add("Файл на сервере", 100);
            listView_TabControl3.Columns.Add("Размер");
            listView_TabControl3.Columns.Add("Приоритет");
            listView_TabControl3.Columns.Add("Состояние", 200);

            TabPage tabPage2 = new TabPage("Успешные передачи");
            TabPage tabPage3 = new TabPage("Файлы в задании");
            tabPage1.Controls.Add(listView_TabControl1);
            tabPage2.Controls.Add(listView_TabControl2);
            tabPage3.Controls.Add(listView_TabControl3);

            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);
            tabControl.TabPages.Add(tabPage3);

            return tabControl;
        }

        private SplitContainer Create_SplitContainer()
        {
            SplitContainer splContainer = new SplitContainer()
            {
                Dock = DockStyle.Fill,
                Panel1MinSize = 50,
                Panel2MinSize = 50,
                SplitterDistance = 75,
                SplitterWidth = 4
        };

            ToolStrip menuToolStrip = new ToolStrip()
            {
                Dock = DockStyle.Top,
                GripStyle = 0,
                BackColor = SystemColors.Control
            };

            ToolStripLabel label1 = new ToolStripLabel()
            {
                Text = "Локальный сайт:",
                Dock = DockStyle.Top
            };

            ToolStripComboBox comboBox1 = new ToolStripComboBox()
            {
                Text = "/home",
                Size = new Size(275, 25),
            };

            menuToolStrip.Items.Add(label1);
            menuToolStrip.Items.Add(comboBox1);

            ToolStripStatusLabel statusLabel1 = new ToolStripStatusLabel()
            {
                Text = "0 файлов и 2 каталога. Общий размер: 14,6 KB"
            };

            StatusStrip statusStrip1 = new StatusStrip()
            {
                Dock = DockStyle.Bottom
            };

            statusStrip1.Items.Add(statusLabel1);

            ImageList imgList1 = new ImageList();
            imgList1.Images.Add(Properties.Resources.fileIcon);

            ListView listView1 = new ListView()
            {
                Dock = DockStyle.Bottom,
                View = View.Details,
                GridLines = true,
                Size = new Size(454, 203)
            };
            listView1.Columns.Add("Имя файла", 100);
            listView1.Columns.Add("Размер");
            listView1.Columns.Add("Тип Файла", 100);
            listView1.Columns.Add("Права");
            listView1.Columns.Add("Владелец", 100);

            listView1.SmallImageList = imgList1;

            ListViewItem item1 = new ListViewItem()
            {
                Text = "..",
            };

            item1.ImageIndex = 0;

            ListViewItem item2 = new ListViewItem()
            {
                Text = ".cache",
            };

            item2.SubItems.Add("");
            item2.SubItems.Add("Каталог");
            item2.SubItems.Add("05.11.2022");

            item2.ImageIndex = 0;

            ListViewItem item3 = new ListViewItem()
            {
                Text = ".config",
            };

            item3.SubItems.Add("");
            item3.SubItems.Add("Каталог");
            item3.SubItems.Add("03.06.2022");

            item3.ImageIndex = 0;

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);

            TreeView treeView1 = new TreeView()
            {
                Dock = DockStyle.Fill
            };

            treeView1.ImageList = imgList1; 
            treeView1.ImageIndex = 0;

            TreeNode firstNode = new TreeNode("С:");
            firstNode.Nodes.Add(new TreeNode("Program Files(x86)"));
            firstNode.Nodes.Add(new TreeNode("temp"));
            firstNode.Nodes.Add(new TreeNode("Windows"));

            TreeNode secondNode = new TreeNode("D:");
            secondNode.Nodes.Add(new TreeNode("Films"));

            treeView1.Nodes.Add(firstNode);
            treeView1.Nodes.Add(secondNode);

            splContainer.Panel1.Controls.Add(treeView1);
            splContainer.Panel1.Controls.Add(menuToolStrip);
            splContainer.Panel1.Controls.Add(listView1);
            splContainer.Panel1.Controls.Add(statusStrip1);




            ToolStrip menuToolStrip2 = new ToolStrip()
            {
                Dock = DockStyle.Top,
                GripStyle = 0,
                BackColor = SystemColors.Control
            };

            ToolStripLabel label2 = new ToolStripLabel()
            {
                Text = "Удаленый сайт:",
                Dock = DockStyle.Top
            };

            ToolStripComboBox comboBox2 = new ToolStripComboBox()
            {
                Text = "/linux/fedora",
                Size = new Size(275, 25),
            };

            menuToolStrip2.Items.Add(label2);
            menuToolStrip2.Items.Add(comboBox2);

            ToolStripStatusLabel statusLabel2 = new ToolStripStatusLabel()
            {
                Text = "0 файлов и 4 каталога. Общий размер: 16,6 KB"
            };

            StatusStrip statusStrip2 = new StatusStrip()
            {
                Dock = DockStyle.Bottom
            };

            statusStrip2.Items.Add(statusLabel2);

            ImageList imgList2 = new ImageList();
            imgList2.Images.Add(Properties.Resources.fileIcon);

            ListView listView2 = new ListView()
            {
                Dock = DockStyle.Bottom,
                View = View.Details,
                GridLines = true,
                Size = new Size(454, 203)
            };
            listView2.Columns.Add("Имя файла", 100);
            listView2.Columns.Add("Размер");
            listView2.Columns.Add("Тип Файла", 100);
            listView2.Columns.Add("Права");
            listView2.Columns.Add("Владелец", 100);

            listView2.SmallImageList = imgList1;

            ListViewItem item4 = new ListViewItem()
            {
                Text = "..",
            };

            item4.ImageIndex = 0;

            ListViewItem item5 = new ListViewItem()
            {
                Text = "Folder1",
            };

            item5.SubItems.Add("");
            item5.SubItems.Add("Каталог");

            item5.ImageIndex = 0;

            ListViewItem item6 = new ListViewItem()
            {
                Text = "Folder2",
            };

            item6.ImageIndex = 0;

            ListViewItem item7 = new ListViewItem()
            {
                Text = "Folder3",
            };
            item7.SubItems.Add("");
            item7.SubItems.Add("Каталог");
            item7.SubItems.Add("02.07.2022");

            item7.ImageIndex = 0;

            ListViewItem item8 = new ListViewItem()
            {
                Text = "Folder4",
            };
            item8.SubItems.Add("");
            item8.SubItems.Add("Каталог");
            item8.SubItems.Add("21.03.2022");

            item8.ImageIndex = 0;

            listView2.Items.Add(item4);
            listView2.Items.Add(item5);
            listView2.Items.Add(item6);
            listView2.Items.Add(item7);
            listView2.Items.Add(item8);

            TreeView treeView2 = new TreeView()
            {
                Dock = DockStyle.Fill
            };

            treeView2.ImageList = imgList1;
            treeView2.ImageIndex = 0;

            TreeNode thirdNode = new TreeNode("linux");
            thirdNode.Nodes.Add(new TreeNode("archlinux"));
            thirdNode.Nodes.Add(new TreeNode("centos"));
            TreeNode subThirdNode = new TreeNode("fedora");
            subThirdNode.Nodes.Add(new TreeNode("fedora-epel"));
            thirdNode.Nodes.Add(subThirdNode);


            treeView2.Nodes.Add(thirdNode);

            splContainer.Panel2.Controls.Add(treeView2);
            splContainer.Panel2.Controls.Add(menuToolStrip2);
            splContainer.Panel2.Controls.Add(listView2);
            splContainer.Panel2.Controls.Add(statusStrip2);

            return splContainer;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Было нажатие на {sender}", $"{sender}");
        }
    }
}
