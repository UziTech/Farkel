using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farkel
{
    public partial class Help : Form
    {
        #region Global Variables
        bool _mouseDown = false;
        int _mouseDownY = 0;
        #endregion
        public Help()
        {
            InitializeComponent();
            label1.Cursor = new Cursor(GetType(),"Grab.cur");
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Top -= (e.NewValue - e.OldValue);
        }
        private void HMouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _mouseDownY = e.Y;
            label1.Cursor = new Cursor(GetType(), "Grabbing.cur");
        }
        private void HMouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                ScrollEventArgs ev = new ScrollEventArgs(ScrollEventType.ThumbPosition, vScrollBar1.Value, (vScrollBar1.Value - (e.Y - _mouseDownY) > vScrollBar1.Maximum - vScrollBar1.LargeChange + 1) ? vScrollBar1.Maximum - vScrollBar1.LargeChange + 1 : (vScrollBar1.Value - (e.Y - _mouseDownY) < vScrollBar1.Minimum) ? vScrollBar1.Minimum : vScrollBar1.Value + _mouseDownY - e.Y);
                vScrollBar1.Value = ev.NewValue;
                vScrollBar1_Scroll(sender, ev);
            }
        }
        private void HMouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            label1.Cursor = new Cursor(GetType(), "Grab.cur");
        }
        private void HMouseWheel(object sender, MouseEventArgs e)
        {
            ScrollEventArgs ev = new ScrollEventArgs(ScrollEventType.ThumbPosition, vScrollBar1.Value, (vScrollBar1.Value - e.Delta / 120 * vScrollBar1.SmallChange * 2 > vScrollBar1.Maximum - vScrollBar1.LargeChange + 1) ? vScrollBar1.Maximum - vScrollBar1.LargeChange + 1 : (vScrollBar1.Value - e.Delta / 120 * vScrollBar1.SmallChange * 2 < vScrollBar1.Minimum) ? vScrollBar1.Minimum : vScrollBar1.Value - e.Delta / 120 * vScrollBar1.SmallChange * 2);
            vScrollBar1.Value = ev.NewValue;
            vScrollBar1_Scroll(sender, ev);
        }
    }
}
