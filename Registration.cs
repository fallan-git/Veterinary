using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary
{
    internal class Registration
    {

        static public void Registration1(string login, string numberphone, string password, string fio)
        {
            DBConnection.msCommand.CommandText = @"INSERT INTO `vet`.`users` (`login`, `password`, `number_phone`, `id_role`, `fio`) VALUES('" + login + "', '" + password + "', '" + numberphone + "', '3', '" + fio + "')";
            object result = DBConnection.msCommand.ExecuteScalar();
            
        }
    }
}
