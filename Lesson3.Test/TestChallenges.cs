using FakeItEasy;
using FluentAssertions;
using Lesson3.Enums;

namespace Lesson3.Test;

public class TestChallenges
{
    public static readonly IEnumerable<object[]> CoinFlipResultData = new List<object[]>
    {
        new object[] { new[] { 1, 0, 1, 1, 0, 1, 0, 1, 0, 0 } },
        new object[] { new[] { 0, 0, 0, 1, 1, 0, 1, 1, 1, 1 } },
    };

    [Theory]
    [MemberData(nameof(CoinFlipResultData))]
    public void FlipCoin_Called_ReturnsExpectedCoinSide(int[] expectedFlipResults)
    {
        // Arrange
        var random = A.Fake<Random>();
        A.CallTo(() => random.Next(2)).ReturnsNextFromSequence(expectedFlipResults);

        // Act
        var flipResults = Enumerable
            .Range(1, expectedFlipResults.Length)
            .Select(_ => Challenges.FlipCoin(random));

        // Assert
        flipResults.Should().BeEquivalentTo(expectedFlipResults.Cast<CoinSide>());
    }

    public static readonly IEnumerable<object[]> DiceRollResultData = new List<object[]>
    {
        new object[] { 6, new[] { 1, 4, 2, 6, 3 } },
        new object[] { 20, new[] { 20, 18, 4, 18, 1 } },
    };

    [Theory]
    [MemberData(nameof(DiceRollResultData))]
    public void RollNSidedDice_CalledWithValidNumberOfSides_ReturnsExpectedRoll(
        int n,
        int[] expectedRollResults
    )
    {
        // Arrange
        var random = A.Fake<Random>();
        A.CallTo(() => random.Next(n))
            .ReturnsNextFromSequence(
                expectedRollResults.Select(rollResult => rollResult - 1).ToArray()
            );
        A.CallTo(() => random.Next(1, n + 1)).ReturnsNextFromSequence(expectedRollResults);

        // Act
        var rollResults = Enumerable
            .Range(1, expectedRollResults.Length)
            .Select(_ => Challenges.RollNSidedDice(n, random))
            .ToArray();

        // Assert
        rollResults.Should().BeEquivalentTo(expectedRollResults);
    }

