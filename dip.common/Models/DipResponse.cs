using System;
using System.Collections.Generic;
using System.Text;

namespace dip.common.Models
{
    public class DipResponse

    {

        public int Id { get; set; }

        public string Plaque { get; set; }

        public List<TripResponse> Trips { get; set; }

        public UserResponse User { get; set; }

        
    }
}
