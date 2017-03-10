using System;
using System.Collections.Generic;

namespace ConsoleApplication12{
    class Program{
        static void Main(string[] args){
            String result = postData.login("mail@mail.it","mia9assword");
            Console.WriteLine(result);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("nome", "tizio");
            parameters.Add("cognome", "caio");
            parameters.Add("mail", "mail@uni.it");
            parameters.Add("pass", "segreto");
            parameters.Add("nascita", "93-2-04");
            result = postData.addUser(parameters);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
