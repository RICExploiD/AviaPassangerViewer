using System;
using System.IO;
using System.Windows;
    using System.Collections.Generic;

using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace AviaPassangerViewer.Views
{
    using Models;
    using MVVM.Base;

    internal sealed class PassangerViewerViewModel : NotifyPropertyChanged
    {
        private readonly PassangerViewer _view;
        public ObservableCollection<AviaPassanger> AviaPassangerList { get; set; } = new();
        public Command UploadFile { get; set; } = new();
        public PassangerViewerViewModel(PassangerViewer view)
        {
            _view = view;
            _view.InitializeComponent();
            _view.DataContext = this;

            UploadFile.ExecutableAction += _ => GetPassangerFile();
        }
        public void GetPassangerFile()
        {
            var s = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (s.ShowDialog() != true) return;

            ParsePassangerFile(s.FileName);
        }
        public void ParsePassangerFile(string fileName)
        {
            using var stream = new StreamReader(fileName);

            var file = stream.ReadToEnd();

            var entities = file.Trim().Split("\r\n");

            AviaPassangerList?.Clear();

            foreach ( var entity in entities ) 
            {
                try 
                { 
                    var passanger = entity.Split(';');

                    var person = new Person(passanger[0], passanger[1], passanger[2]);
                    var flight = new Flight(Convert.ToDateTime(passanger[3]), Convert.ToInt32(passanger[4]));

                    AviaPassangerList.Add(new AviaPassanger(person, flight));
                }
                catch (Exception ex) { }
            }

            if (AviaPassangerList?.Count == 0)
                MessageBox.Show("File empty or not valid.");
        }
    }
}
