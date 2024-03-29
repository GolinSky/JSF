﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers
{
    [Serializable]
    public class DictionaryWrapper<TKey, TValue>
    {
        [SerializeField] private List<KeyValue<TKey,TValue>> keyValue;

        private Dictionary<TKey, TValue> dictionary;

        public Dictionary<TKey, TValue> Dictionary => dictionary ??= UnityDictionaryFactory.Build(keyValue);
    }
}