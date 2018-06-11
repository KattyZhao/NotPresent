using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    ///  Model for recording data for the map pin
    /// </summary>
    public class MapPinLocationModel
    {
        public double Latitude;//record the location latitude
        public double Longitude;//record the location longtitude
        public string Heading;//record the location name
        public string Body;//record description
        public string color;//record pin color
        public string Uri;//record picture
        public string funfact; //record one sentence funfact for map use
    }
}