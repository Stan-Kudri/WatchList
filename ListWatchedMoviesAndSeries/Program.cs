using MaterialSkin;

namespace ListWatchedMoviesAndSeries
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new BoxCinemaForm());

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(new BoxCinemaForm());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple800, Primary.DeepPurple600, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);
        }
    }
}
