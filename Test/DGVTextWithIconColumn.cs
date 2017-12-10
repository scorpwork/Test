using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Test
{
    public class DGVTextWithIconColumn : DataGridViewImageColumn
    {
        public DGVTextWithIconColumn()
        {
            CellTemplate = new DGVTextWithIconCell(); ;
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
                    !value.GetType().IsAssignableFrom(typeof(DGVTextWithIconCell)))
                {
                    throw new InvalidCastException("Ошибка");
                }
                base.CellTemplate = value;
            }
        }

        private DGVTextWithIconCell ProgressBarCellTemplate
        {
            get
            {
                return (DGVTextWithIconCell)this.CellTemplate;
            }
        }
    }
}
