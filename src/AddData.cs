using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Substrate;
using Substrate.TileEntities;

namespace CreativeModePlus
{
    public partial class AddData : Form
    {
        private static int id;
        private static Block data;
        public static Block Data { get { return data; } }

        public static void getData(int ID, Form main)
        {
            AddData temp = new AddData(main);
            data.ID = id = ID;
            data.Data = 0;
            data.ent = null;
            temp.selectData(ID);
            temp.Dispose();

        }

        private AddData(Form main)
        {
            InitializeComponent(main);

        }

        private void selectData(int ID)
        {
            switch (ID)
            {
                case 52:
                    data.ent = makeSpawner();

                    break;

                // Stairs
                case 53:
                case 67:
                case 108:
                case 109:
                case 114:
                case 128:
                case 134:
                case 135:
                case 136:
                    data.Data = makeStairs();

                    break;

                // Torches
                case 50:
                case 75:
                case 76:
                    data.Data = makeTorches();

                    break;

                // Repeaters
                case 93:
                case 94:
                    data.Data = makeRepeaters();

                    break;

                // Wood Logs
                case 17:
                    data.Data = makeLogs();

                    break;

                // Wood Planks, Leaves, Saplings, double slabs
                case 5:
                case 6:
                case 18:
                case 125:
                    data.Data = makeWoodType();

                    break;

                // Wood Slabs
                case 126:
                    data.Data = makeWoodSlabs();

                    break;

                // Special Rails
                case 27:
                case 28:
                    data.Data = makeSpRails();

                    break;

                // Rails
                case 66:
                    data.Data = makeRails();

                    break;

                // Pistons
                case 29:
                case 33:
                    data.Data = makePistons();

                    break;

                // Tall Grass
                case 31:
                    data.Data = makeGrass();

                    break;

                // Wool
                case 35:
                    data.Data = makeWool();

                    break;

                // Stone Slabs & doubles
                case 43:
                case 44:
                    data.Data = makeStoneSlabs();

                    break;

                // Chests, Furnaces, Ladders, Wall Signs, Dispensers
                case 23:
                case 54:
                case 61:
                case 62:
                case 65:
                case 68:
                case 130:
                    data.Data = makeChests();

                    break;

                // End Portal Frame & pumpkins
                case 86:
                case 91:
                case 120:
                    data.Data = makeEndPortalFrame();

                    break;

                // Buttons
                case 77:
                case 143:
                    data.Data = makeButtons();

                    break;

                // Sign
                case 63:
                    data.Data = makeSign();

                    break;

                // Crops
                case 59:
                case 104:
                case 105:
                    data.Data = makeCrops();

                    break;

                // Nether Wart, carrots and potatoes
                case 115:
                case 141:
                case 142:
                    data.Data = makeWart();

                    break;

                // Farmland
                case 60:
                    data.Data = makeFarm();

                    break;

                // Redstone
                case 55:
                    data.Data = makeWires();

                    break;

                // Trip Wire Hooks
                case 131:
                    data.Data = makeHooks();

                    break;

                // Lever
                case 69:
                    data.Data = makeLevers();

                    break;

                // Bed
                case 26:
                    data.Data = makeBed();

                    break;

                // Doors
                case 64:
                case 71:
                    data.Data = makeDoors();

                    break;

                // Fence Gate
                case 107:
                    data.Data = makeFence();

                    break;

                // Trap Door
                case 96:
                    data.Data = makeTraps();

                    break;

                // Monster Eggs
                case 97:
                    data.Data = makeEggs();

                    break;

                // Stone Brick
                case 98:
                    data.Data = makeStoneBrick();

                    break;

                // Sandstone
                case 24:
                    data.Data = makeSandstone();

                    break;

                // Vines
                case 106:
                    data.Data = makeVines();

                    break;

                // Heads THIS SECTION WILL DO SOMETHING WHEN MORE INFORMATION COMES OUT
                /*case 144:
                 data.ent = makeHead();

                break;*/

                // Anvil
                case 145:
                    data.Data = makeAnvil();

                    break;

            }
        }

