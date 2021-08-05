using System;
using System.Text;

namespace Aes_Example
{
    class AesExample
    {
        public static void Main()
        {
            /*
             * This code will allow you to setup an authentication key on the computer's registry.  You'll want to only run this on 
             * computers that are authenticated against your AD domain, of course.
             * The code goes into the computer registry and creates a key under the HKEY_CURRENT_USER directory.
             * Create the appropriate keys to be set in the registry as seen below.
             * Don't store keys/connection strings as plain text in the registry if you can help it.
             * 
            */

            //Let's create three strings and convert them to Base64Strings


            
            string TestKey1 = Convert.ToBase64String(Encoding.Unicode.GetBytes("Testing Entry 1"));
            string TestKey2 = Convert.ToBase64String(Encoding.Unicode.GetBytes("Testing Entry 2"));
            string TestKey3 = Convert.ToBase64String(Encoding.Unicode.GetBytes("Testing Entry 3"));

            //here's what the masked entries look like
            Console.WriteLine("The first key looks like this: " + TestKey1);
            Console.WriteLine("The second key looks like this: " + TestKey2);
            Console.WriteLine("The third key looks like this: " + TestKey3);

            Console.Clear(); //clear out the console just for grins...

            //Now, let's set three keys in the machine registry that will store our masked entries
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("TestKeys");
            key.SetValue("TestKey1", TestKey1);
            key.SetValue("TestKey2", TestKey2);
            key.SetValue("TestKey3", TestKey3);
            key.Close();

            //logic to retrieve a registry key value
            const string rt = "HKEY_CURRENT_USER";
            const string sk = "TestKeys";  //your original key name will go here.
            const string kn = rt + "\\" + sk;

            var keya = Microsoft.Win32.Registry.GetValue(kn, "TestKey1", "novalue");  //get the key out of the registry.
            var keyb = Microsoft.Win32.Registry.GetValue(kn, "TestKey2", "novalue");  //get the key out of the registry.
            var keyc = Microsoft.Win32.Registry.GetValue(kn, "TestKey3", "novalue");  //get the key out of the registry.

            //here's what the un-masked entries look like



            Console.WriteLine("The first key looks like this: " + Encoding.Unicode.GetString(Convert.FromBase64String(keya.ToString())));
            Console.WriteLine("The second key looks like this: " + Encoding.Unicode.GetString(Convert.FromBase64String(keyb.ToString())));
            Console.WriteLine("The third key looks like this: " + Encoding.Unicode.GetString(Convert.FromBase64String(keyc.ToString())));

            
        }
    }
}

