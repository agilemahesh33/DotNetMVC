namespace SIEMENS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1,2,3,-4,-1,4};
            List<int> list2 = list.ToList();
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            list2 = list.ToList();
            list2.Sort();  
            Console.WriteLine("----------------");
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }
            int j = 0;
            int temp;
            for (int i = 0; i < list.Count; i++)
            {   
                if(list[0] >=0)
                {
                    continue;
                }
                else if (list[0])
                {

                }

                    j = i + 1;
                //If number is negative
                if (list[i] < 0 && list[j] >= 0 && i % 2 ==0)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
                //if Number is positive
                else if (list[i] >= 0 && i % 2 !=0)
                {
                    //temp = list[i];
                    //list[i] = list[j];
                    //list[j] = temp;

                }
                //
                else
                {

                }
            }
            Console.WriteLine("Positive no list");
            foreach (int i in list2)
            {
                //Console.WriteLine(i);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
