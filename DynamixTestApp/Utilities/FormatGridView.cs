using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamixTestApp.Utilities
{
  public static  class FormatGridView
    {
        public static void ChangeGridProperties(DataGridView dgvMaster)
        {

            dgvMaster.ColumnHeadersHeight = 30;

            dgvMaster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMaster.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

            DataGridViewCellStyle style = dgvMaster.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.FromArgb(231, 235, 238);
            style.ForeColor = Color.FromArgb(115, 117, 119);
            style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvMaster.EnableHeadersVisualStyles = false;

            dgvMaster.BackgroundColor = Color.White;
            dgvMaster.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvMaster.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMaster.BorderStyle = BorderStyle.Fixed3D;

            dgvMaster.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dgvMaster.RowTemplate.Height = 30;
            dgvMaster.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvMaster.DefaultCellStyle.ForeColor = Color.FromArgb(115, 117, 119);



            dgvMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvMaster.MultiSelect = false;
            dgvMaster.RowHeadersWidth = 10;
            dgvMaster.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMaster.RowHeadersVisible = false;
            dgvMaster.RowTemplate.DefaultCellStyle.Padding = new Padding(5, 0, 10, 0);

            foreach (DataGridViewColumn c in dgvMaster.Columns)
            {
                c.Resizable = DataGridViewTriState.False;
                c.ReadOnly = true;
            }

            dgvMaster.AllowUserToOrderColumns = true;
            dgvMaster.BackgroundColor = SystemColors.Control;
            dgvMaster.BorderStyle = BorderStyle.Fixed3D;
            //dgvMaster.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMaster.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);

        }

    }
}
