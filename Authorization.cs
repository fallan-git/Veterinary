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
        static public string Role, Number, User;

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
                }
                else
                {
                    Role = null;
                    Number = null;
                }
            }
            catch 
            {
                Role = User = null;
                MessageBox.Show("Ошибка при авторизациии!!!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public string AuthorizationName(string login)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT Familia FROM users WHERE Login = '" + login + "' ";
                object result = DBConnection.msCommand.ExecuteScalar();
                Number = result.ToString();
                return Number;
            }
            catch 
            {
                return null;
            }
        }
    }
}
