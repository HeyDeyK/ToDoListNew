using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemPage : ContentPage
	{
		public ItemPage ()
		{
			InitializeComponent ();
		}
        private void Save(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            if(todoItem.Done == true)
            {
                todoItem.Obrazek = "check.png";
            }
            else
            {
                todoItem.Obrazek = "none.png";
            }
            App.Database.SaveItemAsync(todoItem);
            Navigation.PopModalAsync();
        }

    }
}