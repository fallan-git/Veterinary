using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class Information
    {
        static public DataTable DtbInformation = new DataTable();
        static public void GetInfo()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM information;";
                DtbInformation.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbInformation);
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public bool AddInfo(string Title, string Content)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"INSERT INTO `information` (`title`, `content`) VALUES ('" + Title + "', '" + Content + "');";
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

        static public bool EditInfo(string IdInfo, string Title, string Content)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"UPDATE `information` SET `title` = '" + Title + "', `content` = '" + Content + "' WHERE (`id_info` = '" + IdInfo + "');";
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
        static public void DeleteInfo(string IdInfo)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"DELETE FROM `information` WHERE (`id_info` = '" + IdInfo + "');";
                DBConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
