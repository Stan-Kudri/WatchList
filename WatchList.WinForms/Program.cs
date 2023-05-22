using MaterialSkin;
using WatchList.WinForms.DbContext;

namespace WatchList.WinForms
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

            using var db = new FileDbContextFactory("app.db").Create();
            var form = new BoxCinemaForm(db);
            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple800, Primary.DeepPurple600, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);

            Application.Run(form);
        }
    }
}