        private int makeAnvil()
        {
            int toRet = 0;
            RadioButton s = new RadioButton(),
                        w = new RadioButton(),
                        n = new RadioButton(),
                        e = new RadioButton();
            ComboBox ort = new ComboBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Anvil Options";
            s.Text = "South";
            w.Text = "West";
            n.Text = "North";
            e.Text = "East";

            ort.Items.AddRange(new object[] { "Undamaged", "Slight", "Heavy" });
            Controls.AddRange(new Control[] { opt, s, w, n, e, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            w.Location = new Point(125, 27);
            n.Location = new Point(15, 50);
            e.Location = new Point(125, 50);
            ort.Location = new Point(15, 75);
            btnData.Location = new Point(15, 98);

            s.Checked = true;
            ort.SelectedIndex = 0;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else if (w.Checked)
                toRet = 1;

            else if (n.Checked)
                toRet = 2;

            else
                toRet = 3;

            if (ort.SelectedIndex == 1)
                toRet += 4;

            else if (ort.SelectedIndex == 2)
                toRet += 8;

            return toRet;

        }

        private int makeStairs()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox inv = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Stair Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            inv.Text = "Invert";

            Controls.AddRange(new Control[] { opt, n, s, e, w, inv });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            inv.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 0;

            else if (w.Checked)
                toRet = 1;

            else if (s.Checked)
                toRet = 2;

            else
                toRet = 3;

            if (inv.Checked)
                toRet += 4;

            return toRet;

        }

        private int makeTorches()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton(),
                        g = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Torch Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            g.Text = "Ground";

            Controls.AddRange(new Control[] { opt, n, s, e, w, g });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            g.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            g.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 1;

            else if (w.Checked)
                toRet = 2;

            else if (s.Checked)
                toRet = 3;

            else if (n.Checked)
                toRet = 4;

            else
                toRet = 5;

            return toRet;

        }

        private int makeRepeaters()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            Label opt = new Label(),
                        tik = new Label();
            HScrollBar tkB = new HScrollBar();

            Size = new Size(200, 185);

            // Set Item Text
            opt.Text = "Repeater Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            tik.Text = tik.Name = "1 Tick";

            // Set Ranges
            tkB.Minimum = 1;
            tkB.Maximum = 13;
            tkB.Value = 1;
            tkB.Size = new Size(170, 17);
            tkB.ValueChanged += new EventHandler(tkB_ValueChanged);

            Controls.AddRange(new Control[] { opt, n, s, e, w, tik, tkB });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            tik.Location = new Point(15, 73);
            tkB.Location = new Point(15, 96);
            btnData.Location = new Point(15, 119);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 1;

            else if (w.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 2;

            else
                toRet = 0;

            toRet += (tkB.Value - 1) * 4;

            return toRet;

        }

        private void tkB_ValueChanged(Object sender, EventArgs e)
        {
            Control[] tik = Controls.Find("1 Tick", true);

            HScrollBar tkB = ((HScrollBar)sender);

            tik[0].Text = "" + tkB.Value + " Tick";

            if (tkB.Value > 1)
                tik[0].Text += "s";

        }

