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
            public const int JokesPerPage = 6;

            public const int CommentsPerPage = 3;

            public const int CurrentPage = 1;

            public const int UsersPerPage = 3;
        }

        public class Forgotten
        {
            public const string ForgottenUsername = "Forgotten Username";

            public const string ForgottenEmail = "Forgotten Email";
        }
    }
}
