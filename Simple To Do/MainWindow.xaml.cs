using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simple_To_Do
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TodoEntryTextBox.Focus();
        }

        //TODO Find out more about RoutedEventArgs
        /// <summary>
        /// Checks if the TodoEntryTextBox has text. If it does, create a CheckBox, TextBlock and Button with desired values.
        /// Then add each of those UIElements to a Horizontal Stack Panel. Then create a Grid with 3 columns such that any
        /// UIElement placed in the center column will be centered in the window. Then add that Grid to the TodoListBox.
        /// </summary>
        /// <param name="sender">The Add Todo button on the Main Window.</param>
        /// <param name="e"> //TODO I'm not sure what this is honestly...</param>
        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TodoEntryTextBox.Text))
            {
                CheckBox checkBox = new()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    ToolTip = "Complete",
                    Margin = new Thickness(2),
                };

                checkBox.Checked += CompleteTaskCheckBox_Checked;

                TextBlock textBlock = new()
                {
                    Text = TodoEntryTextBox.Text,
                    TextWrapping = TextWrapping.Wrap,
                    ToolTip = "Tarry not...",
                    Width = 500,
                    //Height = 30, // disable for TextWrapping
                    FontSize = 18,
                    Padding = new Thickness(2),
                    Margin = new Thickness(10, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center
                };

                Button button = new()
                {
                    Content = "X",
                    ToolTip = "Delete",
                    Width = 30,
                    Height = 30,
                    Background = new SolidColorBrush(Colors.Red)
                };

                button.Click += DeleteTaskButton_Clicked;

                StackPanel stackPanel = new()
                {
                    Orientation = Orientation.Horizontal
                };
                stackPanel.Children.Add(checkBox);
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(button);

                Grid grid = new();
                ColumnDefinition col0 = new()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                ColumnDefinition col1 = new()
                {
                    Width = new GridLength(0, GridUnitType.Auto)
                };
                ColumnDefinition col2 = new()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                grid.ColumnDefinitions.Add(col0);
                grid.ColumnDefinitions.Add(col1);
                grid.ColumnDefinitions.Add(col2);
                grid.Children.Add(stackPanel);
                Grid.SetColumn(stackPanel, 1);

                TodoListBox.Items.Add(grid);
            }

            TodoEntryTextBox.Clear();
            TodoEntryTextBox.Focus();
        }

        /// <summary>
        /// "Completes" the task by removing the Todo Item from TodoListBox. First, gets reference to the sender by setting
        /// a CheckBox to the sender casted to a CheckBox. Since I know the parent container of the sender is a StackPanel,
        /// I use the VisualTreeHelper class to get the parent. Since I know the parent container of the StackPanel is a Grid,
        /// I use the VisualTreeHelper again to get the Grid. The Grid container is ultimately what I want to remove from
        /// TodoListBox, so I call the Remove() method passing the grid.
        /// </summary>
        /// <param name="sender">The CheckBox associate with the particular task.</param>
        /// <param name="e">//TODO I'm not sure what this is honestly...</param>
        private void CompleteTaskCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            StackPanel stackPanel = (StackPanel)VisualTreeHelper.GetParent(checkBox);
            Grid grid = (Grid)VisualTreeHelper.GetParent(stackPanel);
            TodoListBox.Items.Remove(grid);

            TodoEntryTextBox.Focus();
        }

        /// <summary>
        /// "Deletes" the task by removing the Todo Item from TodoListBox in an identical manner to CompleteTaskCheckBox_Checked.
        /// TODO - more robust functionality.
        /// </summary>
        /// <param name="sender">The CheckBox associate with the particular task.</param>
        /// <param name="e">//TODO I'm not sure what this is honestly...</param>
        private void DeleteTaskButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel stackPanel = (StackPanel)VisualTreeHelper.GetParent(button);
            Grid grid = (Grid)VisualTreeHelper.GetParent(stackPanel);
            TodoListBox.Items.Remove(grid);

            TodoEntryTextBox.Focus();
        }

    }
}
