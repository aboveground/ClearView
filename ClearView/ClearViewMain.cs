using FolderTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearView
{
    public class ClearViewMain
    {
        private FolderContent folder;
        private MainWindow window;

        public ClearViewMain()
        {
            
        }

        internal MainWindow GetWindow()
        {
            window = new MainWindow();
            return window;
        }
    }
}
