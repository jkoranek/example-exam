using System;
using Orientation_example_exam.Data;
using Orientation_example_exam.Models;

namespace Orientation_example_exam.Services
{
	public class UserService : IUserService
	{
		private readonly ApplicationContext database;

		public UserService(ApplicationContext database)
		{
			this.database = database;
		}

		public bool IsUserInDb(User user)
        {
			return database.Users.Any(u => u.Id == user.Id);
        }

		public bool IsUserInDb(long id)
		{
			return database.Users.Any(u => u.Id == id);
		}

		public bool IsAliasInDb(User user)
		{
			return database.Users.Any(u => u.Alias == user.Alias);
		}

		public bool IsAliasInDb(string alias)
		{
			return database.Users.Any(u => u.Alias == alias);
		}

		public bool IsSecretCodeInDb(User user)
		{
			return database.Users.Any(u => u.SecretCode == user.SecretCode);
		}

		public bool IsSecretCodeInDb(string secretCode)
		{
			return database.Users.Any(u => u.SecretCode == secretCode);
		}

		public void AddUserToDb(User user)
        {
			database.Users.Add(user);
			database.SaveChanges();
        }

		public void HitCountUp(string alias)
		{
			User? findingUser = database.Users.FirstOrDefault(u => u.Alias == alias);
			if (findingUser != null)
            {
				findingUser.HitCount++;
				database.SaveChanges();
			}
		}

		public string FindUrl(User user)
        {
			return database.Users.FirstOrDefault(u => u.Id == user.Id).Url;
        }

		public string FindUrl(string alias)
		{
			return database.Users.FirstOrDefault(u => u.Alias == alias).Url;
		}

		public IEnumerable<object> FillList()
		{
			return database.Users.Select(u => new { Id = u.Id, Alias = u.Alias, Url = u.Url, HitPoint = u.HitCount });
		}

		public void Delete(User user)
		{
			database.Users.Remove(user);
			database.SaveChanges();
		}

		public void Delete(string secretCode)
		{
			User? deletedUser = database.Users.FirstOrDefault(u => u.SecretCode == secretCode);

			if(deletedUser != null)
            {
				database.Users.Remove(deletedUser);
				database.SaveChanges();
			}
		}

		public bool IsCorrectSecretCode(User user, string secretCode)
        {
			User findingUser = database.Users.FirstOrDefault(user);

			return findingUser.SecretCode == secretCode;
        }

		public bool IsCorrectSecretCode(long id, string secretCode)
		{
			User? findingUser = database.Users.Find(id);

            if(findingUser != null)
			{
				return findingUser.SecretCode == secretCode;
			}

			return false;
		}
    }
}
