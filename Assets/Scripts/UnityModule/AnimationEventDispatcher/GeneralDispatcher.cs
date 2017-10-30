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
        private const string ANIMATION_EVENT_NAME_BEGIN_ANIMATION = "BeginAnimation";

        /// <summary>
        /// 汎用イベント名: アニメーション終了
        /// </summary>
        private const string ANIMATION_EVENT_NAME_END_ANIMATION = "EndAnimation";

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
        public void DispatchBeginAnimation() {
            this.StreamAnimationEvent.OnNext(new AnimationEvent() { stringParameter = ANIMATION_EVENT_NAME_BEGIN_ANIMATION});
        }

        /// <summary>
        /// アニメーション終了を表す AnimationEvent を Dispatch する
        /// </summary>
        public void DispatchEndAnimation() {
            this.StreamAnimationEvent.OnNext(new AnimationEvent() { stringParameter = ANIMATION_EVENT_NAME_END_ANIMATION});
        }

        /// <summary>
        /// Dispatch されたアニメーション開始を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchBeginAnimation() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_BEGIN_ANIMATION);
        }

        /// <summary>
        /// Dispatch されたアニメーション終了を表す AnimationEvent を UniRx ストリームとして返す
        /// </summary>
        /// <returns>AnimationEvent のストリーム</returns>
        public IObservable<AnimationEvent> OnDispatchEndAnimation() {
            return this.OnDispatchAsObservable(ANIMATION_EVENT_NAME_BEGIN_ANIMATION);
        }

    }

}
