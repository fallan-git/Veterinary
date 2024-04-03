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
        static public string resulting;
        static public void Registration1(string login, string numberphone, string password, string fio)
        {
            DBConnection.msCommand.CommandText = @"SELECT id_account FROM vet.users WHERE login = '" + login + "';";
            var result = DBConnection.msCommand.ExecuteScalar();
            if (result != null)
            {
                MessageBox.Show("Данный логин уже существует, выберите другой!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DBConnection.msCommand.CommandText = "INSERT INTO `vet`.`users` (`login`, `password`, `number_phone`, `id_role`, `fio`) VALUES('" + login + "', '" + password + "', '" + numberphone + "', '3', '" + fio + "')";
                    DBConnection.msCommand.ExecuteScalar();
                    MessageBox.Show(login + ", вы были успешно зарегестрированны! Зайдите в свой аккаунт.", "Успешная регистрация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resulting = "true";
                }
                catch
                {
                    MessageBox.Show("Ошибка при регистрации!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
