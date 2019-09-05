using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace _4_9_Task3
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connStr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            byte[] imgData = FileUpload1.FileBytes;
            Session["img"] = imgData;
            SqlCommand cmd = new SqlCommand("Insert into Product(ProductName,Price,ProductImage,Description) values(@ProductName,@Price,@ProductImage,@Description)", con);
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@ProductImage", imgData);
            cmd.Parameters.AddWithValue("@Description", txtDesc.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("ShowImg.aspx");
            con.Close();
        }
    }
}