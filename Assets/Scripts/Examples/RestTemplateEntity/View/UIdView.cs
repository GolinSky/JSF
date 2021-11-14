using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using UnityEngine.UI;

namespace UnityEngine.Examples.RestTemplateEntity.View
{
    public class UIdView : View<string>
    {
        [SerializeField] private Text uIdText;
        
        public override void SetContext(string context)
        {
            uIdText.text = context;
        }
    }
}
