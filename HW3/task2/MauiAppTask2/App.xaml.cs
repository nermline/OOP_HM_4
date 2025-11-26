using Microsoft.Extensions.DependencyInjection;

namespace MauiAppTask2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            window.Width = 800;
            window.Height = 600;

            return window;
        }
    }
}