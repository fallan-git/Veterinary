using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class Pets
    {
        static public DataTable DtbPets = new DataTable();
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
        static public bool AddPet(string IdUser, string Date, string Name, string Disease)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `login` FROM `users` WHERE `id_account` = '" + IdUser + "'";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    DBConnection.msCommand.CommandText = @"INSERT INTO `pets` (`id_user`, `date`, `name`, `disease`) VALUES ('" + IdUser + "', '" + Date + "', '" + Name + "', '" + Disease + "');";
                    if (DBConnection.msCommand.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool EditPet(string IdPet, string IdUser, string Date, string Name, string Disease)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"UPDATE `pets` SET `id_user` = '" + IdUser + "', `date` = '" + Date + "', `name` = '" + Name + "', `disease` = '" + Disease + "' WHERE (`id_pet` = '" + IdPet + "');";
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
        static public void DeletePet(string IdPet)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"DELETE FROM `pets` WHERE (`id_pet` = '" + IdPet + "');";
                DBConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
