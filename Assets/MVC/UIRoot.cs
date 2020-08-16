/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using UnityEngine;

public class UIRoot
{
    static Transform transform;
    static Transform recyclePool;
    static Transform workStation;
    static Transform noticeStation;
    static bool isInit;

    public static void Init() {
        if (transform==null) {
            var obj = Resources.Load<GameObject>("UI/UIRoot");
            transform = GameObject.Instantiate(obj).transform;
        }
        if (recyclePool==null) {
            recyclePool = transform.Find("RecyclePool");
        }
        if (workStation == null) {
            workStation = transform.Find("WorkStation");
        }
        if (noticeStation == null) {
            noticeStation = transform.Find("NoticeStation");
        }
        isInit = true;
    }
    public static void SetParent(Transform window,bool isOpen,bool isTipWindow = false) {
        if (!isInit) {
            Init();
        }
        if (isOpen==true) {
            if (isTipWindow) {
                window.SetParent(noticeStation, false);
            }
            else {
                window.SetParent(workStation, false);
            }
        }
        else {
            window.SetParent(recyclePool, false);
        }
    }
}
