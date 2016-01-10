using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class Class7
    {
        /*
         * 关于协变与逆变的测试
         * https://msdn.microsoft.com/zh-cn/library/ee207183(v=vs.110).aspx
         * https://msdn.microsoft.com/zh-cn/library/dd469487(v=vs.110).aspx
         * https://msdn.microsoft.com/zh-cn/library/dd469484(v=vs.110).aspx
         * 
         */

        [Fact]
        public void TestContravariant()
        {
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

            // Implicit conversion of IEqualityComparer<BaseClass> to 
            // IEqualityComparer<DerivedClass>.
            IEqualityComparer<DerivedClass> childComparer = baseComparer;
        }

        [Fact]
        public void TestCovariant()
        {
            //只有引用类型才支持使用泛型接口中的变体。 值类型不支持变体
            //IEnumerable<int> integers = new List<int>();
            // The following statement generates a compiler errror,
            // because int is a value type.
            // IEnumerable<Object> objects = integers;

            // The following line generates a compiler error
            // because classes are invariant.
            // List<Object> list = new List<String>();

            // You can use the interface object instead.
            IEnumerable<Object> listObjects = new List<String>();
        }

        [Fact]
        public void TestMyCovariant()
        {
            ICovariant<Object> iobj = new Sample<Object>();
            ICovariant<String> istr = new Sample<String>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj = istr;

            //This will error
            //istr = iobj;
        }
    }

    // Simple hierarchy of classes.
    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }

    // Covariant interface.
    interface ICovariant<out R> { }

    // Extending covariant interface.
    interface IExtCovariant<out R> : ICovariant<R> { }

    // Implementing covariant interface.
    class Sample<R> : ICovariant<R> { }
}
