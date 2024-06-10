using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPFEFCore.Views
{
    /// <summary>
    /// Header.xaml 的交互逻辑
    /// </summary>
    public partial class Header : UserControl
    {
        //1、声明依赖属性变量
        public static readonly DependencyProperty MyToggleButtonProperty;

        static Header()
        {
            MyToggleButtonProperty = DependencyProperty.Register("MyToggleButton", typeof(bool), typeof(Header));
        }

        public Header()
        {
            InitializeComponent();
        }

        public bool MyToggleButton
        {
            get
            {
                return (bool)GetValue(MyToggleButtonProperty);
            }
            set
            {
                SetValue(MyToggleButtonProperty, value);
            }
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
            Environment.Exit(0);
        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            bool value = toggleButton.IsChecked ?? false;
            MyToggleButton = value;
        }
    }
}
