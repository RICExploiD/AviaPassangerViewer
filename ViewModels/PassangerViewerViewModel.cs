using System;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

using Microsoft.Win32;

namespace AviaPassangerViewer.ViewModels
{
    using Models;
    using MVVM.Base;

    internal sealed class PassangerViewerViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<AviaPassanger> AviaPassangerList { get; set; } = new();
        public Command UploadFile { get; set; }
        public PassangerViewerViewModel()
        {
            UploadFile = new(GetPassangerFile);
        }
        public void GetPassangerFile()
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (fileDialog.ShowDialog() != true) return;

            ParsePassangerFile(fileDialog.FileName);
        }
        public void ParsePassangerFile(string fileName)
        {
            var entities = File.ReadAllLines(fileName);

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
