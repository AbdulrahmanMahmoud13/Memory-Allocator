namespace Memory_Allocator
{
    partial class MemAllc
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
            this.MemSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NumProcess = new System.Windows.Forms.TextBox();
            this.AllocAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumHoles = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProcessTable = new System.Windows.Forms.DataGridView();
            this.HolesTable = new System.Windows.Forms.DataGridView();
            this.HoleSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear = new System.Windows.Forms.Button();
            this.Allocate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DeAllocate = new System.Windows.Forms.Button();
            this.HowToUse = new System.Windows.Forms.Button();
            this.GeneProcess = new System.Windows.Forms.Button();
            this.GeneHole = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NewProcess = new System.Windows.Forms.Button();
            this.DeAlloc = new System.Windows.Forms.CheckedListBox();
            this.ProcessSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HolesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MemSize
            // 
            this.MemSize.ForeColor = System.Drawing.Color.Silver;
            this.MemSize.Location = new System.Drawing.Point(27, 28);
            this.MemSize.Name = "MemSize";
            this.MemSize.Size = new System.Drawing.Size(114, 20);
            this.MemSize.TabIndex = 0;
            this.MemSize.Text = "Enter the Size in (KB)";
            this.MemSize.Leave += new System.EventHandler(this.MemSize_Leave);
            this.MemSize.Enter += new System.EventHandler(this.MemSize_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Memory Size ";
            // 
            // NumProcess
            // 
            this.NumProcess.ForeColor = System.Drawing.Color.Silver;
            this.NumProcess.Location = new System.Drawing.Point(27, 87);
            this.NumProcess.Name = "NumProcess";
            this.NumProcess.Size = new System.Drawing.Size(141, 20);
            this.NumProcess.TabIndex = 2;
            this.NumProcess.Text = "Write a Number (Ex. 5)";
            this.NumProcess.Leave += new System.EventHandler(this.NumProcess_Leave);
            this.NumProcess.Enter += new System.EventHandler(this.NumProcess_Enter);
            // 
            // AllocAlgorithm
            // 
            this.AllocAlgorithm.DisplayMember = "First Fit";
            this.AllocAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AllocAlgorithm.FormattingEnabled = true;
            this.AllocAlgorithm.Items.AddRange(new object[] {
            "First Fit",
            "Best Fit"});
            this.AllocAlgorithm.Location = new System.Drawing.Point(174, 28);
            this.AllocAlgorithm.Name = "AllocAlgorithm";
            this.AllocAlgorithm.Size = new System.Drawing.Size(90, 21);
            this.AllocAlgorithm.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Allocation Algorithm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Num. of Processes";
            // 
            // NumHoles
            // 
            this.NumHoles.ForeColor = System.Drawing.Color.Silver;
            this.NumHoles.Location = new System.Drawing.Point(299, 90);
            this.NumHoles.Name = "NumHoles";
            this.NumHoles.Size = new System.Drawing.Size(137, 20);
            this.NumHoles.TabIndex = 6;
            this.NumHoles.Text = "Write a Number (Ex. 5)";
            this.NumHoles.Leave += new System.EventHandler(this.NumHoles_Leave);
            this.NumHoles.Enter += new System.EventHandler(this.NumHoles_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Num. of Holes";
            // 
            // ProcessTable
            // 
            this.ProcessTable.AllowUserToAddRows = false;
            this.ProcessTable.AllowUserToDeleteRows = false;
            this.ProcessTable.AllowUserToResizeColumns = false;
            this.ProcessTable.AllowUserToResizeRows = false;
            this.ProcessTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ProcessTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessSize,
            this.Status});
            this.ProcessTable.Location = new System.Drawing.Point(23, 134);
            this.ProcessTable.Name = "ProcessTable";
            this.ProcessTable.RowHeadersWidth = 60;
            this.ProcessTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ProcessTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessTable.Size = new System.Drawing.Size(237, 150);
            this.ProcessTable.TabIndex = 8;
            this.ProcessTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ProcessTable_CellFormatting);
            // 
            // HolesTable
            // 
            this.HolesTable.AllowUserToAddRows = false;
            this.HolesTable.AllowUserToDeleteRows = false;
            this.HolesTable.AllowUserToResizeColumns = false;
            this.HolesTable.AllowUserToResizeRows = false;
            this.HolesTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HolesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HolesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoleSize,
            this.StartAddress});
            this.HolesTable.Location = new System.Drawing.Point(299, 134);
            this.HolesTable.Name = "HolesTable";
            this.HolesTable.RowHeadersWidth = 60;
            this.HolesTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.HolesTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HolesTable.Size = new System.Drawing.Size(243, 150);
            this.HolesTable.TabIndex = 9;
            this.HolesTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.HolesTable_CellFormatting);
            // 
            // HoleSize
            // 
            this.HoleSize.HeaderText = "Size (KB)";
            this.HoleSize.Name = "HoleSize";
            this.HoleSize.Width = 80;
            // 
            // StartAddress
            // 
            this.StartAddress.HeaderText = "Starting Address";
            this.StartAddress.Name = "StartAddress";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(27, 348);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 10;
            this.Clear.Text = "Reset";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Allocate
            // 
            this.Allocate.Location = new System.Drawing.Point(467, 345);
            this.Allocate.Name = "Allocate";
            this.Allocate.Size = new System.Drawing.Size(75, 23);
            this.Allocate.TabIndex = 11;
            this.Allocate.Text = "Allocate";
            this.Allocate.UseVisualStyleBackColor = true;
            this.Allocate.Click += new System.EventHandler(this.Allocate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Processes to De-Allocate";
            // 
            // DeAllocate
            // 
            this.DeAllocate.Location = new System.Drawing.Point(266, 345);
            this.DeAllocate.Name = "DeAllocate";
            this.DeAllocate.Size = new System.Drawing.Size(75, 23);
            this.DeAllocate.TabIndex = 14;
            this.DeAllocate.Text = "De-Allocate";
            this.DeAllocate.UseVisualStyleBackColor = true;
            this.DeAllocate.Click += new System.EventHandler(this.DeAllocate_Click);
            // 
            // HowToUse
            // 
            this.HowToUse.Location = new System.Drawing.Point(442, 25);
            this.HowToUse.Name = "HowToUse";
            this.HowToUse.Size = new System.Drawing.Size(100, 23);
            this.HowToUse.TabIndex = 15;
            this.HowToUse.Text = "How to use ?";
            this.HowToUse.UseVisualStyleBackColor = true;
            this.HowToUse.Click += new System.EventHandler(this.HowToUse_Click);
            // 
            // GeneProcess
            // 
            this.GeneProcess.Location = new System.Drawing.Point(174, 87);
            this.GeneProcess.Name = "GeneProcess";
            this.GeneProcess.Size = new System.Drawing.Size(90, 36);
            this.GeneProcess.TabIndex = 16;
            this.GeneProcess.Text = "Generate Processes";
            this.GeneProcess.UseVisualStyleBackColor = true;
            this.GeneProcess.Click += new System.EventHandler(this.GeneProcess_Click);
            // 
            // GeneHole
            // 
            this.GeneHole.Location = new System.Drawing.Point(442, 87);
            this.GeneHole.Name = "GeneHole";
            this.GeneHole.Size = new System.Drawing.Size(100, 23);
            this.GeneHole.TabIndex = 17;
            this.GeneHole.Text = "Generate Holes";
            this.GeneHole.UseCompatibleTextRendering = true;
            this.GeneHole.UseVisualStyleBackColor = true;
            this.GeneHole.Click += new System.EventHandler(this.GeneHole_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(141, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "(KB)";
            // 
            // NewProcess
            // 
            this.NewProcess.Enabled = false;
            this.NewProcess.Location = new System.Drawing.Point(27, 290);
            this.NewProcess.Name = "NewProcess";
            this.NewProcess.Size = new System.Drawing.Size(237, 23);
            this.NewProcess.TabIndex = 19;
            this.NewProcess.Text = "Add New Process";
            this.NewProcess.UseVisualStyleBackColor = true;
            this.NewProcess.Click += new System.EventHandler(this.NewProcess_Click);
            // 
            // DeAlloc
            // 
            this.DeAlloc.FormattingEnabled = true;
            this.DeAlloc.Location = new System.Drawing.Point(140, 345);
            this.DeAlloc.Name = "DeAlloc";
            this.DeAlloc.Size = new System.Drawing.Size(120, 34);
            this.DeAlloc.TabIndex = 20;
            // 
            // ProcessSize
            // 
            this.ProcessSize.HeaderText = "Size (KB)";
            this.ProcessSize.Name = "ProcessSize";
            this.ProcessSize.Width = 80;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // MemAllc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 390);
            this.Controls.Add(this.DeAlloc);
            this.Controls.Add(this.NewProcess);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GeneHole);
            this.Controls.Add(this.GeneProcess);
            this.Controls.Add(this.HowToUse);
            this.Controls.Add(this.DeAllocate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Allocate);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.HolesTable);
            this.Controls.Add(this.ProcessTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumHoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AllocAlgorithm);
            this.Controls.Add(this.NumProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MemSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MemAllc";
            this.Text = "Memory Allocator";
            this.Load += new System.EventHandler(this.MemAllc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HolesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MemSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumProcess;
        private System.Windows.Forms.ComboBox AllocAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumHoles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ProcessTable;
        private System.Windows.Forms.DataGridView HolesTable;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Allocate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeAllocate;
        private System.Windows.Forms.Button HowToUse;
        private System.Windows.Forms.Button GeneProcess;
        private System.Windows.Forms.Button GeneHole;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoleSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button NewProcess;
        private System.Windows.Forms.CheckedListBox DeAlloc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

