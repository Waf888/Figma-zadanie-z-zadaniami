using System.Collections.ObjectModel;

namespace Figma_zadanie_z_zadaniami
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Item> Products { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Products = new ObservableCollection<Item>();
            BindingContext = this;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            string nazwa = AddItem.Text;
            if (string.IsNullOrEmpty(nazwa))
                return;
            AddItem.Text = "";

            var JuzDodany = Products.FirstOrDefault(p => p.Name.Equals(nazwa, StringComparison.OrdinalIgnoreCase));

            if (JuzDodany != null)
            {
                JuzDodany.Quantity++;
                Products.Remove(JuzDodany);
                Products.Add(JuzDodany);
            }
            else
            {
                Products.Add(new Item { Name = nazwa, Quantity = 1 });
            }

            wyswietl.ItemsSource = Products;
        }

        private void DelButton_Clicked(object sender, EventArgs e)
        {
            var selected = wyswietl.SelectedItem;
            Products.Remove((Item)selected);
        }
    }
}
