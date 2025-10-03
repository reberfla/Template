namespace GreenKasse.Domain;

public class MyPrice
{
    private int _price = 0;

    public int Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value > 0)
            {
                _price = value;
            }
        }
    }

    public void MyVoidFunction(string myString)
    {
        // ...
        Console.WriteLine(myString);
    }

    public MyPrice SetPrice(int price)
    {
        _price = price;
        return this;
    }

}

public class Foo
{
    public Foo()
    {
        var myPrice = new MyPrice();

        Console.WriteLine(myPrice
            .SetPrice(3)
            .SetPrice(5)
            .Price
        );
    }
}
