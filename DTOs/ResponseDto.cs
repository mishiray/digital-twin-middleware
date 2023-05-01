using System;
using System.Collections.Generic;

namespace DigitalTwinMiddleware.DTOs
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
    public class AuthIOTResponse
    {
        public string Token { get; set; }
        public string IOTDeviceId { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public class ApiTokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
