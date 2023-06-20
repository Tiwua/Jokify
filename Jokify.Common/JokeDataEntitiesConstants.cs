namespace Jokify.Common
{
	public class JokeDataEntitiesConstants
	{
		public class Joke
		{
			public const int JokeCategoryMinValue = 5;
			public const int JokeCategoryMaxValue = 50;

			public const string JokeRatingMinValue = "0.00";
			public const string JokeRatingMaxValue = "5.00";

			public const int JokeSetupMinValue = 50;
			public const int JokeSetupMaxValue = 5000;

            public const int JokePunchlineMinValue = 50;
            public const int JokePunchlineMaxValue = 5000;

			public const string DecimalFluentApiPrecision = "decimal(3,2)";
        }

		public class Comment
		{
			public const int CommentContentMinValue = 3;
			public const int CommentContentMaxValue = 500;
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
