using System;
using System.Drawing;
using System.Windows.Forms;

namespace SM64MidiCompanion.Components
{
    public class TrackListBox : CheckedListBox
    {

        Image checkedBox, unCheckedBox;

        float x, y;

        public TrackListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            base.ItemHeight = 200;
            checkedBox = (Image)(Properties.Resources.ResourceManager.GetObject("CheckedBox"));
            unCheckedBox = (Image)(Properties.Resources.ResourceManager.GetObject("UnCheckedBox"));
            CheckOnClick = true;
        }

        public override int ItemHeight
        {
            get
            {
                return 36;
            }
            set
            {
                base.ItemHeight = value;
            }
        }

        Brush brush = new SolidBrush(Color.White);

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Image image;
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;


            e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 100, e.Bounds.Height);


            if (e.Index >= 0)
            {

                if (!CheckedIndices.Contains(e.Index))
                {
                    image = unCheckedBox;

                } else {
                    image = checkedBox;
                }

                e.Graphics.DrawImage(image, 2, e.Bounds.Y + 2, 32, 32);
                
                var textRect = e.Bounds;
                textRect.X += 32;
                textRect.Width += 32;
                string itemText = Items[e.Index].ToString();
                TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, Color.Black, flags);
                
            }
        }

        protected override bool AllowSelection => false;


        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            Point mousePos = FindForm().PointToClient(MousePosition);

            if (mousePos.X <= Location.X ||  mousePos.X > Location.X + 36)
            {
                ice.NewValue = ice.CurrentValue;
            }

        }

    }
}
