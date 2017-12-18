using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msg.Text = "";
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        if (txtOldPass.Text != "" && txtNewPass.Text != "" && txtOldPass.Text != "")
        {
            if (txtNewPass.Text == txtConfirmPass.Text)
            {
                clsUser obj = new clsUser();
                obj.UserID = Request.Cookies["UserID"].Value;
                obj.Password = txtOldPass.Text;
                obj.UserType = Convert.ToInt32(Response.Cookies["UserType"].Value);
                obj.Op = 9;
                DataTable dt = obj.UserMaster(obj).Tables[0];
                if(dt.Rows.Count>0)
                {
                    obj.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    obj.Password = txtNewPass.Text;
                    obj.Op = 10;
                    obj.UserMaster(obj);
                    msg.Text = "<script type='text/javascript'>alert('Password Changed');</script>";
                }
                else
                {
                    msg.Text = "<script type='text/javascript'>alert('Wrong Old Password');</script>";
                }
            }
            else
            {
                msg.Text = "<script type='text/javascript'>alert('New password and confirm passwords are not matching');</script>";
            }
        }
        else 
        {
            msg.Text = "<script type='text/javascript'>alert('Fields cannot be empty');</script>";
        }
    }
}