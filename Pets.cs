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
        static public object True;
        static public DataTable DtbPets = new DataTable();
        static public DataTable DtbPetsForRec = new DataTable();
        static public DataTable DtbPetsForUser = new DataTable();

        static public void GetPetsForUser()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM pets WHERE `id_user` = '" + Authorization.ID + "';";
                DtbPetsForUser.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbPetsForUser);
                DBConnection.msCommand.CommandText = @"SELECT `id_pet` FROM `pets` WHERE `id_user` = '" + Authorization.ID + "';";
                True = DBConnection.msCommand.ExecuteScalar();
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void GetPetsForRec()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `name` FROM pets WHERE `id_user` = '" + Authorization.ID + "';";
                DtbPetsForRec.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbPetsForRec);

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
        static public bool AddPet(string IdUser, string Date, string Name, string Disease)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `login` FROM `users` WHERE `id_account` = '" + IdUser + "'";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    DateTime NewDate = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string EndDate = NewDate.ToString("yyyy-MM-dd"); 

                    DBConnection.msCommand.CommandText = @"INSERT INTO `pets` (`id_user`, `date`, `name`, `disease`) VALUES ('" + IdUser + "', '" + EndDate + "', '" + Name + "', '" + Disease + "');";
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
                DBConnection.msCommand.CommandText = @"SELECT `login` FROM `users` WHERE `id_account` = '" + IdUser + "'";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    DateTime NewDate = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string EndDate = NewDate.ToString("yyyy-MM-dd");
                    DBConnection.msCommand.CommandText = @"UPDATE `pets` SET `id_user` = '" + IdUser + "', `date` = '" + EndDate + "', `name` = '" + Name + "', `disease` = '" + Disease + "' WHERE (`id_pet` = '" + IdPet + "');";
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
                MessageBox.Show("Ошибка измененя данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        static public void DeletePet(string IdPet)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"UPDATE `records` SET `id_pet` = null WHERE `id_pet` = '" + IdPet + "';";
                DBConnection.msCommand.ExecuteNonQuery();
                DBConnection.msCommand.CommandText = @"DELETE FROM `pets` WHERE (`id_pet` = '" + IdPet + "');";
                DBConnection.msCommand.ExecuteNonQuery();
                MessageBox.Show("Питомец удалён", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
