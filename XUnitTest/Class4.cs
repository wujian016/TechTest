using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class OrderFixture : IDisposable
    {
        public HashSet<string> Orders; 
        public OrderFixture()
        {
            Orders = new HashSet<string>();
            Orders.Add("order1");
            //Db = new SqlConnection("MyConnectionString");

            // ... initialize data in the test Order ...
        }

        public void Dispose()
        {
            Orders.Clear();
            // ... clean up test data from the Order ...
        }

        //public SqlConnection Db { get; private set; }
    }

    [CollectionDefinition("Order collection")]
    public class OrderCollection : ICollectionFixture<OrderFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Order collection")]
    public class OrderTestClass1
    {
        OrderFixture fixture;

        public OrderTestClass1(OrderFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddOrder()
        {
            this.fixture.Orders.Add("order2");
            var count = this.fixture.Orders.Count;
            Assert.Equal(2,count);
        }
    }

    [Collection("Order collection")]
    public class OrderTestClass2
    {
       OrderFixture fixture;

        public OrderTestClass2(OrderFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void AddOrder()
        {
            this.fixture.Orders.Add("order3");
            var count = this.fixture.Orders.Count;
            Assert.Equal(3, count);
        }
    }
}
