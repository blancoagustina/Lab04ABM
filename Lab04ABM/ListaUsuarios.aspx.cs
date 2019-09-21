using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] dias = new int[31];
        for (int i = 1; i < dias.Length; i++)
        {
            dias[i - 1] = i;
        }
        this.drpFechaNacDia.DataSource = dias;
    }

   
}