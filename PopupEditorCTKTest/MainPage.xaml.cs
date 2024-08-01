using CommunityToolkit.Maui.Views;

namespace PopupEditorCTKTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            await PopupInsideEditor();
        }

        private async Task PopupInsideEditor()

        {
            var p = new CommunityToolkit.Maui.Views.Popup();

            Grid grid = new Grid() { BackgroundColor = Colors.Red, HeightRequest = 300, WidthRequest = 300, Margin = 5, Padding = 5, RowSpacing = 2 };
            grid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            grid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

            Entry entry = new Entry() { HeightRequest = 50, HorizontalOptions = LayoutOptions.Fill, Background = Colors.White, Text = "Entry" };
            grid.Add(entry, 0, 0);

            Editor editor = new Editor() { HorizontalOptions = LayoutOptions.Fill, HeightRequest = 100, Background = Colors.Yellow };
            grid.Add(editor, 0, 1);

            p.Content = grid;
            await this.ShowPopupAsync(p);

        }
    }

}
