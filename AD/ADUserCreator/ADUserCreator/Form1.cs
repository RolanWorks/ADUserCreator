using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Windows.Forms;
using tik4net;

namespace ADUserCreator
{
    public partial class Form1 : Form
    {
        private string logDirectory = "logs";

        public Form1()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            comboGroups.Items.Clear();
            comboGroups.Items.Add("WiFiUsers");
            comboGroups.Items.Add("TestGroup");
            comboGroups.SelectedIndex = 0;
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = GeneratePassword();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedGroup = comboGroups.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedGroup))
            {
                MessageBox.Show("Введите имя, пароль и выберите группу.");
                return;
            }

            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "server.com", "OU=RADIUS WI-FI,DC=server,DC=com"))
                {
                    UserPrincipal existingUser = UserPrincipal.FindByIdentity(context, username);
                    if (existingUser != null)
                    {
                        MessageBox.Show("Пользователь уже существует.");
                        return;
                    }

                    using (UserPrincipal user = new UserPrincipal(context))
                    {
                        user.SamAccountName = username;
                        user.SetPassword(password);
                        user.Enabled = true;
                        user.PasswordNeverExpires = true;
                        user.Save();

                        using (PrincipalContext rootContext = new PrincipalContext(ContextType.Domain, "server.com"))
                        {
                            GroupPrincipal group = GroupPrincipal.FindByIdentity(rootContext, selectedGroup);
                            if (group != null)
                            {
                                group.Members.Add(user);
                                group.Save();
                            }
                            else
                            {
                                MessageBox.Show("Группа не найдена.");
                                return;
                            }
                        }

                        Log($"Создан пользователь {username} | Пароль: {password}");
                        MessageBox.Show($"✅ Пользователь создан и добавлен в группу {selectedGroup}.\nПароль: {password}", "Успех");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка при создании пользователя {username}: {ex.Message}");
                MessageBox.Show("❌ Ошибка: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "server.com"))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, username);
                    if (user != null)
                    {
                        user.Delete();
                        Log($"Удален: {username}");
                        MessageBox.Show("✅ Пользователь удален.", "Успех");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка при удалении {username}: {ex.Message}");
                MessageBox.Show("❌ Ошибка: " + ex.Message);
            }
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "server.com"))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, username);
                if (user != null)
                {
                    DirectoryEntry de = (DirectoryEntry)user.GetUnderlyingObject();
                    string whenCreated = de.Properties["whenCreated"].Value.ToString();

                    string info = $"Имя: {user.SamAccountName}\n" +
                                  $"Включен: {user.Enabled}\n" +
                                  $"Последний вход: {user.LastLogon?.ToLocalTime()}\n" +
                                  $"Дата создания: {whenCreated}";

                    MessageBox.Show(info, "🔍 Найден пользователь");
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка");
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                newPassword = GeneratePassword();
                txtPassword.Text = newPassword;
            }

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "server.com"))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, username);
                if (user != null)
                {
                    user.SetPassword(newPassword);
                    user.Save();

                    Log($"Пароль изменен: {username} | Новый: {newPassword}");
                    MessageBox.Show($"✅ Пароль изменен.\nНовый: {newPassword}", "Успех");
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка");
                }
            }
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            string todayLog = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");

            if (File.Exists(todayLog))
                System.Diagnostics.Process.Start("notepad.exe", todayLog);
            else
                MessageBox.Show("Файл логов за сегодня не найден.");
        }

        private void btnShowHotspot_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
                {
                    connection.Open("192.168.10.1", "admin", "password your");

                    var active = connection.CreateCommand("/ip/hotspot/active/print").ExecuteList();

                    string result = "Подключения Hotspot:\n";
                    foreach (var row in active)
                    {
                        result += $"User: {row.Words["user"]}, IP: {row.Words["address"]}, MAC: {row.Words["mac-address"]}, " +
                                  $"Uptime: {row.Words["uptime"]}, Rx: {row.Words["bytes-in"]}, Tx: {row.Words["bytes-out"]}\n";
                    }

                    MessageBox.Show(result, "Hotspot Clients");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка API: " + ex.Message);
            }
        }

        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10) + "a1!";
        }

        /// <summary>
        /// Запись лога по датам в папку logs
        /// </summary>
        private void Log(string message)
        {
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            string logFile = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
            File.AppendAllText(logFile, $"{DateTime.Now:HH:mm:ss}: {message}{Environment.NewLine}");
        }
    }
}
