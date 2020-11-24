using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Ghasedak.ViewModel;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service
{
    public class SponsorService : ISponsor
    {
        private Context _context;
        public SponsorService(Context context)
        {
            _context = context;
        }

        public object GetSponsor(int charityId, int opratorId)
        {
            IQueryable<Sponsor> result = _context.Sponsors.Where(x => x.charityId == charityId && x.opratorId == opratorId);

            var res = result.OrderByDescending(u => u.id).ToList();
            if (res.Count() == 0)

                return new { Data = res, Count = res.Count(), IsError = true, Message = "حامی ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }
        public object AddSponsor(IEnumerable<SponsorViewModel> SponsorViewModel, Oprator oprator)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    List<SponsorPay> sponsorPayUserActivitys = new List<SponsorPay>();

                    foreach (var item in SponsorViewModel)
                    {
                        if (item.sponsorId == 0)
                        {
                            var oldSponsor = _context.Sponsors.FirstOrDefault(x => x.nationalcode == item.nationalcode);
                            Sponsor sponsor = new Sponsor();
                            SponsorPay sponsorPay = new SponsorPay();
                            if (oldSponsor == null)
                            {
                                sponsor.address = item.address;
                                sponsor.birthDate = item.birthDate;
                                sponsor.fullName = item.fullName;
                                sponsor.mobile = item.mobile;
                                sponsor.nationalcode = item.nationalcode;
                                sponsor.phone = item.phone;
                                sponsor.charityId = oprator.charityId;
                                sponsor.opratorId = oprator.id;
                                _context.Sponsors.Add(sponsor);
                                sponsorPay.sponsorId = sponsor.id;
                            }
                            else
                            {
                                sponsorPay.sponsorId = oldSponsor.id;
                            }
                            sponsorPay.charityId = oprator.charityId;
                            sponsorPay.opratorId = oprator.id;
                            sponsorPay.price = item.price;
                            sponsorPay.description = item.description;
                            sponsorPay.deviceCode = item.deviceCode;
                            sponsorPay.terminalCode = item.terminalCode;
                            sponsorPay.recieverCode = item.recieverCode;
                            sponsorPayUserActivitys.Add(sponsorPay);
                            _context.SponsorPays.Add(sponsorPay);
                        }
                        else
                        {
                            SponsorPay sponsorPay = new SponsorPay();
                            sponsorPay.sponsorId = item.sponsorId;
                            sponsorPay.charityId = oprator.charityId;
                            sponsorPay.opratorId = oprator.id;
                            sponsorPay.price = item.price;
                            sponsorPay.description = item.description;
                            sponsorPay.deviceCode = item.deviceCode;
                            sponsorPay.terminalCode = item.terminalCode;
                            sponsorPay.recieverCode = item.recieverCode;
                            sponsorPayUserActivitys.Add(sponsorPay);
                            _context.SponsorPays.Add(sponsorPay);
                        }
                    }
                    _context.SaveChanges();
                    foreach (var item in sponsorPayUserActivitys)
                    {
                         UserActivityAdd userActivityAdd = new UserActivityAdd(_context);

                        userActivityAdd.Add(item.opratorId, item.charityId, DateTime.Now, UserActivityEnum.register, "مشارکت با قیمت  " + item.price + " و شماره پذیرنده " + item.recieverCode +"و شماره پایانه "+item.terminalCode+"و شماره دستگاه "+item.deviceCode+ " ثبت گردید.");
                    }
                    trans.Commit();
                    return new { IsError = false, message = "پرداخت حامیان با موفقیت ثبت گردید." };
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                }
            }
            return new { IsError = true, message = "پرداخت حامیان با مشکل مواجه شده است." };

        }

        public int AddSponsorFromAdmin(Sponsor Sponsor)
        {
            _context.Sponsors.Add(Sponsor);
            _context.SaveChanges();
            return Sponsor.id;
        }



        public PagedList<Sponsor> GetSponsor(int pageId = 1)
        {
            IQueryable<Sponsor> result = _context.Sponsors.OrderByDescending(x => x.id);
            //if (!string.IsNullOrEmpty(filternumber))
            //{
            //    result = result.Where(x => x.number.Contains(filternumber));
            //}
            PagedList<Sponsor> res = new PagedList<Sponsor>(result, pageId, 10);
            return res;
        }
    }
}
