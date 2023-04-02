using System;
using System.Collections.Generic;
using System.Linq;
using CodeFramework.Runtime.Utils.Parse;
using UnityEngine;

namespace CodeFramework.Runtime.Utils.Array
{
    [Serializable]
    public class DataList<Value, InternalValue, Id> where Value : InternalData<Id, InternalValue>
    {
        [SerializeField] protected List<Value> list;
        private readonly Dictionary<Id, InternalValue> dictionary = new Dictionary<Id, InternalValue>();

        protected Dictionary<Id, InternalValue> Dictionary
        {
            get
            {
                if (dictionary.IsNullOrEmpty())
                {
                    list.ForEach(x => dictionary.Add(x.ID, x.Value));
                }

                return dictionary;
            }
        }
        
        protected bool IsInvalidList()
        {
            if (list.IsNullOrEmpty())
            {
                Debug.LogWarning($"List is null or empty");
                Debug.LogWarning($"Cancel validation");
                return true;
            }

            return false;
        }

        public bool IsValidList => !list.IsNullOrEmpty();

        public virtual void SortById()
        {
            if (IsInvalidList())
            {
                return;
            }

            list = list.OrderByDescending(x => x.ID).ToList();
        }

        public virtual void Validate()
        {
            if (IsInvalidList())
            {
                return;
            }
            var dict = new Dictionary<Id, Value>();
            bool hasSameValues = false;
            foreach (var value in list)
            {
                if (dict.ContainsKey(value.ID))
                {
                    Debug.Log($"Found same element with id {value.ID}");
                    hasSameValues = true;
                    continue;
                }
                dict.Add(value.ID, value);
            }

            if (hasSameValues)
            {
                Debug.Log($"Initial validating");
                list = new System.Collections.Generic.List<Value>(dict.Values);
                Debug.Log($"Validation is finished");

            }
            else
            {
                Debug.Log($"There is no errors");
            }
        }

        public bool HasKey(Id id) => Dictionary.ContainsKey(id);

        private bool HasValue(InternalValue value) => Dictionary.ContainsValue(value);

        public InternalValue GetById(Id id)
        {
            if (HasKey(id))
            {
                return Dictionary[id];
            }

            Debug.LogWarning($"{typeof(Id)} not found in dictionary: {typeof(Id)}".Paint(Color.green));
            return Dictionary.FirstOrDefault().Value;
        }

        public Id GetByValue(InternalValue value)
        {
            if (HasValue(value))
            {
                foreach (var valuePair in dictionary)
                {
                    if (valuePair.Value.Equals(value))
                    {
                        return valuePair.Key;
                    }
                }
            }

            return Dictionary.FirstOrDefault().Key;
        }

        public Dictionary<Id, InternalValue>.KeyCollection Keys => Dictionary.Keys;
        public Dictionary<Id, InternalValue>.ValueCollection Values => Dictionary.Values;
    }
}