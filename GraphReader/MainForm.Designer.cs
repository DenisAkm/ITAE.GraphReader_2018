using GraphReader.Classes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GraphReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("mid");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("med");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("graph1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьTextReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьTableWriterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.листToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьВсеГрафикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьВсеМедианныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьВсеСредниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.снятьВсеГрафикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снятьВсеМедианныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снятьВсеСредниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстовыйРедакторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преобразоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3Level2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new GraphReader.Classes.ExTreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxFinish = new System.Windows.Forms.TextBox();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoFinish = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStep = new System.Windows.Forms.CheckBox();
            this.checkBoxBorders = new System.Windows.Forms.CheckBox();
            this.checkBox_dB = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxExportPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSkip = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxDelimeter = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDelimeter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownDecimalNumb = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1Level2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelLevel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel3Level2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDecimalNumb)).BeginInit();
            this.tableLayoutPanel1Level2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanelLevel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.toolStripMenuItem3,
            this.изменитьToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1604, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.открытьTextReaderToolStripMenuItem,
            this.открытьTableWriterToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.открытьToolStripMenuItem.Text = "Открыть/Добавить";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // открытьTextReaderToolStripMenuItem
            // 
            this.открытьTextReaderToolStripMenuItem.Name = "открытьTextReaderToolStripMenuItem";
            this.открытьTextReaderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.открытьTextReaderToolStripMenuItem.Text = "Открыть TextReader";
            this.открытьTextReaderToolStripMenuItem.Click += new System.EventHandler(this.открытьTextReaderToolStripMenuItem_Click);
            // 
            // открытьTableWriterToolStripMenuItem
            // 
            this.открытьTableWriterToolStripMenuItem.Name = "открытьTableWriterToolStripMenuItem";
            this.открытьTableWriterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.открытьTableWriterToolStripMenuItem.Text = "Открыть TableWriter";
            this.открытьTableWriterToolStripMenuItem.Click += new System.EventHandler(this.открытьTableWriterToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.графикToolStripMenuItem,
            this.листToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // графикToolStripMenuItem
            // 
            this.графикToolStripMenuItem.Checked = true;
            this.графикToolStripMenuItem.CheckOnClick = true;
            this.графикToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            this.графикToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.графикToolStripMenuItem.Text = "График";
            this.графикToolStripMenuItem.Click += new System.EventHandler(this.графикToolStripMenuItem_Click);
            // 
            // листToolStripMenuItem
            // 
            this.листToolStripMenuItem.Checked = true;
            this.листToolStripMenuItem.CheckOnClick = true;
            this.листToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.листToolStripMenuItem.Name = "листToolStripMenuItem";
            this.листToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.листToolStripMenuItem.Text = "Лист";
            this.листToolStripMenuItem.Click += new System.EventHandler(this.листToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьВсеГрафикиToolStripMenuItem,
            this.выбратьВсеМедианныеToolStripMenuItem,
            this.выбратьВсеСредниеToolStripMenuItem,
            this.toolStripSeparator1,
            this.снятьВсеГрафикиToolStripMenuItem,
            this.снятьВсеМедианныеToolStripMenuItem,
            this.снятьВсеСредниеToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem3.Text = "Выбрать";
            // 
            // выбратьВсеГрафикиToolStripMenuItem
            // 
            this.выбратьВсеГрафикиToolStripMenuItem.Name = "выбратьВсеГрафикиToolStripMenuItem";
            this.выбратьВсеГрафикиToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выбратьВсеГрафикиToolStripMenuItem.Text = "Выбрать все графики";
            this.выбратьВсеГрафикиToolStripMenuItem.Click += new System.EventHandler(this.выбратьВсеГрафикиToolStripMenuItem_Click);
            // 
            // выбратьВсеМедианныеToolStripMenuItem
            // 
            this.выбратьВсеМедианныеToolStripMenuItem.Name = "выбратьВсеМедианныеToolStripMenuItem";
            this.выбратьВсеМедианныеToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выбратьВсеМедианныеToolStripMenuItem.Text = "Выбрать все медианные";
            this.выбратьВсеМедианныеToolStripMenuItem.Click += new System.EventHandler(this.выбратьВсеМедианныеToolStripMenuItem_Click);
            // 
            // выбратьВсеСредниеToolStripMenuItem
            // 
            this.выбратьВсеСредниеToolStripMenuItem.Name = "выбратьВсеСредниеToolStripMenuItem";
            this.выбратьВсеСредниеToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.выбратьВсеСредниеToolStripMenuItem.Text = "Выбрать все средние";
            this.выбратьВсеСредниеToolStripMenuItem.Click += new System.EventHandler(this.выбратьВсеСредниеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // снятьВсеГрафикиToolStripMenuItem
            // 
            this.снятьВсеГрафикиToolStripMenuItem.Name = "снятьВсеГрафикиToolStripMenuItem";
            this.снятьВсеГрафикиToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.снятьВсеГрафикиToolStripMenuItem.Text = "Снять все графики";
            this.снятьВсеГрафикиToolStripMenuItem.Click += new System.EventHandler(this.снятьВсеГрафикиToolStripMenuItem_Click);
            // 
            // снятьВсеМедианныеToolStripMenuItem
            // 
            this.снятьВсеМедианныеToolStripMenuItem.Name = "снятьВсеМедианныеToolStripMenuItem";
            this.снятьВсеМедианныеToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.снятьВсеМедианныеToolStripMenuItem.Text = "Снять все медианные";
            this.снятьВсеМедианныеToolStripMenuItem.Click += new System.EventHandler(this.снятьВсеМедианныеToolStripMenuItem_Click);
            // 
            // снятьВсеСредниеToolStripMenuItem
            // 
            this.снятьВсеСредниеToolStripMenuItem.Name = "снятьВсеСредниеToolStripMenuItem";
            this.снятьВсеСредниеToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.снятьВсеСредниеToolStripMenuItem.Text = "Снять все средние";
            this.снятьВсеСредниеToolStripMenuItem.Click += new System.EventHandler(this.снятьВсеСредниеToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текстовыйРедакторToolStripMenuItem,
            this.преобразоватьToolStripMenuItem});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.изменитьToolStripMenuItem.Text = "Редактирование";
            // 
            // текстовыйРедакторToolStripMenuItem
            // 
            this.текстовыйРедакторToolStripMenuItem.Name = "текстовыйРедакторToolStripMenuItem";
            this.текстовыйРедакторToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.текстовыйРедакторToolStripMenuItem.Text = "Текстовый редактор";
            this.текстовыйРедакторToolStripMenuItem.Click += new System.EventHandler(this.текстовыйРедакторToolStripMenuItem_Click);
            // 
            // преобразоватьToolStripMenuItem
            // 
            this.преобразоватьToolStripMenuItem.Name = "преобразоватьToolStripMenuItem";
            this.преобразоватьToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.преобразоватьToolStripMenuItem.Text = "Редактор значений";
            this.преобразоватьToolStripMenuItem.Click += new System.EventHandler(this.преобразоватьToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G,
            this.H,
            this.I,
            this.J,
            this.K,
            this.L,
            this.M,
            this.N,
            this.O,
            this.P,
            this.Q,
            this.R,
            this.S});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dataGridView1.Size = new System.Drawing.Size(411, 841);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            // 
            // A
            // 
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // B
            // 
            this.B.HeaderText = "B";
            this.B.Name = "B";
            this.B.ReadOnly = true;
            this.B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.ReadOnly = true;
            this.C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.ReadOnly = true;
            this.D.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.ReadOnly = true;
            this.E.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // F
            // 
            this.F.HeaderText = "F";
            this.F.Name = "F";
            this.F.ReadOnly = true;
            this.F.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // G
            // 
            this.G.HeaderText = "G";
            this.G.Name = "G";
            this.G.ReadOnly = true;
            this.G.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // H
            // 
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.ReadOnly = true;
            this.H.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // I
            // 
            this.I.HeaderText = "I";
            this.I.Name = "I";
            this.I.ReadOnly = true;
            this.I.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // J
            // 
            this.J.HeaderText = "J";
            this.J.Name = "J";
            this.J.ReadOnly = true;
            this.J.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // K
            // 
            this.K.HeaderText = "K";
            this.K.Name = "K";
            this.K.ReadOnly = true;
            this.K.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // L
            // 
            this.L.HeaderText = "L";
            this.L.Name = "L";
            this.L.ReadOnly = true;
            this.L.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // M
            // 
            this.M.HeaderText = "M";
            this.M.Name = "M";
            this.M.ReadOnly = true;
            this.M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // N
            // 
            this.N.HeaderText = "N";
            this.N.Name = "N";
            this.N.ReadOnly = true;
            this.N.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // O
            // 
            this.O.HeaderText = "O";
            this.O.Name = "O";
            this.O.ReadOnly = true;
            this.O.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // P
            // 
            this.P.HeaderText = "P";
            this.P.Name = "P";
            this.P.ReadOnly = true;
            this.P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Q
            // 
            this.Q.HeaderText = "Q";
            this.Q.Name = "Q";
            this.Q.ReadOnly = true;
            this.Q.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            this.R.ReadOnly = true;
            this.R.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // S
            // 
            this.S.HeaderText = "S";
            this.S.Name = "S";
            this.S.ReadOnly = true;
            this.S.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "Обновить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(816, 841);
            this.zedGraphControl1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.LightSalmon;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel3Level2);
            this.splitContainer2.Panel1MinSize = 288;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1Level2);
            this.splitContainer2.Size = new System.Drawing.Size(1598, 847);
            this.splitContainer2.SplitterDistance = 357;
            this.splitContainer2.TabIndex = 6;
            this.splitContainer2.TabStop = false;
            // 
            // tableLayoutPanel3Level2
            // 
            this.tableLayoutPanel3Level2.ColumnCount = 5;
            this.tableLayoutPanel3Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3Level2.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel3Level2.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel3Level2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3Level2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3Level2.Name = "tableLayoutPanel3Level2";
            this.tableLayoutPanel3Level2.RowCount = 2;
            this.tableLayoutPanel3Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 288F));
            this.tableLayoutPanel3Level2.Size = new System.Drawing.Size(357, 847);
            this.tableLayoutPanel3Level2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.tableLayoutPanel3Level2.SetColumnSpan(this.treeView1, 5);
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "mid";
            treeNode2.Name = "Node2";
            treeNode2.Text = "med";
            treeNode3.Name = "Node0";
            treeNode3.Text = "graph1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tableLayoutPanel3Level2.SetRowSpan(this.treeView1, 2);
            this.treeView1.Size = new System.Drawing.Size(351, 553);
            this.treeView1.TabIndex = 1;
            this.treeView1.TabStop = false;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel3Level2.SetColumnSpan(this.tabControl1, 5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(3, 562);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(351, 282);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(343, 253);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Построение";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxStart, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFinish, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxStep, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxX, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxY, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBoxFileName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxAutoStart, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxAutoFinish, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxAutoStep, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxBorders, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_dB, 0, 7);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(337, 247);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBoxStart
            // 
            this.textBoxStart.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStart.Location = new System.Drawing.Point(131, 66);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(202, 22);
            this.textBoxStart.TabIndex = 2;
            this.textBoxStart.TextChanged += new System.EventHandler(this.textBoxStart_TextChanged);
            this.textBoxStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEnterNumber_KeyPress);
            // 
            // textBoxFinish
            // 
            this.textBoxFinish.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFinish.Location = new System.Drawing.Point(131, 97);
            this.textBoxFinish.Name = "textBoxFinish";
            this.textBoxFinish.Size = new System.Drawing.Size(202, 22);
            this.textBoxFinish.TabIndex = 3;
            this.textBoxFinish.TextChanged += new System.EventHandler(this.textBoxFinish_TextChanged);
            this.textBoxFinish.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEnterNumber_KeyPress);
            // 
            // textBoxStep
            // 
            this.textBoxStep.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStep.Location = new System.Drawing.Point(131, 128);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(202, 22);
            this.textBoxStep.TabIndex = 4;
            this.textBoxStep.TextChanged += new System.EventHandler(this.textBoxStep_TextChanged);
            this.textBoxStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEnterNumber_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Название";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxX
            // 
            this.comboBoxX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBoxX.Location = new System.Drawing.Point(131, 159);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(202, 24);
            this.comboBoxX.TabIndex = 5;
            // 
            // comboBoxY
            // 
            this.comboBoxY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBoxY.Location = new System.Drawing.Point(131, 190);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(202, 24);
            this.comboBoxY.TabIndex = 6;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFileName.Location = new System.Drawing.Point(131, 8);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(202, 15);
            this.textBoxFileName.TabIndex = 20;
            this.textBoxFileName.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Колонка X";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "Колонка Y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoStart.Checked = true;
            this.checkBoxAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(4, 66);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(120, 24);
            this.checkBoxAutoStart.TabIndex = 26;
            this.checkBoxAutoStart.TabStop = false;
            this.checkBoxAutoStart.Text = "Начало";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.checkBoxAutoStart_CheckedChanged);
            // 
            // checkBoxAutoFinish
            // 
            this.checkBoxAutoFinish.AutoSize = true;
            this.checkBoxAutoFinish.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoFinish.Checked = true;
            this.checkBoxAutoFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutoFinish.Location = new System.Drawing.Point(4, 97);
            this.checkBoxAutoFinish.Name = "checkBoxAutoFinish";
            this.checkBoxAutoFinish.Size = new System.Drawing.Size(120, 24);
            this.checkBoxAutoFinish.TabIndex = 27;
            this.checkBoxAutoFinish.TabStop = false;
            this.checkBoxAutoFinish.Text = "Конец";
            this.checkBoxAutoFinish.UseVisualStyleBackColor = true;
            this.checkBoxAutoFinish.CheckedChanged += new System.EventHandler(this.checkBoxAutoFinish_CheckedChanged);
            // 
            // checkBoxAutoStep
            // 
            this.checkBoxAutoStep.AutoSize = true;
            this.checkBoxAutoStep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoStep.Checked = true;
            this.checkBoxAutoStep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxAutoStep.Location = new System.Drawing.Point(4, 128);
            this.checkBoxAutoStep.Name = "checkBoxAutoStep";
            this.checkBoxAutoStep.Size = new System.Drawing.Size(120, 24);
            this.checkBoxAutoStep.TabIndex = 28;
            this.checkBoxAutoStep.TabStop = false;
            this.checkBoxAutoStep.Text = "Шаг";
            this.checkBoxAutoStep.UseVisualStyleBackColor = true;
            this.checkBoxAutoStep.CheckedChanged += new System.EventHandler(this.checkBoxAutoStep_CheckedChanged);
            // 
            // checkBoxBorders
            // 
            this.checkBoxBorders.AutoSize = true;
            this.checkBoxBorders.BackColor = System.Drawing.SystemColors.Control;
            this.checkBoxBorders.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxBorders.Checked = true;
            this.checkBoxBorders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBorders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxBorders.Location = new System.Drawing.Point(4, 35);
            this.checkBoxBorders.Name = "checkBoxBorders";
            this.checkBoxBorders.Size = new System.Drawing.Size(120, 24);
            this.checkBoxBorders.TabIndex = 2;
            this.checkBoxBorders.TabStop = false;
            this.checkBoxBorders.Text = "Границы";
            this.checkBoxBorders.UseVisualStyleBackColor = false;
            this.checkBoxBorders.CheckedChanged += new System.EventHandler(this.checkBoxBorders_CheckedChanged);
            // 
            // checkBox_dB
            // 
            this.checkBox_dB.AutoSize = true;
            this.checkBox_dB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_dB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_dB.Location = new System.Drawing.Point(4, 221);
            this.checkBox_dB.Name = "checkBox_dB";
            this.checkBox_dB.Size = new System.Drawing.Size(120, 24);
            this.checkBox_dB.TabIndex = 23;
            this.checkBox_dB.TabStop = false;
            this.checkBox_dB.Text = "В дБ";
            this.checkBox_dB.UseVisualStyleBackColor = true;
            this.checkBox_dB.CheckedChanged += new System.EventHandler(this.checkBox_dB_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.tableLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(343, 253);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Результаты";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxExportPath, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 253);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button2, 2);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Медианные и средние в .docx";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Медианные и средние в .txt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxExportPath
            // 
            this.textBoxExportPath.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxExportPath, 2);
            this.textBoxExportPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxExportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxExportPath.Location = new System.Drawing.Point(3, 43);
            this.textBoxExportPath.Name = "textBoxExportPath";
            this.textBoxExportPath.Size = new System.Drawing.Size(337, 20);
            this.textBoxExportPath.TabIndex = 4;
            this.textBoxExportPath.Text = "С://расположение программы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Экспортировать файлы в папку:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(246, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "Обзор";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button4, 2);
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(3, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(337, 44);
            this.button4.TabIndex = 7;
            this.button4.Text = "Создать таблицу по меткам";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OpenTableWriter);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tableLayoutPanel6);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(343, 253);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.72515F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.27485F));
            this.tableLayoutPanel6.Controls.Add(this.numericUpDownSkip, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.checkBoxDelimeter, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxDelimeter, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.checkBoxHeader, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.comboBox1, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.numericUpDownDecimalNumb, 1, 5);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 7;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(343, 253);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // numericUpDownSkip
            // 
            this.numericUpDownSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSkip.Enabled = false;
            this.numericUpDownSkip.Location = new System.Drawing.Point(197, 117);
            this.numericUpDownSkip.Name = "numericUpDownSkip";
            this.numericUpDownSkip.Size = new System.Drawing.Size(142, 22);
            this.numericUpDownSkip.TabIndex = 26;
            this.numericUpDownSkip.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(4, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(186, 45);
            this.label12.TabIndex = 20;
            this.label12.Text = "Автоматическое определение разделителя";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxDelimeter
            // 
            this.checkBoxDelimeter.AutoSize = true;
            this.checkBoxDelimeter.Checked = true;
            this.checkBoxDelimeter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDelimeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDelimeter.Location = new System.Drawing.Point(197, 4);
            this.checkBoxDelimeter.Name = "checkBoxDelimeter";
            this.checkBoxDelimeter.Size = new System.Drawing.Size(142, 39);
            this.checkBoxDelimeter.TabIndex = 2;
            this.checkBoxDelimeter.UseVisualStyleBackColor = true;
            this.checkBoxDelimeter.CheckedChanged += new System.EventHandler(this.checkBoxDelimeter_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(4, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 30);
            this.label13.TabIndex = 21;
            this.label13.Text = "Разделитель";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "Количество нечитаемых строк";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxDelimeter
            // 
            this.comboBoxDelimeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxDelimeter.Enabled = false;
            this.comboBoxDelimeter.FormattingEnabled = true;
            this.comboBoxDelimeter.Items.AddRange(new object[] {
            "Tab",
            "Пробел",
            "Точка",
            "Запятая",
            "Точка с запятой"});
            this.comboBoxDelimeter.Location = new System.Drawing.Point(197, 50);
            this.comboBoxDelimeter.Name = "comboBoxDelimeter";
            this.comboBoxDelimeter.Size = new System.Drawing.Size(142, 24);
            this.comboBoxDelimeter.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "Файл с заголовком";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.Checked = true;
            this.checkBoxHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHeader.Location = new System.Drawing.Point(197, 81);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.Size = new System.Drawing.Size(142, 24);
            this.checkBoxHeader.TabIndex = 28;
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            this.checkBoxHeader.CheckedChanged += new System.EventHandler(this.checkBoxHeader_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 36);
            this.label4.TabIndex = 30;
            this.label4.Text = "Десятичные разделитель для записи в .txt:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.Items.AddRange(new object[] {
            "Точка",
            "Запятая"});
            this.comboBox1.Location = new System.Drawing.Point(197, 155);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 24);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 32);
            this.label5.TabIndex = 31;
            this.label5.Text = "Количество десятичных знаков";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDecimalNumb
            // 
            this.numericUpDownDecimalNumb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDecimalNumb.Location = new System.Drawing.Point(197, 193);
            this.numericUpDownDecimalNumb.Name = "numericUpDownDecimalNumb";
            this.numericUpDownDecimalNumb.Size = new System.Drawing.Size(142, 22);
            this.numericUpDownDecimalNumb.TabIndex = 32;
            this.numericUpDownDecimalNumb.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1Level2
            // 
            this.tableLayoutPanel1Level2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1Level2.ColumnCount = 2;
            this.tableLayoutPanel1Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.71519F));
            this.tableLayoutPanel1Level2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.28481F));
            this.tableLayoutPanel1Level2.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1Level2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1Level2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1Level2.Name = "tableLayoutPanel1Level2";
            this.tableLayoutPanel1Level2.RowCount = 2;
            this.tableLayoutPanel1Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Level2.Size = new System.Drawing.Size(1237, 847);
            this.tableLayoutPanel1Level2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LightSalmon;
            this.tableLayoutPanel1Level2.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel2.Controls.Add(this.zedGraphControl1);
            this.tableLayoutPanel1Level2.SetRowSpan(this.splitContainer1, 2);
            this.splitContainer1.Size = new System.Drawing.Size(1231, 841);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 3;
            this.openFileDialog1.Multiselect = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // tableLayoutPanelLevel1
            // 
            this.tableLayoutPanelLevel1.ColumnCount = 1;
            this.tableLayoutPanelLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLevel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanelLevel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLevel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelLevel1.Name = "tableLayoutPanelLevel1";
            this.tableLayoutPanelLevel1.RowCount = 2;
            this.tableLayoutPanelLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelLevel1.Size = new System.Drawing.Size(1604, 858);
            this.tableLayoutPanelLevel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 882);
            this.Controls.Add(this.tableLayoutPanelLevel1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GraphReader ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel3Level2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDecimalNumb)).EndInit();
            this.tableLayoutPanel1Level2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanelLevel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        public ExTreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Level2;
        private System.Windows.Forms.ToolStripMenuItem открытьTextReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3Level2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLevel1;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem листToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxFinish;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.CheckBox checkBoxAutoFinish;
        private System.Windows.Forms.CheckBox checkBoxAutoStep;
        private System.Windows.Forms.CheckBox checkBoxBorders;
        private System.Windows.Forms.CheckBox checkBox_dB;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBoxDelimeter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownSkip;
        private System.Windows.Forms.ComboBox comboBoxDelimeter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсеГрафикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсеМедианныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсеСредниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьВсеГрафикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьВсеМедианныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьВсеСредниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьTableWriterToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TextBox textBoxExportPath;
        public System.Windows.Forms.NumericUpDown numericUpDownDecimalNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn A;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn G;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn K;
        private System.Windows.Forms.DataGridViewTextBoxColumn L;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn O;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстовыйРедакторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem преобразоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;        
    }
}

