using System;
namespace WordPress.Data
{
	public static class ValidationHelper
	{
		public static string GetDaySuffix(this DateTime value)
		{
			switch (value.Day)
			{
				case 1:
				case 21:
				case 31:
					return "st";
				case 2:
				case 22:
					return "nd";
				case 3:
				case 23:
					return "rd";
				default:
					return "th";
			}
		}


		public static bool IsValidCCNumber(string number)
		{
			var deltas = new[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
			int checksum = 0;
			char[] chars = number.ToCharArray();
			for (int i = chars.Length - 1; i > -1; i--)
			{
				int j = chars[i] - 48;
				checksum += j;
				if (((i - chars.Length) % 2) == 0)
					checksum += deltas[j];
			}
			return ((checksum % 10) == 0);
		}
		
		public static DateTime? ParseDate(this string value)
		{
			DateTime date;
			return DateTime.TryParse(value, out date) ? (DateTime?)date : null;
		}

		public static DateTime ParseDateMin(this string value)
		{
			DateTime date;
			return DateTime.TryParse(value, out date) ? (DateTime)date : DateTime.MinValue;
		}
		
		public static int? ParseInt(this string value)
		{
			int i;
			return int.TryParse(value, out i) ? (int?)i : null;
		}

        public static int ParseInt(this string value, int def)
        {
            int i;
            return int.TryParse(value, out i) ? i : def;
        }


		public static decimal? ParseDecimal(this string value)
		{
			decimal i;
			return decimal.TryParse(value, out i) ? (decimal?)i : null;
		}

		public static decimal ParseDecimal(this string value, decimal def)
		{
			decimal i;
			return decimal.TryParse(value, out i) ? (decimal)i : def;
		}


		public static decimal? ParseMoney(this string value)
		{
			decimal i;
			if (!string.IsNullOrWhiteSpace(value))
			{
				value = value.Replace("$", "");
			}
			return decimal.TryParse(value, out i) ? (decimal?)i : null;
		}

		public static decimal ParseMoney(this string value, decimal def)
		{
			decimal i;
			if (!string.IsNullOrWhiteSpace(value))
			{
				value = value.Replace("$", "");
			}
			return decimal.TryParse(value, out i) ? (decimal)i : def;
		}
		
		public static int ParseInt0(this string value)
		{
			int i;
			return int.TryParse(value, out i) ? i : 0;
		}

		public static long? ParseLong(this string value)
		{
			long i;
            return long.TryParse(value, out i) ? (long?)i : null;
		}

        public static long ParseLong(this string value, long def)
        {
            long i;
            return long.TryParse(value, out i) ? i : def;
        }

		public static long ParseLong0(this string value)
		{
			long i;
			return long.TryParse(value, out i) ? i : 0;
		}

		public static bool? ParseBool(this string value)
		{
			bool i;
			return bool.TryParse(value, out i) ? (bool?)i : null;
		}

		public static bool ParseBoolFalse(this string value)
		{
			bool i;
			return bool.TryParse(value, out i) ? i : false;
		}

        public static TEnum? ParseEnum<TEnum>(this string value) where TEnum : struct
        {
            TEnum result;
            if (Enum.TryParse<TEnum>(value, true, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static TEnum ParseEnum<TEnum>(this string value, TEnum def) where TEnum : struct
        {
            TEnum result;
            if (Enum.TryParse<TEnum>(value, true, out result))
            {
                return result;
            }
            else
            {
                return def;
            }
        }


		public static int ToInt(this int? value, int onNull=0) { return value.HasValue ? value.Value : onNull; }
		public static decimal ToInt(this decimal? value, decimal onNull = 0) { return value.HasValue ? value.Value : onNull; }

	}
}
