using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Practice7
{

    public class AirportComparer : IComparer<Airport>
    {
        public int Compare([AllowNull] Airport x, [AllowNull] Airport y)
        {
            return x.Size - y.Size;
        }
    }
    // "01:45"  Time(129) Min, Hour
    // 720, 1250 

    public enum AirportSizes
    {
        Small,     //0
        Medium,    //1
        Large,     //2
        Mega,      //3
        SuperMega  //4
    }

    public class Airport : IComparable<Airport>
    {
        public string Name { get; private set; }
        public string CountryCode { get; private set; }
        public string SizeName { get; private set; }
        public AirportSizes Size { get; private set; }

        public Airport(string name, string countryCode, AirportSizes size)
        {
            this.Name = name;
            this.CountryCode = countryCode;
            this.SizeName = Enum.GetName(typeof(AirportSizes), size);
            this.Size = size;
        }

        public int CompareTo([AllowNull] Airport other)
        {
            return other.Size - this.Size;

            //if (other.Size > this.Size)
            //{
            //    return 1;
            //}
            //else if (other.Size < this.Size)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
}