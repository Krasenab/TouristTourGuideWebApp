using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;


namespace TouristTourGuide.Infrastrucutre
{
    public class OnlineUsersMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly string _cookieName;
        private static readonly ConcurrentDictionary<string, bool> AllKeys = new ConcurrentDictionary<string, bool>();
        private readonly int _lastActivityMinutes;
        public OnlineUsersMiddleware(RequestDelegate next, string cookieName = "IsOnline", int lastActivityMinutes = 10)
        {
            this._cookieName = cookieName;
                this._next = next;
            this._lastActivityMinutes = lastActivityMinutes;
        }
        public Task InvokeAsync(HttpContext context,IMemoryCache memoryCache) 
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(this._cookieName,out string userId))
                {
                    // first login after being offline
                    userId = context.User.GetCurrentUserId()!;
                    context.Response.Cookies.Append(this._cookieName, userId, new CookieOptions() { HttpOnly = true,MaxAge=TimeSpan.FromDays(30) });


                }
                memoryCache.GetOrCreate(userId, cacheEntry => 
                {
                    if (!AllKeys.TryAdd(userId,true))
                    {
                        // Adding key failed to CD so we have ann err;
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(_lastActivityMinutes);

                        cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
                    }
                    return string.Empty;
                });
            }
            else
            {
                if (context.Request.Cookies.TryGetValue(this._cookieName,out  string userId))
                {
                    if (!AllKeys.TryRemove(userId,out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }
                    context.Response.Cookies.Delete(this._cookieName);    
                }
            }
            return this._next(context);
           
        }
        public static bool CheckIfUserIsOnline(string userId) 
        {
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            return success && valueTaken;
        }
        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyStr = (string)key;  // userId
            if (AllKeys.TryRemove(keyStr, out _))
            {
                AllKeys.TryUpdate(keyStr, false, true);
            }
        }

    }
}
