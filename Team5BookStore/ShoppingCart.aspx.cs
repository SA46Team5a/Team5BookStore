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
        string username = "LeTawn55";

        void Page_PreInit(Object sender, EventArgs e)
        {
            this.MasterPageFile = "~/AllUsers.Master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //List<CartItem> cartItemList = CartItemModel.GetCartItems("Madele68");
            //BookStoreEntities model = new BookStoreEntities();
            BindGrid();
            //GridView1.DataSource = cartItemList;
            //GridView1.DataBind();

            //int minValue = 1;
            
            //if (Int32.Parse(TextBox2.Text) > maxValue)
            {

            }

            RangeValidator1.MaximumValue = Convert.ToString(maxValue);

            TotalAmountLabel.Text = string.Format("{0:C}", TotalPrice(CartItemModel.GetCartItems(username)));
         }

        private void BindGrid()
        {
            List<CartItem> cartItemList = CartItemModel.GetCartItems(username);
            GridView1.DataSource = cartItemList;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //some method to update cart quantity;
            //compute amount = price * quantity;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Label1.Text = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]).ToString();
            int cartItemId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            CartItemModel.RemoveFromCart(cartItemId);
            BindGrid();
            
        }

        protected decimal? TotalPrice(List<CartItem> cartItemList)
        {
            decimal? sum = 0;
            foreach(CartItem ci in cartItemList)
            {
                sum += ci.TotalPrice; 
            }
            return sum;
        }

        protected void CheckOutButton_Click(object sender, EventArgs e)
        {
            //CartModel.CheckOutCart(username);
            //Response.Redirect("~/Receipt.aspx");
        }

        //    protected void TextBox1_TextChanged(object sender, EventArgs e)
        //    {
        //        TextBox thisTextBox = (TextBox)sender;
        //        GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
        //        int row = thisGridViewRow.RowIndex;
        //        //rowChanged[row] = true;

        //        Button1.Text= ((TextBox)sender).Text;
        //    }

        //    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //    {
        //        GridViewRow thisGridViewRow = (GridViewRow)sender;
        //        int row = thisGridViewRow.RowIndex;
        //        Button1.Text = row.ToString();
        //    }
    }
}