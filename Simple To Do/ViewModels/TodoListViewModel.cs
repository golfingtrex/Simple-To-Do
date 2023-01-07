using System.Windows.Input;

namespace Simple_To_Do.ViewModels
{
    internal class TodoListViewModel : ViewModel
    {
        private string todoName;
        public string TodoName
        {
            get
            {
                return todoName;
            }
            set
            {
                todoName = value;
                OnPropertyChanged(nameof(TodoName));
            }
        }

        public ICommand CompleteTodoCommand { get; }
        public ICommand DeleteTodoCommand { get; }

        public TodoListViewModel()
        {

        }

    }
}
