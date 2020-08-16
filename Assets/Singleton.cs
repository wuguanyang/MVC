/*
CreateBy:     wgy
CreateTime:   2020/08/13 15:53:06
Description:  单例模板
*/

using System;
using System.Reflection;

namespace EM {
    //
    public abstract class Singleton<T> where T : class {

        protected static T instance;
        public static T Instance {
            get {
                if (instance == null) {
                    // 先获取所有非public的构造方法
                    ConstructorInfo[] ctors = typeof (T).GetConstructors (BindingFlags.Instance | BindingFlags.NonPublic);
                    // 从ctors中获取无参的构造方法
                    ConstructorInfo ctor = Array.Find (ctors, c => c.GetParameters ().Length == 0);
                    if (ctor == null)
                        throw new Exception ("Non-public ctor() not found!");
                    // 调用构造方法
                    instance = ctor.Invoke (null) as T;
                }
                return instance;
            }
        }
        protected Singleton () {

        }

    }

}
public class XXXManager {
    private static XXXManager instance = null;
    public static XXXManager Instance {
        get {
            if (instance == null) {
                instance = new XXXManager ();
            }
            return instance;
        }
    }
    private XXXManager () { }
}