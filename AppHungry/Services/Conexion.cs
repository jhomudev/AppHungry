using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppHungry.Services
{
    public class Conexion
    {
        public static FirebaseClient Firebase = new FirebaseClient("https://apphungry-94ed8-default-rtdb.firebaseio.com/");
    }
}

