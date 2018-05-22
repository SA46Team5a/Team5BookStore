using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team5BookStore.Models;

namespace Team5BookStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        int maxValue = 10;

        void Page_PreInit(Object sender, EventArgs e)
        {
            this.MasterPageFile = "~/AllUsers.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BookStoreEntities model = new BookStoreEntities();

            GridView1.DataSource = model.CartItems.ToList<CartItem>();
            GridView1.DataBind();

            //int minValue = 1;
            
            //if (Int32.Parse(TextBox2.Text) > maxValue)
            {

            }

            RangeValidator1.MaximumValue = Convert.ToString(maxValue);
         }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //some method to update cart quantity;
            //compute amount = price * quantity;
        }
        
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
            int row = thisGridViewRow.RowIndex;
            //rowChanged[row] = true;

            Button1.Text= ((TextBox)sender).Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow thisGridViewRow = (GridViewRow)sender;
            int row = thisGridViewRow.RowIndex;
            Button1.Text = row.ToString();
        }
    }
}