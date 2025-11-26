namespace MauiAppTask2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object? sender, EventArgs e)
        {
            string? input = InputEntry.Text;

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input is null || !int.TryParse(input, out int number))
                {
                    DisplayAlertAsync("Відповідь", "Введено некоректне значення", "OK");
                }
                else
                {
                    DisplayAlertAsync("Відповідь", $"Ви ввели число: {number}", "OK");
                }
            }
        }
    }
}
