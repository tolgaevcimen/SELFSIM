﻿namespace VisualInterface
{
    partial class Presenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
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
        private void InitializeComponent ()
        {
            this.drawing_panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_console = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.cb_choose_alg = new System.Windows.Forms.ComboBox();
            this.btn_run_update_bfs = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_random_nodes = new System.Windows.Forms.Button();
            this.number_of_random_nodes = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawing_panel
            // 
            this.drawing_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawing_panel.BackColor = System.Drawing.Color.White;
            this.drawing_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawing_panel.Location = new System.Drawing.Point(8, 8);
            this.drawing_panel.Margin = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(546, 549);
            this.drawing_panel.TabIndex = 0;
            this.drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseDown);
            this.drawing_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseMove);
            this.drawing_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.drawing_panel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 565);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.68595F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.31405F));
            this.tableLayoutPanel2.Controls.Add(this.tb_console, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_refresh, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.cb_choose_alg, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_run_update_bfs, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_clear, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btn_random_nodes, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.number_of_random_nodes, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(558, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 557);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tb_console
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tb_console, 2);
            this.tb_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_console.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_console.Location = new System.Drawing.Point(4, 4);
            this.tb_console.Margin = new System.Windows.Forms.Padding(4);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_console.Size = new System.Drawing.Size(284, 279);
            this.tb_console.TabIndex = 3;
            // 
            // btn_refresh
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btn_refresh, 2);
            this.btn_refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_refresh.Enabled = false;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_refresh.Location = new System.Drawing.Point(3, 515);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(286, 39);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.Text = "Refresh Nodes";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // cb_choose_alg
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cb_choose_alg, 2);
            this.cb_choose_alg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_choose_alg.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_choose_alg.FormattingEnabled = true;
            this.cb_choose_alg.Location = new System.Drawing.Point(3, 290);
            this.cb_choose_alg.Name = "cb_choose_alg";
            this.cb_choose_alg.Size = new System.Drawing.Size(286, 39);
            this.cb_choose_alg.TabIndex = 10;
            this.cb_choose_alg.SelectedIndexChanged += new System.EventHandler(this.cb_choose_alg_SelectedIndexChanged);
            // 
            // btn_run_update_bfs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btn_run_update_bfs, 2);
            this.btn_run_update_bfs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_run_update_bfs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_run_update_bfs.Location = new System.Drawing.Point(3, 335);
            this.btn_run_update_bfs.Name = "btn_run_update_bfs";
            this.btn_run_update_bfs.Size = new System.Drawing.Size(286, 39);
            this.btn_run_update_bfs.TabIndex = 9;
            this.btn_run_update_bfs.Text = "Run";
            this.btn_run_update_bfs.UseVisualStyleBackColor = true;
            this.btn_run_update_bfs.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_clear
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btn_clear, 2);
            this.btn_clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_clear.Location = new System.Drawing.Point(4, 471);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(284, 37);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_random_nodes
            // 
            this.btn_random_nodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_random_nodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_random_nodes.Location = new System.Drawing.Point(4, 426);
            this.btn_random_nodes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_random_nodes.Name = "btn_random_nodes";
            this.btn_random_nodes.Size = new System.Drawing.Size(218, 37);
            this.btn_random_nodes.TabIndex = 4;
            this.btn_random_nodes.Text = "Generate Random Nodes";
            this.btn_random_nodes.UseVisualStyleBackColor = true;
            this.btn_random_nodes.Click += new System.EventHandler(this.btn_random_nodes_Click);
            // 
            // number_of_random_nodes
            // 
            this.number_of_random_nodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.number_of_random_nodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.number_of_random_nodes.Location = new System.Drawing.Point(226, 429);
            this.number_of_random_nodes.Margin = new System.Windows.Forms.Padding(0, 7, 4, 11);
            this.number_of_random_nodes.Name = "number_of_random_nodes";
            this.number_of_random_nodes.Size = new System.Drawing.Size(62, 31);
            this.number_of_random_nodes.TabIndex = 5;
            // 
            // Presenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 565);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Presenter";
            this.Text = "Presenter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawing_panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_clear;
        public System.Windows.Forms.TextBox tb_console;
        private System.Windows.Forms.Button btn_random_nodes;
        private System.Windows.Forms.TextBox number_of_random_nodes;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_run_update_bfs;
        private System.Windows.Forms.ComboBox cb_choose_alg;
    }
}
