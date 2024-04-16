using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Veterinary
{
    internal class Registration
    {
        static public string Resulting;
        static public void Registrations(string Login, string NumberPhone, string Password, string FIO)
        {
            DBConnection.msCommand.CommandText = @"SELECT id_account FROM users WHERE login = '" + Login + "';";
            object Result = DBConnection.msCommand.ExecuteScalar();
            if (Result != null)
            {
                MessageBox.Show("Данный логин уже существует, выберите другой!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DBConnection.msCommand.CommandText = "INSERT INTO `21100_vet`.`users` (`login`, `password`, `number_phone`, `id_role`, `fio`) VALUES('" + Login + "'," +
                        " '" + Password + "', '" + NumberPhone + "', '3', '" + FIO + "')";
                    DBConnection.msCommand.ExecuteScalar();
                    MessageBox.Show(Login + ", вы были успешно зарегестрированны! Зайдите в свой аккаунт.", "Успешная регистрация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resulting = "true";
                }
                catch
                {
                    MessageBox.Show("Ошибка при регистрации!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

