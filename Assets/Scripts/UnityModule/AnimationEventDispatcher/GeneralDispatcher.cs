using UniRx;
using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    /// <summary>
    /// 汎用ディスパッチャ
    /// </summary>
    public class GeneralDispatcher : Base {

        /// <summary>
        /// 汎用イベント名: アニメーション開始
        /// </summary>
        private const string ANIMATION_EVENT_NAME_BEGIN = "Begin";

        /// <summary>
        /// 汎用イベント名: アニメーション終了
        /// </summary>
        private const string ANIMATION_EVENT_NAME_END = "End";

        /// <summary>
        /// AnimationEvent を Dispatch する
        /// </summary>
        /// <param name="animationEvent">Inspector で設定する情報を含んだ AnimationEvent</param>
        public void Dispatch(AnimationEvent animationEvent) {
            this.StreamAnimationEvent.OnNext(animationEvent);
        }

        /// <summary>
        /// アニメーション開始を表す AnimationEvent を Dispatch する
        /// </summary>
        public void DispatchBegin() {
            this.StreamAnimationEvent.OnNext(new AnimationEvent() { stringParameter = ANIMATION_EVENT_NAME_BEGIN});
        }

        /// <summary>
        /// アニメーション終了を表す AnimationEvent を Dispatch する
        /// </summary>
        public void DispatchEnd() {
            this.StreamAnimationEvent.OnNext(new AnimationEvent() { stringParameter = ANIMATION_EVENT_NAME_END});
        }

        /// <summary>
        /// Dispatch されたアニメーション開始を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchBeginAsObservable() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_BEGIN);
        }

        /// <summary>
        /// Dispatch されたアニメーション終了を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchEndAsObservable() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_BEGIN);
        }

    }

}
