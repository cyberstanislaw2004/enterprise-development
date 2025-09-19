using Airlines.Domain;
using Airlines.Domain.Fixture;
using Airlines.Tests;
using Xunit;

namespace ConsoleApp1;

public class Program
{
    public void Main(string[] args)
    {
        var test1 = new AirlinesTests(AirlinesFixture fixture);

    }
}