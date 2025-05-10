using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdapterDP
{
    // Target interface
    internal interface IDataVisualizer
    {
        void DisplayGraph(string JSONData);
    }
    

    // Adapter
    public class DataFormatAdapter : IDataVisualizer
    {
        private readonly AnalyticsLibrary _adaptee;

        public DataFormatAdapter(AnalyticsLibrary adaptee)
        {
            _adaptee = adaptee;
        }

        public void DisplayGraph(string JSONData)
        {
            CustomLibraryObject obj = GetObjectFromJSON(JSONData);
            _adaptee.DisplayGraph(obj);
        }

        private CustomLibraryObject GetObjectFromJSON(string jsonData)
        {
            // Convert JSON Data to Object
            return JsonConvert.DeserializeObject<CustomLibraryObject>(jsonData);
        }
    }
}
