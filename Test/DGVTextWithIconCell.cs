﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Test
{
    class DGVTextWithIconCell : DataGridViewImageCell
    {
        static Image emptyImage;
        static DGVTextWithIconCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DGVTextWithIconCell()
        {
            this.ValueType = typeof(int);
        }

        protected override object GetFormattedValue(object value,
            int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }

        protected override void Paint(System.Drawing.Graphics g,
                   System.Drawing.Rectangle clipBounds,
                   System.Drawing.Rectangle cellBounds,
                   int rowIndex,
                   DataGridViewElementStates cellState,
                   object value, object formattedValue,
                   string errorText,
                   DataGridViewCellStyle cellStyle,
                   DataGridViewAdvancedBorderStyle advancedBorderStyle,
                   DataGridViewPaintParts paintParts)
        {
            bool hideIcon = false;
            string text = "";
            try
            {
                text = value.ToString();
                if (text.IndexOf("*") > 0)
                {
                    text.Remove(text.IndexOf("*"));
                    hideIcon = true;
                }
            }
            catch { }

            Brush backColorBrush = new SolidBrush(Color.Black);
            Brush foreColorBrush = new SolidBrush(Color.Black);

            // Рисование рамки ячейки
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            float posX = cellBounds.X;
            float posY = cellBounds.Y;

            float textWidth = TextRenderer.MeasureText(text, cellStyle.Font).Width;
            float textHeight = TextRenderer.MeasureText(text, cellStyle.Font).Height;

            // Положение текста в зависимости от выравнивания в ячейке
            posX = cellBounds.X;
            posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;

            double WidthElemCell = (cellBounds.Width - 5) / (double)cellBounds.Width;

            if (hideIcon)
            {
                Icon icon = SetIcon(Properties.Resources.hide_show, cellBounds);
                g.DrawString(text, cellStyle.Font, foreColorBrush, posX + 30, posY - 5);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
                return;
            }
            else
            {
                g.DrawString(text, cellStyle.Font, foreColorBrush, posX + 30, posY - 5);
            }

            /*if (progressVal == -1)
            {
                Icon icon = SetIcon(Properties.Resources.play, cellBounds);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
                return;
            }

            if (percentage == 0)
            {
                Icon icon = SetIcon(Properties.Resources.stop, cellBounds);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
            }

            if (percentage > 0.0 && percentage < 1)
            {
                Icon icon = SetIcon(Properties.Resources.stop, cellBounds);
                if (pauseMod)
                {
                    icon = SetIcon(Properties.Resources.play, cellBounds);
                }
                g.Clear(Color.White);
                base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
                int width = Convert.ToInt32((percentage * cellBounds.Width * WidthElemCell)) - 30;
                int height = 1;
                g.FillRectangle(new SolidBrush(Color.Blue), cellBounds.X + 30, cellBounds.Y + cellBounds.Height / 3 * 2, width, height);
                g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, posX + 30, posY - 5);
            }
        }*/
        }

        public override object Clone()
        {
            DGVTextWithIconCell dataGridViewCell = base.Clone() as DGVTextWithIconCell;
            return dataGridViewCell;
        }

        private Icon SetIcon(Bitmap bitmap, System.Drawing.Rectangle cellBounds)
        {
            System.IntPtr icH = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(icH);
            return icon;
        }
    }
}
