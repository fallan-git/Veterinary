using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class Authorization
    {
        static public string Role, Number, User, Password, FIO, ID;

        static public void Authorization1(string login, string password)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"Select name_role from role, users WHERE login = '" + login + "' and password = '" + password + "' and users.id_role=role.id_role";
                object result = DBConnection.msCommand.ExecuteScalar();
                if (result != null )
                {
                    Role = result.ToString();
                    User = login;
                    Password = password;

                    DBConnection.msCommand.CommandText = @"SELECT id_account FROM users WHERE login = '" + login + "';";
                    object id = DBConnection.msCommand.ExecuteScalar();
                    ID = Convert.ToString(id);

                    DBConnection.msCommand.CommandText = @"Select name_role from role, users WHERE login = '" + login + "' and password = '" + password + "' and users.id_role=role.id_role";
                    object number = DBConnection.msCommand.ExecuteScalar();
                    Number = Convert.ToString(number);

                }
                else
                {
                    Role = null;
                }
            }
            catch 
            {
                Role = null;
                User = null;
                MessageBox.Show("Ошибка при авторизациии!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
