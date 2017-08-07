using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

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

    }

}