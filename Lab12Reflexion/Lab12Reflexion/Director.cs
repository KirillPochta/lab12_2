using Lab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Reflexion
{
    class Director:ISmart
    {
        public delegate void DirectorHandler(string message);
        public event DirectorHandler Promote;
        public event DirectorHandler Punishment;

        public string name;
        public int money;
        public int position;
        public Director(string name, int money, int position)
        {
            this.name = name;
            this.money = money;
            this.position = position;
        }
        public Director() { }
        public void Reduced()
        {
            if (money > 0)
            {
                position -= 1;
                money -= 5;
                if (Punishment != null)
                {
                    Punishment?.Invoke($"{name} was fine on 5 and have {position} position");
                    if (money <= 0) { money = 0; Console.WriteLine($"{name} end up money now!"); }
                }
                Console.WriteLine($"{name} now have {money} money's");
            }
            else Console.WriteLine($"{name} no money's");
        }
        public void GetSum(int an)
        {
            int x = 2;
            int y = 3;
            an = x + y;
            Console.WriteLine(an);
        }

        public void Think()
        {
            throw new NotImplementedException();
        }

        public void Analyze(int an)
        {
            throw new NotImplementedException();
        }

        public void Info()
        {
            throw new NotImplementedException();
        }
    }
}
