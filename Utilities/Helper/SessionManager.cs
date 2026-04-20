using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Utilities.Helper
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }
        public static void Login(this User u) => CurrentUser = u;
        public static void Logout() => CurrentUser = null;
        public static bool IsLoggedIn() => CurrentUser != null;
        public static bool IsAdmin() => CurrentUser?.IsAdmin ?? false;
    }
}
