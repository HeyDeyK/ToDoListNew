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
	public partial class AddItem : ContentPage
	{
		public AddItem ()
		{
			InitializeComponent ();
		}
        private void Save(object sender, EventArgs e)
        {
            TodoItem item = new TodoItem();
            item.Notes = eNotes.Text;
            item.Obrazek = "none.png";
            item.Done = false;
            App.Database.SaveItemAsync(item);
            Navigation.PopModalAsync();
        }
    }
}