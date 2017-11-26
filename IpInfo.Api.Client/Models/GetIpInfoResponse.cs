﻿namespace IpInfo.Api.Client.Models
{
    public class GetIpInfoResponse
    {
        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
