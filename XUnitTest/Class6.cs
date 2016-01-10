using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace XUnitTest
{
    public class MyTestCaseOrderer : ITestCaseOrderer
    {
        private readonly IMessageSink diagnosticMessageSink;

        public MyTestCaseOrderer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            var result = testCases.ToList();  // Run them in discovery order
            var message = new DiagnosticMessage("Ordered {0} test cases", result.Count);
            diagnosticMessageSink.OnMessage(message);
            return result;
        }
    }
}
