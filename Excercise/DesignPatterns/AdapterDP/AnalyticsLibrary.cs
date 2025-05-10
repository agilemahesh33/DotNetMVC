using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDP
{
    // Adaptee - incompatible interface
    public class AnalyticsLibrary
    {
        public void DisplayGraph(CustomLibraryObject data)
        {
            Console.WriteLine($"Graph Title: {data.Title}");
            Console.WriteLine("Data Points: " + string.Join(", ", data.DataPoints));
        }
    }
    // Adaptee's expected input object
    public class CustomLibraryObject
    {
        public string Title { get; set; }
        public List<int> DataPoints { get; set; }
    }
}
