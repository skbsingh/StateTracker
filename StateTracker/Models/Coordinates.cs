using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace StateTracker.Models
{
    [DataContract]
    public class Coordinates
    {
        [DataMember]
        public int Row { get; set; }
        [DataMember]
        public int Column { get; set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}