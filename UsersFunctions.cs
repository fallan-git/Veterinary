using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class UsersFunctions
    {
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
                }
                catch
                {
                    MessageBox.Show("Ошибка при обновлении данных!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}