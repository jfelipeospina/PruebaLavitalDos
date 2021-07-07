using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginService.App_Code
{
    public class LogIn
    {
        PruebaEntities1 ME = new PruebaEntities1();
        private string vusername;
        private string vpassword;
        public string Usuario
        {
            get
            {
                return vusername;
            }
            set
            {
                vusername = value;
            }
        }
        public string Contraseña
        {
            get
            {
                return vpassword;
            }
            set
            {
                vpassword = value;
            }
        }
        public string UserLogin()
        {
            var login = (from user in ME.TBL_USUARIO where user.Usuario == vusername && user.Contraseña == vpassword select user).Count() > 0;
            if (login)
            {
                return "1";
            }
            else return "0";
        }

    }
}