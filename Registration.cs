using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary
{
    internal class Registration
    {

        static public void Registration1(string login, string numberphone, string password)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"INSERT INTO `vet_test`.`account` (`Login`, `Password`, `Number_phone`, `id_role`) VALUES('" + login + "', '" + password + "', '" + numberphone + "', '3')";
            }
            catch
            {

            }
        }
    }
}
