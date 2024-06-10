using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TestWPFEFCore.MyDependencyObject
{
    public class MyDependencyOB
    {
        //通过静态方法的形式暴露读的操作
        public static bool GetMyDependencyOBIschecked(DependencyObject obj)
        {
            return (bool)obj.GetValue(MyDependencyOBIscheckedProperty);
        }

        //通过静态方法的形式暴露写的操作
        public static void SetMyDependencyOBIschecked(DependencyObject obj, bool value)
        {
            obj.SetValue(MyDependencyOBIscheckedProperty, value);
        }
        //通过使用RegisterAttached来注册一个附加属性
        public static readonly DependencyProperty MyDependencyOBIscheckedProperty =
DependencyProperty.RegisterAttached("MyDependencyOBIschecked", typeof(bool), typeof(MyDependencyOB), new PropertyMetadata(false, OnMyDependencyOBIscheckedChanged));

        //根据附加属性中的值，当值改变的时候，旋转相应的角度。
        private static void OnMyDependencyOBIscheckedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as UIElement;
            if (element != null)
            {
                //element.RenderTransformOrigin = new Point(0.5, 0.5);
                //element.RenderTransform = new RotateTransform((double)e.NewValue);

                obj.SetValue(MyDependencyOBIscheckedProperty, e.NewValue);
            }
        }
    }
}
