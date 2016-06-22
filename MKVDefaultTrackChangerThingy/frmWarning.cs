using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKVDefaultTrackChangerThingy
{
    public partial class frmWarning : Form
    {
        #region init

        public frmWarning()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);     // Set form icon to one in program's exe
        }

        public frmWarning(string warning)
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);     // Set form icon to one in program's exe

            lblWarning.Text = warning;          // Set the main form's message label to the string supplied to constructor
        }

        #endregion init

        #region events

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;            // Send OK.
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;        // Send Cancel
        }

        #endregion events
    }
}
