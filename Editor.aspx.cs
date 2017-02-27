using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace cmsProject
{
    public partial class Editor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateItems();
            UpdateJokes();
            UpdateCompanyData();
        }

        public void UpdateItems()
        {

            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select id, headline, description, category, picture from item";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewItems.DataSource = rdr;
                GridViewItems.DataBind();

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxId.Text = GridViewItems.SelectedRow.Cells[1].Text;
            TextBoxHeadline.Text = GridViewItems.SelectedRow.Cells[2].Text;
            TextBoxDescription.Text = GridViewItems.SelectedRow.Cells[3].Text;
            TextBoxCategory.Text = GridViewItems.SelectedRow.Cells[4].Text;

            GridViewItems.SelectedRowStyle.BackColor = System.Drawing.Color.LightGray;
            ButtonCreate.Enabled = false;
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from item";
            string sqlins = "insert into item values (@headline, @category, @picture, @description)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "newItem");
                dt = ds.Tables["newItem"];

                string filename = string.Empty;
                filename = Path.GetFileName(fileUploadItem.PostedFile.FileName);
                fileUploadItem.PostedFile.SaveAs(Server.MapPath("~/pictures/" + filename));

                DataRow newrow = dt.NewRow();
                newrow["headline"] = TextBoxHeadline.Text;
                newrow["category"] = TextBoxCategory.Text;
                newrow["picture"] = fileUploadItem.FileName;
                newrow["description"] = TextBoxDescription.Text;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@headline", SqlDbType.Text, 200, "headline");
                cmd.Parameters.Add("@category", SqlDbType.Text, 200, "category");
                cmd.Parameters.Add("@picture", SqlDbType.Text, 200, "picture");
                cmd.Parameters.Add("@description", SqlDbType.Text, 2000, "description");

                da.InsertCommand = cmd;
                da.Update(ds, "newItem");
                LabelMessage.Text = "Item has been added";

                UpdateItems();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from item";
            string sqlupd = "update item set headline = @headline, category = @category, picture = @picture, description = @description where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "item");
                dt = ds.Tables["item"];
              
                int mytableindex = GridViewItems.SelectedIndex;
                dt.Rows[mytableindex]["headline"] = TextBoxHeadline.Text;
                dt.Rows[mytableindex]["category"] = TextBoxCategory.Text;
                if (fileUploadItem.HasFile == true && fileUploadItem.PostedFile.ContentLength > 0)
                {
                    string filename = string.Empty;
                    filename = Path.GetFileName(fileUploadItem.PostedFile.FileName);
                    fileUploadItem.PostedFile.SaveAs(Server.MapPath("~/pictures/" + filename));

                    dt.Rows[mytableindex]["picture"] = fileUploadItem.FileName;
                }
                dt.Rows[mytableindex]["description"] = TextBoxDescription.Text;

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@headline", SqlDbType.Text, 200, "headline");
                cmd.Parameters.Add("@category", SqlDbType.Text, 200, "category");
                cmd.Parameters.Add("@picture", SqlDbType.Text, 200, "picture");
                cmd.Parameters.Add("@description", SqlDbType.Text, 2000, "description");
                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "item");
                LabelMessage.Text = "Item has been updated";

                UpdateItems();

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from item";
            string sqldel = "delete from item where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "item");
                dt = ds.Tables["item"];

                int mytableindex = GridViewItems.SelectedIndex;
                dt.Rows[mytableindex]["id"] = Convert.ToInt32(GridViewItems.SelectedRow.Cells[1].Text);

                cmd = new SqlCommand(sqldel, conn);
                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "item");

                LabelMessage.Text = TextBoxHeadline.Text + " has been deleted";

                UpdateItems();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            TextBoxId.Text = "";
            TextBoxHeadline.Text = "";
            TextBoxDescription.Text = "";
            TextBoxCategory.Text = "";
            ButtonCreate.Enabled = true;

        }

        protected void ButtonMainItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;

            string sqlupd = "update selection set fk_mainitem = @id";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = Convert.ToInt32(GridViewItems.SelectedRow.Cells[1].Text);
                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Item has been inserted";

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonItemOne_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;

            string sqlupd = "update selection set fk_item1 = @id";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = Convert.ToInt32(GridViewItems.SelectedRow.Cells[1].Text);
                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Item has been inserted";

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonItemTwo_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;

            string sqlupd = "update selection set fk_item2 = @id";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = Convert.ToInt32(GridViewItems.SelectedRow.Cells[1].Text);
                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Item has been inserted";

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        /* --------------- Jokes --------------------------------------*/
        public void UpdateJokes()
        {

            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from joke";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewJokes.DataSource = rdr;
                GridViewJokes.DataBind();

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridViewJokes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxJokeId.Text = GridViewJokes.SelectedRow.Cells[1].Text;
            TextBoxCaption.Text = GridViewJokes.SelectedRow.Cells[2].Text;

            GridViewJokes.SelectedRowStyle.BackColor = System.Drawing.Color.LightGray;
            ButtonCreateJoke.Enabled = false;

        }

        protected void ButtonCancelJoke_Click(object sender, EventArgs e)
        {
            TextBoxJokeId.Text = "";
            TextBoxCaption.Text = "";
            ButtonCreateJoke.Enabled = true;

        }

        protected void ButtonInsertJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;

            string sqlupd = "update selection set fk_joke = @id";

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = Convert.ToInt32(GridViewJokes.SelectedRow.Cells[1].Text);
                cmd.ExecuteNonQuery();
                LabelJokeMessageBottom.Text = "Joke has been inserted";

            }
            catch (Exception ex)
            {
                LabelJokeMessageBottom.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonCreateJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from joke";
            string sqlins = "insert into joke values (@caption, @picture)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "newJoke");
                dt = ds.Tables["newJoke"];

                string filename = string.Empty;
                filename = Path.GetFileName(fileUploadJoke.PostedFile.FileName);
                fileUploadJoke.PostedFile.SaveAs(Server.MapPath("~/jokes/" + filename));

                DataRow newrow = dt.NewRow();
                newrow["caption"] = TextBoxCaption.Text;
                newrow["picture"] = fileUploadJoke.FileName;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@caption", SqlDbType.Text, 200, "caption");
                cmd.Parameters.Add("@picture", SqlDbType.Text, 200, "picture");

                da.InsertCommand = cmd;
                da.Update(ds, "newJoke");
                LabelJokeMessage.Text = "Joke has been added";

                UpdateJokes();
            }
            catch (Exception ex)
            {
                LabelJokeMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonUpdateJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from joke";
            string sqlupd = "update joke set caption = @caption, picture = @picture where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "joke");
                dt = ds.Tables["joke"];

                int mytableindex = GridViewJokes.SelectedIndex;
                dt.Rows[mytableindex]["caption"] = TextBoxCaption.Text;
                if (fileUploadJoke.HasFile == true && fileUploadJoke.PostedFile.ContentLength > 0)
                {
                    string filename = string.Empty;
                    filename = Path.GetFileName(fileUploadJoke.PostedFile.FileName);
                    fileUploadJoke.PostedFile.SaveAs(Server.MapPath("~/jokes/" + filename));

                    dt.Rows[mytableindex]["picture"] = fileUploadJoke.FileName;
                }

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@caption", SqlDbType.Text, 200, "caption");
                cmd.Parameters.Add("@picture", SqlDbType.Text, 200, "picture");

                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "joke");
                LabelMessage.Text = "Joke has been updated";

                UpdateJokes();

            }
            catch (Exception ex)
            {
                LabelJokeMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonDeleteJoke_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from joke";
            string sqldel = "delete from joke where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "joke");
                dt = ds.Tables["joke"];

                int mytableindex = GridViewJokes.SelectedIndex;
                dt.Rows[mytableindex]["id"] = Convert.ToInt32(GridViewJokes.SelectedRow.Cells[1].Text);

                cmd = new SqlCommand(sqldel, conn);
                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "joke");

                LabelJokeMessage.Text = TextBoxCaption.Text + " has been deleted";

                UpdateJokes();
            }
            catch (Exception ex)
            {
                LabelJokeMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        /* Company */
        public void UpdateCompanyData()
        {

            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "select * from company";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewCompany.DataSource = rdr;
                GridViewCompany.DataBind();

            }
            catch (Exception ex)
            {
                LabelCompanyMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridViewCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCompanyId.Text = GridViewCompany.SelectedRow.Cells[1].Text;
            TextBoxCompanyName.Text = GridViewCompany.SelectedRow.Cells[2].Text;
            TextBoxCompanyTelephone.Text = GridViewCompany.SelectedRow.Cells[4].Text;

            GridViewCompany.SelectedRowStyle.BackColor = System.Drawing.Color.LightGray;
            ButtonCompanyCreate.Enabled = false;

        }

        protected void ButtonCompanyCancel_Click(object sender, EventArgs e)
        {
            TextBoxCompanyId.Text = "";
            TextBoxCompanyName.Text = "";
            TextBoxCompanyTelephone.Text = "";
            ButtonCompanyCreate.Enabled = true;

        }

        protected void ButtonCompanyCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from company";
            string sqlins = "insert into company values (@name, @logo, @telephone)";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "newCompany");
                dt = ds.Tables["newCompany"];

                string filename = string.Empty;
                filename = Path.GetFileName(fileUploadLogo.PostedFile.FileName);
                fileUploadLogo.PostedFile.SaveAs(Server.MapPath("~/logo/" + filename));

                DataRow newrow = dt.NewRow();
                newrow["name"] = TextBoxCompanyName.Text;
                newrow["logo"] = fileUploadLogo.FileName;
                newrow["telephone"] = TextBoxCompanyTelephone.Text;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@name", SqlDbType.Text, 200, "name");
                cmd.Parameters.Add("@logo", SqlDbType.Text, 200, "logo");
                cmd.Parameters.Add("@telephone", SqlDbType.Text, 200, "telephone");

                da.InsertCommand = cmd;
                da.Update(ds, "newCompany");
                LabelCompanyMessage.Text = "Company has been added";

                UpdateCompanyData();
            }
            catch (Exception ex)
            {
                LabelCompanyMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonCompanyUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from company";
            string sqlupd = "update company set name = @name, logo = @logo, telephone = @telephone where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "company");
                dt = ds.Tables["company"];

                int mytableindex = GridViewCompany.SelectedIndex;
                dt.Rows[mytableindex]["name"] = TextBoxCompanyName.Text;
                if (fileUploadLogo.HasFile == true && fileUploadLogo.PostedFile.ContentLength > 0)
                {
                    string filename = string.Empty;
                    filename = Path.GetFileName(fileUploadLogo.PostedFile.FileName);
                    fileUploadLogo.PostedFile.SaveAs(Server.MapPath("~/logo/" + filename));

                    dt.Rows[mytableindex]["logo"] = fileUploadLogo.FileName;
                }
                dt.Rows[mytableindex]["telephone"] = TextBoxCompanyTelephone.Text;

                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@name", SqlDbType.Text, 200, "name");
                cmd.Parameters.Add("@logo", SqlDbType.Text, 200, "logo");
                cmd.Parameters.Add("@telephone", SqlDbType.Text, 20, "telephone");

                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "company");
                LabelCompanyMessage.Text = "Company has been updated";

                UpdateCompanyData();

            }
            catch (Exception ex)
            {
                LabelCompanyMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ButtonCompanyDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(dbconn.Configuration());
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
            SqlCommand cmd = null;
            string sqlsel = "select * from company";
            string sqldel = "delete from company where id = @id";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "company");
                dt = ds.Tables["company"];

                int mytableindex = GridViewCompany.SelectedIndex;
                dt.Rows[mytableindex]["id"] = Convert.ToInt32(GridViewCompany.SelectedRow.Cells[1].Text);

                cmd = new SqlCommand(sqldel, conn);
                SqlParameter parm = cmd.Parameters.Add("@id", SqlDbType.Int, 4, "id");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "company");

                LabelCompanyMessage.Text = TextBoxCompanyName.Text + " has been deleted";

                UpdateCompanyData();
            }
            catch (Exception ex)
            {
                LabelCompanyMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}