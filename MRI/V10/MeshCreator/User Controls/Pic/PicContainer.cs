using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MeshCreator
{
    public partial class PicContainer : UserControl
    {
        public PicContainer()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------
        public void DrawHoverCircle(Point p)
        {
            picExOriginal1.DrawHoverCircle(p);
            picExOverLay1.DrawHoverCircle(p);
            picExIntermediate1.DrawHoverCircle(p);
        }
        //---------------------------------------------------------------------------
        public void Init(References r)
        {
            picExOriginal1.Init(r);
            picExOverLay1.Init(r);
            picExIntermediate1.Init(r);
            picExFinal1.Init(r);
        }
        //---------------------------------------------------------------------------
        public void Reset()
        {
            picExFinal1.Reset();
            picExOverLay1.Reset();
            picExIntermediate1.Reset();
        }
        //---------------------------------------------------------------------------
        public picExOriginal PicOri
        {
            get { return picExOriginal1; }
        }
        //---------------------------------------------------------------------------
        public PicExOverLay PicOver
        {
            get { return picExOverLay1; }
        }
        //---------------------------------------------------------------------------
        public PicExIntermediate PicInter
        {
            get { return picExIntermediate1; }
        }
        //---------------------------------------------------------------------------
        public PicExFinal PicFinal
        {
            get { return picExFinal1; }
        }
    }
}
