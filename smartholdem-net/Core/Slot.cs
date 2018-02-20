using System;

namespace SmartHoldemNet.Core
{
	public class Slot
	{
		private static readonly DateTime beginEpoch = new DateTime(2017, 10, 21, 13, 00, 0, DateTimeKind.Utc);

		public static int GetTime()
		{
			//DateTime date = DateTime.Now;

			return Convert.ToInt32((DateTime.UtcNow - beginEpoch).TotalMilliseconds / 1000);
		}
	}
}