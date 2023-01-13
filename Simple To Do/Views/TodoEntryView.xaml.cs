using System.Windows;
using System.Windows.Controls;

namespace Simple_To_Do.Views
{
    /// <summary>
    /// Interaction logic for TodoEntryView.xaml
    /// </summary>
    public partial class TodoEntryView : UserControl
    {
        public TodoEntryView()
        {
            InitializeComponent();
        }

        private void TodoEntryButton_Click(object sender, RoutedEventArgs e)
        {
            //// Get the parent window of the current view
            //var parentWindow = Window.GetWindow(this);

            //// Find the ListBox in the other view by its name
            //var otherViewListBox = FindName("TodoList") as ListBox;
            //if (otherViewListBox != null)
            //{
            //    // Get the string from the TextBox
            //    var text = abc.Text;
            //    // Add the string to the ListBox
            //    otherViewListBox.Items.Add(text);
            //}

            //LB.Items.Add(mainStack.FindName("abc").ToString());

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var control = mainWindow.TryFindResource("TodoListView");


            //Views.TodoListView todoListView = (TodoListView)this.FindName("TodoListView");
            //var control = todoListView.FindName("TodoList") as ListBox;

            if (true)
            {
                int x = 5;
                x++;
            }

            //control?.Items.Add("hi");
        }
    }
}
