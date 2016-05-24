namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PSTR = new System.Windows.Forms.Label();
            this.PNUM = new System.Windows.Forms.NumericUpDown();
            this.QUERYBTN = new System.Windows.Forms.Button();
            this.SQLTEXT = new System.Windows.Forms.RichTextBox();
            this.RESULTTEXT = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PNUM)).BeginInit();
            this.SuspendLayout();
            // 
            // PSTR
            // 
            this.PSTR.BackColor = System.Drawing.Color.Lime;
            this.PSTR.Font = new System.Drawing.Font("Consolas", 14F);
            this.PSTR.Location = new System.Drawing.Point(13, 13);
            this.PSTR.Name = "PSTR";
            this.PSTR.Size = new System.Drawing.Size(726, 126);
            this.PSTR.TabIndex = 0;
            this.PSTR.Text = "다음 ER 다이어그램을 Oracle DBMS에 입력하시오 (create)";
            this.PSTR.Click += new System.EventHandler(this.PSTR_Click);
            // 
            // PNUM
            // 
            this.PNUM.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNUM.Location = new System.Drawing.Point(759, 65);
            this.PNUM.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.PNUM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PNUM.Name = "PNUM";
            this.PNUM.Size = new System.Drawing.Size(120, 30);
            this.PNUM.TabIndex = 1;
            this.PNUM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PNUM.ValueChanged += new System.EventHandler(this.PNUM_ValueChanged);
            // 
            // QUERYBTN
            // 
            this.QUERYBTN.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QUERYBTN.Location = new System.Drawing.Point(899, 41);
            this.QUERYBTN.Name = "QUERYBTN";
            this.QUERYBTN.Size = new System.Drawing.Size(119, 74);
            this.QUERYBTN.TabIndex = 2;
            this.QUERYBTN.Text = "GO";
            this.QUERYBTN.UseVisualStyleBackColor = true;
            this.QUERYBTN.Click += new System.EventHandler(this.QUERYBTN_Click);
            // 
            // SQLTEXT
            // 
            this.SQLTEXT.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLTEXT.Location = new System.Drawing.Point(13, 153);
            this.SQLTEXT.Name = "SQLTEXT";
            this.SQLTEXT.Size = new System.Drawing.Size(1005, 148);
            this.SQLTEXT.TabIndex = 3;
            this.SQLTEXT.Text = "SQLTEXT";
            this.SQLTEXT.TextChanged += new System.EventHandler(this.SQLTEXT_TextChanged);
            // 
            // RESULTTEXT
            // 
            this.RESULTTEXT.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESULTTEXT.Location = new System.Drawing.Point(13, 323);
            this.RESULTTEXT.Name = "RESULTTEXT";
            this.RESULTTEXT.Size = new System.Drawing.Size(1005, 148);
            this.RESULTTEXT.TabIndex = 4;
            this.RESULTTEXT.Text = "RESULTTEXT";
            this.RESULTTEXT.TextChanged += new System.EventHandler(this.RESULTTEXT_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 532);
            this.Controls.Add(this.RESULTTEXT);
            this.Controls.Add(this.SQLTEXT);
            this.Controls.Add(this.QUERYBTN);
            this.Controls.Add(this.PNUM);
            this.Controls.Add(this.PSTR);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PNUM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PSTR;
        private System.Windows.Forms.NumericUpDown PNUM;
        private System.Windows.Forms.Button QUERYBTN;
        private System.Windows.Forms.RichTextBox SQLTEXT;
        private System.Windows.Forms.RichTextBox RESULTTEXT;
    }
}

