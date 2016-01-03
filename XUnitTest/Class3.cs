using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class DatabaseFixture :IDisposable
    {
        public Stack<int> Stack; 


        public DatabaseFixture()
        { 

            Stack = new Stack<int>();
            //Db = new SqlConnection("MyConnectionString");

            // ... initialize data in the test database ...
            Stack.Push(42);
            Stack.Push(38);
            Stack.Push(88);
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
            Stack.Clear();
             
        }

        //public SqlConnection Db { get; private set; }
    }

    public class InfoFixture : IDisposable
    {
        public Stack<string> Stack;

        public InfoFixture()
        {

            Stack = new Stack<string>();
            //Db = new SqlConnection("MyConnectionString");

            // ... initialize data in the test database ...
            Stack.Push("wujian");
            Stack.Push("xisnd"); 
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
            Stack.Clear();
        }

        //public SqlConnection Db { get; private set; }
    }

    public class MyDatabaseTests : IClassFixture<DatabaseFixture>, IClassFixture<InfoFixture>
    {
        DatabaseFixture fixture;
        private InfoFixture Info;

        public MyDatabaseTests( DatabaseFixture fixture,InfoFixture info)
        {
            this.Info = info;
            this.fixture = fixture;
        }

        // ... write tests, using fixture.Db to get access to the SQL Server ...


        [Fact]
        public void CountShouldReturnZeroInfo()
        {
            var count = Info.Stack.Count;

            Info.Stack.Push("maind");

            Assert.Equal(4, count + 1);
        }

        [Fact]
        public void CountShouldReturnOneString()
        {
            var count = Info.Stack.Count;

            Info.Stack.Push("OS");

            Assert.Equal(3, count + 1);
        }

        [Fact]
        public void CountShouldReturnZero()
        {
            var count = fixture.Stack.Count;

            fixture.Stack.Push(28);

            Assert.Equal(5, count + 1);
        }

        [Fact]
        public void CountShouldReturnOne()
        {
            var count = fixture.Stack.Count;

            fixture.Stack.Push(28);

            Assert.Equal(4, count + 1);
        }
    }
}
