using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;

namespace Figma_zadanie_z_zadaniami
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }
        private int doneCount = 0;
        private string filePath = Path.Combine(FileSystem.AppDataDirectory, "task.json");

        public MainPage()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            BindingContext = this;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            var text = AddItem.Text?.Trim();
            if (string.IsNullOrEmpty(text)) return;

            Tasks.Add(new TaskItem { Name = text });
            AddItem.Text = "";
        }

        private void DeleteSelected_Clicked(object sender, EventArgs e)
        {
            var toDelete = Tasks.Where(t => t.IsSelected).ToList();
            foreach (var item in toDelete)
                Tasks.Remove(item);
        }

        private void MarkSelectedDone_Clicked(object sender, EventArgs e)
        {
            var done = Tasks.Where(t => t.IsSelected).ToList();
            foreach (var item in done)
            {
                doneCount++;
                Tasks.Remove(item);
            }

            DoneButton.Text = $"Zrobione : {doneCount}";
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize(Tasks);
            File.WriteAllText(filePath, json);
        }

        private void LoadButton_Clicked(object sender, EventArgs e)
        {
            string json = File.ReadAllText(filePath);
            var restored = JsonSerializer.Deserialize<List<TaskItem>>(json);
            Tasks.Clear();
            foreach (var item in restored)
                Tasks.Add(item);
        
        }

        private void WylogujButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//LoginPage");
        }
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}

