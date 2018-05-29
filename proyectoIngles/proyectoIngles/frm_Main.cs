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
using DevExpress.XtraEditors.Controls;

namespace proyectoIngles
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        DataAccess da = new DataAccess();
             
        public frm_Main()
        {
            InitializeComponent();
        }

        String[] getData(char tipo, int tiempo)
        {
            DataTable myDT = new DataTable();
            /*
             PARA TIPO 
             A = AFIRMATIVA
             N = NEGATIVA
             I = INTERROGATIVA

            PARA TIEMPO
            1 = PRESENTE
            2 = PASADO
            3 = FUTURO
            4 = PARTICIPIO
            5 = PASADO PERFECTO
            6 = PRESENTE PERFECTO
             */
            
            if (tiempo==1) {
                string query = "SELECT oracion FROM presente WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
            myDT =da.fillDataTable(query);
            }

            else if(tiempo == 2)
            {
                string query = "SELECT oracion FROM pasado WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
                myDT = da.fillDataTable(query);
            }
            else if (tiempo == 3)
            {
                string query = "SELECT oracion FROM futuro WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
                myDT = da.fillDataTable(query);
            }

            else if (tiempo== 4)
            {
                string query = "SELECT oracion FROM participio WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
                myDT = da.fillDataTable(query);
            }

            else if(tiempo == 5)
            {
                string query = "SELECT oracion FROM pasadoperfecto WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
                myDT = da.fillDataTable(query);
            }

            else if(tiempo== 6)
            {
                string query = "SELECT oracion FROM perfecto WHERE tipo = '{0}'";
                query = string.Format(query, tipo);
                myDT = da.fillDataTable(query);
            }
           
            string[] data = new string[myDT.Rows.Count];
            for(int i = 0; i < myDT.Rows.Count; i++)
            {
                data[i] = myDT.Rows[i]["oracion"].ToString();
            }
            return data;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            string[] miArraytoDisplay = new string[] { "PRESENTE","PASADO","FUTURO", "PARTICIPIO","PASADO PERFECTO","PRESENTE PERFECTO" };
            string[] miArrayType = new string[] { "AFIRMATIVA", "NEGATIVA", "INTERROGATIVA" };
            cmbTime.Properties.DataSource = miArraytoDisplay;
            cmbType.Properties.DataSource = miArrayType;            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string type = cmbType.EditValue.ToString();
            string time = cmbTime.EditValue.ToString();
            int tiempo = 0;
            char tipo='C';
            #region CONDICIONALES
            if (time == "PRESENTE")
            {
                tiempo = 1;
            }
            if (time == "PASADO")
            {
                tiempo = 2;
            }

            if (time == "FUTURO")
            {
                tiempo = 3;
            }

            if (time == "PARTICIPIO")
            {
                tiempo = 4;
            }
            if (time == "PASADO PERFECTO")
            {
                tiempo = 5;
            }
            if (time == "PRESENTE PERFECTO")
            {
                tiempo = 6;
            }

            if(type=="AFIRMATIVA")
            {
                tipo = 'A';
            }

            if (type == "NEGATIVA")
            {
                tipo = 'N';
            }

            if (type == "INTERROGATIVA")
            {
                tipo = 'I';
            }
            #endregion
            //ENVIAMOS A SOLICITAR LA DATA
            string[] arrayoraciones= getData(tipo, tiempo);
            int index= arrayoraciones.Count();
            Random rnd = new Random();
            int select= rnd.Next(1, index);
            lblOration.Text = arrayoraciones[select];
            

        }
    }
}