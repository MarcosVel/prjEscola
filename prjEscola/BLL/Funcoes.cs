using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjEscola.BLL {
    public class Funcoes {
        private static string _connString = "Initial Catalog=BDESCOLA;Data Source=DESKTOP-R68MLJP\\SQLEXPRESS01;user id=bdusuario; password=senha;";
    
        public static string connString
        {
            get { return _connString; }
            set { }
        }

        public static string DateToDB(System.DateTime TheDate){
            //Return TheDate.Month.ToString() + "/" + TheDate.Day.ToString() + "/" + TheDate.Year.ToString() + " " + TheDate.ToLongTimeString()
            return TheDate.Year.ToString() + "/" + TheDate.Month.ToString() + "/" + TheDate.Day.ToString() + " " + TheDate.ToLongTimeString();
        }

    }
}