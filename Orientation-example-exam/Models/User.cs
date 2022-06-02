using System;
namespace Orientation_example_exam.Models
{
	public class User
	{
        public long Id { get; set; }
		public string Alias { get; set; }
		public string Url { get; set; }
		public string SecretCode { get; set; }
        public int HitCount { get; set; }

        public User()
		{
			Random random = new Random();
			int randomCode = random.Next(1000, 10000);

			SecretCode = randomCode.ToString();
			HitCount = 0;
		}

		public User(string alias, string url)
		{
			Random random = new Random();
			int randomCode = random.Next(1000, 10000);

			Alias = alias;
			Url = url;
			SecretCode = randomCode.ToString();
			HitCount = 0;
		}
	}
}

