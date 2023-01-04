using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Simple_To_Do.Models
{
    internal class TodoCreator
    {
        private Button submitTodoButton = new();
        public Button SubmitTodoButton => submitTodoButton;

        private TextBox todoTextBox = new();
        public TextBox TodoTextBox => todoTextBox;
    }
}
