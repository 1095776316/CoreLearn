using System;
using System.Collections.Generic;
using System.Text;

namespace PollyPro1
{
    public class Test
    {
        public virtual  void Say()
        {
            try
            {
                throw new ArgumentException("xxx");
            }
            catch
            {

            }
        }
    }
}
