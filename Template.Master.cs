using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace cmsProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowLogo();
            ShowName();
            ShowTelephone();
        }

        private void ShowLogo()
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            string sqlsel = "select logo from company";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterLogo.DataSource = rdr;
                RepeaterLogo.DataBind();
            }
            catch (Exception ex)
            {
                //LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        private void ShowName()
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            string sqlsel = "select name from company";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterName.DataSource = rdr;
                RepeaterName.DataBind();
            }
            catch (Exception ex)
            {
                //LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        private void ShowTelephone()
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            string sqlsel = "select telephone from company";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterTelephone.DataSource = rdr;
                RepeaterTelephone.DataBind();
            }
            catch (Exception ex)
            {
                //LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}