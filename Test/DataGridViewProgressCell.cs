using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Test
{
    class DataGridViewProgressCell : DataGridViewImageCell
    {
        static Image emptyImage;

        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
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
            int progressVal = 0;
            try
            {
                if (Convert.ToInt16(value) == 0 || value == null)
                {
                    value = 0;
                }

                progressVal = Convert.ToInt32(value);
            }
            catch { }

            float percentage = ((float)progressVal / 100.0f);
            Brush backColorBrush = new SolidBrush(Color.Black);
            Brush foreColorBrush = new SolidBrush(Color.Black);

            // Рисование рамки ячейки
            base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            float posX = cellBounds.X;
            float posY = cellBounds.Y;

            float textWidth = TextRenderer.MeasureText(progressVal.ToString() + "%", cellStyle.Font).Width;
            float textHeight = TextRenderer.MeasureText(progressVal.ToString() + "%", cellStyle.Font).Height;

            // Положение текста в зависимости от выравнивания в ячейке
            switch (cellStyle.Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y + cellBounds.Height - textHeight;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2;
                    posY = cellBounds.Y;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    posX = cellBounds.X;
                    posY = cellBounds.Y;
                    break;

                case DataGridViewContentAlignment.TopRight:
                    posX = cellBounds.X + cellBounds.Width - textWidth;
                    posY = cellBounds.Y;
                    break;

            }

            double WidthElemCell = (cellBounds.Width - 5) / (double)cellBounds.Width; 

            if (percentage == 0)
            {
                Bitmap bitmap = Properties.Resources.download_sound;
                System.IntPtr icH = bitmap.GetHicon();
                Icon icon = Icon.FromHandle(icH);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
            }

            if (percentage > 0.0 && percentage < 1)
            {
                int cellBoundHeight = cellBounds.Height;
                Bitmap bitmap = Properties.Resources.downloading_sound;
                System.IntPtr icH = bitmap.GetHicon();
                Icon icon = Icon.FromHandle(icH);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBoundHeight / 3 );
                // Рисование прогресса
                int width = Convert.ToInt32((percentage * cellBounds.Width * WidthElemCell)) - 30;
                int height = 1;
                g.FillRectangle(new SolidBrush(Color.Blue), cellBounds.X + 30, cellBounds.Y + cellBoundHeight/3*2, width, height);
                // Рисование текста
                g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, posX+30, posY-5);
            }

            if (percentage == 1 || percentage < 0)
            {
                Bitmap bitmap = Properties.Resources.downloaded_sound;
                System.IntPtr icH = bitmap.GetHicon();
                Icon icon = Icon.FromHandle(icH);
                g.DrawIcon(icon, cellBounds.X, cellBounds.Y + cellBounds.Height / 3);
                g.DrawString("Файл загружен", cellStyle.Font, foreColorBrush, posX + 30, posY);
            }
        }

        public override object Clone()
        {
            DataGridViewProgressCell dataGridViewCell = base.Clone() as DataGridViewProgressCell;
            return dataGridViewCell;
        }
    }
}
