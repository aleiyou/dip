using dip.common;
using dip.common.Enum;
using dip.web.Data.Entities;
using dip.web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dip.web.Data
{
    public class SeedDb

    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _UserHelper;

        public SeedDb(DataContext dataContext,
          
            IUserHelper serHelper)
        {
            _dataContext = dataContext;
            _UserHelper = serHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
        
            await CheckUserAsync("1010", "alex", "Barrera", "alexbarresanchez@gmail.com", "350 634 2747",
                 "Calle Luna Calle Sol", UserType.Admin);

            var Driver = await CheckUserAsync("2020", "juan", "suma", "felipe@gmail.com", "3502334455", "callefin", UserType.Driver);
            var user1 = await CheckUserAsync("2020", "juan", "suma", "juan@gmail.com", "3502334455", "callefin", UserType.User);
           

            await CheckDipsAsync(Driver, user1);



        }

        private async Task<UserEntity> CheckUserAsync(
          string document,
          string firstName,
          string lastName,
          string email,
          string phone,
          string address,
          UserType userType)
        {
            var User = await _UserHelper.GetUserByEmailAsync(email);
            if (User == null)
            {


                User = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,

                };

                await _UserHelper.AddUserAsync(User, "123456");
                await _UserHelper.AddUserToRoleAsync(User, userType.ToString());


            }

            return User;
        }

        private async Task CheckRolesAsync()
        {
            await _UserHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _UserHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _UserHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckDipsAsync(
       

                UserEntity Driver,
                UserEntity user1)
        {
            if (_dataContext.Dips.Any())
            {
                return;
            }

            _dataContext.Dips.Add(new DipEntity
            {
                User = Driver,
                Plaque = "SHU357",

                Trips = new List<TripEntity>

                {
                    new TripEntity
                    {

                        StartDate= DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.8f,
                        Source= "ITM Robledo",
                        Target = "ITM Fraternidad",
                        Remarks= "conductor muy amable",
                        User = user1


                    },


                    new TripEntity
                    {

                        StartDate= DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.8f,
                        Source= "ITM Fraternidad",
                        Target = "ITM Robledo",
                        Remarks= "conductor muy amable",
                         User = user1



                    }


                }



            }) ;

            await _dataContext.SaveChangesAsync();
        }
    }
}


