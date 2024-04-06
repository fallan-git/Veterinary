using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class VetFunctions
    {
        static public DataTable DtbUsers = new DataTable();
        static public DataTable DtbPets = new DataTable();
        static public DataTable DtbRecords = new DataTable();

        static public void GetUsers()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT id_account, fio, number_phone FROM users;";
                DtbUsers.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbUsers);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void GetPets()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM pets;";
                DtbPets.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbPets);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static public void GetRecords()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM records;";
                DtbRecords.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbRecords);
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
