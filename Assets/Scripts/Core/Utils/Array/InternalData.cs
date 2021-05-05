using System;
using UnityEngine;

namespace Core.Utils.Array
{
    [Serializable]
    public class InternalData<Id, InternalValue>
    {
        [Header("New Preset:")]
        [Space(1)]
        [SerializeField] protected Id id;
        [SerializeField] protected InternalValue value;
        
        public Id ID => id;
        public InternalValue Value => value;
    }
}