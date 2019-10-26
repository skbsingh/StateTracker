using StateTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StateTracker.Controllers
{
    public class BoardController : ApiController
    {
        [HttpGet]
        public List<Panel> CreateBoard()
        {

            List<Panel> Panels = new List<Panel>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }

            return Panels;
        }

        [HttpPost]
        public string AddBattleShip([FromBody] List<Panel> gameBoard, int shipWidth, int orientation, int startRow, int startColumn)
        {
            //We cannot place ships beyond the boundaries of the board
            if (startRow < 1 || startRow > 10 || startColumn < 1 || startColumn > 10)
                return "startRow and startColumn should between 1 and 10";

            int endRow = startRow, endColumn = startColumn;
            List<int> panelNumbers = new List<int>();

            //if orientation = 0 then place the ship horizontally else vertically
            if (orientation == 0)
                endRow = endRow + (shipWidth - 1);
            else
                endColumn = endColumn + (shipWidth - 1);

            //We cannot place ships beyond the boundaries of the board
            if (endRow > 10 || endColumn > 10)
                return "We cannot place ship beyond the boundaries of the board";

            //Check if specified panels are occupied
            var affectedPanels = this.Range(gameBoard, startRow, startColumn, endRow, endColumn);
            if (affectedPanels.Any(x => x.IsOccupied))
                return "We cannot place ship on this position as it is already occupied";

            foreach (var panel in affectedPanels)
            {
                panel.OccupationType = OccupationType.Ship;
            }

            return "Ship placed successfully";
        }

        private List<Panel> Range(List<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels.Where(x => x.Coordinates.Row >= startRow
                                     && x.Coordinates.Column >= startColumn
                                     && x.Coordinates.Row <= endRow
                                     && x.Coordinates.Column <= endColumn).ToList();
        }
    }
}
