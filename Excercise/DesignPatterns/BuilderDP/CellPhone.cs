﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    internal class CellPhone
    {
        private string brand;
        private string os;
        private string processor;
        private double screenSize;
        private int battery;
        private int camera;

        public CellPhone(string brand, string os, string processor, double screenSize, int battery, int camera)
        {
            this.brand = brand;
            this.os = os;
            this.processor = processor;
            this.screenSize = screenSize;
            this.battery = battery;
            this.camera = camera;
        }
        public override string ToString()
        {
            return
                $"Brand:{brand}, " +
                $"OS: {os}, " +
                $"Processor: {processor}, " +
                $"ScreenSize: {screenSize}, " +
                $"Battery: {battery}, " +
                $"Camera: {camera}";
        }
    }
}
