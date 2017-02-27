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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMainItem();
            ShowItemOne();
            ShowItemTwo();
            ShowJoke();
        }

            private void ShowMainItem()
            {
                SqlConnection conn = new SqlConnection(dbconn.Configuration());
                SqlCommand cmd = null;
                SqlDataReader rdr = null;

                string sqlsel = "select headline, category, picture, description from selection, item where fk_mainitem = item.id";

                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sqlsel, conn);

                    rdr = cmd.ExecuteReader();
                    RepeaterMainItem.DataSource = rdr;
                    RepeaterMainItem.DataBind();
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

            private void ShowItemOne()
            {
                SqlConnection conn = new SqlConnection(dbconn.Configuration());
                SqlCommand cmd = null;
                SqlDataReader rdr = null;

                string sqlsel = "select headline, category, picture, description from selection, item where fk_item1 = item.id";

                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sqlsel, conn);

                    rdr = cmd.ExecuteReader();
                    RepeaterItem1.DataSource = rdr;
                    RepeaterItem1.DataBind();
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

            private void ShowItemTwo()
            {
                SqlConnection conn = new SqlConnection(dbconn.Configuration());
                SqlCommand cmd = null;
                SqlDataReader rdr = null;

                string sqlsel = "select headline, category, picture, description from selection, item where fk_item2 = item.id";

                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sqlsel, conn);

                    rdr = cmd.ExecuteReader();
                    RepeaterItem2.DataSource = rdr;
                    RepeaterItem2.DataBind();
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

            private void ShowJoke()
            {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            string sqlsel = "select caption, picture from selection, joke where fk_joke = joke.id";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);

                rdr = cmd.ExecuteReader();
                RepeaterJoke.DataSource = rdr;
                RepeaterJoke.DataBind();
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