    [Theory]
    [InlineData(-4, "It isn't possible to have a -4-sided dice")]
    [InlineData(0, "It isn't possible to have a 0-sided dice")]
    public void RollNSidedDice_CalledWithInvalidNumberOfSides_ThrowsExceptionWithExpectedMessage(
        int n,
        string expectedErrorMessage
    )
    {
        // Arrange
        var expectedCall = () => Challenges.RollNSidedDice(n);

        // Assert
        expectedCall
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"{expectedErrorMessage}*");
    }

    public static readonly IEnumerable<object[]> CurrentDatesAndReturnDates = new List<object[]>
    {
        new object[] { new DateTime(2021, 10, 8), new DateTime(2021, 10, 22) },
        new object[] { new DateTime(2022, 4, 27), new DateTime(2022, 5, 11) },
    };

    [Theory]
    [MemberData(nameof(CurrentDatesAndReturnDates))]
    public void GetRenewedReturnDate_Called_ReturnsDateTwoWeeksFromToday(
        DateTime currentDate,
        DateTime expectedReturnDate
    )
    {
        // Act
        var returnDate = Challenges.GetRenewedReturnDate(currentDate);

        // Assert
        returnDate.Should().Be(expectedReturnDate);
    }

    public static readonly IEnumerable<object[]> DateOfBirthAndAgeData = new List<object[]>
    {
        new object[] { new DateTime(2008, 1, 1), new DateTime(2008, 1, 1), (years: 0, months: 0) },
        new object[]
        {
            new DateTime(2009, 11, 12),
            new DateTime(2009, 5, 11),
            (years: 0, months: 6),
        },
        new object[]
        {
            new DateTime(2010, 6, 5),
            new DateTime(2010, 3, 20),
            (years: 0, months: 2),
        },
        new object[]
        {
            new DateTime(2012, 10, 7),
            new DateTime(2011, 4, 5),
            (years: 1, months: 6),
        },
        new object[]
        {
            new DateTime(2016, 2, 8),
            new DateTime(2012, 9, 30),
            (years: 3, months: 4),
        },
        new object[]
        {
            new DateTime(2000, 7, 24),
            new DateTime(1900, 7, 25),
            (years: 99, months: 11),
        },
    };

    [Theory]
    [MemberData(nameof(DateOfBirthAndAgeData))]
    public void CalculateAge_CalledWithValidDateOfBirth_ReturnsExpectedAge(
        DateTime currentDate,
        DateTime dateOfBirth,
        (int years, int months) expectedAge
    )
    {
        // Act
        var age = Challenges.CalculateAge(dateOfBirth, currentDate);

        // Assert
        age.Should().Be(expectedAge);
    }

    public static readonly IEnumerable<object[]> InvalidDateOfBirthAndAgeData = new List<object[]>
    {
        new object[]
        {
            new DateTime(2008, 1, 1),
            new DateTime(2008, 1, 2),
            "Date of birth cannot be in the future",
        },
    };

    [Theory]
    [MemberData(nameof(InvalidDateOfBirthAndAgeData))]
    public void CalculateAge_CalledWithInvalidDateOfBirth_ThrowsExceptionWithExpectedMessage(
        DateTime currentDate,
        DateTime dateOfBirth,
        string expectedErrorMessage
    )
    {
        // Arrange
        var expectedCall = () => Challenges.CalculateAge(dateOfBirth, currentDate);

        // Assert
        expectedCall
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"{expectedErrorMessage}*");
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(2, 33.510321638291124)]
    [InlineData(2.8794119114848606, 100)]
    public void CalculateSphereVolume_CalledWithValidRadius_ReturnsExpectedVolume(
        double radius,
        double expectedVolume
    )
    {
        // Act
        var volume = Challenges.CalculateSphereVolume(radius);

        // Assert
        volume.Should().BeApproximately(expectedVolume, precision: 0.000001);
    }

    [Theory]
    [InlineData(-1, "It isn't possible for a sphere to have a negative radius")]
    public void CalculateSphereVolume_CalledWithInvalidRadius_ThrowsExceptionWithExpectedMessage(
        double radius,
        string expectedErrorMessage
    )
    {
        // Arrange
        var expectedCall = () => Challenges.CalculateSphereVolume(radius);

        // Assert
        expectedCall
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"{expectedErrorMessage}*");
    }

    public static readonly IEnumerable<object[]> CoefficientsAndExpectedSolutions =
        new List<object[]>
        {
            new object[] { 4, -9, -28, new[] { -1.75, 4.0 } },
            new object[] { 1, -8, 16, new[] { 4.0 } },
            new object[] { 1, 12, 0, new[] { -12.0, 0.0 } },
            new object[] { 4, 0, -25, new[] { -2.5, 2.5 } },
            new object[] { 2, 0, 0, new[] { 0.0 } },
            new object[] { 0, 2, -3, new[] { 1.5 } },
            new object[] { 0, 5, 0, new[] { 0.0 } },
            new object[] { 0, 0, 1, Array.Empty<double>() },
            new object[] { 7, -3, 2, Array.Empty<double>() },
        };

    [Theory]
    [MemberData(nameof(CoefficientsAndExpectedSolutions))]
    public void CalculateQuadraticEquationSolutions_CalledWithNotAllZeroCoefficients_ReturnsExpectedSolutions(
        double a,
        double b,
        double c,
        double[] expectedSolutions
    )
    {
        // Act
        var solutions = Challenges.CalculateQuadraticEquationSolutions(a, b, c);

        // Assert
        solutions.Should().BeEquivalentTo(expectedSolutions);
    }

    [Theory]
    [InlineData(0, 0, 0, "Infinite number of solutions found")]
    public void CalculateQuadraticEquationSolutions_CalledWithAllZeroCoefficients_ThrowsExceptionWithExpectedMessage(
        double a,
        double b,
        double c,
        string expectedErrorMessage
    )
    {
        // Arrange
        var expectedCall = () => Challenges.CalculateQuadraticEquationSolutions(a, b, c);

        // Assert
        expectedCall
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage($"{expectedErrorMessage}*");
    }

    [Theory]
    [InlineData("5", 5)]
    [InlineData("1", 1)]
    public void GetGuestCount_Called_ReturnsExpectedGuestCountWithValidResponse(
        string response,
        int expectedGuestCount
    )
    {
        // Arrange
        var stringReader = new StringReader($"{response}\n");
        Console.SetIn(stringReader);

        // Act
        var guestCount = Challenges.GetGuestCount();

        // Assert
        guestCount.Should().Be(expectedGuestCount);
    }

    [Theory]
    [InlineData("-1", "Bookings cannot be for a negative number of guests")]
    [InlineData("0", "Bookings cannot be for zero guests")]
    [InlineData("1.5", "Bookings must be for a valid whole number of guests")]
    [InlineData("-2.5", "Bookings must be for a valid whole number of guests")]
    [InlineData("hello", "Bookings must be for a valid whole number of guests")]
    public void GetGuestCount_Called_ThrowsExpectedExceptionWithInvalidResponse(
        string response,
        string expectedErrorMessage
    )
    {
        // Arrange
        var stringReader = new StringReader($"{response}\n");
        Console.SetIn(stringReader);
        var expectedCall = Challenges.GetGuestCount;

        // Assert
        expectedCall
            .Should()
            .ThrowExactly<FormatException>()
            .WithMessage($"{expectedErrorMessage}*");
    }

    [Theory]
    [InlineData("3", "That will be 33.33 each, thank you!")]
    [InlineData("1", "That will be 100.00 each, thank you!")]
    [InlineData("-1", "The bill cannot be split between a negative number of guests.")]
    [InlineData("0", "The bill cannot be split between zero guests.")]
    [InlineData("1.5", "That isn't a valid whole number of guests.")]
    [InlineData("-2.5", "That isn't a valid whole number of guests.")]
    [InlineData("hello", "That isn't a valid whole number of guests.")]
    public void SplitBillEvenly_Called_OutputsExpectedMessage(
        string response,
        string expectedOutput
    )
    {
        // Arrange
        var stringReader = new StringReader($"{response}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.SplitBillEvenly();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(2);
        outputLines[1].Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("0", "You selected: Purchase some fruit.")]
    [InlineData("2", "You selected: Just have a browse.")]
    [InlineData("4", "That wasn't one of the options.")]
    [InlineData("hello", "That wasn't one of the options.")]
    public void GreetCustomer_Called_OutputsExpectedMessage(string response, string message)
    {
        // Arrange
        var stringReader = new StringReader($"{response}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.GreetCustomer();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(6);
        outputLines[5].Should().Be(message);
    }

    [Theory]
    [InlineData("orange", "That will be 1.24, please!")]
    [InlineData("apple", "That will be 0.95, please!")]
    [InlineData("banana", "That wasn't one of the options.")]
    public void ServeCustomer_Called_OutputsExpectedMessage(string response, string message)
    {
        // Arrange
        var stringReader = new StringReader($"{response}\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);

        // Act
        Challenges.ServeCustomer();

        // Assert
        var outputLines = stringWriter
            .ToString()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        outputLines.Length.Should().Be(5);
        outputLines[4].Should().Be(message);
    }
}
