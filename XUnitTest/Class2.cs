using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class StackTests : IDisposable
    {
        Stack<int> stack;

        public StackTests()
        {
            stack = new Stack<int>();
        }

        public void Dispose()
        {
            stack.Clear();
        }

        [Fact]
        public void WithNoItems_CountShouldReturnZero()
        {
            var count = stack.Count;

            stack.Push(88);

            Assert.Equal(0, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnOne()
        {
            stack.Push(42);

            var count = stack.Count;

            Assert.Equal(1, count);
        }
    }
}
