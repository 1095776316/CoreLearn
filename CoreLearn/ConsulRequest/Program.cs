using healthyBar;
using System;

namespace ConsulRequest
{
    class Program
    {
         static void Main(string[] args)
        {
            Handler handler = new Handler();
            handler.Drink();
            ISee.Name = "zhangsan1";
            Console.WriteLine(ISee.Name);
            ISee.Name = "zhangsan2";
            Console.WriteLine(ISee.Name);
        }
    }

    public class ISee
    { 
      public static string Name { get; set; }
    }
}
