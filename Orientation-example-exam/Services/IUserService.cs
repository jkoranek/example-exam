using System;
using Orientation_example_exam.Data;
using Orientation_example_exam.Models;

namespace Orientation_example_exam.Services
{
	public interface IUserService
	{
        bool IsUserInDb(User user);
        bool IsUserInDb(long id);
        void AddUserToDb(User user);
        bool IsAliasInDb(User user);
        bool IsAliasInDb(string alias);
        void HitCountUp(string alias);
        string FindUrl(User user);
        string FindUrl(string alias);
        IEnumerable<object> FillList();
        bool IsSecretCodeInDb(User user);
        bool IsSecretCodeInDb(string secretCode);
        void Delete(User user);
        void Delete(string secretCode);
        bool IsCorrectSecretCode(User user, string secretCode);
        bool IsCorrectSecretCode(long id, string secretCode);
    }
}

