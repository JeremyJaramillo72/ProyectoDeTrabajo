using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    internal class Diseño
    {
         public void AplicarBordeRedondo(PictureBox pictureBox)
        {
            if (pictureBox.Image == null) return;

            int tamaño = Math.Min(pictureBox.Width, pictureBox.Height);
            Bitmap imagenCircular = new Bitmap(tamaño, tamaño);

            using (Graphics g = Graphics.FromImage(imagenCircular))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Crear un círculo perfecto con margen corregido
                int margen = 2; // Ajusta el margen para evitar imperfecciones en el borde
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(margen, margen, tamaño - margen * 2, tamaño - margen * 2);
                    g.SetClip(path);
                    g.DrawImage(pictureBox.Image, margen, margen, tamaño - margen * 2, tamaño - margen * 2);
                }

                // Dibujar borde blanco fino
                int grosorBorde = 2;
                using (Pen bordeBlanco = new Pen(Color.White, grosorBorde))
                {
                    g.DrawEllipse(bordeBlanco, margen, margen, tamaño - margen * 2, tamaño - margen * 2);
                }
            }

            pictureBox.Image = imagenCircular;
        }
        public void RedondearPaneles(Panel panel1, PaintEventArgs e)
        {
            

            int borderRadius = 20;
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = panel1.ClientRectangle;
            int diameter = borderRadius * 2;

            path.StartFigure();
            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel1.Region = new Region(path);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(new SolidBrush(panel1.BackColor), path);
        }
    }
}
