
namespace Hackathon.Tests
{
    using System;
    using KellermanSoftware.CompareNetObjects;

    public static class TestExtentions
    {
        public static void DisplayDifferences(this ComparisonResult original)
        {
            if (original?.Differences == null) return;

            foreach (var difference in original.Differences)
            {
                Console.WriteLine($"{difference.ActualName} >> Expected: {difference.Object1Value} Actual: {difference.Object2Value}");
            }
        }

    }
}
