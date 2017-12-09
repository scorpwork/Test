using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public class DGMusicProgressColumn : DataGridViewImageColumn
    {
        public DGMusicProgressColumn()
        {
            CellTemplate = new DGMusicProgressCell(); ;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DGMusicProgressCell)))
                {
                    throw new InvalidCastException("Ошибка");
                }
                base.CellTemplate = value;
            }
        }

        private DGMusicProgressCell ProgressBarCellTemplate
        {
            get
            {
                return (DGMusicProgressCell)this.CellTemplate;
            }
        }
    }
}
