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
        private ObservableCollection<string> files;

        public ObservableCollection<string> Files 
        {
            get { return files; }
            set
            {
                files = value;
                NotifyOfPropertyChange(() => Files);
            }

        }

        private string selectedFile;

        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                NotifyOfPropertyChange(() => SelectedFile);
                NotifyOfPropertyChange(() => CanRemoveFile);
            }
        }

        public ShellViewModel()
        {
            Files = new BindableCollection<string>
                {
                    "Matteo",
                    "Mario",
                    "John"
                };
        }
        public string My { get; set; } = "fdf";
        public bool CanSayHello(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

      

        public void NewFile()
        {
            Files.Add("New file");
        }
        public bool CanRemoveFile
        {
            get { return SelectedFile != null; }
        }
        public void RemoveFile()
        {
            Files.Remove(selectedFile);
        }
    }
}
