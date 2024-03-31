using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LoginReg
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private string dbFileName = "database.db";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string dbFilePath = Path.Combine(Application.StartupPath, dbFileName);

            // kopiowanie pliku bazy danych do katalogu roboczego, jeśli nie ma go 
            if (!File.Exists(dbFilePath))
            {
                try
                {
                    File.Copy(Path.Combine(Application.StartupPath, "database.db"), dbFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas kopiowania bazy danych: {ex.Message}");
                    return;
                }
            }

            // połączenie z bazą danych 
            connection = new SQLiteConnection($"Data Source={dbFilePath};Version=3;");
            connection.Open();

            string createUserTableQuery = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT, Password TEXT)";
            ExecuteQuery(createUserTableQuery);
        }

        private void ExecuteQuery(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string login = textBoxLoginRegister.Text;
            string password = textBoxPasswordRegister.Text;
            string repeatPassword = textBoxPasswordRegisterRepeat.Text;

            if (!ValidateRegistration(login, password, repeatPassword))
            {
                return;
            }

            string checkExistingUserQuery = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
            using (SQLiteCommand command = new SQLiteCommand(checkExistingUserQuery, connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                int existingUserCount = Convert.ToInt32(command.ExecuteScalar());
                if (existingUserCount > 0)
                {
                    MessageBox.Show("Podany login jest już zajęty. Wybierz inny login.");
                    return;
                }
            }

            // sol
            byte[] saltBytes = GenerateSalt();

            // hashowabnie hasła z sola
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
            Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
            Array.Copy(saltBytes, 0, saltedPasswordBytes, passwordBytes.Length, saltBytes.Length);
            string passwordHash = HashPassword(saltedPasswordBytes);

            // do bazy zapis
            string insertUserQuery = $"INSERT INTO Users (Login, PasswordHash, Salt) VALUES (@Login, @PasswordHash, @Salt)";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(insertUserQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(saltBytes));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Rejestracja zakończona pomyślnie.");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Błąd podczas wstawiania danych użytkownika: {ex.Message}");
            }

        }
        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; 
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private string HashPassword(byte[] passwordBytes)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        private bool VerifyPassword(string login, string password)
        {
            string selectUserQuery = "SELECT PasswordHash, Salt FROM Users WHERE Login = @Login";
            using (SQLiteCommand command = new SQLiteCommand(selectUserQuery, connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader.GetString(0);
                        string storedSalt = reader.GetString(1);
                        byte[] saltBytes = Convert.FromBase64String(storedSalt);

                        // hashowanie hasła
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
                        Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
                        Array.Copy(saltBytes, 0, saltedPasswordBytes, passwordBytes.Length, saltBytes.Length);
                        string inputHash = HashPassword(saltedPasswordBytes);

                        return inputHash == storedHash;
                    }
                }
            }
            return false; // jakby nie było użytkownika takiego
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLoginLogin.Text;
            string password = textBoxPasswordLogin.Text;

            // walidacja danych
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return;
            }

            // pobranie hasha i soli od użytkownika z bazy
            string selectUserQuery = "SELECT PasswordHash, Salt FROM Users WHERE Login = @Login";
            using (SQLiteCommand command = new SQLiteCommand(selectUserQuery, connection))
            {
                command.Parameters.AddWithValue("@Login", login);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader.GetString(0);
                        string storedSalt = reader.GetString(1);
                        byte[] saltBytes = Convert.FromBase64String(storedSalt);

                        //hashowanie hasła wprowadzonego przez użytkownika z pobraną solą
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
                        Array.Copy(passwordBytes, saltedPasswordBytes, passwordBytes.Length);
                        Array.Copy(saltBytes, 0, saltedPasswordBytes, passwordBytes.Length, saltBytes.Length);
                        string inputHash = HashPassword(saltedPasswordBytes);

                        // prównanie hasha wprowadzonego hasła z hashem z bazy danych
                        if (inputHash == storedHash)
                        {
                            MessageBox.Show("Zalogowano pomyślnie!");
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("Nieprawidłowy login lub hasło. Spróbuj ponownie.");
        }

        private bool ValidateRegistration(string login, string password, string repeatedPassword)
        {
            // sprawdzanie czy pola nie są puste
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repeatedPassword))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return false;
            }

            // czy hasła identyczne
            if (password != repeatedPassword)
            {
                MessageBox.Show("Hasła nie pasują do siebie.");
                return false;
            }

            // żeby hasło miałoo 6 znaków min
            if (password.Length < 6)
            {
                MessageBox.Show("Hasło powinno zawierać co najmniej 6 znaków.");
                return false;
            }
            return true;
        }
        private bool ValidateLogin(string login, string password, string repeatedPassword)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repeatedPassword))
            {
                MessageBox.Show("Wszystkie pola są wymagane.");
                return false;
            }

            if (password != repeatedPassword)
            {
                MessageBox.Show("Hasła nie pasują do siebie.");
                return false;
            }

            return true;
        }
    }
}
