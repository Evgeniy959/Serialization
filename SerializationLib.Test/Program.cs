using System;
using System.Reflection;

namespace SerializationLib.Test
{
    class Program
    {
        static void Main()
        {
            var temp = new TestClass();

            var str = CsvSerialization.Serialize(temp);
            Console.WriteLine(str);
        }
    }

    class TestClass
    {
        public int temp = 5;
        public MyEnum m = MyEnum.V;
        public string str = "dfgghhgfj";
        public bool f = true;
        public char dd = 'g';
        public MyClass mm = new MyClass();
        public MyStruct j = new MyStruct();
    }

    enum MyEnum
    {
        T, V, F
    }

    class MyClass
    {
        public int t = 99;
    }

    struct MyStruct
    {
        public int r;
    }
}