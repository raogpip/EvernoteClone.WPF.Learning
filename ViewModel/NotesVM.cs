using EvernoteClone.WPF.Learning.Model;
using EvernoteClone.WPF.Learning.ViewModel.Commands;
using EvernoteClone.WPF.Learning.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.WPF.Learning.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        private Notebook selectedNotebook;


        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
                GetNotes();
            }

        }

        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;


        public NotesVM()
        {
            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNotebooks();
        }




        public void CreateNotebook()
        {
            Notebook notebook = new Notebook
            {
                Name = "very long New notebook",
            };

            DataBaseHelper.Insert(notebook);

            GetNotebooks();
        }

        public void CreateNote(int noteBookID)
        {
            Note newNote = new Note()
            {
                NotebookId = noteBookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New Note"
            };

            DataBaseHelper.Insert(newNote);

            GetNotes();
        }

        private void GetNotebooks()
        {
            var notebooks = DataBaseHelper.Read<Notebook>();

            Notebooks.Clear();
            foreach(var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        private void GetNotes()
        {
            if(SelectedNotebook != null)
            {
                var notes = DataBaseHelper.Read<Note>()
                    .Where(n => n.NotebookId == SelectedNotebook.Id).ToList();

                Notes.Clear();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
