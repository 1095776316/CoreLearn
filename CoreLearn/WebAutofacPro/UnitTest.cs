using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutofacPro
{
    public class UnitTest : IUnitTest
    {
        public string Get()
        {
            return "testOK";
        }
    }
    public interface IUnitTest
    {
        string Get();
    }
}
