namespace AdapterDP
{
    //Client
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                'Title': 'Monthly Sales',
                'DataPoints': [100, 150, 200, 250]
            }";

            AnalyticsLibrary analytics = new AnalyticsLibrary();
            IDataVisualizer visualizer = new DataFormatAdapter(analytics);

            visualizer.DisplayGraph(json); // Adapter in action
        }
    }
}
