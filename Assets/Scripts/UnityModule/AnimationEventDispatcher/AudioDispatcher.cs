using GameObjectExtension;
using UniRx;
using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    /// <summary>
    /// 音声再生に関するディスパッチャ
    /// </summary>
    public class AudioDispatcher : Base {

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
        }

        /// <summary>
        /// AnimationEvent の objectReferenceParameter にセットするオーディオ情報
        /// </summary>
        /// <remarks>struct 的な役割だが、 ScriptableObject 型じゃないと objectReferenceParameter にセットできないので class にしている</remarks>
        private class AudioInformation : ScriptableObject {

            /// <summary>
            /// AudioClip のインスタンス
            /// </summary>
            public AudioClip AudioClip;

            /// <summary>
            /// ループ再生するかどうか
            /// </summary>
            public bool ShouldLoop;

        }

        /// <summary>
        /// Unity lifecycle: Start
        /// </summary>
        /// <remarks>イベント発火ストリームを Subscribe する</remarks>
        private void Start() {
            this.StreamAnimationEvent
                .Subscribe(
                    (animationEvent) => {
                        AudioInformation audioInformation = animationEvent.objectReferenceParameter as AudioInformation;
                        if (audioInformation == default(AudioInformation)) {
                            return;
                        }
                        this.PlayInternal(audioInformation.AudioClip, audioInformation.ShouldLoop);
                    }
                );
        }

        /// <summary>
        /// 再生する
        /// </summary>
        /// <remarks>AnimationEvent として呼び出されることを想定している</remarks>
        /// <param name="audioClip">再生対象の AudioClip</param>
        public void Play(AudioClip audioClip) {
            AudioInformation audioInformation = ScriptableObject.CreateInstance<AudioInformation>();
            audioInformation.AudioClip = audioClip;
            audioInformation.ShouldLoop = false;
            this.StreamAnimationEvent
                .OnNext(
                    new AnimationEvent() {
                        objectReferenceParameter = audioInformation,
                    }
                );
        }

        /// <summary>
        /// ループ再生する
        /// </summary>
        /// <remarks>AnimationEvent として呼び出されることを想定している</remarks>
        /// <param name="audioClip">再生対象の AudioClip</param>
        public void PlayLoop(AudioClip audioClip) {
            AudioInformation audioInformation = ScriptableObject.CreateInstance<AudioInformation>();
            audioInformation.AudioClip = audioClip;
            audioInformation.ShouldLoop = true;
            this.StreamAnimationEvent
                .OnNext(
                    new AnimationEvent() {
                        objectReferenceParameter = audioInformation,
                    }
                );
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