using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Schema;

namespace Simple_To_Do.Models
{
    internal class TodoItem
    {
        private  CheckBox isCompleteCheckBox = new();
        public CheckBox IsCompleteCheckBox => isCompleteCheckBox;

        private  TextBlock todoNameTextBlock = new();
        public TextBlock TodoNameTextBlock => todoNameTextBlock;

        private Button deleteTodoButton = new();
        public Button DeleteTodoButton => deleteTodoButton;
    }
}
