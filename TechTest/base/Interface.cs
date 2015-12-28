using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wujian.Tech.Base
{
    class Inteface
    {
       internal static void Test()
        {
            /*
             http://developer.51cto.com/art/200908/146045.htm 
             TextBox中的方法Paint隐藏了Control中的方法Paint，但是没有改变从Control.Paint到IControl.Paint 的映射 
             */
            Console.WriteLine("Test using new");

            Control1 c1 = new Control1();
            TextBox1 t1 = new TextBox1();
            IControl ic1 = c1;
            IControl it1 = t1;
            c1.Paint();
            t1.Paint();
            ic1.Paint(); 
            it1.Paint();

            Console.WriteLine();
            Console.WriteLine("Test using override");
            Control2 c2 = new Control2();
            TextBox2 t2 = new TextBox2();
            IControl ic2 = c2;
            IControl it2 = t2;
            Control2 it22 = t2;
            c2.Paint();
            t2.Paint();
            ic2.Paint();
            it2.Paint();
            it22.Paint();

            /*
             http://www.cnblogs.com/ben-zhang/archive/2012/12/18/2823455.html
             显示接口实现与隐式接口实现的适应场景
                1.当类实现一个接口时，通常使用隐式接口实现，这样可以方便的访问接口方法和类自身具有的方法和属性。
                2.当类实现多个接口时，并且接口中包含相同的方法签名，此时使用显式接口实现。即使没有相同的方法签名，仍推荐使用显式接口，因为可以标识出哪个方法属于哪个接口。
                3.隐式接口实现，类和接口都可访问接口中方法。显式接口实现，只能通过接口访问。
             */
            Console.WriteLine();
            Console.WriteLine("Test using explicit interface");
            Control3 c3 = new Control3();
            TextBox3 t3 = new TextBox3();
            IControl ic3 = new Control3();
            IControl it3 = t3; 
            ic3.Paint();
            it3.Paint();

            Console.WriteLine();
            Console.WriteLine("Test using multiple interface");
            Combox cb = new Combox();
            cb.Paint();

        }
    }

    class Control1:IControl
    {
        public void Paint()
        {
            Console.WriteLine("Control.Paint");
        }
    }

    class TextBox1:Control1
    {
        public new void Paint()
        {
            Console.WriteLine("TextBox.Paint");
        }
    }

    class Control2 : IControl
    {
        public virtual void Paint()
        {
            Console.WriteLine("Control.Paint");
        }
    }

    class TextBox2 : Control2
    {
        public override void Paint()
        {
            Console.WriteLine("TextBox.Paint");
        }
    }

    class Control3 : IControl
    {
        protected virtual void PaintControl()
        {
            Console.WriteLine("Control.Paint");
        }

        void IControl.Paint()
        {
            PaintControl();
        }
    }

    class TextBox3 : Control3
    {
        protected override void PaintControl()
        {
            Console.WriteLine("TextBox.Paint");
        }
    }

    class Combox : ICombox
    {
        public void SetText(string text)
        {
            Console.WriteLine("ITextBox.SetText");
        }

        public void Paint()
        {
            Console.WriteLine("IControl.Paint");
        }

        public void SetItems(string items)
        {
            Console.WriteLine("IListBox.SetItems");
        }
    }

    interface IControl
    {
        void Paint();
    }

    interface ITextBox: IControl
    {
        void SetText(string text);
    }

    interface IListBox: IControl
    {
        void SetItems(string items);
    }

    interface ICombox:ITextBox,IListBox
    {
    }
}
