using AutoFixtureDemo.ConsoleApp.Interfaces;
using System.Linq;

namespace AutoFixtureDemo.ConsoleApp.Services
{
    public class Adder : IAdder
    {
        public double Add(params double[] args)
        {
            return args.Sum(x => x);
        }
    }
}