        private int makeLogs()
        {
            int toRet = 0;
            RadioButton o = new RadioButton(),
                        s = new RadioButton(),
                        b = new RadioButton(),
                        m = new RadioButton();
            ComboBox ort = new ComboBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Log Options";
            o.Text = "Oak";
            s.Text = "Spruce";
            b.Text = "Birch";
            m.Text = "Jungle";

            ort.Items.AddRange(new object[] { "Up-Down", "East-West", "North-South" });
            Controls.AddRange(new Control[] { opt, o, s, b, m, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            o.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            b.Location = new Point(15, 50);
            m.Location = new Point(125, 50);
            ort.Location = new Point(15, 75);
            btnData.Location = new Point(15, 98);

            o.Checked = true;
            ort.SelectedIndex = 0;

            ShowDialog();

            if (b.Checked)
                toRet = 2;

            else if (m.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 1;

            else
                toRet = 0;

            if (ort.SelectedIndex == 0)
                toRet += 0;

            else if (ort.SelectedIndex == 1)
                toRet += 4;

            else
                toRet += 8;

            return toRet;

        }

        private int makeWoodType()
        {
            int toRet = 0;
            RadioButton o = new RadioButton(),
                        s = new RadioButton(),
                        b = new RadioButton(),
                        m = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 136);

            // Set Item Text
            opt.Text = "Wood Options";
            o.Text = "Oak";
            s.Text = "Spruce";
            b.Text = "Birch";
            m.Text = "Jungle";

            Controls.AddRange(new Control[] { opt, o, s, b, m });

            // Set Locations
            opt.Location = new Point(12, 9);
            o.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            b.Location = new Point(15, 50);
            m.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            o.Checked = true;

            ShowDialog();

            if (b.Checked)
                toRet = 2;

            else if (m.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 1;

            else
                toRet = 0;

            return toRet;

        }

        private int makeWoodSlabs()
        {
            int toRet = 0;
            RadioButton o = new RadioButton(),
                        s = new RadioButton(),
                        b = new RadioButton(),
                        m = new RadioButton();
            CheckBox inv = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Stair Options";
            o.Text = "Oak";
            s.Text = "Spruce";
            b.Text = "Birch";
            m.Text = "Jungle";
            inv.Text = "Invert";

            Controls.AddRange(new Control[] { opt, o, s, b, m, inv });

            // Set Locations
            opt.Location = new Point(12, 9);
            o.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            b.Location = new Point(15, 50);
            m.Location = new Point(125, 50);
            inv.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            o.Checked = true;

            ShowDialog();

            if (b.Checked)
                toRet = 2;

            else if (m.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 1;

            else
                toRet = 0;

            if (inv.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeSpRails()
        {
            int toRet = 0;
            RadioButton ns = new RadioButton(),
                        ew = new RadioButton(),
                        n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox pwr = new CheckBox();
            Label opt = new Label();

            Size = new Size(350, 159);

            // Set Item Text
            opt.Text = "Special Rail Options";
            ns.Text = "North-South";
            ew.Text = "East-West";
            n.Text = "Ascend North";
            s.Text = "Ascend South";
            e.Text = "Ascend East";
            w.Text = "Ascend West";
            pwr.Text = "Powered";

            Controls.AddRange(new Control[] { opt, ns, n, s, ew, e, w, pwr });

            if (id == 28)
                pwr.Enabled = false;

            // Set Locations
            opt.Location = new Point(12, 9);
            ns.Location = new Point(15, 27);
            n.Location = new Point(125, 27);
            s.Location = new Point(235, 27);
            ew.Location = new Point(15, 50);
            e.Location = new Point(125, 50);
            w.Location = new Point(235, 50);
            pwr.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            ns.Checked = true;

            ShowDialog();

            if (ns.Checked)
                toRet = 0;

            else if (ew.Checked)
                toRet = 1;

            else if (e.Checked)
                toRet = 2;

            else if (w.Checked)
                toRet = 3;

            else if (n.Checked)
                toRet = 4;

            else
                toRet = 5;

            if (pwr.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeRails()
        {
            int toRet = 0;
            ComboBoxWithIcons ort = new ComboBoxWithIcons();
            Label opt = new Label();

            Size = new Size(200, 120);

            // Set Item Text
            opt.Text = "Rail Options";

            // Set Item Configuation
            ort.DropDownStyle = ComboBoxStyle.DropDownList;
            ort.DrawMode = DrawMode.OwnerDrawFixed;

            populate(ort);

            Controls.AddRange(new Control[] { opt, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            ort.Location = new Point(15, 29);
            btnData.Location = new Point(15, 55);

            ort.SelectedIndex = 0;

            ShowDialog();

            toRet = ort.SelectedIndex;

            return toRet;

        }

        private void populate(ComboBoxWithIcons ort)
        {
            String pop = "CreativeModePlus.res.block_icons.rails.";
            Stream file = Asm.exe.GetManifestResourceStream(pop + "0.png");

            ort.Add("North-South", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "1.png");
            ort.Add("East-West", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "1.png");
            ort.Add("Ascend East", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "1.png");
            ort.Add("Ascend West", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "0.png");
            ort.Add("Ascend North", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "0.png");
            ort.Add("Ascend South", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "2.png");
            ort.Add("South to East", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "3.png");
            ort.Add("South to West", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "4.png");
            ort.Add("North to West", Image.FromStream(file), -1);
            file.Close();

            file = Asm.exe.GetManifestResourceStream(pop + "5.png");
            ort.Add("North to East", Image.FromStream(file), -1);
            file.Close();

        }

        private int makePistons()
        {
            int toRet = 0;
            RadioButton d = new RadioButton(),
                        u = new RadioButton(),
                        n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox pwr = new CheckBox();
            Label opt = new Label();

            Size = new Size(350, 159);

            // Set Item Text
            opt.Text = "Piston Options";
            d.Text = "Down";
            u.Text = "Up";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            pwr.Text = "Extended";

            Controls.AddRange(new Control[] { opt, d, n, s, u, e, w, pwr });

            // Set Locations
            opt.Location = new Point(12, 9);
            d.Location = new Point(15, 27);
            n.Location = new Point(125, 27);
            s.Location = new Point(235, 27);
            u.Location = new Point(15, 50);
            e.Location = new Point(125, 50);
            w.Location = new Point(235, 50);
            pwr.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            d.Checked = true;

            ShowDialog();

            if (d.Checked)
                toRet = 0;

            else if (u.Checked)
                toRet = 1;

            else if (n.Checked)
                toRet = 2;

            else if (s.Checked)
                toRet = 3;

            else if (w.Checked)
                toRet = 4;

            else
                toRet = 5;

            if (pwr.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeGrass()
        {
            int toRet = 0;
            RadioButton t = new RadioButton(),
                        s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Grass Options";
            t.Text = "Tall Grass";
            s.Text = "Dead Shurb";
            f.Text = "Fern";

            Controls.AddRange(new Control[] { opt, t, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            t.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            f.Location = new Point(15, 50);
            btnData.Location = new Point(15, 73);

            t.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else if (t.Checked)
                toRet = 1;

            else
                toRet = 2;

            return toRet;

        }

        private int makeWool()
        {
            int toRet = 0;
            ComboBox ort = new ComboBox();
            Label opt = new Label();

            Size = new Size(200, 120);

            // Set Item Text
            opt.Text = "Wool Options";

            ort.Items.AddRange(new object[]{ "White",
                                     "Orange",
                                     "Magenta",
                                     "Light Blue",
                                     "Yellow",
                                     "Lime",
                                     "Pink",
                                     "Gray",
                                     "Light Gray",
                                     "Cyan",
                                     "Purple",
                                     "Blue",
                                     "Brown",
                                     "Green",
                                     "Red",
                                     "Black" });
            Controls.AddRange(new Control[] { opt, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            ort.Location = new Point(15, 29);
            btnData.Location = new Point(15, 55);

            ort.SelectedIndex = 0;

            ShowDialog();

            toRet = ort.SelectedIndex;

            return toRet;

        }

        private int makeStoneSlabs()
        {
            int toRet = 0;
            RadioButton ss = new RadioButton(),
                        cs = new RadioButton(),
                        b = new RadioButton(),
                        s = new RadioButton(),
                        sb = new RadioButton();
            CheckBox pwr = new CheckBox();
            Label opt = new Label();

            Size = new Size(350, 159);

            // Set Item Text
            opt.Text = "Piston Options";
            ss.Text = "Sandstone";
            cs.Text = "Cobblestone";
            b.Text = "Brick";
            s.Text = "Stone";
            sb.Text = "Stone Brick";
            pwr.Text = "Inverted";

            Controls.AddRange(new Control[] { opt, s, b, ss, cs, sb, pwr });

            if (id == 43)
                pwr.Enabled = false;

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            b.Location = new Point(125, 27);
            ss.Location = new Point(235, 27);
            cs.Location = new Point(15, 50);
            sb.Location = new Point(125, 50);
            pwr.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            s.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else if (ss.Checked)
                toRet = 1;

            else if (cs.Checked)
                toRet = 3;

            else if (b.Checked)
                toRet = 4;

            else
                toRet = 5;

            if (pwr.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeChests()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 136);

            // Set Item Text
            opt.Text = "" + ((BlockNames)id) + " Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";

            Controls.AddRange(new Control[] { opt, n, s, e, w });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 5;

            else if (w.Checked)
                toRet = 4;

            else if (s.Checked)
                toRet = 3;

            else
                toRet = 2;

            return toRet;

        }

        private int makeEndPortalFrame()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 136);

            // Set Item Text
            opt.Text = "" + ((BlockNames)id) + " Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";

            Controls.AddRange(new Control[] { opt, n, s, e, w });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 3;

            else if (w.Checked)
                toRet = 1;

            else if (s.Checked)
                toRet = 0;

            else
                toRet = 2;

            return toRet;

        }

        private int makeButtons()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 136);

            // Set Item Text
            opt.Text = "Button Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";

            Controls.AddRange(new Control[] { opt, n, s, e, w });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 1;

            else if (w.Checked)
                toRet = 2;

            else if (s.Checked)
                toRet = 3;

            else
                toRet = 4;

            return toRet;

        }

        private int makeSign()
        {
            int toRet = 0;
            ComboBox ort = new ComboBox();
            Label opt = new Label();

            Size = new Size(200, 120);

            // Set Item Text
            opt.Text = "Sign Post Options";

            ort.Items.AddRange(new object[]{ "South",
                                     "South-Southwest",
                                     "Southwest",
                                     "West-Southwest",
                                     "West",
                                     "West-Northwest",
                                     "Northwest",
                                     "North-Northwest",
                                     "North",
                                     "North-Northeast",
                                     "Northeast",
                                     "East-Northeast",
                                     "East",
                                     "East-Southeast",
                                     "Southeast",
                                     "South-Southeast" });
            Controls.AddRange(new Control[] { opt, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            ort.Location = new Point(15, 29);
            btnData.Location = new Point(15, 55);

            ort.SelectedIndex = 0;

            ShowDialog();

            toRet = ort.SelectedIndex;

            return toRet;

        }

        private int makeCrops()
        {
            int toRet = 0;
            RadioButton s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 115);

            // Set Item Text
            opt.Text = "Crop Options";
            s.Text = "Just Planted";
            f.Text = "Full Grown";

            Controls.AddRange(new Control[] { opt, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            f.Location = new Point(125, 27);
            btnData.Location = new Point(15, 50);

            s.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else
                toRet = 7;

            return toRet;

        }

        private int makeWart()
        {
            int toRet = 0;
            RadioButton s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 115);

            // Set Item Text
            opt.Text = "Crop Options";
            s.Text = "Just Planted";
            f.Text = "Full Grown";

            Controls.AddRange(new Control[] { opt, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            f.Location = new Point(125, 27);
            btnData.Location = new Point(15, 50);

            s.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else
                toRet = 3;

            return toRet;

        }

        private int makeFarm()
        {
            int toRet = 0;
            RadioButton s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 115);

            // Set Item Text
            opt.Text = "Farm Options";
            s.Text = "Dry";
            f.Text = "Wet";

            Controls.AddRange(new Control[] { opt, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            f.Location = new Point(125, 27);
            btnData.Location = new Point(15, 50);

            s.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else
                toRet = 8;

            return toRet;

        }

        private int makeWires()
        {
            int toRet = 0;
            RadioButton s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 115);

            // Set Item Text
            opt.Text = "Wire Options";
            s.Text = "Unpowered";
            f.Text = "Powered";

            Controls.AddRange(new Control[] { opt, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            s.Location = new Point(15, 27);
            f.Location = new Point(125, 27);
            btnData.Location = new Point(15, 50);

            s.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 0;

            else
                toRet = 15;

            return toRet;

        }

        private int makeHooks()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox inv = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Hook Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            inv.Text = "Set";

            Controls.AddRange(new Control[] { opt, n, s, e, w, inv });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            inv.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 3;

            else if (w.Checked)
                toRet = 1;

            else if (s.Checked)
                toRet = 0;

            else
                toRet = 2;

            if (inv.Checked)
                toRet += 4;

            return toRet;

        }

        private int makeLevers()
        {
            int toRet = 0;
            RadioButton gns = new RadioButton(),
                        gew = new RadioButton(),
                        cns = new RadioButton(),
                        cew = new RadioButton(),
                        n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox pwr = new CheckBox();
            Label opt = new Label();

            Size = new Size(475, 159);

            // Set Item Text
            opt.Text = "Lever Options";
            gns.Text = "N-S Ground";
            gew.Text = "E-W Ground";
            cns.Text = "N-S Ceiling";
            cew.Text = "E-W Ceiling";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            pwr.Text = "Active";

            Controls.AddRange(new Control[]{ opt,
                                     gns,
                                     n,
                                     s,
                                     cns,
                                     gew,
                                     e,
                                     w,
                                     cew,
                                     pwr });

            // Set Locations
            opt.Location = new Point(12, 9);
            gns.Location = new Point(15, 28);
            n.Location = new Point(125, 28);
            s.Location = new Point(235, 28);
            cns.Location = new Point(355, 28);
            gew.Location = new Point(15, 51);
            e.Location = new Point(125, 51);
            w.Location = new Point(235, 51);
            cew.Location = new Point(355, 51);
            pwr.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            gns.Checked = true;

            ShowDialog();

            if (cns.Checked)
                toRet = 0;

            else if (e.Checked)
                toRet = 1;

            else if (w.Checked)
                toRet = 2;

            else if (s.Checked)
                toRet = 3;

            else if (n.Checked)
                toRet = 4;

            else if (gns.Checked)
                toRet = 5;

            else if (gew.Checked)
                toRet = 6;

            else
                toRet = 7;

            if (pwr.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeBed()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 136);

            // Set Item Text
            opt.Text = "Bed (Head) Options";
            n.Text = "Head North";
            s.Text = "Head South";
            e.Text = "Head East";
            w.Text = "Head West";

            Controls.AddRange(new Control[] { opt, n, s, e, w });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 11;

            else if (w.Checked)
                toRet = 9;

            else if (s.Checked)
                toRet = 8;

            else
                toRet = 10;

            return toRet;

        }

        private int makeDoors()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox inv = new CheckBox(),
                        opn = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Door Options";
            n.Text = "Northwest";
            s.Text = "Northeast";
            e.Text = "Southeast";
            w.Text = "Southwest";
            inv.Text = "Top";
            opn.Text = "Open";

            Controls.AddRange(new Control[] { opt, n, s, e, w, inv, opn });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            inv.Location = new Point(15, 73);
            opn.Location = new Point(125, 73);
            btnData.Location = new Point(15, 96);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 2;

            else if (w.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 1;

            else
                toRet = 0;

            if (inv.Checked)
                toRet += 4;

            if (opn.Checked)
                toRet += 8;

            return toRet;

        }

        private int makeFence()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox opn = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Fence Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            opn.Text = "Open";

            Controls.AddRange(new Control[] { opt, n, s, e, w, opn });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            opn.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 3;

            else if (w.Checked)
                toRet = 1;

            else if (s.Checked)
                toRet = 0;

            else
                toRet = 2;

            if (opn.Checked)
                toRet += 4;

            return toRet;

        }

        private int makeTraps()
        {
            int toRet = 0;
            RadioButton n = new RadioButton(),
                        s = new RadioButton(),
                        e = new RadioButton(),
                        w = new RadioButton();
            CheckBox opn = new CheckBox();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Trap Options";
            n.Text = "North";
            s.Text = "South";
            e.Text = "East";
            w.Text = "West";
            opn.Text = "Open";

            Controls.AddRange(new Control[] { opt, n, s, e, w, opn });

            // Set Locations
            opt.Location = new Point(12, 9);
            n.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            opn.Location = new Point(15, 73);
            btnData.Location = new Point(15, 96);

            n.Checked = true;

            ShowDialog();

            if (e.Checked)
                toRet = 2;

            else if (w.Checked)
                toRet = 3;

            else if (s.Checked)
                toRet = 0;

            else
                toRet = 1;

            if (opn.Checked)
                toRet += 4;

            return toRet;

        }

        private int makeEggs()
        {
            int toRet = 0;
            RadioButton t = new RadioButton(),
                        s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 159);

            // Set Item Text
            opt.Text = "Egg Options";
            t.Text = "Stone";
            s.Text = "Cobblestone";
            f.Text = "Stone Brick";

            Controls.AddRange(new Control[] { opt, t, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            t.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            f.Location = new Point(15, 50);
            btnData.Location = new Point(15, 73);

            t.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 1;

            else if (t.Checked)
                toRet = 0;

            else
                toRet = 2;

            return toRet;

        }

        private int makeStoneBrick()
        {
            int toRet = 0;
            RadioButton sb = new RadioButton(),
                        cr = new RadioButton(),
                        ms = new RadioButton(),
                        ch = new RadioButton();
            Label opt = new Label();

            Size = new Size(225, 135);

            // Set Item Text
            opt.Text = "Brick Options";
            sb.Text = "Stone Brick";
            cr.Text = "Cracked Brick";
            ms.Text = "Mossy Brick";
            ch.Text = "Chiseled Brick";

            Controls.AddRange(new Control[] { opt, sb, cr, ms, ch });

            // Set Locations
            opt.Location = new Point(12, 9);
            sb.Location = new Point(15, 27);
            cr.Location = new Point(125, 27);
            ms.Location = new Point(15, 50);
            ch.Location = new Point(125, 50);
            btnData.Location = new Point(15, 73);

            sb.Checked = true;

            ShowDialog();

            if (sb.Checked)
                toRet = 0;

            else if (cr.Checked)
                toRet = 2;

            else if (ms.Checked)
                toRet = 3;

            else
                toRet = 3;

            return toRet;

        }

        private int makeSandstone()
        {
            int toRet = 0;
            RadioButton t = new RadioButton(),
                        s = new RadioButton(),
                        f = new RadioButton();
            Label opt = new Label();

            Size = new Size(200, 135);

            // Set Item Text
            opt.Text = "Egg Options";
            t.Text = "Sandstone";
            s.Text = "Chiseled";
            f.Text = "Smooth";

            Controls.AddRange(new Control[] { opt, t, s, f });

            // Set Locations
            opt.Location = new Point(12, 9);
            t.Location = new Point(15, 27);
            s.Location = new Point(125, 27);
            f.Location = new Point(15, 50);
            btnData.Location = new Point(15, 73);

            t.Checked = true;

            ShowDialog();

            if (s.Checked)
                toRet = 1;

            else if (t.Checked)
                toRet = 0;

            else
                toRet = 2;

            return toRet;

        }

        private int makeVines()
        {
            int toRet = 0;
            CheckBox t = new CheckBox(),
                     n = new CheckBox(),
                     s = new CheckBox(),
                     e = new CheckBox(),
                     w = new CheckBox();
            Label opt = new Label();

            Size = new Size(350, 159);

            // Set Item Text
            opt.Text = "Vine Options";
            t.Text = t.Name = "Top";
            n.Text = n.Name = "North";
            s.Text = s.Name = "South";
            e.Text = e.Name = "East";
            w.Text = w.Name = "West";

            t.CheckedChanged += new EventHandler(vine_CheckedChanged);
            n.CheckedChanged += new EventHandler(vine_CheckedChanged);
            s.CheckedChanged += new EventHandler(vine_CheckedChanged);
            e.CheckedChanged += new EventHandler(vine_CheckedChanged);
            w.CheckedChanged += new EventHandler(vine_CheckedChanged);

            Controls.AddRange(new Control[] { opt, t, n, s, e, w });

            // Set Locations
            opt.Location = new Point(12, 9);
            t.Location = new Point(15, 27);
            n.Location = new Point(125, 27);
            s.Location = new Point(235, 27);
            e.Location = new Point(15, 50);
            w.Location = new Point(125, 50);
            btnData.Location = new Point(15, 96);

            t.Checked = true;

            ShowDialog();

            if (t.Checked)
                toRet = 0;

            if (n.Checked)
                toRet += 4;

            if (s.Checked)
                toRet += 1;

            if (e.Checked)
                toRet += 8;

            if (w.Checked)
                toRet += 2;

            return toRet;

        }

        private void vine_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox temp = ((CheckBox)sender);

            if (temp.Name == "Top" && temp.Checked)
            {
                foreach (object chg in Controls)
                {
                    if (chg.GetType() == temp.GetType() &&
                        chg != sender)
                        ((CheckBox)chg).Checked = false;

                }
            }

            else if (temp.Name != "Top" && temp.Checked == true)
            {
                CheckBox tp = ((CheckBox)Controls.Find("Top", true)[0]);
                tp.Checked = false;

            }
        }

        private TileEntityMobSpawner makeSpawner()
        {
            TileEntityMobSpawner toRet = new TileEntityMobSpawner();
            ComboBox ort = new ComboBox();
            Label opt = new Label();

            Size = new Size(200, 120);

            // Set Item Text
            opt.Text = "Spawner Options";
            ort.Items.AddRange(new object[]{ "Creeper",
                                     "Skeleton",
                                     "Spider",
                                     "Giant",
                                     "Zombie",
                                     "Slime",
                                     "Ghast",
                                     "PigZombie",
                                     "Enderman",
                                     "CaveSpider",
                                     "Silverfish",
                                     "Blaze",
                                     "LavaSlime",
                                     "EnderDragon",
                                     "Whither" });

            Controls.AddRange(new Control[] { opt, ort });

            // Set Locations
            opt.Location = new Point(12, 9);
            ort.Location = new Point(15, 29);
            btnData.Location = new Point(15, 55);

            ort.SelectedIndex = 0;

            ShowDialog();

            toRet.EntityID = ((String)ort.SelectedItem);

            return toRet;

        }
    }
}
