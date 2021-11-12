using System;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Array;

namespace UnityEngine.Examples.ServerConfigurationEntity.Model
{
    [CreateAssetMenu(fileName = "ServerConfigurationsModel", menuName = "Model/ServerConfigurationsModel")]
    public class ServerConfigurationsModel : Model<ServerName,ServerConfigurationModel,ServerConfigurationInternalData>
    {
        private void OnValidate()
        {
            Debug.Log("OnValidate");
            list.ForEach(x=>x.Value.Validate());
        }
    }

    public enum ServerName
    {
        Default = 0,
    }

    [Serializable]
    public class ServerConfigurationInternalData : InternalData<ServerName, ServerConfigurationModel>
    {
    }

    [Serializable]
    public class ServerConfigurationModel
    {
        [SerializeField] private string serverAddress;
        [SerializeField] private UriKind uriKind;
        private Uri uri;

        public Uri Uri
        {
            get
            {
                if (uri == null)
                {
                    Validate();
                }

                return uri;
            }
        }

        public void Validate()
        {
            if (Uri.IsWellFormedUriString(serverAddress, uriKind))
            {
                if (Uri.TryCreate(serverAddress, uriKind, out var result))
                {
                    uri = result;
                }
                else
                {
                    Debug.LogError($"Failed to create uri for {serverAddress}");
                }
            }
            else
            {
                Debug.LogError($"Not Well Formed Uri String uri for {serverAddress}");
            }
            
       
           
        }
    }
}
