﻿using CodeFramework.Runtime.Controllers.BaseServices;

namespace CodeFramework.Runtime.Controllers.ConfigurationService
{
    public static class Configuration //can use smth which data can be changed  - create scriptable object and set default settings
    {
        public const string GameContextName = nameof(GameContext);
        public const string ProjectSettingsName = "ProjectSettings";


        public static IRepository<string> GetDefaultRepository()
        {
            return new ResourceRepository();
        }
    }
}
