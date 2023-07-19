namespace Jokify.Infrastructure.Common
{
	public class DataConstants
	{
		public class Joke
		{
			public const int IntegerIdMinValue = 1;

			public const int JokeTitleMinValue = 5;
			public const int JokeTitleMaxValue = 20;

			public const int JokeCategoryMinValue = 5;
			public const int JokeCategoryMaxValue = 50;

			public const string JokeRatingMinValue = "0.00";
			public const string JokeRatingMaxValue = "5.00";

			public const int JokeSetupMinValue = 10;
			public const int JokeSetupMaxValue = 100;

            public const int JokePunchlineMinValue = 10;
            public const int JokePunchlineMaxValue = 100;

			public const string DecimalFluentApiPrecision = "decimal(3,2)";
        }

		public class Comment
		{
			public const int CommentContentMinValue = 5;
			public const int CommentContentMaxValue = 150;
		}
		public class User
		{
			public const int UserNameMinValue = 3;
			public const int UserNameMaxValue = 20;

			public const int EmailMinValue = 5;
			public const int EmailMaxValue = 60;
		}
        public class Error
        {
            public const string InvalidUserNameErrorMsg = "Invalid Username";
            public const string InvalidPassswordErrorMsg = "Invalid Password";
        }

        public class DisplayConstants
        {
            public const string UsernameDisplay = "Username";
        }
    }
}
