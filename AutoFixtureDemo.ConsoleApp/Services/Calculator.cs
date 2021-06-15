using AutoFixtureDemo.ConsoleApp.Interfaces;

namespace AutoFixtureDemo.ConsoleApp
{
    public class Calculator
    {
        private readonly IAdder _adder;
        private readonly IDivider _divider;
        private readonly IMultiplier _multiplier;
        private readonly ISutractor _sutractor;

        public Calculator(IAdder adder, IDivider divider, IMultiplier multiplier, ISutractor sutractor)
        {
            _adder = adder;
            _divider = divider;
            _multiplier = multiplier;
            _sutractor = sutractor;
        }

        public double Add(double a, double b)
        {
            return _adder.Add(a, b);
        }

        public double Divide(double a, double b)
        {
            return _divider.Divide(a, b);
        }

        public double Multiply(double a, double b)
        {
            return _multiplier.Multiply(a, b);
        }

        public double Subtract(double a, double b)
        {
            return _sutractor.Subtract(a, b);
        }
    }
}
