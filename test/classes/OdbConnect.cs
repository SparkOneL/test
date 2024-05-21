using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.pages;

namespace test.classes
{
    internal class OdbConnect
    {
        public static Test2Entities entityObject;

        public static int GetRole(string login)
        {
            var user = entityObject.users.FirstOrDefault(x => x.login == login);
            return user != null ? user.role : 0;
        }

        public static bool AuntenticateUser(string login, string password)
        {
            // Проверка аутентификации
            var user = entityObject.users.FirstOrDefault(u => u.login == login && u.password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Ошибка аутентификации. Проверьте логин и пароль.");
                return false;
            }
        }
    }
}
