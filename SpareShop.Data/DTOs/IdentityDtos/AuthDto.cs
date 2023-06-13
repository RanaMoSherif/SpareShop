﻿namespace SpareShop.Data.DTOs.IdentityDtos
{
    public class AuthDto : IDtos
    {
        public string Message { get; set; }=string.Empty;
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }
    }
}