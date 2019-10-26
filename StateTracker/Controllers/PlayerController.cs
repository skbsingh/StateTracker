using StateTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StateTracker.Controllers
{
    public class PlayerController : ApiController
    {
        [HttpPost]
        public string AttackPosition([FromBody] List<Panel> gameBoard, int attackRow, int attackColumn)
        {
            //Cannot attack beyond the boundaries of the board
            if (attackRow > 10 || attackColumn > 10)
                return "Cannot attack beyond the boundaries of the board";

            Panel panel = At(gameBoard, attackRow, attackColumn);
            if (panel.OccupationType == OccupationType.Ship)
            {
                panel.OccupationType = OccupationType.Hit;

                return "Target Hit";
            }
            else
            {
                panel.OccupationType = OccupationType.Miss;

                return "Missed";
            }
        }

        private Panel At(List<Panel> panels, int row, int column)
        {
            return panels.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }

    }
}
