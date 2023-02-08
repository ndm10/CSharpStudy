//declare delegate outside class - recommend
public delegate void myDelegateOut(string msg);
public delegate int myDelegateOutReturn();

//declare generic delegate
public delegate T add<T>(T param1, T param2);
internal class Program
{
    private static void Main(string[] args)
    {
        myDelegateIn delIn1 = new myDelegateIn(MethodA);
        delIn1.Invoke("Hello");
        //or
        delIn1("World!");
        //declare by lambda method
        myDelegateIn delIn2 = (string msg) => Console.WriteLine(msg);

        myDelegateOut delOut = (string msg) => Console.WriteLine(msg);

        //Mutilcsat delegate
        myDelegateIn del = delIn1 + delIn2;
        del.Invoke("Multicast delegate!");

        //pass delegate as a parameter
        InvokeDelegate(delIn1);

        //it will return the last method assign
        myDelegateOutReturn outReturn0 = ReturnA;
        myDelegateOutReturn outReturn1 = ReturnB;
        myDelegateOutReturn delReturn = outReturn0 + outReturn1;
        Console.WriteLine(delReturn());

        //using generic delegate
        add<int> sum= Sum;
        Console.WriteLine(sum(10,20));
    }

    //declare delegate inside class
    public delegate void myDelegateIn(string msg);
    //set taget method
    myDelegateIn del = new myDelegateIn(MethodA);
    static void MethodA(string message)
    {
        Console.WriteLine(message);
    }
    //or
    myDelegateIn del1 = MethodA;
    //or set lamda expession
    myDelegateIn del2 = (string msg) => Console.WriteLine(msg);

    //delegate as type parameter
    public static void InvokeDelegate(myDelegateIn delIn)
    {
        delIn("Hello Inside!");
    }

    //return type
    static int ReturnA()
    {
        return 100;
    }

    static int ReturnB()
    {
        return 200;
    }

    public static int Sum(int a, int b)
    { return a + b; }
}
