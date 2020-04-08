using System;
using Newtonsoft.Json;

namespace ConsoleTest
{
    public class Attributes
    {
        public Attributes()
        {
        }
    }

    public class Man
    {
        [JsonProperty("Chinese name")]
        public string Name { get; set; }


    }

    public class Example
    {
        public static void e1()
        {
            Man man = new Man
            {
                Name = "秀儿"
            };
            string json = JsonConvert.SerializeObject(man, Formatting.Indented);
            Console.WriteLine(json);
        }
    }


   
}
