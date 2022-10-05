﻿using System.Security.Claims;

namespace SubjectManagerAPI.Services
{
    public interface IUserContextService
    {
        int? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public UserContextService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }
        public ClaimsPrincipal User => _httpcontextAccessor.HttpContext?.User;
        public int? GetUserId =>
            User is null ? null : int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
