using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace proyectoIngles
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        DataAccess da = new DataAccess();
        public frm_Main()
        {
            InitializeComponent();
        }

        DataTable getData(char tipo, int tiempo)
        {
            /*
             
             */
            DataTable myDT = new DataTable();
            if (tiempo==0) {
            myDT=da.fillDataTable("SELECT * FROM presente");
            }

            return myDT;
        }
    }
}