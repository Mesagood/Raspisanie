using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raspisanie
{
    public class Helper
    {
        public static RaspisanieEntities db = new RaspisanieEntities();
    }

    partial class Users
    {
        public string PhotoPath
        {
            get
            {
                var lenght = Photo.Length - 1;
                var q = Photo.Substring(1, lenght);
                return Environment.CurrentDirectory + "\\" + q;
            }
        }

    }
}
