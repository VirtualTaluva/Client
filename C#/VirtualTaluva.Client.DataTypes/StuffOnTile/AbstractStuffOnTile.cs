using Com.Ericmas001.Windows;

namespace VirtualTaluva.Client.DataTypes.StuffOnTile
{
    public abstract class AbstractStuffOnTile : BaseViewModel
    {
        public abstract void RecalculateMargin(double rotateAngle);
    }
}
