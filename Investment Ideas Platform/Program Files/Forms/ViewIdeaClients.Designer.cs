﻿namespace Relationship_manager_administration_system
{
    partial class viewIdeaClients
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
            this.ideasGrid = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblRmId = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ideasGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ideasGrid
            // 
            this.ideasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ideasGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Summary,
            this.Description,
            this.Client});
            this.ideasGrid.Location = new System.Drawing.Point(12, 120);
            this.ideasGrid.Name = "ideasGrid";
            this.ideasGrid.RowTemplate.Height = 25;
            this.ideasGrid.Size = new System.Drawing.Size(776, 150);
            this.ideasGrid.TabIndex = 0;
            this.ideasGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ideasGrid_CellContentClick);
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // Summary
            // 
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            // 
            // Description
            // 
            this.Description.HeaderText = "Desription";
            this.Description.Name = "Description";
            // 
            // Client
            // 
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 41);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(657, 400);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(121, 41);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblRmId
            // 
            this.lblRmId.AutoSize = true;
            this.lblRmId.Location = new System.Drawing.Point(35, 22);
            this.lblRmId.Name = "lblRmId";
            this.lblRmId.Size = new System.Drawing.Size(39, 15);
            this.lblRmId.TabIndex = 3;
            this.lblRmId.Text = "RM ID";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(35, 300);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(52, 15);
            this.lblClientId.TabIndex = 4;
            this.lblClientId.Text = "Client ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Relationship Administration System";
            // 
            // viewIdeaClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.lblRmId);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ideasGrid);
            this.Name = "viewIdeaClients";
            this.Text = "View Idea Clients";
            this.Load += new System.EventHandler(this.viewIdeaClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ideasGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ideasGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblRmId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.Label label1;
    }
}