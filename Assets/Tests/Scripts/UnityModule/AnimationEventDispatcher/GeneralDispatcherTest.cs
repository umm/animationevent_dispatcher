using System.Collections;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityModule.AnimationEventDispatcher;

namespace Tests.UnityModule {

    public class GeneralDispatcherTest {

        [UnityTest]
        public IEnumerator OnDispatchAsObservableTest() {
            SceneManager.LoadScene("Tests/Scenes/Test");
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            GameObject go = GameObject.Find("General");
            GeneralDispatcher dispatcher = go.GetComponent<GeneralDispatcher>();
            bool resultGeneral = false;
            yield return dispatcher
                .OnDispatchAsObservable("Test")
                .Timeout(System.TimeSpan.FromSeconds(5))
                .First()
                .StartAsCoroutine(
                    (_) => {
                        resultGeneral = true;
                    },
                    (e) => {
                    }
                );
            Assert.IsTrue(resultGeneral, "Dispatch されたかどうか");
            bool resultBegin = false;
            yield return dispatcher
                .OnDispatchBeginAnimation()
                .Timeout(System.TimeSpan.FromSeconds(5))
                .First()
                .StartAsCoroutine(
                    (_) => {
                        resultBegin = true;
                    },
                    (e) => {
                    }
                );
            Assert.IsTrue(resultBegin, "BeginAnimation が Dispatch されたかどうか");
            bool resultEnd = false;
            yield return dispatcher
                .OnDispatchEndAnimation()
                .Timeout(System.TimeSpan.FromSeconds(5))
                .First()
                .StartAsCoroutine(
                    (_) => {
                        resultEnd = true;
                    },
                    (e) => {
                    }
                );
            Assert.IsTrue(resultEnd, "EndAnimation が Dispatch されたかどうか");
        }

    }

}
