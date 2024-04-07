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
    }
}
