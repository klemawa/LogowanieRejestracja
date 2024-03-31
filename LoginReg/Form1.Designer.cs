namespace LoginReg
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLoginLogin = new System.Windows.Forms.TextBox();
            this.textBoxPasswordLogin = new System.Windows.Forms.TextBox();
            this.textBoxPasswordLoginRepeat = new System.Windows.Forms.TextBox();
            this.textBoxLoginRegister = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRegister = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRegisterRepeat = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLoginLogin
            // 
            this.textBoxLoginLogin.Location = new System.Drawing.Point(59, 70);
            this.textBoxLoginLogin.Name = "textBoxLoginLogin";
            this.textBoxLoginLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxLoginLogin.TabIndex = 0;
            this.textBoxLoginLogin.Text = "login";
            // 
            // textBoxPasswordLogin
            // 
            this.textBoxPasswordLogin.Location = new System.Drawing.Point(59, 128);
            this.textBoxPasswordLogin.Name = "textBoxPasswordLogin";
            this.textBoxPasswordLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordLogin.TabIndex = 1;
            this.textBoxPasswordLogin.Text = "password";
            // 
            // textBoxPasswordLoginRepeat
            // 
            this.textBoxPasswordLoginRepeat.Location = new System.Drawing.Point(59, 154);
            this.textBoxPasswordLoginRepeat.Name = "textBoxPasswordLoginRepeat";
            this.textBoxPasswordLoginRepeat.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordLoginRepeat.TabIndex = 2;
            this.textBoxPasswordLoginRepeat.Text = "repeat password";
            // 
            // textBoxLoginRegister
            // 
            this.textBoxLoginRegister.Location = new System.Drawing.Point(256, 70);
            this.textBoxLoginRegister.Name = "textBoxLoginRegister";
            this.textBoxLoginRegister.Size = new System.Drawing.Size(100, 20);
            this.textBoxLoginRegister.TabIndex = 3;
            this.textBoxLoginRegister.Text = "login";
            // 
            // textBoxPasswordRegister
            // 
            this.textBoxPasswordRegister.Location = new System.Drawing.Point(256, 128);
            this.textBoxPasswordRegister.Name = "textBoxPasswordRegister";
            this.textBoxPasswordRegister.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordRegister.TabIndex = 4;
            this.textBoxPasswordRegister.Text = "password";
            // 
            // textBoxPasswordRegisterRepeat
            // 
            this.textBoxPasswordRegisterRepeat.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPasswordRegisterRepeat.Location = new System.Drawing.Point(256, 154);
            this.textBoxPasswordRegisterRepeat.Name = "textBoxPasswordRegisterRepeat";
            this.textBoxPasswordRegisterRepeat.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordRegisterRepeat.TabIndex = 5;
            this.textBoxPasswordRegisterRepeat.Text = "repeat password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(69, 200);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Zaloguj";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(265, 200);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Zarejstruj sie!";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Logowanie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rejestracja";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(413, 287);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPasswordRegisterRepeat);
            this.Controls.Add(this.textBoxPasswordRegister);
            this.Controls.Add(this.textBoxLoginRegister);
            this.Controls.Add(this.textBoxPasswordLoginRepeat);
            this.Controls.Add(this.textBoxPasswordLogin);
            this.Controls.Add(this.textBoxLoginLogin);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxLoginLogin;
        private System.Windows.Forms.TextBox textBoxPasswordLogin;
        private System.Windows.Forms.TextBox textBoxPasswordLoginRepeat;
        private System.Windows.Forms.TextBox textBoxLoginRegister;
        private System.Windows.Forms.TextBox textBoxPasswordRegister;
        private System.Windows.Forms.TextBox textBoxPasswordRegisterRepeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

