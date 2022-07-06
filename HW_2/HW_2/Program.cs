using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


using System.Text.Json;
// using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


// creating WeatherForecast object
var weatherforecast = new WeatherForecast
{
    Date = DateTime.Parse("2019-08-01"),
    TemperatureCelsius = 25,
    Summary = "Hot"
};

Serialize(weatherforecast); //calling  Serialize on WeatherForecast object which will create an xml file

var details=DeSerialize("C:\\Users\\Dell\\source\\repos\\HW_2\\HW_2\\file_xml.xml"); //calling  DeSerialize on xml file which will return the WeatherForecast obejct
Console.WriteLine("" + details.Date+" "+details.TemperatureCelsius+" "+details.Summary);

static void Serialize(WeatherForecast details) //function to serialze WeatherForecast object into xml
{
    XmlSerializer serializer = new XmlSerializer(typeof(WeatherForecast)); 
    using (TextWriter writer = new StreamWriter("C:\\Users\\Dell\\source\\repos\\HW_2\\HW_2\\file_xml.xml"))
    {
        serializer.Serialize(writer, details);
    }
}
static WeatherForecast DeSerialize(string file_name) //function to DeSerialize the xml file into WeatherForecast object
{
    XmlSerializer deserializer=new XmlSerializer(typeof(WeatherForecast));
    TextReader reader=new StreamReader(file_name);
    object obj=deserializer.Deserialize(reader);
    WeatherForecast details=(WeatherForecast)obj;
    reader.Close();
    return details;
}

public class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}

