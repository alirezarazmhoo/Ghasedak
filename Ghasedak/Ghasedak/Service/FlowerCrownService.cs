using Ghasedak.DAL;
using Ghasedak.Models;
using Ghasedak.Service.Interface;
using Ghasedak.Utility;
using Ghasedak.ViewModel;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghasedak.Service
{
    public class FlowerCrownService : IFlowerCrown
    {
        private Context _context;
        public FlowerCrownService(Context context)
        {
            _context = context;
        }

        public object GetFlowerCrown(int charityId)
        {
            IQueryable<FlowerCrown> result = _context.FlowerCrowns.Where(x => x.charityId == charityId);

            var res = result.OrderByDescending(u => u.id).ToList();
            if (res.Count() == 0)

                return new { Data = res, Count = res.Count(), IsError = true, Message = "تاج گل ثبت نشده است" };
            else
                return new { Data = res, Count = res.Count(), IsError = false, Message = "" };
        }

        public int AddFlowerCrownFromAdmin(FlowerCrown FlowerCrown)
        {
            _context.FlowerCrowns.Add(FlowerCrown);
            _context.SaveChanges();
            return FlowerCrown.id;
        }



        public PagedList<FlowerCrown> GetFlowerCrown(int charityId, int pageId = 1, long filterprice = 0)
        {
            IQueryable<FlowerCrown> result = _context.FlowerCrowns.Include(x => x.FlowerCrownType).Where(x => x.charityId == charityId).OrderByDescending(x => x.id);
            if (filterprice != 0)
            {
                result = result.Where(x => x.price == filterprice);
            }
            PagedList<FlowerCrown> res = new PagedList<FlowerCrown>(result, pageId, 10);
            return res;
        }

        public FlowerCrownAdminViewModel GetDataForAdmin(int id)
        {
            var FlowerCrown = _context.FlowerCrowns.Include(x => x.FlowerCrownType).FirstOrDefault(x => x.id == id);
            var oprator = _context.Oprators.FirstOrDefault(x => x.id == FlowerCrown.opratorId);
            var Donator = _context.Donators.FirstOrDefault(x => x.id == FlowerCrown.donatorId);
            var Inturducer = _context.Donators.FirstOrDefault(x => x.id == FlowerCrown.IntroducedId);
            var DeceasedName = _context.DeceasedNames.FirstOrDefault(x => x.id == FlowerCrown.deceasedNameId);
            FlowerCrownAdminViewModel FlowerCrownAdminViewModel = new FlowerCrownAdminViewModel();
            FlowerCrownAdminViewModel.flowerCrown = FlowerCrown;
            FlowerCrownAdminViewModel.oprator = oprator;
            FlowerCrownAdminViewModel.donator = Donator;
            FlowerCrownAdminViewModel.introduced = Inturducer;
            FlowerCrownAdminViewModel.deceasedName = DeceasedName;
            return FlowerCrownAdminViewModel;
        }
        public object AddFlowerCrown(FlowerCrownViewModelApi item, Oprator oprator)
        {
            
                try
                {
                    FlowerCrown flowerCrown = new FlowerCrown();
                    var DeceasedName = _context.DeceasedNames.FirstOrDefault(x => x.guidDeceasedName == item.guidDeceasedName);
                    if (DeceasedName == null)
                    {
                        return new { IsError = true, message = "متوفی قبلا ثبت نشده است." };

                    }
                    var Donator = _context.Donators.FirstOrDefault(x => x.guidDonator == item.guidDonator);
                    if (Donator == null)
                    {
                        return new { IsError = true, message = "اهدا کننده قبلا ثبت نشده است." };

                    }
                     var Introduced = _context.Donators.FirstOrDefault(x => x.guidDonator == item.guidIntroduced);
                    if (Introduced == null)
                    {
                        return new { IsError = true, message = "معرف قبلا ثبت نشده است." };

                    }
                    if (_context.FlowerCrowns.Any(x => x.deceasedNameId == DeceasedName.id && x.IntroducedId == Introduced.id && x.donatorId == Donator.id && x.CeremonyType == item.CeremonyType))
                        return new { IsError = true, message = "تاج گل قبلا ثبت شده است." };
                    flowerCrown.charityId = oprator.charityId;
                    flowerCrown.opratorId = oprator.id;
                    flowerCrown.flowerCrownTypeId = item.flowerCrownTypeId;
                    flowerCrown.registerDate = item.registerDate;
                    flowerCrown.price = item.price;
                    flowerCrown.CeremonyType = item.CeremonyType;
                    flowerCrown.donatorId = Donator.id;
                    flowerCrown.IntroducedId = Introduced.id;
                    flowerCrown.deceasedNameId = DeceasedName.id;
                    _context.FlowerCrowns.Add(flowerCrown);
                    _context.SaveChanges();
                    UserActivityAdd userActivityAdd = new UserActivityAdd(_context);

                    userActivityAdd.Add(oprator.id, oprator.charityId, DateTime.Now, UserActivityEnum.register, "تاج گل با نام متوفی  " + flowerCrown.DeceasedName.deceasedFullName + " با قیمت " + flowerCrown.price + " ثبت گردید.");
                    
                    return new { IsError = false, message = "تاج گل با موفقیت ثبت گردید." };
                }
                catch (Exception ex)
                {
            return new { IsError = true, message = "ثبت تاج گل با مشکل مواجه شده است." };

                }
            

        }

    }
}
