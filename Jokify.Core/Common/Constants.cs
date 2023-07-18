namespace Jokify.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Constants
    {
        public class Error
        {
            public const string InvalidComment = "Invalid Comment";

            public const string SameComment = "Cant edit with the same value!";
        }

        public class Page
        {
            public const int EntitiesPerPage = 6;

            public const int CommentEntitiesPerPage = 3;

            public const int CurrentPage = 1;
        }
    }
}
