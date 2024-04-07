using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class Records
    {
        static public DataTable DtbRecords = new DataTable();
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
        static public bool AddRecords(string Name, string Price, string Description)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"INSERT INTO `list` (`name`, `price`, `description`) VALUES ('" + Name + "', '" + Price + "', '" + Description + "');";
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

        static public bool EditRecords(string IdService, string Name, string Price, string Description)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"UPDATE `list` SET `name` = '" + Name + "', `price` = '" + Price + "', `description` = '" + Description + "' WHERE (`id_service` = '" + IdService + "');";
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
        static public void DeleteRecords(string IdService)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"DELETE FROM `list` WHERE (`id_service` = '" + IdService + "');";
                DBConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
