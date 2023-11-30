using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace assignment24
{
    class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } // Additional property in Destination
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 3: Test the Dynamic Property Mapping

            // Create instances of Source and Destination classes
            Source source = new Source { Id = 1, Name = "Product", Price = 29.99 };
            Destination destination = new Destination();

            // Display source properties
            Console.WriteLine("Source Properties:");
            Console.WriteLine($"Id: {source.Id}, Name: {source.Name}, Price: {source.Price}");

            // Call the MapProperties method to map properties
            MapProperties(source, destination);

            // Display destination properties after mapping
            Console.WriteLine("\nDestination Properties after Mapping:");
            Console.WriteLine($"Id: {destination.Id}, Name: {destination.Name}, Price: {destination.Price}, Description: {destination.Description}");
        }

        // Step 2: Implement Dynamic Property Mapping
        static void MapProperties(object sourceObject, object destinationObject)
        {
            Type sourceType = sourceObject.GetType();
            Type destinationType = destinationObject.GetType();

            // Get common properties using LINQ
            var commonProperties = sourceType.GetProperties()
                .Where(prop => destinationType.GetProperty(prop.Name) != null);

            // Map common properties
            foreach (var property in commonProperties)
            {
                PropertyInfo destinationProperty = destinationType.GetProperty(property.Name);
                destinationProperty.SetValue(destinationObject, property.GetValue(sourceObject));
            }
        }
    }
}
    
