using System;


//Console.WriteLine("TVRemote");
namespace TvRemoteExample {
    class Program
    {
        public static void Main(string[] args)
        {
        
            Tvmodel1 screens = new Tvmodel1();
            TVRemote tVRemote = new TVRemote(screens);
            Console.WriteLine("TVRemote");
            tVRemote.CheckSupportedModels(screens);



            Console.WriteLine("TVModel2");
            TvModel2 tv = new TvModel2();
            tv.DisplayInternalFunctions();


            Console.WriteLine("UnsupportedTV");
            Unsupportedtv faketv = new Unsupportedtv();
            tVRemote.CheckSupportedModels(faketv);
          

        }
    
    }
}