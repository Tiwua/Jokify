namespace Jokify.Common
{
	public class JokeDataEntitiesConstants
	{
		public class Joke
		{
			public const int JokeCategoryMinValue = 5;
			public const int JokeCategoryMaxValue = 50;

			public const string JokeRatingMinValue = "0.00";
			public const string JokeRatingMaxValue = "10.00";

			public const int JokeSetupMinValue = 50;
			public const int JokeSetupMaxValue = 5000;

            public const int JokePunchlineMinValue = 50;
            public const int JokePunchlineMaxValue = 5000;
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

	}
}
