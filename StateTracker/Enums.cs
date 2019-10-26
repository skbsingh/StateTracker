using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StateTracker
{
    public enum OccupationType
    {
        Empty,

        Ship,

        Hit,

        Miss
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }
}