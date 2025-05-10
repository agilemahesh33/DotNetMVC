using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    internal class ApplePhoneBuilder : ICellPhoneBuilder
    {
        private readonly string brand = "Apple";
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;
        public CellPhone GetCellPhone()
        {
            if (processor == null)
                processor = "A18 Pro 6 Core" ;
            return new CellPhone(brand, os, processor, screenSize, battery, camera);
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
    }
}
