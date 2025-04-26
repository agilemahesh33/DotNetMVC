using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    internal class CellPhone
    {
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;

        public CellPhone(string os, string processor, double screenSize, int battery, int camera)
        {
            this.os = os;
            this.processor = processor;
            this.screenSize = screenSize;
            this.battery = battery;
            this.camera = camera;
        }
        public override string ToString()
        {
            return 
                $"OS: {os}, " +
                $"Processor: {processor}, " +
                $"ScreenSize: {screenSize}, " +
                $"Battery: {battery}, " +
                $"Camera: {camera}";
        }
    }
}
