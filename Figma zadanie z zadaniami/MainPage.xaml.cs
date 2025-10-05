using System.Collections.ObjectModel;
using System.Linq;

namespace Figma_zadanie_z_zadaniami
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }
        private int doneCount = 0;

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
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}

