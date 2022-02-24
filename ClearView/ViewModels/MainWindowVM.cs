using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClearView.ViewModels
{
    public class MainWindowVM : BaseVM
    {

        private EventHandler ExitHandler;

        private string mainTitle;
        public string MainTitle { get { return mainTitle; } }

        private double left;
        public double Left { get { return left; } set { left = value; } }
        private double top;
        public double Top { get { return top; } set { top = value; } }
        private double height;
        public double Height { get { return height; } set { height = value; } }
        private double width;
        public double Width { get { return width; } set { width = value; } }

        private ICommand close;
        public ICommand Close { get { return close; } set { close = value; } }

        private ICommand exit;
        public ICommand Exit { get { return exit; } set { exit = value; } }

        private bool isHiddenWorkBench;
        public bool IsHiddenWorkBench
        {
            get { return isHiddenWorkBench; }
            set
            {
                if (value != isHiddenWorkBench)
                {
                    isHiddenWorkBench = value;
                    NotifyPropertyChanged();
                    IsWorkBenchCollapsed = isHiddenWorkBench ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                }
            }
        }

        private System.Windows.Visibility isWorkBenchCollapsed;
        public System.Windows.Visibility IsWorkBenchCollapsed
        {
            get
            {
                return isWorkBenchCollapsed;
            }
            set
            {
                isWorkBenchCollapsed = value;
                NotifyPropertyChanged();
            }
        }

        private System.Windows.Visibility messageAreaVisible;
        public System.Windows.Visibility MessageAreaVisible
        {
            get
            {
                return messageAreaVisible;
            }
            set
            {
                messageAreaVisible = value;
                NotifyPropertyChanged();
            }
        }

        private GridLength workBenchSplitDistance;
        public GridLength WorkBenchSplitDistance
        {
            get { return workBenchSplitDistance; }
            set { workBenchSplitDistance = value; NotifyPropertyChanged(); }
        }

        private GridLength messageAreaWidth;
        public GridLength MessageAreaWidth
        {
            get { return messageAreaWidth; }
            set { messageAreaWidth = value; NotifyPropertyChanged(); }
        }

        public MainWindowVM(EventHandler exitApp)
        {
            ExitHandler = exitApp;
            Left = CV.Default.Left;
            Top = CV.Default.Top;
            Height = CV.Default.Height;
            Width = CV.Default.Width;
            IsHiddenWorkBench = false;// BosonSettings.Default.WorkBenchIsHidden;
            mainTitle = "ClearView Tools";
            WorkBenchSplitDistance = new GridLength(CV.Default.WorkBenchSlitDistance);
           MessageAreaWidth = new GridLength(CV.Default.MessageSplitDistance);
            MessageAreaVisible = Visibility.Visible;
            exit = new RelayCommand(ExecuteExit, CanExecuteexit);
        }

        private bool CanExecuteexit(object parameter)
        {
            return true;
        }

        private void ExecuteExit(object parameter)
        {
            ExitHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}
