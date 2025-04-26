namespace BuilderDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CellPhoneBuilder builder1 = new CellPhoneBuilder();
            builder1.setCamera(33); 
            builder1.setOS("Android");            
            builder1.setBattery(33000);            
            CellPhone phone= builder1.GetCellPhone();
            Console.WriteLine(phone);

            //Single Line Code
            CellPhone phone1 = new CellPhoneBuilder()
                .setProcessor("QualCom")
                .setOS("Android")
                .setBattery(3210)
                .setCamera(033)
                .GetCellPhone();            
            Console.WriteLine(phone1);

            //CellPhone phone = new CellPhone("Android","Qualcom",15,3300,33);
            //Console.WriteLine(phone);
        }
    }
}
