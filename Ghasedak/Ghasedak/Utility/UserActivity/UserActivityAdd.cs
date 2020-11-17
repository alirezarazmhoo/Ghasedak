using Ghasedak.DAL;
using Ghasedak.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Utility
{
    public static class UserActivityAdd
    {
        private static Context sContext;

        public static void init(Context context)
        {
            sContext = context;
        }
        public static void Add(int? opratorId, int charityId, DateTime date, UserActivityEnum status, string description)
        {
            UserActivity UserActivity = new UserActivity();
            UserActivity.opratorId = opratorId;
            UserActivity.charityId = charityId;
            UserActivity.date = date;
            UserActivity.status = status;
            UserActivity.description = description;
            sContext.UserActivities.Add(UserActivity);
            sContext.SaveChanges();
        }

    }
}
