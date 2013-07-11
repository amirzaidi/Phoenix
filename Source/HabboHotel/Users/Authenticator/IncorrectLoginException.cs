using System;
namespace Phoenix.HabboHotel.Users.Authenticator
{
    [Serializable]
	public class IncorrectLoginException : Exception
	{
		public IncorrectLoginException(string Reason) : base(Reason)
		{
		}
	}
}
