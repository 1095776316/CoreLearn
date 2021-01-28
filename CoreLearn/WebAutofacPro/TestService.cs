using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutofacPro
{
    public class TestService : ITestService
    {
        public TestService() {

        }
        private string no;
        public string No { get { if (no == null) no = Guid.NewGuid().ToString(); return no; } }

        public string Get()
        {
            return "test";
        }
    }

    public interface ITestService
    {
        string No { get; }
        string Get();
    }
}
