using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace StateTracker.Models
{
    [DataContract]
    public class Panel
    {
        [DataMember]
        public OccupationType OccupationType { get; set; }

        [DataMember]
        public Coordinates Coordinates { get; set; }

        public Panel(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            OccupationType = OccupationType.Empty;
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Ship;
            }
        }
    }
}