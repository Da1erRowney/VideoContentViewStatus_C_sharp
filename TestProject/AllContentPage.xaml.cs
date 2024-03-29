using DataContent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SQLite;
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace TestProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllContentPage : ContentPage
    {
        private string Choise;
        public List<Content> ContentAll { get; set; }
        public List<Content> ContentSerial { get; set; }
        public List<Content> ContentAnime { get; set; }
        public List<Content> ContentFilm { get; set; }
        public List<Content> ContentDorama { get; set; }
        public List<Content> ContentMult { get; set; }
        public List<Content> ContentDocum { get; set; }
        public List<Content> ContentOther { get; set; }
        public List<Content> ContentViewed { get; set; }
        public List<Content> ContentProcess { get; set; }
        public List<Content> ContentNotStart { get; set; }

        private List<Content> _contentSearch;
        public List<Content> ContentSort { get; set; }
        public List<Content> ContentSearch
        {
            get { return _contentSearch; }
            set
            {
                _contentSearch = value;
                OnPropertyChanged(nameof(ContentSearch));
            }
        }
        public Content SelectedItem { get; set; }

        private DatabaseServiceContent _databaseService;
        public SQLiteConnection CreateDatabase(string databasePath)
        {
            SQLiteConnection connection = new SQLiteConnection(databasePath);
            connection.CreateTable<Content>();
            return connection;

        }

        public AllContentPage()
        {
            InitializeComponent();
            Choise = "All";

            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "content.db");
            _databaseService = new DatabaseServiceContent(databasePath);
            SQLiteConnection connection = CreateDatabase(databasePath);
            DatabaseServiceContent databaseService = new DatabaseServiceContent(databasePath);

            List<Content> contents = databaseService.GetAllContent().ToList();
            ContentAll = contents.ToList();
            List<Content> filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentSerial= filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����").ToList();
            ContentAnime = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����").ToList();
            ContentFilm = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentDorama = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����������").ToList();
            ContentMult = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������������").ToList();
            ContentDocum = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentOther = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "�����������").ToList();
            ContentViewed = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "������").ToList();
            ContentProcess = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "�� �������").ToList();
            ContentNotStart = filteredContents.ToList();

            ViewData();
            BindingContext = this;
        }


        private void ViewData()
        {

            if (ContentAll.Count == 0)
            {
                All.IsVisible = false;
            }
            else
            {
                All.IsVisible = true;
            }
            if (ContentSerial.Count == 0)
            {
                Serial.IsVisible = false;
            }
            else
            {
                Serial.IsVisible = true;
            }
            if (ContentAnime.Count == 0)
            {
                Anime.IsVisible = false;
            }
            else
            {
                Anime.IsVisible = true;
            }
            if (ContentFilm.Count == 0)
            {
                Film.IsVisible = false;
            }
            else
            {
                Film.IsVisible = true;
            }
            if (ContentDorama.Count == 0)
            {
                Dorama.IsVisible = false;
            }
            else
            {
                Dorama.IsVisible = true;
            }
            if (ContentMult.Count == 0)
            {
                Mult.IsVisible = false;
            }
            else
            {
                Mult.IsVisible = true;
            }
            if (ContentDocum.Count == 0)
            {
                Docum.IsVisible = false;
            }
            else
            {
                Docum.IsVisible = true;
            }
            if (ContentOther.Count == 0)
            {
                Other.IsVisible = false;
            }
            else
            {
                Other.IsVisible = true;
            }
            if (ContentViewed.Count == 0)
            {
                Viewed.IsVisible = false;
            }
            else
            {
                Viewed.IsVisible = true;
            }
            if (ContentProcess.Count == 0)
            {
                Process.IsVisible = false;
            }
            else
            {
                Process.IsVisible = true;
            }
            if (ContentNotStart.Count == 0)
            {
                NotStart.IsVisible = false;
            }
            else
            {
                NotStart.IsVisible = true;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            UpdateContent();
            ViewData();


        }

        private void UpdateContent()
        {
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "content.db");
            _databaseService = new DatabaseServiceContent(databasePath);
            SQLiteConnection connection = CreateDatabase(databasePath);
            DatabaseServiceContent databaseService = new DatabaseServiceContent(databasePath);

            List<Content> contents = databaseService.GetAllContent().ToList();
            ContentAll = contents.ToList();

            List<Content> filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentSerial = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����").ToList();
            ContentAnime = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����").ToList();
            ContentFilm = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentDorama = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "�����������").ToList();
            ContentMult = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������������").ToList();
            ContentDocum = filteredContents.ToList();

            filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentOther = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "�����������").ToList();
            ContentViewed = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "������").ToList();
            ContentProcess = filteredContents.ToList();

            filteredContents = contents.Where(c => c.WatchStatus == "�� �������").ToList();
            ContentNotStart = filteredContents.ToList();

           
            BindingContext = this;
        }

        private async void ���Button_Clicked(object sender, EventArgs e)
        {
            All.IsVisible = true;
            Serial.IsVisible = true;
            Anime.IsVisible = true;
            Film.IsVisible = true;
            Dorama.IsVisible = true;
            Mult.IsVisible = true;
            Docum.IsVisible = true;
            Other.IsVisible = true;
            Viewed.IsVisible = true;
            Process.IsVisible = true;
            NotStart.IsVisible = true;
            Sort.IsVisible = false;

        }

        private async void �����Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;

            List<Content> filteredContents = ContentAll.Where(c => c.Type == "�����").ToList();
            ContentSort = filteredContents.ToList();

            Sort.IsVisible = true;
            SortLabel.Text = "�� ���� �����";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;

            List<Content> filteredContents = ContentAll.Where(c => c.Type == "�����").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "��� ���� ������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void �������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;

            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;

            Sort.IsVisible = true;
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "content.db");
            _databaseService = new DatabaseServiceContent(databasePath);
            SQLiteConnection connection = CreateDatabase(databasePath);
            DatabaseServiceContent databaseService = new DatabaseServiceContent(databasePath);

            List<Content> contents = databaseService.GetAllContent().ToList();

            List<Content> filteredContents = contents.Where(c => c.Type == "������").ToList();
            ContentSort = filteredContents.ToList();
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
            SortLabel.Text = "��� ���� �������";
        }

        private async void ������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;
            List<Content> filteredContents = ContentAll.Where(c => c.Type == "������").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "��� ���� ������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ������������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;
            List<Content> filteredContents = ContentAll.Where(c => c.Type == "�����������").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "��� ���� ������������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ������������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;

            List<Content> filteredContents = ContentAll.Where(c => c.Type == "������������").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "��� ���� �������������� ������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;

            List<Content> filteredContents = ContentAll.Where(c => c.Type == "������").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "��� ������ �������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void �����������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;
          
            List<Content> filteredContents = ContentAll.Where(c => c.WatchStatus == "�����������").ToList();
            ContentSort = filteredContents.ToList();
            Sort.IsVisible = true;
            SortLabel.Text = "������������� �������";
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ���������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;
            Sort.IsVisible = true;
            List<Content> filteredContents = ContentAll.Where(c => c.WatchStatus == "������").ToList();
            ContentSort = filteredContents.ToList();
            SortLabel.Text = "�������, ������� �� ������ ��������";
            OnPropertyChanged(nameof(ContentSort));
        }

        private async void ��������Button_Clicked(object sender, EventArgs e)
        {
            ContentSort = null;
            All.IsVisible = false;
            Serial.IsVisible = false;
            Anime.IsVisible = false;
            Film.IsVisible = false;
            Dorama.IsVisible = false;
            Mult.IsVisible = false;
            Docum.IsVisible = false;
            Other.IsVisible = false;
            Viewed.IsVisible = false;
            Process.IsVisible = false;
            NotStart.IsVisible = false;
          
            Sort.IsVisible = true;

            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "content.db");
            _databaseService = new DatabaseServiceContent(databasePath);
            SQLiteConnection connection = CreateDatabase(databasePath);
            DatabaseServiceContent databaseService = new DatabaseServiceContent(databasePath);

            List<Content> contents = databaseService.GetAllContent().ToList();

            List<Content> filteredContents = contents.Where(c => c.WatchStatus.IndexOf("�� �������", StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            ContentSort = filteredContents.ToList();
            BindingContext = this;
            OnPropertyChanged(nameof(ContentSort));
            SortLabel.Text = "�� ������� �������";
           
        }
        private async void OnItemSelectedAll(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentAll[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
            
        }

        private void ItemButtonClickedAll(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)AllContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedAll(item, selectedIndex);
        }


        private void ItemButtonClickedSerial(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)SerialContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedSerial(item, selectedIndex);
        }

        private async void OnItemSelectedSerial(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentSerial[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedAnime(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)AnimeContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedAnime(item, selectedIndex);
        }

        private async void OnItemSelectedAnime(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentAnime[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedFilm(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)FilmContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedFilm(item, selectedIndex);
        }

        private async void OnItemSelectedFilm(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentFilm[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedDorama(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)DoramaContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedDorama(item, selectedIndex);
        }

        private async void OnItemSelectedDorama(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentDorama[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedMult(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)MultContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedMult(item, selectedIndex);
        }

        private async void OnItemSelectedMult(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentMult[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedDocum(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)DocumContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedDocum(item, selectedIndex);
        }

        private async void OnItemSelectedDocum(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentDocum[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedOther(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)OtherContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedOther(item, selectedIndex);
        }

        private async void OnItemSelectedOther(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentOther[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedViewed(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)ViewedContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedViewed(item, selectedIndex);
        }

        private async void OnItemSelectedViewed(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentViewed[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedProcess(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)ProcessContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedProcess(item, selectedIndex);
        }

        private async void OnItemSelectedProcess(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentProcess[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }


        private void ItemButtonClickedNotStart(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)NotStartContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedNotStart(item, selectedIndex);
        }

        private async void OnItemSelectedNotStart(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentNotStart[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Content selectedContent)
            {
                ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
                await Navigation.PushAsync(viewContentPage);
            }
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "content.db");
            _databaseService = new DatabaseServiceContent(databasePath);
            SQLiteConnection connection = CreateDatabase(databasePath);
            DatabaseServiceContent databaseService = new DatabaseServiceContent(databasePath);

            string searchQuery = searchBar.Text;
            if (searchQuery != "")
            {
                All.IsVisible = false;
                Serial.IsVisible = false;
                Anime.IsVisible = false;
                Film.IsVisible = false;
                Dorama.IsVisible = false;
                Mult.IsVisible = false;
                Docum.IsVisible = false;
                Other.IsVisible = false;
                Viewed.IsVisible = false;
                Process.IsVisible = false;
                NotStart.IsVisible = false;
                SearchList.IsVisible = false;
                Sort.IsVisible = true;
                SortLabel.Text = $"������� ������� �� ������� \"{searchQuery}\"";
                AllContentPage viewModel = new AllContentPage();
                BindingContext = viewModel;
                List<Content> contents = databaseService.GetAllContent().ToList();

                List<Content> filteredContents = contents.Where(c => c.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                ContentSort = filteredContents.ToList();
                BindingContext = this;


            }
            else
            {
                SearchList.IsVisible = false;
                Sort.IsVisible = false;
                All.IsVisible = true;
                Serial.IsVisible = true;
                Anime.IsVisible = true;
                Film.IsVisible = true;
                Dorama.IsVisible = true;
                Mult.IsVisible = true;
                Docum.IsVisible = true;
                Other.IsVisible = true;
                Viewed.IsVisible = true;
                Process.IsVisible = true;
                NotStart.IsVisible = true;
                ContentSort = null; // ��������� ��������� ������ � null
                OnPropertyChanged(nameof(ContentSort));
                ViewData();
                UpdateContent();
            }

           

        }

        private void ItemButtonClickedSort(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Content)button.CommandParameter;
            var selectedIndex = new List<Content>((IEnumerable<DataContent.Content>)SortContentCollectionView.ItemsSource).IndexOf(item);
            OnItemSelectedSort(item, selectedIndex);
        }
        private async void OnItemSelectedSort(Content item, int selectedIndex)
        {
            if (item == null)
                return;

            Content selectedContent = ContentSort[selectedIndex];
            ViewContentPage viewContentPage = new ViewContentPage(selectedContent);
            await Navigation.PushAsync(viewContentPage);
        }
    }
}