internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        FirstTestClass.FirstTest_ReturnOkIfZero_ReturnString();
    }
}

public static class FirstTestClass
{ 
 //name Convention ClassName_MethodName_Return

    public static void FirstTest_ReturnOkIfZero_ReturnString()
    {
        try
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            int num = 0;
            FirstTest firstTest = new FirstTest();

            //Act - execute this function
            string result = firstTest.ReturnOkIfZero(num);

            //Assert - wherever is returned is that what you want.
            if(result == "OK")
                Console.WriteLine($"Passed: FirstTest_ReturnOkIfZero_ReturnString");
            else
                Console.WriteLine($"Failed: FirstTest_ReturnOkIfZero_ReturnString");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex);
        }
    }
}

public class FirstTest
{
    public string ReturnOkIfZero(int num)
    {
        if (num == 0)
            return "OK";
        else
            return "NO OK";
    }
}