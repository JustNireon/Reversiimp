namespace Reversiboard
{
    partial class Reversi
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlReversi = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWit = new System.Windows.Forms.Label();
            this.btnPas = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblZwart = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlReversi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlReversi
            // 
            this.pnlReversi.BackColor = System.Drawing.Color.White;
            this.pnlReversi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReversi.Location = new System.Drawing.Point(302, 0);
            this.pnlReversi.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReversi.Name = "pnlReversi";
            this.pnlReversi.Size = new System.Drawing.Size(498, 450);
            this.pnlReversi.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblWit);
            this.panel2.Controls.Add(this.btnPas);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblZwart);
            this.panel2.Controls.Add(this.lblTitel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 450);
            this.panel2.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHelp.FlatAppearance.BorderSize = 2;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(80, 246);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(117, 29);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Reversiboard.Properties.Resources.swap_horizontal;
            this.pictureBox1.Location = new System.Drawing.Point(23, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lblWit
            // 
            this.lblWit.AutoSize = true;
            this.lblWit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.lblWit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblWit.ForeColor = System.Drawing.Color.White;
            this.lblWit.Location = new System.Drawing.Point(75, 92);
            this.lblWit.Name = "lblWit";
            this.lblWit.Size = new System.Drawing.Size(137, 21);
            this.lblWit.TabIndex = 2;
            this.lblWit.Text = "Wit heeft {} stenen";
            // 
            // btnPas
            // 
            this.btnPas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPas.FlatAppearance.BorderSize = 2;
            this.btnPas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPas.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnPas.ForeColor = System.Drawing.Color.White;
            this.btnPas.Location = new System.Drawing.Point(79, 211);
            this.btnPas.Name = "btnPas";
            this.btnPas.Size = new System.Drawing.Size(117, 29);
            this.btnPas.TabIndex = 7;
            this.btnPas.Text = "Pas";
            this.btnPas.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.FlatAppearance.BorderSize = 2;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(79, 176);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 29);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Nieuw spel";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 429);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 21);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Wit is aan zet.";
            // 
            // lblZwart
            // 
            this.lblZwart.AutoSize = true;
            this.lblZwart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.lblZwart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblZwart.ForeColor = System.Drawing.Color.White;
            this.lblZwart.Location = new System.Drawing.Point(75, 123);
            this.lblZwart.Name = "lblZwart";
            this.lblZwart.Size = new System.Drawing.Size(153, 21);
            this.lblZwart.TabIndex = 4;
            this.lblZwart.Text = "Zwart heeft {} stenen";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(101)))), ((int)(((byte)(107)))));
            this.lblTitel.Font = new System.Drawing.Font("Segoe UI Light", 21.75F);
            this.lblTitel.ForeColor = System.Drawing.Color.White;
            this.lblTitel.Location = new System.Drawing.Point(72, 34);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(125, 40);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Reversi™";
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Reversi";
            this.Text = "Reversi";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWit;
        private System.Windows.Forms.Button btnPas;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblZwart;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Panel pnlReversi;
    }
}