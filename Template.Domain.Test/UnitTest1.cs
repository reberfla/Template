namespace Tempalte.Domain.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var myPrice = new MyPrice();
        // Act
        myPrice.SetPrice(3);
        // Assert
        Assert.Equal(3, myPrice.Price);
    }
}