using System.Collections;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityModule.AnimationEventDispatcher;

namespace Tests.UnityModule {

    public class AudioDispatcherTest {

        [UnityTest]
        public IEnumerator OnDispatchAsObservableTest() {
            SceneManager.LoadScene("Tests/Scenes/Test");
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
//            GameObject go = GameObject.Find("Audio");
//            AudioDispatcher dispatcher = go.GetComponent<AudioDispatcher>();
//            bool result = false;
//            yield return Observable.EveryUpdate().Delay(System.TimeSpan.FromMilliseconds(600)).StartAsCoroutine()
//                .OnDispatchAsObservable("Test")
//                .Timeout(System.TimeSpan.FromSeconds(5))
//                .First()
//                .StartAsCoroutine(
//                    (_) => {
//                        result = true;
//                    },
//                    (e) => {
//                    }
//                );
//            Assert.IsTrue(result, "Dispatch されたかどうか");
        }

    }

}
