namespace TestInterfaceTool
{
    partial class ToolForHkc
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ServicesPath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServicePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InterfaceName = new System.Windows.Forms.ComboBox();
            this.txtInterface = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInputArg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtInterfaceSort = new System.Windows.Forms.TextBox();
            this.cmbInterfaceSort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServicesPath
            // 
            this.ServicesPath.FormattingEnabled = true;
            this.ServicesPath.Location = new System.Drawing.Point(122, 11);
            this.ServicesPath.Name = "ServicesPath";
            this.ServicesPath.Size = new System.Drawing.Size(193, 20);
            this.ServicesPath.TabIndex = 0;
            this.ServicesPath.TextChanged += new System.EventHandler(this.ServicesPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "接口路径：";
            // 
            // txtServicePath
            // 
            this.txtServicePath.Location = new System.Drawing.Point(321, 11);
            this.txtServicePath.Name = "txtServicePath";
            this.txtServicePath.Size = new System.Drawing.Size(255, 21);
            this.txtServicePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "接口名称：";
            // 
            // InterfaceName
            // 
            this.InterfaceName.FormattingEnabled = true;
            this.InterfaceName.Location = new System.Drawing.Point(121, 68);
            this.InterfaceName.Name = "InterfaceName";
            this.InterfaceName.Size = new System.Drawing.Size(194, 20);
            this.InterfaceName.TabIndex = 4;
            this.InterfaceName.TextChanged += new System.EventHandler(this.InterfaceName_TextChanged);
            // 
            // txtInterface
            // 
            this.txtInterface.Location = new System.Drawing.Point(321, 67);
            this.txtInterface.Name = "txtInterface";
            this.txtInterface.Size = new System.Drawing.Size(255, 21);
            this.txtInterface.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "输入参数:";
            // 
            // txtInputArg
            // 
            this.txtInputArg.Location = new System.Drawing.Point(121, 97);
            this.txtInputArg.Multiline = true;
            this.txtInputArg.Name = "txtInputArg";
            this.txtInputArg.Size = new System.Drawing.Size(455, 81);
            this.txtInputArg.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "输出数据：";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(121, 203);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(455, 59);
            this.txtOut.TabIndex = 9;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(153, 283);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(93, 23);
            this.btnCommit.TabIndex = 10;
            this.btnCommit.Text = "提交测试";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存参数";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(467, 283);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "导入参数";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtInterfaceSort
            // 
            this.txtInterfaceSort.Location = new System.Drawing.Point(321, 38);
            this.txtInterfaceSort.Name = "txtInterfaceSort";
            this.txtInterfaceSort.Size = new System.Drawing.Size(255, 21);
            this.txtInterfaceSort.TabIndex = 15;
            // 
            // cmbInterfaceSort
            // 
            this.cmbInterfaceSort.FormattingEnabled = true;
            this.cmbInterfaceSort.Location = new System.Drawing.Point(121, 39);
            this.cmbInterfaceSort.Name = "cmbInterfaceSort";
            this.cmbInterfaceSort.Size = new System.Drawing.Size(194, 20);
            this.cmbInterfaceSort.TabIndex = 14;
            this.cmbInterfaceSort.SelectedIndexChanged += new System.EventHandler(this.cmbInterfaceSort_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "接口分类";
            // 
            // ToolForHkc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 318);
            this.Controls.Add(this.txtInterfaceSort);
            this.Controls.Add(this.cmbInterfaceSort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInputArg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInterface);
            this.Controls.Add(this.InterfaceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServicePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServicesPath);
            this.Name = "ToolForHkc";
            this.Text = "惠卡彩接口测试工具";
            this.Load += new System.EventHandler(this.ToolForHkc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ServicesPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServicePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox InterfaceName;
        private System.Windows.Forms.TextBox txtInterface;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInputArg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtInterfaceSort;
        private System.Windows.Forms.ComboBox cmbInterfaceSort;
        private System.Windows.Forms.Label label5;
    }
}

