using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolishProgramer.Models
{
    public static class EditPostContent
    {
       public static string  ChangeTheSignToHtmlCode (string Text)
        {
            var post = Text.IndexOf("{");
            var post1 = Text.IndexOf("}");

            if (post != -1 && post1 != -1)
            {
                return  Text.Substring(+post, post1);
            }
            return null;

            
        }

        public static string ShowTheFirstNchatacters(this string str, int maxLength) => str.Substring(0, Math.Min(str.Length, maxLength));
    }
}
