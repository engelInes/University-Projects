namespace l1WindowsForms
{
    partial class Form1
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
            this.employerLabel = new System.Windows.Forms.Label();
            this.jobLabel = new System.Windows.Forms.Label();
            this.EmployerView = new System.Windows.Forms.DataGridView();
            this.JobView = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            /*this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();*/
            ((System.ComponentModel.ISupportInitialize)(this.EmployerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobView)).BeginInit();
            this.SuspendLayout();
            // 
            // employerLabel
            // 
            this.employerLabel.AutoSize = true;
            this.employerLabel.Location = new System.Drawing.Point(527, 329);
            this.employerLabel.Name = "employerLabel";
            this.employerLabel.Size = new System.Drawing.Size(94, 25);
            this.employerLabel.TabIndex = 3;
            this.employerLabel.Text = "Employer";
            //.employerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // jobLabel
            // 
            this.jobLabel.AutoSize = true;
            this.jobLabel.Location = new System.Drawing.Point(1035, 329);
            this.jobLabel.Name = "jobLabel";
            this.jobLabel.Size = new System.Drawing.Size(45, 25);
            this.jobLabel.TabIndex = 4;
            this.jobLabel.Text = "Job";
            //this.jobLabel.Click += new System.EventHandler(this.Table2_Click);
            // 
            // EmployerView
            // 
            /*this.EmployerView.AllowUserToAddRows = false;
            this.EmployerView.AllowUserToDeleteRows = false;*/
            this.EmployerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployerView.Location = new System.Drawing.Point(833, 12);
            this.EmployerView.Name = "EmployerView";
            this.EmployerView.RowHeadersWidth = 72;
            this.EmployerView.RowTemplate.Height = 31;
            this.EmployerView.Size = new System.Drawing.Size(431, 368);
            this.EmployerView.TabIndex = 0;
            //.EmployerView.SelectionChanged += new System.EventHandler(this.EmployerView_SelectionChanged);
            // 
            // JobView
            // 
            /*this.JobView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JobView.Location = new System.Drawing.Point(591, 93);
            this.JobView.Name = "JobView";
            this.JobView.RowHeadersWidth = 72;
            this.JobView.Size = new System.Drawing.Size(431, 368);
            this.JobView.TabIndex = 3;
            this.JobView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JobView_CellContentClick);
            this.JobView.SelectionChanged += new System.EventHandler(this.JobView_SelectionChanged);*/
            this.EmployerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployerView.Location = new System.Drawing.Point(302, 12);
            this.EmployerView.Name = "JobView";
            this.EmployerView.RowHeadersWidth = 72;
            this.EmployerView.RowTemplate.Height = 31;
            this.EmployerView.Size = new System.Drawing.Size(478, 368);
            this.EmployerView.TabIndex = 1;
            // 
            // addButton
            // 
            /*this.addButton.Location = new System.Drawing.Point(93, 493);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(183, 45);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);*/
            // 
            // deleteButton
            // 
            /*this.deleteButton.Location = new System.Drawing.Point(778, 493);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(183, 45);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);*/
            // 
            // updateButton
            // 
            this.updateButton.AccessibleDescription = "updateButton";
            this.updateButton.AccessibleName = "updateButton";
            this.updateButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.updateButton.Location = new System.Drawing.Point(440, 493);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(183, 45);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.Form1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 716);
            this.Controls.Add(this.updateButton);
            /*this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);*/
            this.Controls.Add(this.JobView);
            this.Controls.Add(this.EmployerView);
            this.Controls.Add(this.jobLabel);
            this.Controls.Add(this.employerLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employerLabel;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.DataGridView EmployerView;
        private System.Windows.Forms.DataGridView JobView;
        /*private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;*/
        private System.Windows.Forms.Button updateButton;
    }
}

