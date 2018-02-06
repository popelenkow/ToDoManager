using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TDM.ViewModels
{
    class ShellViewModel : Screen
    {
        private ObservableCollection<FileViewModel> files;

        public ObservableCollection<FileViewModel> Files 
        {
            get { return files; }
            set
            {
                files = value;
                NotifyOfPropertyChange(() => Files);
            }

        }

        private FileViewModel selectedFile;

        public FileViewModel SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != null)
                {
                    selectedFile.FileIsSelected = false;
                }
                if (value != null)
                {
                    value.FileIsSelected = true;
                }
                selectedFile = value;
                NotifyOfPropertyChange(() => SelectedFile);
                NotifyOfPropertyChange(() => CanRemoveFile);
                NotifyOfPropertyChange(() => CanRenameFile);
            }
        }

        public ShellViewModel()
        {
            Files = new BindableCollection<FileViewModel>
                {
                    new FileViewModel{ Name = "Matteo" },
                     new FileViewModel{ Name = "Mario" },
                     new FileViewModel{ Name = "John" }
                };
        }
        public string My { get; set; } = "fdf";
        public bool CanSayHello(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

      

        public void NewFile()
        {
            var file = new FileViewModel { Name = "New file" };
            Files.Add(file);
            SelectedFile = file;
        }
        public bool CanRemoveFile
        {
            get { return SelectedFile != null; }
        }
        public void RemoveFile()
        {
            FileViewModel newSelectedFile = null;
            if (Files.Count > 1)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    if (Files[i] == SelectedFile)
                    {

                        if (i == Files.Count - 1)
                        {
                            newSelectedFile = Files[i - 1];
                        }
                        else
                        {
                            newSelectedFile = Files[i + 1];
                        }
                    }
                }
            }
            Files.Remove(SelectedFile);
            SelectedFile = newSelectedFile;
        }
        public bool CanRenameFile
        {
            get { return SelectedFile != null; }
        }
        public void RenameFile()
        {
            SelectedFile.EditorIsFocused = true;
        }
    }
}
