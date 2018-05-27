namespace DynamixTestApp
{
    partial class Master
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExecuteSQLAsDataTable = new System.Windows.Forms.Button();
            this.btnExecuteAsScalarAsLong = new System.Windows.Forms.Button();
            this.btnExecuteAsScalarWithParamsAsLong = new System.Windows.Forms.Button();
            this.btnExecuteAsListUsingSQLQuery = new System.Windows.Forms.Button();
            this.btnExecuteAsListUsingFunction = new System.Windows.Forms.Button();
            this.btnExecuteAsListUsingFunctionAndParameters = new System.Windows.Forms.Button();
            this.btnExecuteAsObjectUsingSqlQuery = new System.Windows.Forms.Button();
            this.btnExecuteAsObjectUsingFunctionName = new System.Windows.Forms.Button();
            this.btnExecuteAsObjectUsingFunctionNameAndParameters = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnExecuteNonQueryUsingFunction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 220;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblTitle);
            this.splitContainer1.Panel2.Controls.Add(this.dgvResult);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 770);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteSQLAsDataTable);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsScalarAsLong);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsScalarWithParamsAsLong);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsListUsingSQLQuery);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsListUsingFunction);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsListUsingFunctionAndParameters);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsObjectUsingSqlQuery);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsObjectUsingFunctionName);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteAsObjectUsingFunctionNameAndParameters);
            this.flowLayoutPanel1.Controls.Add(this.btnExecuteNonQueryUsingFunction);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 55);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 672);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnExecuteSQLAsDataTable
            // 
            this.btnExecuteSQLAsDataTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteSQLAsDataTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteSQLAsDataTable.Location = new System.Drawing.Point(0, 10);
            this.btnExecuteSQLAsDataTable.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteSQLAsDataTable.Name = "btnExecuteSQLAsDataTable";
            this.btnExecuteSQLAsDataTable.Size = new System.Drawing.Size(190, 42);
            this.btnExecuteSQLAsDataTable.TabIndex = 0;
            this.btnExecuteSQLAsDataTable.Text = "( Execute SQL ) As DataTabe";
            this.btnExecuteSQLAsDataTable.UseVisualStyleBackColor = true;
            this.btnExecuteSQLAsDataTable.Click += new System.EventHandler(this.btnExecuteSQLAsDataTable_Click);
            // 
            // btnExecuteAsScalarAsLong
            // 
            this.btnExecuteAsScalarAsLong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsScalarAsLong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsScalarAsLong.Location = new System.Drawing.Point(0, 65);
            this.btnExecuteAsScalarAsLong.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsScalarAsLong.Name = "btnExecuteAsScalarAsLong";
            this.btnExecuteAsScalarAsLong.Size = new System.Drawing.Size(190, 42);
            this.btnExecuteAsScalarAsLong.TabIndex = 1;
            this.btnExecuteAsScalarAsLong.Text = "( Execute As Scalar ) Using Function As long";
            this.btnExecuteAsScalarAsLong.UseVisualStyleBackColor = true;
            this.btnExecuteAsScalarAsLong.Click += new System.EventHandler(this.btnExecuteAsScalarAsLong_Click);
            // 
            // btnExecuteAsScalarWithParamsAsLong
            // 
            this.btnExecuteAsScalarWithParamsAsLong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsScalarWithParamsAsLong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsScalarWithParamsAsLong.Location = new System.Drawing.Point(0, 120);
            this.btnExecuteAsScalarWithParamsAsLong.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsScalarWithParamsAsLong.Name = "btnExecuteAsScalarWithParamsAsLong";
            this.btnExecuteAsScalarWithParamsAsLong.Size = new System.Drawing.Size(190, 58);
            this.btnExecuteAsScalarWithParamsAsLong.TabIndex = 2;
            this.btnExecuteAsScalarWithParamsAsLong.Text = "( Execute As Scalar ) With Function And Parameters  As long";
            this.btnExecuteAsScalarWithParamsAsLong.UseVisualStyleBackColor = true;
            this.btnExecuteAsScalarWithParamsAsLong.Click += new System.EventHandler(this.btnExecuteAsScalarWithParamsAsLong_Click);
            // 
            // btnExecuteAsListUsingSQLQuery
            // 
            this.btnExecuteAsListUsingSQLQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsListUsingSQLQuery.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsListUsingSQLQuery.Location = new System.Drawing.Point(0, 191);
            this.btnExecuteAsListUsingSQLQuery.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsListUsingSQLQuery.Name = "btnExecuteAsListUsingSQLQuery";
            this.btnExecuteAsListUsingSQLQuery.Size = new System.Drawing.Size(190, 42);
            this.btnExecuteAsListUsingSQLQuery.TabIndex = 3;
            this.btnExecuteAsListUsingSQLQuery.Text = "( Execute As List ) Using SQL Query";
            this.btnExecuteAsListUsingSQLQuery.UseVisualStyleBackColor = true;
            this.btnExecuteAsListUsingSQLQuery.Click += new System.EventHandler(this.btnExecuteAsListUsingSQLQuery_Click);
            // 
            // btnExecuteAsListUsingFunction
            // 
            this.btnExecuteAsListUsingFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsListUsingFunction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsListUsingFunction.Location = new System.Drawing.Point(0, 246);
            this.btnExecuteAsListUsingFunction.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsListUsingFunction.Name = "btnExecuteAsListUsingFunction";
            this.btnExecuteAsListUsingFunction.Size = new System.Drawing.Size(190, 42);
            this.btnExecuteAsListUsingFunction.TabIndex = 4;
            this.btnExecuteAsListUsingFunction.Text = "( Execute As List ) Using Function";
            this.btnExecuteAsListUsingFunction.UseVisualStyleBackColor = true;
            this.btnExecuteAsListUsingFunction.Click += new System.EventHandler(this.btnExecuteAsListUsingFunction_Click);
            // 
            // btnExecuteAsListUsingFunctionAndParameters
            // 
            this.btnExecuteAsListUsingFunctionAndParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsListUsingFunctionAndParameters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsListUsingFunctionAndParameters.Location = new System.Drawing.Point(0, 301);
            this.btnExecuteAsListUsingFunctionAndParameters.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsListUsingFunctionAndParameters.Name = "btnExecuteAsListUsingFunctionAndParameters";
            this.btnExecuteAsListUsingFunctionAndParameters.Size = new System.Drawing.Size(190, 51);
            this.btnExecuteAsListUsingFunctionAndParameters.TabIndex = 5;
            this.btnExecuteAsListUsingFunctionAndParameters.Text = "( Execute As List ) Using Function And Parameters";
            this.btnExecuteAsListUsingFunctionAndParameters.UseVisualStyleBackColor = true;
            this.btnExecuteAsListUsingFunctionAndParameters.Click += new System.EventHandler(this.btnExecuteAsListUsingFunctionAndParameters_Click);
            // 
            // btnExecuteAsObjectUsingSqlQuery
            // 
            this.btnExecuteAsObjectUsingSqlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsObjectUsingSqlQuery.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsObjectUsingSqlQuery.Location = new System.Drawing.Point(0, 365);
            this.btnExecuteAsObjectUsingSqlQuery.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsObjectUsingSqlQuery.Name = "btnExecuteAsObjectUsingSqlQuery";
            this.btnExecuteAsObjectUsingSqlQuery.Size = new System.Drawing.Size(190, 51);
            this.btnExecuteAsObjectUsingSqlQuery.TabIndex = 6;
            this.btnExecuteAsObjectUsingSqlQuery.Text = "( Execute As Object ) Using SQL Query";
            this.btnExecuteAsObjectUsingSqlQuery.UseVisualStyleBackColor = true;
            this.btnExecuteAsObjectUsingSqlQuery.Click += new System.EventHandler(this.btnExecuteAsObjectUsingSqlQuery_Click);
            // 
            // btnExecuteAsObjectUsingFunctionName
            // 
            this.btnExecuteAsObjectUsingFunctionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsObjectUsingFunctionName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsObjectUsingFunctionName.Location = new System.Drawing.Point(0, 429);
            this.btnExecuteAsObjectUsingFunctionName.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsObjectUsingFunctionName.Name = "btnExecuteAsObjectUsingFunctionName";
            this.btnExecuteAsObjectUsingFunctionName.Size = new System.Drawing.Size(190, 51);
            this.btnExecuteAsObjectUsingFunctionName.TabIndex = 7;
            this.btnExecuteAsObjectUsingFunctionName.Text = "( Execute As Object ) Using Function";
            this.btnExecuteAsObjectUsingFunctionName.UseVisualStyleBackColor = true;
            this.btnExecuteAsObjectUsingFunctionName.Click += new System.EventHandler(this.btnExecuteAsObjectUsingFunctionName_Click);
            // 
            // btnExecuteAsObjectUsingFunctionNameAndParameters
            // 
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Location = new System.Drawing.Point(0, 493);
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Name = "btnExecuteAsObjectUsingFunctionNameAndParameters";
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Size = new System.Drawing.Size(190, 51);
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.TabIndex = 8;
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Text = "( Execute As Object ) Using Function And Parameters";
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.UseVisualStyleBackColor = true;
            this.btnExecuteAsObjectUsingFunctionNameAndParameters.Click += new System.EventHandler(this.btnExecuteAsObjectUsingFunctionNameAndParameters_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(21, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(48, 25);
            this.lblTitle.TabIndex = 909;
            this.lblTitle.Text = "Title";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResult.Location = new System.Drawing.Point(21, 66);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(815, 692);
            this.dgvResult.TabIndex = 908;
            // 
            // btnExecuteNonQueryUsingFunction
            // 
            this.btnExecuteNonQueryUsingFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecuteNonQueryUsingFunction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExecuteNonQueryUsingFunction.Location = new System.Drawing.Point(0, 557);
            this.btnExecuteNonQueryUsingFunction.Margin = new System.Windows.Forms.Padding(0, 10, 0, 3);
            this.btnExecuteNonQueryUsingFunction.Name = "btnExecuteNonQueryUsingFunction";
            this.btnExecuteNonQueryUsingFunction.Size = new System.Drawing.Size(190, 51);
            this.btnExecuteNonQueryUsingFunction.TabIndex = 9;
            this.btnExecuteNonQueryUsingFunction.Text = "( Execute Non Query ) Using Function";
            this.btnExecuteNonQueryUsingFunction.UseVisualStyleBackColor = true;
            this.btnExecuteNonQueryUsingFunction.Click += new System.EventHandler(this.btnExecuteNonQueryUsingFunction_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 770);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Master";
            this.Text = "Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExecuteSQLAsDataTable;
        private System.Windows.Forms.Button btnExecuteAsScalarAsLong;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExecuteAsScalarWithParamsAsLong;
        private System.Windows.Forms.Button btnExecuteAsListUsingSQLQuery;
        private System.Windows.Forms.Button btnExecuteAsListUsingFunction;
        private System.Windows.Forms.Button btnExecuteAsListUsingFunctionAndParameters;
        private System.Windows.Forms.Button btnExecuteAsObjectUsingSqlQuery;
        private System.Windows.Forms.Button btnExecuteAsObjectUsingFunctionName;
        private System.Windows.Forms.Button btnExecuteAsObjectUsingFunctionNameAndParameters;
        private System.Windows.Forms.Button btnExecuteNonQueryUsingFunction;
    }
}

