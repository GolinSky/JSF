﻿using UnityEngine;

namespace CodeFramework.Runtime.Utils.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioHelper : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        public void PlayAudioSource()
        {
            audioSource.Play();
        }
    }
}