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

    }

}