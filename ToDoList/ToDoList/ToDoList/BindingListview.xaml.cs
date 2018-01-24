using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingListview : ContentPage
    {
        public ObservableCollection<TodoItem> Persons { get; set; } = new ObservableCollection<TodoItem>();

        public ICommand SelectedItemCommand { get; set; }
        ObservableCollection<TodoItem> itemsFromDb;
        public BindingListview()
        {
            InitializeComponent();

            SelectedItemCommand = new Command<TodoItem>(SelectedItemCommandImplementation);

            CreateSampleData();
            this.BindingContext = this;
            

        }

        private void SelectedItemCommandImplementation(TodoItem person)
        {
            Console.WriteLine(person.Notes);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }
        private void CreateSampleData()
        {

            var dbConnection = App.Database;

            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
            TodoItem item2 = new TodoItem();
            item.Notes = "Dodělat tenhle ukol";
            item.Obrazek = "check.png";
            item2.Notes = "Koupit perník";
            item2.Obrazek = "none.png";
            /*App.Database.SaveItemAsync(item);
            App.Database.SaveItemAsync(item2);*/


            LoadData();
            
            /*foreach (TodoItem todoItem in itemsFromDb)
            {
               *string obrazek = "";
                if (todoItem.Obrazek == "check.png")
                {
                    obrazek = "check.png";
                }
                else
                {
                    obrazek = "none.png";
                }
                Console.WriteLine(todoItem.Notes);
                Persons.Add(new TodoItem() { Notes = "haha", Obrazek = "none.png" });
            }*/
            
            
            
            // for (int i = 0; i < 10; i++) persons.Add(new Person() { Lastname = "Jméno" + i, Firstname = "Přijmení" + i, DateOfBirth = new DateTime(1980+i,1,1) });
        }
        private void LoadData()
        {
            var itemsFromDb = App.Database.GetItemsAsync().Result;
            Root.ItemsSource = itemsFromDb;
        }/*
        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            var switchItem = (Switch)sender;
            TodoItem SelectedParent = (TodoItem)switchItem.BindingContext;
        }*/
        void AddToDo(object sender, EventArgs args)
        {
            
                Navigation.PushModalAsync(new AddItem {});
        }
        private void ItemTap(object sender, ItemTappedEventArgs e)
        {
            /*Console.WriteLine((e.Item as TodoItem).Obrazek);
            if(((e.Item as TodoItem).Obrazek)=="check.png")
            {
                (e.Item as TodoItem).Obrazek = "none.png";

            }
            else
            {
                (e.Item as TodoItem).Obrazek = "check.png";
            }*/
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem != null)
            {
                Navigation.PushModalAsync(new ItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}