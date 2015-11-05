using System.Collections.Generic;

namespace GridInfrastructure
{
    public interface IGrid
    {
        Cell this[int row, int column] { get; set; }

        int Columns { get; set; }
        int Rows { get; set; }
        int Size { get; }

        string ContentsOf(Cell cell);
        IEnumerable<Cell> GetAllCells();
        List<List<Cell>> GetAllRows();
        IEnumerator<Cell> GetEnumerator();
        string ToDebug();
        string ToString();
        string ToString(bool displayGridCoordinates);
    }
}