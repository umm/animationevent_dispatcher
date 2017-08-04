using System.Collections;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityModule.AnimationEventDispatcher;

namespace Tests.UnityModule {

    public class AnimationEventDispatcherTest {

        [UnityTest]
        public IEnumerator OnDispatchAsObservableTest() {
            SceneManager.LoadScene("Tests/Scenes/Test");
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            GameObject go = GameObject.Find("Test");
            GeneralDispatcher dispatcher = go.GetComponent<GeneralDispatcher>();
            bool result = false;
            yield return dispatcher
                .OnDispatchAsObservable("Test")
                .Timeout(System.TimeSpan.FromSeconds(5))
                .First()
                .StartAsCoroutine(
                    (_) => {
                        result = true;
                    },
                    (e) => {
                    }
                );
            Assert.IsTrue(result, "Dispatch されたかどうか");
        }

    }

}
