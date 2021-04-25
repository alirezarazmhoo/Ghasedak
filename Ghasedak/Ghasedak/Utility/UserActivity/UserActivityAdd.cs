using Ghasedak.DAL;
using Ghasedak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Utility
{
    public class UserActivityAdd
    {
        private static Context sContext;

        public UserActivityAdd(Context context)
        {
            sContext = context;
        }
        public void Add(int? opratorId, int charityId, DateTime date, UserActivityEnum status, string description, string json = "", string nameTable = "", string op = "")
        {
            UserActivity UserActivity = new UserActivity();
            UserActivity.opratorId = opratorId;
            UserActivity.charityId = charityId;
            UserActivity.date = date;
            UserActivity.status = status;
            UserActivity.description = description;
            sContext.UserActivities.Add(UserActivity);
            AllTableData allTableData = new AllTableData();
            allTableData.registerDate = PersianCalendarDate.PersianCalendarResult(DateTime.Now);
            allTableData.json = json;
            allTableData.op = op;
            allTableData.nameTable = nameTable;
            sContext.AllTableDatas.Add(allTableData);
            sContext.SaveChanges();
        }
    }
}
