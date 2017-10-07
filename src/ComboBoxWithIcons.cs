using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreativeModePlus
{
    public class ComboBoxWithIcons : ComboBox
    {
        public ComboBoxWithIcons()
         : base()
        {
            ;

        }

        public void Add(String text, Image icon, int ID)
        {
            Items.Add(new ComboBoxItem(text, icon, ID));

        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index > -1)
            {
                ComboBoxItem itm = ((ComboBoxItem)Items[e.Index]);
                int x = e.Bounds.Left + (16 - itm.Img.Width) / 2,
                    y = (15 - itm.Img.Height) / 2,
                    w = itm.Img.Width,
                    h = itm.Img.Height;

                x = (x > 0) ? x : 0;
                y = ((y > 0) ? y : 0) + e.Bounds.Top;
                w = (w > 15) ? 15 : w;
                h = (h > 15) ? 15 : h;

                e.Graphics.DrawImage(itm.Img,
                                      new Rectangle(x, y, w, h),
                                      new Rectangle(0, 0, itm.Img.Width, itm.Img.Height),
                                      GraphicsUnit.Pixel);
                e.Graphics.DrawString(itm.Text,
                                       e.Font,
                                       new SolidBrush(e.ForeColor),
                                       x + w,
                                       e.Bounds.Top + 2);

            }

            base.OnDrawItem(e);

        }
    }
}
