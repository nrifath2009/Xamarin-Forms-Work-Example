using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JsonLoaderApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string personListText = string.Empty;
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream("JsonLoaderApp.DataService.data.json"))
            {
                personListText = new StreamReader(stream).ReadToEnd();
            }
            var personList = JsonConvert.DeserializeObject<ObservableCollection<Person>>(personListText);
            personListView.ItemsSource = personList;
        }
    }
}
