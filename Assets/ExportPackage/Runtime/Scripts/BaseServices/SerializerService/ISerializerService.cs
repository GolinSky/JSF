﻿namespace CodeFramework.Runtime.Controllers.BaseServices.SerializerService
{
    public interface ISerializerService 
    {
        string Serialize<T>(T objectData);
        T Deserialize<T>(string jsonData);
    }
}
