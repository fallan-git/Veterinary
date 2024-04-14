using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class Users
    {
        static public DataTable DtbUsersForVet = new DataTable();
        static public DataTable DtbUsersForVet2 = new DataTable();
        static public DataTable DtbUsersForRec = new DataTable();
        static public DataTable DtbUsers = new DataTable();

        static public void GetUsersForRec()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `fio` FROM `users` WHERE `id_role` = '2';";
                DtbUsersForRec.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbUsersForRec);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void GetUsersForVet()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT id_account, fio, number_phone FROM users;";
                DtbUsersForVet.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbUsersForVet);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void GetUsersForVet2()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT id_account, fio, number_phone, name FROM users JOIN pets ON id_account = id_user;";
                DtbUsersForVet2.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbUsersForVet2);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void GetUsers()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM users;";
                DtbUsers.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbUsers);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public bool AddUser(string Login, string Password, string FIO, string NumberPhone, string IdRole)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"INSERT INTO `users` (`login`, `password`, `fio`, `number_phone`, `id_role`) VALUES ('" + Login + "', '" + Password + "', '" + FIO + "', '" + NumberPhone + "', '" + IdRole + "');";
                if (DBConnection.msCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool EditUser(string IdUser, string Login, string Password, string FIO, string NumberPhone, string IdRole)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"UPDATE `users` SET `login` = '" + Login + "', `password` = '" + Password + "', `fio` = '" + FIO + "', `number_phone` = '" + NumberPhone + "', `id_role` = '" + IdRole + "' WHERE (`id_account` = '" + IdUser + "');";
                if (DBConnection.msCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка измененя данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        static public void DeleteUser(string IdUser)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"DELETE FROM `users` WHERE (`id_account` = '" + IdUser + "');";
                DBConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void UppdateProfile(string Login, string NumberPhone, string Password, string FIO)
        {
            DBConnection.msCommand.CommandText = @"SELECT id_account FROM users WHERE login = '" + Login + "';";
            object Result = DBConnection.msCommand.ExecuteScalar();
            if (Result == null)
            {
                try
                {
                    DBConnection.msCommand.CommandText = @"UPDATE `users` SET `login` = '" + Login + "', `password` = '" + Password + "', `number_phone` = '" + NumberPhone + "', `fio` = '" + FIO + "' WHERE (`id_account` = '" + Authorization.ID + "');";
                    DBConnection.msCommand.ExecuteScalar();
                    MessageBox.Show("Данные профиля были успешно обновлены!", "Успешная регистрация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DBConnection.msCommand.ExecuteNonQuery() > 0)
                    {
                        Authorization.Authorization1(Login, Password);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при обновлении данных!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Convert.ToString(Result) != Authorization.ID)
            {
                MessageBox.Show("Данный логин уже существует, выберите другой!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DBConnection.msCommand.CommandText = @"UPDATE `users` SET `login` = '" + Login + "', `password` = '" + Password + "', `number_phone` = '" + NumberPhone + "', `fio` = '" + FIO + "' WHERE (`id_account` = '" + Authorization.ID + "');";
                    DBConnection.msCommand.ExecuteScalar();
                    MessageBox.Show("Данные профиля были успешно обновлены!", "Успешная регистрация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DBConnection.msCommand.ExecuteNonQuery() > 0)
                    {
                        Authorization.Authorization1(Login, Password);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при обновлении данных!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
