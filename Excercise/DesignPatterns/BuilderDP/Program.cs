namespace BuilderDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SamsungPhoneBuilder builder1 = new SamsungPhoneBuilder();
            builder1.setCamera(33); 
            builder1.setOS("Android");            
            builder1.setBattery(33000);            
            CellPhone phone= builder1.GetCellPhone();
            Console.WriteLine(phone);

            //Single Line Code
            CellPhone phone1 = new ApplePhoneBuilder()                
                .setOS("IOS")
                .setBattery(3210)
                .setCamera(51)
                .GetCellPhone();            
            Console.WriteLine(phone1);

            // Example: Direct instantiation (not recommended if using builder)
            //CellPhone phone = new CellPhone("Android","Qualcom",15,3300,33);
            //Console.WriteLine(phone);
        }
    }
}
