using System.Collections;
using System.Collections.Generic;
using GameObjectExtension;
using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    public class AudioDispatcher : MonoBehaviour {

        /// <summary>
        /// AudioSource の実体
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// AudioSource
        /// </summary>
        private AudioSource AudioSource {
            get {
                if (this.audioSource == default(AudioSource)) {
                    this.audioSource = this.gameObject.GetOrAddComponent<AudioSource>();
                }
                return this.audioSource;
            }
            set {
                this.audioSource = value;
            }
        }

        public void Play(AudioClip audioClip) {
            this.PlayInternal(audioClip, false);
        }

        public void PlayLoop(AudioClip audioClip) {
            this.PlayInternal(audioClip, true);
        }

        private void PlayInternal(AudioClip audioClip, bool loop) {
            this.AudioSource.clip = audioClip;
            this.AudioSource.loop = loop;
            this.AudioSource.Play();
        }

    }

}