﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClearView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private ClearViewMain main;
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            main = new ClearViewMain();
            main.GetWindow().Show();
        }
    }
}
