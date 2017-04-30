using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;


namespace SkyDiveCuautla
{
    public class MyDataGridView : DataGridView
    {

        private Image m_Image;

        public MyDataGridView()
        {
            m_Image = Image.FromFile("C:\\SkyDiveCuautla\\datagridview_bg");

        }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
 	        base.PaintBackground(graphics, clipBounds, gridBounds);
        }

        public Image backimage
        {
           get
             { 
               return m_Image;
             }
           set
             { 
               m_Image = value;
             }
        } 

    }
}
