/*
CreateBy:     wgy
CreateTime:   2020/08/13 15:53:06
Description:  继承MonoBehaviour的单例模板
*/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EM {

    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour {

        protected static T instance;

        protected static GameObject instanceGameObject;

        public static T Instance {
            get {
                if (instanceGameObject==null) {
                    instanceGameObject = new GameObject (typeof (T).ToString ());
                    instance = instanceGameObject.AddComponent<T> ();
                    DontDestroyOnLoad (instanceGameObject);
                }
                return instance;
            }
        }
        protected virtual void OnDestroy () {
            instance = null;
            instanceGameObject = null;
        }
    }

}/*、ds*/