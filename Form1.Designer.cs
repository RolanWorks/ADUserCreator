namespace ADUserCreator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.comboGroups = new System.Windows.Forms.ComboBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnOpenLogs = new System.Windows.Forms.Button();
            this.btnShowHotspot = new System.Windows.Forms.Button();
            this.SuspendLayout();

            var defaultFont = new System.Drawing.Font("Segoe UI", 10F);

            // txtUsername
            this.txtUsername.Font = defaultFont;
            this.txtUsername.Location = new System.Drawing.Point(180, 30);
            this.txtUsername.Size = new System.Drawing.Size(220, 25);

            // txtPassword
            this.txtPassword.Font = defaultFont;
            this.txtPassword.Location = new System.Drawing.Point(180, 70);
            this.txtPassword.Size = new System.Drawing.Size(220, 25);

            // lblUsername
            this.lblUsername.Font = defaultFont;
            this.lblUsername.Location = new System.Drawing.Point(20, 30);
            this.lblUsername.Size = new System.Drawing.Size(150, 25);
            this.lblUsername.Text = "Имя пользователя:";

            // lblPassword
            this.lblPassword.Font = defaultFont;
            this.lblPassword.Location = new System.Drawing.Point(20, 70);
            this.lblPassword.Size = new System.Drawing.Size(150, 25);
            this.lblPassword.Text = "Пароль:";

            // lblGroup
            this.lblGroup.Font = defaultFont;
            this.lblGroup.Location = new System.Drawing.Point(20, 110);
            this.lblGroup.Size = new System.Drawing.Size(150, 25);
            this.lblGroup.Text = "Группа:";

            // comboGroups
            this.comboGroups.Font = defaultFont;
            this.comboGroups.Location = new System.Drawing.Point(180, 110);
            this.comboGroups.Size = new System.Drawing.Size(220, 25);

            // btnGeneratePassword
            this.btnGeneratePassword.Font = defaultFont;
            this.btnGeneratePassword.Location = new System.Drawing.Point(20, 150);
            this.btnGeneratePassword.Size = new System.Drawing.Size(380, 35);
            this.btnGeneratePassword.Text = "Сгенерировать пароль";
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);

            // btnCreateUser
            this.btnCreateUser.Font = defaultFont;
            this.btnCreateUser.Location = new System.Drawing.Point(20, 195);
            this.btnCreateUser.Size = new System.Drawing.Size(180, 35);
            this.btnCreateUser.Text = "Создать";
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);

            // btnDeleteUser
            this.btnDeleteUser.Font = defaultFont;
            this.btnDeleteUser.Location = new System.Drawing.Point(220, 195);
            this.btnDeleteUser.Size = new System.Drawing.Size(180, 35);
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            // btnFindUser
            this.btnFindUser.Font = defaultFont;
            this.btnFindUser.Location = new System.Drawing.Point(20, 240);
            this.btnFindUser.Size = new System.Drawing.Size(180, 35);
            this.btnFindUser.Text = "Найти";
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);

            // btnChangePassword
            this.btnChangePassword.Font = defaultFont;
            this.btnChangePassword.Location = new System.Drawing.Point(220, 240);
            this.btnChangePassword.Size = new System.Drawing.Size(180, 35);
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            // btnOpenLogs
            this.btnOpenLogs.Font = defaultFont;
            this.btnOpenLogs.Location = new System.Drawing.Point(20, 285);
            this.btnOpenLogs.Size = new System.Drawing.Size(180, 35);
            this.btnOpenLogs.Text = "Открыть логи";
            this.btnOpenLogs.Click += new System.EventHandler(this.btnOpenLogs_Click);

            // btnShowHotspot
            this.btnShowHotspot.Font = defaultFont;
            this.btnShowHotspot.Location = new System.Drawing.Point(220, 285);
            this.btnShowHotspot.Size = new System.Drawing.Size(180, 35);
            this.btnShowHotspot.Text = "Подключения MikroTik";
            this.btnShowHotspot.Click += new System.EventHandler(this.btnShowHotspot_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(430, 350);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.comboGroups);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.btnCreateUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnFindUser);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnOpenLogs);
            this.Controls.Add(this.btnShowHotspot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "AD User Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox comboGroups;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnOpenLogs;
        private System.Windows.Forms.Button btnShowHotspot;
    }
}
