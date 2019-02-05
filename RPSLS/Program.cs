using System;
using System.Collections.Generic;
using System.Reflection;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseAI> ais = new List<BaseAI>();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(StudentAI)))
                {
                    ais.Add((BaseAI)Activator.CreateInstance(type));
                }
            }

            foreach (var ai in ais)
            {
                Console.WriteLine(ai);
            }
            //Game.Battle(new RandomAI(), new RockOnlyAI());
        }
    }
}
