using System.Collections;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityModule;

namespace Tests.UnityModule {

    public class AnimationEventDispatcherTest {

        [UnityTest]
        public IEnumerator OnDispatchAsObservableTest() {
            SceneManager.LoadScene("Tests/Scenes/Test");
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            GameObject go = GameObject.Find("Test");
            AnimationEventDispatcher dispatcher = go.GetComponent<AnimationEventDispatcher>();
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
