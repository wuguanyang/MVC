/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using UnityEngine;
using EM;
using System.Collections.Generic;

public class WindowManager : Singleton<WindowManager> {

    Dictionary<WindowType, BaseWindow> windowDic = new Dictionary<WindowType, BaseWindow>();
    public WindowManager() { 
        //这是在干嘛
    }
    public BaseWindow OpenWindos(WindowType type) {
        BaseWindow window;
        if (windowDic.TryGetValue(type,out window)) {
            window.Open();
            return window;
        }
        else {
            Debug.LogError(string.Format("Open Error:{0}", type));
            return null;
        }
    }

    public void CloseWindow(WindowType type) {
        BaseWindow window;
        if (windowDic.TryGetValue(type, out window)) {
            window.Close();    
        }
        else {
            Debug.LogError(string.Format("Open Error:{0}", type));
        }
    }
    //根据场景类型预加载
    public void PreLoadWindow(SceneType type) {
        foreach (var item in windowDic.Values) {
            if (item.GetSceneType()==type) {
                item.PreLoad();
            }
        }
    }
    //获取某个场景类型的所有窗口

    //隐藏某个场景类型的所有窗口

    public void HideAllWindow(SceneType type,bool isDestory=false) {
        foreach (var item in windowDic.Values) {
            if (item.GetSceneType() == type) {
                item.Close(isDestory);
            }
        }
    }
}
