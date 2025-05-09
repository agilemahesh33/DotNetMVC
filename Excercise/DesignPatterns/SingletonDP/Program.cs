namespace SingletonDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton abc = new Singleton();//Error inaccessible due to protection level
            Singleton inst = Singleton.getInstance();//Direct Access because of static
            Console.WriteLine("Hello, World!");
        }
    }
}
