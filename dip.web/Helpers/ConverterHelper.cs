using dip.common.Models;
using dip.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dip.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        
            public DipResponse ToDipResponse(DipEntity DipEntity)
            {
                return new DipResponse
                {
                    Id = DipEntity.Id,
                    Plaque = DipEntity.Plaque,
                    Trips = DipEntity.Trips?.Select(t => new TripResponse
                    {
                        EndDate = t.EndDate,
                        Id = t.Id,
                        Qualification = t.Qualification,
                        Remarks = t.Remarks,
                        Source = t.Source,
                        SourceLatitude = t.SourceLatitude,
                        SourceLongitude = t.SourceLongitude,
                        StartDate = t.StartDate,
                        Target = t.Target,
                        TargetLatitude = t.TargetLatitude,
                        TargetLongitude = t.TargetLongitude,
                        TripDetails = t.TripDetails?.Select(td => new TripDetailResponse
                        {
                            Date = td.Date,
                            Id = td.Id,
                            Latitude = td.Latitude,
                            Longitude = td.Longitude
                        }).ToList(),
                        User = ToUserResponse(t.User)
                    }).ToList(),
                    User = ToUserResponse(DipEntity.User)
                };
            }

        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }
    }
    }

