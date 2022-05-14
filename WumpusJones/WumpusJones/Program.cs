using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WumpusJones
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static void ConfigureServices()
        {
            ServiceCollection services = new();
            // Add Injected Services here. 
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new Form1());
        }
    }
}
