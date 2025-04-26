namespace BuilderDP
{
    internal interface ICellPhoneBuilder
    {
        CellPhone GetCellPhone();
        ICellPhoneBuilder setBattery(int battery);
        ICellPhoneBuilder setCamera(int camera);
        ICellPhoneBuilder setOS(string os);
        ICellPhoneBuilder setProcessor(string processor);
        ICellPhoneBuilder setScreenSize(double screenSize);
    }
}