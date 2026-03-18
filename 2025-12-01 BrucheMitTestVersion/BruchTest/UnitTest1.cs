using Bruch;
using Xunit;

namespace BruchTest;

public class FractionTests
{
    [Fact]
    public void Constructor_CreatesValidFraction()
    {
        // Arrange & Act
        var fraction = new Fraction(1, 2);
        
        // Assert
        Assert.Equal(1, fraction.Num);
        Assert.Equal(2, fraction.Den);
    }

    [Fact]
    public void Constructor_SimplifiesFraction()
    {
        // Arrange & Act
        var fraction = new Fraction(4, 8);
        
        // Assert
        Assert.Equal(1, fraction.Num);
        Assert.Equal(2, fraction.Den);
    }

    [Fact]
    public void Constructor_ThrowsExceptionForZeroDenominator()
    {
        // Arrange, Act & Assert
        Assert.Throws<DivideByZeroException>(() => new Fraction(1, 0));
    }

    [Fact]
    public void Parse_ParsesSimpleFraction()
    {
        // Arrange & Act
        var fraction = Fraction.Parse("3/4");
        
        // Assert
        Assert.Equal(3, fraction.Num);
        Assert.Equal(4, fraction.Den);
    }

    [Fact]
    public void Parse_ParsesMixedNumber()
    {
        // Arrange & Act
        var fraction = Fraction.Parse("1 1/2");
        
        // Assert
        Assert.Equal(3, fraction.Num); // 1 * 2 + 1 = 3
        Assert.Equal(2, fraction.Den);
    }

    [Fact]
    public void Parse_ParsesWholeNumber()
    {
        // Arrange & Act
        var fraction = Fraction.Parse("5");
        
        // Assert
        Assert.Equal(5, fraction.Num);
        Assert.Equal(1, fraction.Den);
    }

    [Fact]
    public void Parse_ThrowsExceptionForNull()
    {
        // Arrange, Act & Assert
        Assert.Throws<FormatException>(() => Fraction.Parse(null!));
    }

    [Fact]
    public void Addition_AddsTwoFractions()
    {
        // Arrange
        var f1 = new Fraction(1, 2);
        var f2 = new Fraction(1, 3);
        
        // Act
        var result = f1 + f2;
        
        // Assert
        Assert.Equal(5, result.Num); // 1/2 + 1/3 = 3/6 + 2/6 = 5/6
        Assert.Equal(6, result.Den);
    }

    [Fact]
    public void ToString_ReturnsSimpleFraction()
    {
        // Arrange
        var fraction = new Fraction(3, 4);
        
        // Act
        var result = fraction.ToString();
        
        // Assert
        Assert.Equal("3/4", result);
    }

    [Fact]
    public void ToString_ReturnsWholeNumber()
    {
        // Arrange
        var fraction = new Fraction(4, 2);
        
        // Act
        var result = fraction.ToString();
        
        // Assert
        Assert.Equal("2", result);
    }

    [Fact]
    public void ToString_ReturnsMixedNumber()
    {
        // Arrange
        var fraction = new Fraction(7, 4);
        
        // Act
        var result = fraction.ToString();
        
        // Assert
        Assert.Equal("1 3/4", result);
    }

    [Fact]
    public void GenerateRandomString_ReturnsValidFormat()
    {
        // Act
        var randomString = Fraction.GenerateRandomString();
        
        // Assert
        Assert.NotNull(randomString);
        Assert.NotEmpty(randomString);
        
        // Should be parseable
        var fraction = Fraction.Parse(randomString);
        Assert.NotNull(fraction);
    }
}
