using GameObjectExtension;
using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    /// <summary>
    /// 音声再生に関するディスパッチャ
    /// </summary>
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
                    // AudioSource がアタッチされていない場合は AddComponent する
                    this.audioSource = this.gameObject.GetOrAddComponent<AudioSource>();
                    this.audioSource.playOnAwake = false;
                }
                return this.audioSource;
            }
            set {
                this.audioSource = value;
            }
        }

        /// <summary>
        /// 再生する
        /// </summary>
        /// <remarks>AnimationEvent として呼び出されることを想定している</remarks>
        /// <param name="audioClip">再生対象の AudioClip</param>
        public void Play(AudioClip audioClip) {
            this.PlayInternal(audioClip, false);
        }

        /// <summary>
        /// ループ再生する
        /// </summary>
        /// <remarks>AnimationEvent として呼び出されることを想定している</remarks>
        /// <param name="audioClip">再生対象の AudioClip</param>
        public void PlayLoop(AudioClip audioClip) {
            this.PlayInternal(audioClip, true);
        }

        /// <summary>
        /// 実際の再生処理
        /// </summary>
        /// <param name="audioClip">再生対象の AudioClip</param>
        /// <param name="loop">ループ再生する場合は真</param>
        private void PlayInternal(AudioClip audioClip, bool loop) {
            this.AudioSource.clip = audioClip;
            this.AudioSource.loop = loop;
            this.AudioSource.Play();
        }

    }

}