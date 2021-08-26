using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace howto_point_in_polygon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The polygon's points.
        Point[] Points = 
        {
            new Point(133,  14),
            new Point( 44, 228),
            new Point(255,  83),
            new Point( 16,  74),
            new Point(214, 246),
        };

        // Draw the polygon.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, Points);
            e.Graphics.DrawPolygon(Pens.Red, Points);
        }

        // Set the cursor depending on whether the mouse is over the polygon.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor new_cursor;
            if (PointIsInPolygon(Points, e.Location)){
                 MessageBox.Show("The point is inside the polygon", "Inside",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                new_cursor = Cursors.Cross;
            }
            else {
                 MessageBox.Show("The point is outside the polygon", "Outside",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                new_cursor = Cursors.Default;
                }
            // Update the cursor.
            if (this.Cursor != new_cursor) this.Cursor = new_cursor;
        }

        // Return true if the point is inside the polygon.
        private bool PointIsInPolygon(Point[] polygon, Point target_point)
        {
            // Make a GraphicsPath containing the polygon.
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygon);

            // See if the point is inside the path.
            return path.IsVisible(target_point);            
        }
    }
}
