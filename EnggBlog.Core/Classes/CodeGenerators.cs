using System;
using System.Collections.Generic;
using System.Text;

namespace EnggBlog.Core.Classes
{
    public class CodeGenerators
    {
        public static string ProductCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }
    }
}
