using dip.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dip.web.Data
{
    public class SeedDb

    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckDipsAsync();


        }


        private async Task CheckDipsAsync()
        {


            if (_dataContext.Dips.Any())
            {
                return;
            }

            _dataContext.Dips.Add(new DipEntity
            {

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



                    },


                    new TripEntity
                    {

                        StartDate= DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.8f,
                        Source= "ITM Fraternidad",
                        Target = "ITM Robledo",
                        Remarks= "conductor muy amable",



                    }


                }



            });

            await _dataContext.SaveChangesAsync();
        }
    }
}


