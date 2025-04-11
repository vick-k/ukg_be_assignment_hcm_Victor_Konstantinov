﻿using HCM.Web.Services.Interfaces;

namespace HCM.Web.Services
{
	public class BaseService : IBaseService
	{
		public bool IsGuidValid(string? id, ref Guid parsedGuid)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return false;
			}

			bool isGuidValid = Guid.TryParse(id, out parsedGuid);

			if (!isGuidValid)
			{
				return false;
			}

			return true;
		}
	}
}
