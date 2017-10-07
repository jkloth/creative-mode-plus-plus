using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CreativeModePlus
{
    class BlockColor
    {
        private static int[] blockColors = null;

        public static int getBlockColor(int blkID)
        {
            if (blockColors == null)
                initBlockColors();

            if (blkID < 0 || blkID > 145)
                blkID = 95;

            return blockColors[blkID];

        }

        public static void initBlockColors()
        {
            blockColors = new int[146];

            // Set to default colors
            blockColors[52] = -15790321;//0xff0f0f0f;
            blockColors[7] = blockColors[119] = -16777216;//0xff000000;
            blockColors[22] = -16776961;//0xff0000ff;
            blockColors[3] = blockColors[60] = -8372224;//0xff804000;
            blockColors[87] = -2354116;//0xffdc143c;
            blockColors[57] = blockColors[138] - 16711681;//0xff00ffff;
            blockColors[88] = -12574720;//0xff402000;
            blockColors[54] = -6270976;//0xffa05000;
            blockColors[13] = blockColors[118] = -8355712;//0xff808080;
            blockColors[103] = -16751616;//0xff006400;
            blockColors[130] = -14663648;//0xff204020;
            blockColors[24] = blockColors[128] = -4145056;//0xffc0c060;
            blockColors[49] = blockColors[116] = blockColors[122] = -14352330;
            //0xff250036;
            blockColors[112] = blockColors[113] = blockColors[114] = -12578816;
            //0xff401000;
            blockColors[123] = -8376320;//0xff803000;
            blockColors[5] = blockColors[17] = blockColors[53] =
             blockColors[63] = blockColors[64] = blockColors[65] =
             blockColors[68] = blockColors[72] = blockColors[85] =
             blockColors[96] = blockColors[107] = blockColors[125] =
             blockColors[126] = blockColors[134] = blockColors[135] =
             blockColors[136] = blockColors[143] = -3907072;//0xffc46200;
            blockColors[29] = blockColors[33] = blockColors[34] = -3890624;
            //0xffc4a240;
            blockColors[4] = blockColors[23] = blockColors[43] =
             blockColors[44] = blockColors[61] = blockColors[62] =
             blockColors[67] = blockColors[69] = blockColors[97] =
             blockColors[139] = -5658199;
            //0xffa9a9a9;
            blockColors[48] = -8338304;//0xff80c480;
            blockColors[45] = blockColors[108] = blockColors[137] =
             blockColors[140] = -3899264;//0xffc48080;
            blockColors[2] = -16744448;//0xff008000;
            blockColors[8] = blockColors[9] = -7876885;//0xff87ceeb;
            blockColors[79] = -8323073;//0xff80ffff;
            blockColors[1] = blockColors[70] = blockColors[77] =
             blockColors[98] = blockColors[109] = blockColors[117] = -2894893;
            //0xffd3d3d3;
            blockColors[21] = -2894849;//0xffd3d3ff;
            blockColors[56] = -2883585;//0xffd3ffff;
            blockColors[129] = -2883629;//0xffd3ffd3;
            blockColors[73] = blockColors[74] = -11309;//0xffffd3d3;
            blockColors[14] = -45;//0xffffffd3;
            blockColors[6] = blockColors[18] = blockColors[31] =
             blockColors[32] = blockColors[37] = blockColors[38] =
             blockColors[39] = blockColors[40] = blockColors[81] =
             blockColors[83] = blockColors[99] = blockColors[100] =
             blockColors[104] = blockColors[105] = blockColors[106] =
             blockColors[111] = blockColors[115] = blockColors[127] =
             blockColors[141] = blockColors[142] = -7278960;
            //0xff90ee90;
            blockColors[28] = blockColors[42] = blockColors[66] =
             blockColors[71] = blockColors[101] = -7039852;//0xff949494;
            blockColors[19] = -20382;//0xffffb062;
            blockColors[90] = -2653441;//0xffd782ff;
            blockColors[133] = -16711936;//0xff00ff00;
            blockColors[95] = blockColors[36] = -65281;//0xffff00ff;
            blockColors[55] = blockColors[75] = blockColors[76] =
             blockColors[93] = blockColors[94] = blockColors[131] = -8388608;
            //0xff800000;
            blockColors[86] = blockColors[91] = -23296;//0xffffa500;
            blockColors[12] = -108;//0xffffff94;
            blockColors[15] = -9543;//0xffffdab9;
            blockColors[35] = -8388480;//0xff800080;
            blockColors[26] = -65536;//0xffff0000;
            blockColors[46] = -53248;//0xffff3000;
            blockColors[25] = -8380416;//0xff802000;
            blockColors[10] = blockColors[11] = -49152;//0xffff4000;
            blockColors[82] = -360334;//0xfffa8072;
            blockColors[20] = blockColors[102] = -5383962;//0xffadd8e6;
            blockColors[92] = -14675968;//0xff201000;
            blockColors[16] = -14671840;//0xff202020;
            blockColors[59] = -663885;//0xfff5deb3;
            blockColors[78] = blockColors[80] = -3866625;//0xffc4ffff;
            blockColors[30] = blockColors[132] = -2039584;//0xffe0e0e0;
            blockColors[110] = -1459713;//0xffe9b9ff;
            blockColors[120] = blockColors[121] = -60;//0xffffffc4;
            blockColors[0] = -1;//0xffffffff;
            blockColors[50] = blockColors[51] = blockColors[89] =
             blockColors[124] = -256;//0xffffff00;
            blockColors[58] = blockColors[84] = -15360;//0xffffc400;
            blockColors[41] = blockColors[27] = -27648;//0xffff9400;
            blockColors[47] = -16350076;//0xff068484
            blockColors[144] = -11865;//0xffFFD1A7
            blockColors[145] = -12566464;//0xff404040

        }

        public void changeColors()
        {
            ;

        }
    }
}
