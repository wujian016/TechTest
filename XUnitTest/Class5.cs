using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTest
{
    public class MyTestClass:IClassFixture<WriteFileHelper>
    {
        private readonly ITestOutputHelper output;

        public MyTestClass(WriteFileHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MyTest()
        {
            var temp = "my class!";
            output.WriteLine("This is output from {0}", temp);
        }
    }

    public class WriteFileHelper : ITestOutputHelper
    {

        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        public void WriteLine(string message)
        {
           File.WriteAllText("message.log",message);
        }
    }

    public class MyMesageClass //: IClassFixture<DiagnosticMessage>
    {
        private readonly IMessageSink diagnosticMessageSink;

        public MyMesageClass(DiagnosticMessage diagnosticMessageSink)
        {
           // this.diagnosticMessageSink = diagnosticMessageSink;
        }

        [Fact]
        public void MyTest()
        {
            var temp = "my class!";
            var message = new DiagnosticMessage("Ordered {0} test cases");

            diagnosticMessageSink.OnMessage(message);
        }
    }
}
