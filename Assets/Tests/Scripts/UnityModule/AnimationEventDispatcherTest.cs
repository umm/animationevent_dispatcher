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
        [Timeout(10000)]
        public IEnumerator OnDispatchAsObservableTest() {
            SceneManager.LoadScene("Tests/Scenes/Test");
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(15.0f);
            GameObject go = GameObject.Find("Test");
            AnimationEventDispatcher dispatcher = go.GetComponent<AnimationEventDispatcher>();
            yield return dispatcher
                .OnDispatchAsObservable("Test")
                .First()
                .StartAsCoroutine(
                    (_) => {
                        Assert.Pass();
                    },
                    (e) => {
                    }
                );

        }

    }

}
