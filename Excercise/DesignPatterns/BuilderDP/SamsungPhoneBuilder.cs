using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    internal class SamsungPhoneBuilder : ICellPhoneBuilder
    {
        private string brand = "Samsung";
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;

        //Create Setter Methods for the above fields
        public ICellPhoneBuilder setOS(string os)
        {
            this.os = os;
            return this;
        }
        public ICellPhoneBuilder setProcessor(string processor)
        {
            this.processor = processor;
            return this;
        }
        public ICellPhoneBuilder setScreenSize(double screenSize)
        {
            this.screenSize = screenSize;
            return this;
        }
        public ICellPhoneBuilder setBattery(int battery)
        {
            this.battery = battery;
            return this;
        }
        public ICellPhoneBuilder setCamera(int camera)
        {
            this.camera = camera;
            return this;
        }

        //Create Method which will create new object by setting above values
        //and will return the same
        public CellPhone GetCellPhone()
        {
            return new CellPhone(brand, os, processor, screenSize, battery, camera);
        }
    }
}
