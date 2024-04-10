using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

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

        static public bool AddRecordForUser(string Date, string Time, string NameService, string Veterinar, string Pet)
        {
            object IdPet;
            try
            {
                DateTime NewDate = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string EndDate = NewDate.ToString("yyyy-MM-dd");

                DBConnection.msCommand.CommandText = @"SELECT `id_service` FROM `list` WHERE `name` = '" + NameService + "';";
                object IdService = DBConnection.msCommand.ExecuteScalar();
                if (Pet != "null")
                {
                    DBConnection.msCommand.CommandText = @"SELECT `id_pet` FROM `pets` WHERE `name` = '" + Pet + "';";
                    IdPet = DBConnection.msCommand.ExecuteScalar();
                }
                else
                {
                    IdPet = "null";
                }
                DBConnection.msCommand.CommandText = @"SELECT `time` FROM records WHERE `date` = '" + EndDate + "' and `time` = '" + Time + "';";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result == null)
                {
                    DBConnection.msCommand.CommandText = @"INSERT INTO `records` (`id_users`, `id_pet`, `id_service`, `date`, `time`, `veterinarian`) VALUES ('" + Authorization.ID + "', " + IdPet + ", '" + IdService + "', '" + EndDate + "', '" + Time + "', '" + Veterinar + "');";
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
                    MessageBox.Show("Данное время занято!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public bool AddRecord(string IdUser, string IdPet, string IdService, string Date, string Time, string Veterinar)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `login` FROM `users` WHERE `id_account` = '" + IdUser + "';";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    DBConnection.msCommand.CommandText = @"SELECT `name` FROM `pets` WHERE `id_pet` = '" + IdPet + "';";
                    object Result2 = DBConnection.msCommand.ExecuteScalar();
                    if (Result2 != null)
                    {
                        DBConnection.msCommand.CommandText = @"SELECT `name` FROM `list` WHERE id_service = '" + IdService + "';";
                        object Result3 = DBConnection.msCommand.ExecuteScalar();
                        if (Result3 != null)
                        {
                            DateTime NewDate = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            string EndDate = NewDate.ToString("yyyy-MM-dd");

                            DBConnection.msCommand.CommandText = @"INSERT INTO `records` (`id_users`, `id_pet`, `id_service`, `date`, `time`, `veterinarian`) VALUES ('" + IdUser + "', '" + IdPet + "', '" + IdService + "', '" + EndDate + "', '" + Time + "', '" + Veterinar + "');";
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
                            MessageBox.Show("Такой услуги не существует.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такого питомца не существует.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        static public bool EditRecord(string IdRecord, string IdUser, string IdPet, string IdService, string Date, string Time, string Veterinar)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `login` FROM `users` WHERE `id_account` = '" + IdUser + "';";
                object Result = DBConnection.msCommand.ExecuteScalar();
                if (Result != null)
                {
                    DBConnection.msCommand.CommandText = @"SELECT `name` FROM `pets` WHERE `id_pet` = '" + IdPet + "';";
                    object Result2 = DBConnection.msCommand.ExecuteScalar();
                    if (Result2 != null)
                    {
                        DBConnection.msCommand.CommandText = @"SELECT `name` FROM `list` WHERE id_service = '" + IdService + "';";
                        object Result3 = DBConnection.msCommand.ExecuteScalar();
                        if (Result3 != null)
                        {
                            DateTime NewDate = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            string EndDate = NewDate.ToString("yyyy-MM-dd");
                            DBConnection.msCommand.CommandText = @"UPDATE `records` SET `id_users` = '" + IdUser + "', `id_pet` = '" + IdPet + "', `id_service` = '" + IdService + "', `date` = '" + EndDate + "', `time` = '" + Time + "', `veterinarian` = '" + Veterinar + "' WHERE (`id_record` = '" + IdRecord + "');";
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
                            MessageBox.Show("Такой услуги не существует.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такого питомца не существует.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        static public void DeleteRecord(string IdRecord)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"DELETE FROM `records` WHERE (`id_record` = '" + IdRecord + "');";
                DBConnection.msCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка удаления данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}