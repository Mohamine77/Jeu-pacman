using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace Jeu_pacman
{
    public class Partie
    {
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
      
    }
}