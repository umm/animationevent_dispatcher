using System;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityModule.AnimationEventDispatcher {

    public abstract class Base : MonoBehaviour {

        /// <summary>
        /// AnimationEvent Dispatch 時に発火するストリームの実体
        /// </summary>
        private Subject<AnimationEvent> streamAnimationEvent;

        /// <summary>
        /// AnimationEvent Dispatch 時に発火するストリーム
        /// </summary>
        /// <remarks>外から触られたくなかったので protected にしています</remarks>
        protected Subject<AnimationEvent> StreamAnimationEvent {
            get {
                if (this.streamAnimationEvent == default(Subject<AnimationEvent>)) {
                    this.streamAnimationEvent = new Subject<AnimationEvent>();
                }
                return this.streamAnimationEvent;
            }
            set {
                this.streamAnimationEvent = value;
            }
        }

        /// <summary>
        /// Dispatch された AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchAsObservable() {
            return this.StreamAnimationEvent.AsObservable();
        }

        /// <summary>
        /// Dispatch された AnimationEvent をフィルタして UniRx ストリームとして返す
        /// </summary>
        /// <param name="intParameter">フィルタする整数値</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchAsObservable(int intParameter) {
            return this.OnDispatchAsObservable()
                .Where(x => x.intParameter == intParameter);
        }

        /// <summary>
        /// Dispatch された AnimationEvent をフィルタして UniRx ストリームとして返す
        /// </summary>
        /// <param name="floatParameter">フィルタする浮動小数値</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchAsObservable(float floatParameter) {
            return this.OnDispatchAsObservable()
                .Where(x => Mathf.Approximately(x.floatParameter, floatParameter));
        }

        /// <summary>
        /// Dispatch された AnimationEvent をフィルタして UniRx ストリームとして返す
        /// </summary>
        /// <param name="stringParameter">フィルタする文字列値</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchAsObservable(string stringParameter) {
            return this.OnDispatchAsObservable()
                .Where(x => x.stringParameter == stringParameter);
        }

        /// <summary>
        /// Dispatch された AnimationEvent をフィルタして UniRx ストリームとして返す
        /// </summary>
        /// <param name="objectReferenceParameter">フィルタするオブジェクトの参照</param>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchAsObservable(Object objectReferenceParameter) {
            return this.OnDispatchAsObservable()
                .Where(x => x.objectReferenceParameter == objectReferenceParameter);
        }

    }

}