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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьTextReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьTableWriterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.листToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаМедианныхсреднихToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаКонтрольныхЗначенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьВdatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поФайлуНаГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеВОдинФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстовыйРедакторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.преобразоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewFilesBrowser = new GraphReader.Classes.ExTreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewGraphBrowser = new System.Windows.Forms.ListView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_dB = new System.Windows.Forms.CheckBox();
            this.checkBoxNorma = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonOriginal = new System.Windows.Forms.RadioButton();
            this.radioButtonMiddle = new System.Windows.Forms.RadioButton();
            this.radioButtonMedian = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1Level2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelLevel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.exportToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.настройкиToolStripMenuItem,
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
            this.загрузитьtoolStripMenuItem,
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
            this.открытьToolStripMenuItem.Text = "Новый";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // загрузитьtoolStripMenuItem
            // 
            this.загрузитьtoolStripMenuItem.Name = "загрузитьtoolStripMenuItem";
            this.загрузитьtoolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.загрузитьtoolStripMenuItem.Text = "Загрузить файлы";
            this.загрузитьtoolStripMenuItem.Click += new System.EventHandler(this.загрузитьtoolStripMenuItem_Click);
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
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВWordToolStripMenuItem,
            this.выгрузитьВdatToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.exportToolStripMenuItem.Text = "Экспорт";
            // 
            // сохранитьВWordToolStripMenuItem
            // 
            this.сохранитьВWordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаМедианныхсреднихToolStripMenuItem,
            this.таблицаКонтрольныхЗначенийToolStripMenuItem});
            this.сохранитьВWordToolStripMenuItem.Name = "сохранитьВWordToolStripMenuItem";
            this.сохранитьВWordToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.сохранитьВWordToolStripMenuItem.Text = "Выгрузить в Word";
            // 
            // таблицаМедианныхсреднихToolStripMenuItem
            // 
            this.таблицаМедианныхсреднихToolStripMenuItem.Name = "таблицаМедианныхсреднихToolStripMenuItem";
            this.таблицаМедианныхсреднихToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.таблицаМедианныхсреднихToolStripMenuItem.Text = "Таблица медианных/средних";
            this.таблицаМедианныхсреднихToolStripMenuItem.Click += new System.EventHandler(this.таблицаМедианныхсреднихToolStripMenuItem_Click);
            // 
            // таблицаКонтрольныхЗначенийToolStripMenuItem
            // 
            this.таблицаКонтрольныхЗначенийToolStripMenuItem.Name = "таблицаКонтрольныхЗначенийToolStripMenuItem";
            this.таблицаКонтрольныхЗначенийToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.таблицаКонтрольныхЗначенийToolStripMenuItem.Text = "Таблица контрольных значений";
            this.таблицаКонтрольныхЗначенийToolStripMenuItem.Click += new System.EventHandler(this.таблицаКонтрольныхЗначенийToolStripMenuItem_Click);
            // 
            // выгрузитьВdatToolStripMenuItem
            // 
            this.выгрузитьВdatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поФайлуНаГрафикToolStripMenuItem,
            this.всеВОдинФайлToolStripMenuItem});
            this.выгрузитьВdatToolStripMenuItem.Name = "выгрузитьВdatToolStripMenuItem";
            this.выгрузитьВdatToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.выгрузитьВdatToolStripMenuItem.Text = "Выгрузить в (*.dat)";
            // 
            // поФайлуНаГрафикToolStripMenuItem
            // 
            this.поФайлуНаГрафикToolStripMenuItem.Name = "поФайлуНаГрафикToolStripMenuItem";
            this.поФайлуНаГрафикToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.поФайлуНаГрафикToolStripMenuItem.Text = "По файлу на график";
            this.поФайлуНаГрафикToolStripMenuItem.Click += new System.EventHandler(this.поФайлуНаГрафикToolStripMenuItem_Click);
            // 
            // всеВОдинФайлToolStripMenuItem
            // 
            this.всеВОдинФайлToolStripMenuItem.Name = "всеВОдинФайлToolStripMenuItem";
            this.всеВОдинФайлToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.всеВОдинФайлToolStripMenuItem.Text = "Все графики в один файл";
            this.всеВОдинФайлToolStripMenuItem.Click += new System.EventHandler(this.всеВОдинФайлToolStripMenuItem_Click);
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
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem1});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.настройкиToolStripMenuItem.Text = "Параметры";
            // 
            // открытьToolStripMenuItem1
            // 
            this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.открытьToolStripMenuItem1.Text = "Настройки";
            this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.открытьToolStripMenuItem1_Click);
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
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dataGridView1.Size = new System.Drawing.Size(411, 821);
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
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(816, 821);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1MinSize = 288;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1Level2);
            this.splitContainer2.Size = new System.Drawing.Size(1598, 827);
            this.splitContainer2.SplitterDistance = 357;
            this.splitContainer2.TabIndex = 6;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.LightSalmon;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer3.Size = new System.Drawing.Size(357, 827);
            this.splitContainer3.SplitterDistance = 515;
            this.splitContainer3.TabIndex = 7;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer4.Size = new System.Drawing.Size(357, 515);
            this.splitContainer4.SplitterDistance = 180;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.treeViewFilesBrowser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обозреватель файлов";
            // 
            // treeViewFilesBrowser
            // 
            this.treeViewFilesBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFilesBrowser.Location = new System.Drawing.Point(3, 16);
            this.treeViewFilesBrowser.Name = "treeViewFilesBrowser";
            this.treeViewFilesBrowser.Size = new System.Drawing.Size(351, 161);
            this.treeViewFilesBrowser.TabIndex = 8;
            this.treeViewFilesBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFilesBrowser_AfterSelect);
            this.treeViewFilesBrowser.DoubleClick += new System.EventHandler(this.treeViewFilesBrowser_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 331);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обозреватель графиков";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.listViewGraphBrowser, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(351, 312);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // listViewGraphBrowser
            // 
            this.listViewGraphBrowser.CheckBoxes = true;
            this.listViewGraphBrowser.ContextMenuStrip = this.contextMenuStrip2;
            this.listViewGraphBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGraphBrowser.FullRowSelect = true;
            this.listViewGraphBrowser.GridLines = true;
            this.listViewGraphBrowser.HideSelection = false;
            this.listViewGraphBrowser.LabelEdit = true;
            this.listViewGraphBrowser.Location = new System.Drawing.Point(0, 0);
            this.listViewGraphBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.listViewGraphBrowser.Name = "listViewGraphBrowser";
            this.listViewGraphBrowser.Size = new System.Drawing.Size(351, 312);
            this.listViewGraphBrowser.TabIndex = 2;
            this.listViewGraphBrowser.UseCompatibleStateImageBehavior = false;
            this.listViewGraphBrowser.View = System.Windows.Forms.View.List;
            this.listViewGraphBrowser.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewGraphBrowser_ItemChecked);
            this.listViewGraphBrowser.SelectedIndexChanged += new System.EventHandler(this.listViewGraphBrowser_SelectedIndexChanged);
            this.listViewGraphBrowser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewGraphBrowser_KeyUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переименоватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(162, 48);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.переименоватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(357, 308);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(351, 51);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.checkBox_dB, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxNorma, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.checkBox1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(345, 32);
            this.tableLayoutPanel5.TabIndex = 29;
            // 
            // checkBox_dB
            // 
            this.checkBox_dB.AutoSize = true;
            this.checkBox_dB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_dB.Location = new System.Drawing.Point(3, 3);
            this.checkBox_dB.Name = "checkBox_dB";
            this.checkBox_dB.Size = new System.Drawing.Size(109, 26);
            this.checkBox_dB.TabIndex = 23;
            this.checkBox_dB.TabStop = false;
            this.checkBox_dB.Text = "В дБ";
            this.checkBox_dB.UseVisualStyleBackColor = true;
            this.checkBox_dB.CheckedChanged += new System.EventHandler(this.checkBoxModification_CheckedChanged);
            // 
            // checkBoxNorma
            // 
            this.checkBoxNorma.AutoSize = true;
            this.checkBoxNorma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxNorma.Location = new System.Drawing.Point(233, 3);
            this.checkBoxNorma.Name = "checkBoxNorma";
            this.checkBoxNorma.Size = new System.Drawing.Size(109, 26);
            this.checkBoxNorma.TabIndex = 24;
            this.checkBoxNorma.Text = "Нормировать";
            this.checkBoxNorma.UseVisualStyleBackColor = true;
            this.checkBoxNorma.CheckedChanged += new System.EventHandler(this.checkBoxModification_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(118, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 26);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "В разы";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBoxModification_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 114);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.radioButtonOriginal, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonMiddle, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonMedian, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(345, 95);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // radioButtonOriginal
            // 
            this.radioButtonOriginal.AutoSize = true;
            this.radioButtonOriginal.Checked = true;
            this.radioButtonOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonOriginal.Location = new System.Drawing.Point(3, 3);
            this.radioButtonOriginal.Name = "radioButtonOriginal";
            this.radioButtonOriginal.Size = new System.Drawing.Size(339, 25);
            this.radioButtonOriginal.TabIndex = 26;
            this.radioButtonOriginal.TabStop = true;
            this.radioButtonOriginal.Text = "Оригинальное";
            this.radioButtonOriginal.UseVisualStyleBackColor = true;
            this.radioButtonOriginal.CheckedChanged += new System.EventHandler(this.CurveModificationChanged);
            // 
            // radioButtonMiddle
            // 
            this.radioButtonMiddle.AutoSize = true;
            this.radioButtonMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonMiddle.Location = new System.Drawing.Point(3, 65);
            this.radioButtonMiddle.Name = "radioButtonMiddle";
            this.radioButtonMiddle.Size = new System.Drawing.Size(339, 27);
            this.radioButtonMiddle.TabIndex = 25;
            this.radioButtonMiddle.Text = "Среднеарифметическое";
            this.radioButtonMiddle.UseVisualStyleBackColor = true;
            this.radioButtonMiddle.CheckedChanged += new System.EventHandler(this.CurveModificationChanged);
            // 
            // radioButtonMedian
            // 
            this.radioButtonMedian.AutoSize = true;
            this.radioButtonMedian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonMedian.Location = new System.Drawing.Point(3, 34);
            this.radioButtonMedian.Name = "radioButtonMedian";
            this.radioButtonMedian.Size = new System.Drawing.Size(339, 25);
            this.radioButtonMedian.TabIndex = 24;
            this.radioButtonMedian.Text = "Медианное";
            this.radioButtonMedian.UseVisualStyleBackColor = true;
            this.radioButtonMedian.CheckedChanged += new System.EventHandler(this.CurveModificationChanged);
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
            this.tableLayoutPanel1Level2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1Level2.Name = "tableLayoutPanel1Level2";
            this.tableLayoutPanel1Level2.RowCount = 2;
            this.tableLayoutPanel1Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1Level2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1Level2.Size = new System.Drawing.Size(1237, 827);
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
            this.splitContainer1.Size = new System.Drawing.Size(1231, 821);
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
            this.tableLayoutPanelLevel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLevel1.Name = "tableLayoutPanelLevel1";
            this.tableLayoutPanelLevel1.RowCount = 3;
            this.tableLayoutPanelLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1Level2;
        private System.Windows.Forms.ToolStripMenuItem открытьTextReaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLevel1;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem листToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem открытьTableWriterToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
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
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.ListView listViewGraphBrowser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаМедианныхсреднихToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаКонтрольныхЗначенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьВdatToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radioButtonOriginal;
        private System.Windows.Forms.RadioButton radioButtonMiddle;
        private System.Windows.Forms.RadioButton radioButtonMedian;
        private System.Windows.Forms.ToolStripMenuItem загрузитьtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поФайлуНаГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеВОдинФайлToolStripMenuItem;
        public ExTreeView treeViewFilesBrowser;
        public System.Windows.Forms.CheckBox checkBox_dB;
        public System.Windows.Forms.CheckBox checkBoxNorma;
        public System.Windows.Forms.CheckBox checkBox1;        
    }
}

