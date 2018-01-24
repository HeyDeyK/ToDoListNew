using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var dbConnection = App.Database;

            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
            TodoItem item2 = new TodoItem();
            item.Notes = "Dodělat tenhle ukol";
            item2.Notes = "Koupit perník";
            App.Database.SaveItemAsync(item);
            App.Database.SaveItemAsync(item2);
            


            var itemsFromDb = App.Database.GetItemsAsync().Result;

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDb.Count);
            foreach (TodoItem todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");


            ItemsCount.Text = "Items in Database " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }
    }
}
