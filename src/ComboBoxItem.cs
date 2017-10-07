using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CreativeModePlus
{
    public class ComboBoxItem
    {
        private String text = null;
        private Image img = null;
        private int id = -1;

        public String Text { get { return text; } }
        public Image Img { get { return img; } }
        public int ID { get { return id; } }

        public ComboBoxItem(String text, Image img, int id)
        {
            this.text = text;
            this.img = img;
            this.id = id;

        }
    }
}
