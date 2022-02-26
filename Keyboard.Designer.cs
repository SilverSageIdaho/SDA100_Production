
namespace SDA100
{
    partial class Keyboard
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
            this.btn_Keyboard_Cancel = new System.Windows.Forms.Button();
            this.btn_Keyboard_OK = new System.Windows.Forms.Button();
            this.txt_Test = new System.Windows.Forms.TextBox();
            this.btn_Test1 = new System.Windows.Forms.Button();
            this.btn_Test2 = new System.Windows.Forms.Button();
            this.btn_Test3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Keyboard_Cancel
            // 
            this.btn_Keyboard_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Keyboard_Cancel.Location = new System.Drawing.Point(581, 404);
            this.btn_Keyboard_Cancel.Name = "btn_Keyboard_Cancel";
            this.btn_Keyboard_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Keyboard_Cancel.TabIndex = 0;
            this.btn_Keyboard_Cancel.Text = "Cancel";
            this.btn_Keyboard_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Keyboard_OK
            // 
            this.btn_Keyboard_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Keyboard_OK.Location = new System.Drawing.Point(673, 404);
            this.btn_Keyboard_OK.Name = "btn_Keyboard_OK";
            this.btn_Keyboard_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_Keyboard_OK.TabIndex = 1;
            this.btn_Keyboard_OK.Text = "OK";
            this.btn_Keyboard_OK.UseVisualStyleBackColor = true;
            // 
            // txt_Test
            // 
            this.txt_Test.Location = new System.Drawing.Point(141, 73);
            this.txt_Test.Multiline = true;
            this.txt_Test.Name = "txt_Test";
            this.txt_Test.Size = new System.Drawing.Size(208, 45);
            this.txt_Test.TabIndex = 5;
            // 
            // btn_Test1
            // 
            this.btn_Test1.Location = new System.Drawing.Point(141, 133);
            this.btn_Test1.Name = "btn_Test1";
            this.btn_Test1.Size = new System.Drawing.Size(50, 50);
            this.btn_Test1.TabIndex = 6;
            this.btn_Test1.Text = "Hello";
            this.btn_Test1.UseVisualStyleBackColor = true;
            this.btn_Test1.Click += new System.EventHandler(this.btn_Test1_Click);
            // 
            // btn_Test2
            // 
            this.btn_Test2.Location = new System.Drawing.Point(217, 133);
            this.btn_Test2.Name = "btn_Test2";
            this.btn_Test2.Size = new System.Drawing.Size(50, 50);
            this.btn_Test2.TabIndex = 7;
            this.btn_Test2.Text = "World";
            this.btn_Test2.UseVisualStyleBackColor = true;
            this.btn_Test2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Test3
            // 
            this.btn_Test3.Location = new System.Drawing.Point(299, 133);
            this.btn_Test3.Name = "btn_Test3";
            this.btn_Test3.Size = new System.Drawing.Size(50, 50);
            this.btn_Test3.TabIndex = 8;
            this.btn_Test3.Text = "!!!!";
            this.btn_Test3.UseVisualStyleBackColor = true;
            this.btn_Test3.Click += new System.EventHandler(this.btn_Test3_Click);
            // 
            // Keyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Test3);
            this.Controls.Add(this.btn_Test2);
            this.Controls.Add(this.btn_Test1);
            this.Controls.Add(this.txt_Test);
            this.Controls.Add(this.btn_Keyboard_OK);
            this.Controls.Add(this.btn_Keyboard_Cancel);
            this.Name = "Keyboard";
            this.Text = "Keyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Keyboard_Cancel;
        private System.Windows.Forms.Button btn_Keyboard_OK;
        private System.Windows.Forms.TextBox txt_Test;
        private System.Windows.Forms.Button btn_Test1;
        private System.Windows.Forms.Button btn_Test2;
        private System.Windows.Forms.Button btn_Test3;
    }
}