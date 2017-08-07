using UnityEngine;

namespace UnityModule.AnimationEventDispatcher {

    /// <summary>
    /// 汎用ディスパッチャ
    /// </summary>
    public class GeneralDispatcher : Base {

        /// <summary>
        /// AnimationEvent を Dispatch する
        /// </summary>
        /// <param name="animationEvent">Inspector で設定する情報を含んだ AnimationEvent</param>
        public void Dispatch(AnimationEvent animationEvent) {
            this.StreamAnimationEvent.OnNext(animationEvent);
        }

    }

}
