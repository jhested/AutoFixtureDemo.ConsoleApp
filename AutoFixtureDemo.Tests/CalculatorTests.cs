using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixtureDemo.ConsoleApp;
using AutoFixtureDemo.ConsoleApp.Interfaces;
using AutoFixtureDemo.ConsoleApp.Services;
using Moq;
using System;
using Xunit;

namespace AutoFixtureDemo.Tests
{
    public class CalculatorTests
    {
        public Fixture Fixture { get; init; }

        public CalculatorTests()
        {
            Fixture = new Fixture();
            Fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void ShouldAddCorrectly()
        {
            Fixture.Register<IAdder>(() => new Adder());
            var sut = Fixture.Create<Calculator>(); //Auto inject all required services. For IAdder Adder will be used

            Assert.Equal(10 + 5, sut.Add(10, 5));
        }

        [Fact]
        public void DoSomeRandomMocking()
        {
            var addMock = Mock.Get(Fixture.Freeze<IAdder>());
            var divideMock = Mock.Get(Fixture.Freeze<IDivider>());

            var sut = Fixture.Create<Calculator>(); //Auto inject all required services. For IAdder Adder will be used

            sut.Add(1, 2);

            addMock.Verify(x => x.Add(It.IsAny<double[]>()), Times.Once);
            divideMock.Verify(x => x.Divide(It.IsAny<double[]>()), Times.Never);
        }
    }
}
