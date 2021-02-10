using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vs = new int[] { 1, 3, 4 };
            List<Apple> apples = new List<Apple>() {
             new Apple(){ Id=1, Name="苹果1", Price=20, Province="shanghai", Weight=300},
                new Apple(){ Id=2, Name="苹果2", Price=20, Province="shanghai", Weight=300},
                new Apple(){ Id=3, Name="苹果3", Price=20, Province="shanghai", Weight=300},
                new Apple(){ Id=4, Name="苹果4", Price=20, Province="shanghai", Weight=300},
                new Apple(){ Id=5, Name="苹果5", Price=20, Province="shanghai", Weight=300}
            };
            var ids = apples.Select(x => x.Id).ToList();

            var s = new SQLinq<Apple>().Where(p => (p.Id == 1 || p.Id == 2) && p.Name==("苹果") && vs.Contains(p.Id));
            var d= s.ToSQL();
            var b= d.Where;
            Console.WriteLine(b);
            Console.ReadKey();
        }

        public class Apple
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Province { get; set; }

            public decimal Price { get; set; }

            public decimal Weight { get; set; }
        }
    }
}
