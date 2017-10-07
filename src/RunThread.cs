using Substrate;
using System.Drawing;

namespace CreativeModePlus
{
    public enum RunThread
    {
        Init,
        LoadLayer,
        Update,
        SaveLayer

    }

    public struct Block
    {
        public Block(int id) { ID = id; Data = 0; ent = null; }

        public int ID, Data;

        public TileEntity ent;

    }

    public struct Limits
    {
        public int[][] clr,
                       lyr;
        public Block[][] map;

    }
}