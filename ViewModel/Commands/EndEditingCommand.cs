using EvernoteClone.WPF.Learning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.WPF.Learning.ViewModel.Commands
{
    public class EndEditingCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public NotesVM ViewModel { get; set; }

        public EndEditingCommand(NotesVM viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Notebook notebook = parameter as Notebook;
            if(notebook != null)
            {
                ViewModel.StopEditing(notebook);
            }
        }
    }
}
