﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veterinary
{
    internal class DBConnection
    {
        static string DBConnect = "server = localhost; user = root; password = draytr21100; database = 21100_vet;";
        static public MySqlDataAdapter msDataAdapter;
        static MySqlConnection myconnect;
        static public MySqlCommand msCommand;
        
        public static bool ConnectionDB()
        {
            try
            {
                myconnect = new MySqlConnection(DBConnect);
                myconnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = myconnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
