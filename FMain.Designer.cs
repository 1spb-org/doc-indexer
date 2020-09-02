namespace DocIndexer
{
    partial class FMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lvIndex = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btFilter = new System.Windows.Forms.Button();
            this.txFilter = new System.Windows.Forms.TextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReferencesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reindexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.visit1spborgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 31);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(339, 387);
            this.propertyGrid1.TabIndex = 0;
            // 
            // lvIndex
            // 
            this.lvIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chFolder,
            this.chFullPath,
            this.chFileId});
            this.lvIndex.HideSelection = false;
            this.lvIndex.Location = new System.Drawing.Point(0, 31);
            this.lvIndex.Name = "lvIndex";
            this.lvIndex.Size = new System.Drawing.Size(547, 387);
            this.lvIndex.TabIndex = 2;
            this.lvIndex.UseCompatibleStateImageBehavior = false;
            this.lvIndex.View = System.Windows.Forms.View.Details;
            this.lvIndex.SelectedIndexChanged += new System.EventHandler(this.lvIndex_SelectedIndexChanged);
            this.lvIndex.Click += new System.EventHandler(this.lvIndex_Click);
            // 
            // chName
            // 
            this.chName.Text = "File Name";
            this.chName.Width = 142;
            // 
            // chFolder
            // 
            this.chFolder.Text = "Folder";
            this.chFolder.Width = 145;
            // 
            // chFullPath
            // 
            this.chFullPath.Text = "Full Path";
            this.chFullPath.Width = 235;
            // 
            // chFileId
            // 
            this.chFileId.Text = "File Id";
            this.chFileId.Width = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btFilter);
            this.splitContainer1.Panel1.Controls.Add(this.txFilter);
            this.splitContainer1.Panel1.Controls.Add(this.lvIndex);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Size = new System.Drawing.Size(933, 443);
            this.splitContainer1.SplitterDistance = 552;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 3;
            // 
            // btFilter
            // 
            this.btFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFilter.Location = new System.Drawing.Point(460, 5);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(87, 25);
            this.btFilter.TabIndex = 4;
            this.btFilter.Text = "Filter";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // txFilter
            // 
            this.txFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txFilter.Location = new System.Drawing.Point(3, 6);
            this.txFilter.Name = "txFilter";
            this.txFilter.Size = new System.Drawing.Size(449, 22);
            this.txFilter.TabIndex = 3;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 421);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(371, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 25);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.visit1spborgToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showReferencesListToolStripMenuItem,
            this.reindexToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // showReferencesListToolStripMenuItem
            // 
            this.showReferencesListToolStripMenuItem.Enabled = false;
            this.showReferencesListToolStripMenuItem.Name = "showReferencesListToolStripMenuItem";
            this.showReferencesListToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.showReferencesListToolStripMenuItem.Text = "Show references list";
            this.showReferencesListToolStripMenuItem.Visible = false;
            // 
            // reindexToolStripMenuItem
            // 
            this.reindexToolStripMenuItem.Name = "reindexToolStripMenuItem";
            this.reindexToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.reindexToolStripMenuItem.Text = "Reindex";
            this.reindexToolStripMenuItem.Click += new System.EventHandler(this.reindexToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(933, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusMessage
            // 
            this.tsStatusMessage.Name = "tsStatusMessage";
            this.tsStatusMessage.Size = new System.Drawing.Size(42, 17);
            this.tsStatusMessage.Text = "Ready.";
            // 
            // visit1spborgToolStripMenuItem
            // 
            this.visit1spborgToolStripMenuItem.Name = "visit1spborgToolStripMenuItem";
            this.visit1spborgToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.visit1spborgToolStripMenuItem.Text = "&1spb.org";
            this.visit1spborgToolStripMenuItem.Click += new System.EventHandler(this.visit1spborgToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.projectToolStripMenuItem.Text = "&Project page";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "George\'s Documents Indexer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_FormClosing);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ListView lvIndex;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chFolder;
        private System.Windows.Forms.ColumnHeader chFullPath;
        private System.Windows.Forms.ColumnHeader chFileId;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.TextBox txFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReferencesListToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusMessage;
        private System.Windows.Forms.ToolStripMenuItem reindexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit1spborgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
    }
}

