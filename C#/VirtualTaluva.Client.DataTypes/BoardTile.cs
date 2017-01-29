using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Com.Ericmas001.Windows;

namespace VirtualTaluva.Client.DataTypes
{
    public class BoardTile : BaseViewModel
    {
        public static double XOffset { get; set; } = Global.NB_TILES / 2.0;
        public static double YOffset { get; set; } = Global.NB_TILES / 2.0;

        private readonly int m_X;
        private readonly int m_Y;
        private readonly IBoard m_Board;

        public Thickness Margin =>  new Thickness((m_X - XOffset) * Global.TILE_WIDTH - (m_Y % 2 * (Global.TILE_WIDTH / 2)), (m_Y - YOffset) * Global.TILE_HEIGHT, 0, 0);

        public FastObservableCollection<Land> Lands { get; } = new FastObservableCollection<Land>();

        public string Pos => $"{m_X},{m_Y}";
        public Thickness PosMargin => new Thickness((m_X - XOffset) * Global.TILE_WIDTH - (m_Y % 2 * (Global.TILE_WIDTH / 2)) + 25, (m_Y - YOffset) * Global.TILE_HEIGHT + 25, 0, 0);

        public BoardTile(IBoard board, int x, int y)
        {
            m_X = x;
            m_Y = y;
            m_Board = board;
        }

        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
        public void RefreshMargin() => RaisePropertyChanged(nameof(Margin));
    }
}