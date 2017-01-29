using System.Windows;

namespace VirtualTaluva.Client.DataTypes
{
    public interface IBoard
    {
        Thickness Bounds { get; }
        BoardTile[,] BoardMatrix { get; }
        int NbPlayingTiles { get; }
    }
}
