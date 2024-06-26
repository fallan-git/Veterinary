﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinary
{
    internal class List
    {
        static public DataTable DtbList = new DataTable();
        static public DataTable DtbListForRec = new DataTable();

        static public void GetListForRec()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT `name` FROM `list`;";
                DtbListForRec.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbListForRec);

            }
            catch
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public void GetList()
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT * FROM list;";
                DtbList.Clear();
                DBConnection.msDataAdapter.SelectCommand = DBConnection.msCommand;
                DBConnection.msDataAdapter.Fill(DtbList);

            }
            catch 
            {
                MessageBox.Show("Ошибка получения данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static public bool AddList(string Name, string Price, string Description)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"INSERT INTO `list` (`name`, `price`, `description`) VALUES ('" + Name + "', '" + Price + "', '" + Description + "');";
                if(DBConnection.msCommand.ExecuteNonQuery() > 0)
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

        static public bool EditList(string IdService, string Name, string Price, string Description)
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
        static public void DeleteList(string IdService)
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
