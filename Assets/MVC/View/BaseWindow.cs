/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  窗口实例
*/

using UnityEngine;
using UnityEngine.UI;
//窗体类型
public enum WindowType {
    LoginWindow,
    StoreWindow,
    TipWindow,
}
//场景类型：窗体属于哪个场景，根据场景提供预加载窗体
public enum SceneType { 
    None,
    Login,
    Battle,
}
public class BaseWindow
{
    protected SceneType sceneType;//场景类型   
    protected WindowType selfType;//窗体类型
    protected Transform transform;//窗体的节点
    protected string resName;//资源名称
    protected bool resident;//是否常驻：如果是常驻的话，关闭就是不激活，如果不是常驻：关闭就是销毁
    protected bool visible; //是否可见：当前窗体的可见状态
                            //ui控件
    protected Button[] buttonList;//按钮列表

    //--------给子类提供的接口：
    //窗体初始化
    protected virtual void Awake() {
        buttonList = transform.GetComponentsInChildren<Button>(true);
        RegisterUIEvent();
    }
    //ui事件的注册
    protected virtual void RegisterUIEvent() { }
    //添加监听游戏事件 todo On？
    protected virtual void OnAddListener() { }
    //移除游戏事件
    protected virtual void OnRemoveListener() { }
    //每次打开
    protected virtual void OnEnable() { }
    //每次关闭
    protected virtual void OnDisable() { }
    //每帧更新
    public virtual void Update(float deltaTime) { }


    //----给windowmanager提供的借口
    //打开
    public void Open() {
        if (transform==null) {
            if (Creat()) {
                Awake();
            }
        }
        if (transform.gameObject.activeSelf==false) {
            UIRoot.SetParent(transform, true, selfType == WindowType.TipWindow);
            transform.gameObject.SetActive(true);
            visible = true;
            OnEnable();//调用激活时候的事件
            OnAddListener();//添加事件
        }
    }
    //关闭
    public void Close(bool isDestory=false) {
        if (transform.gameObject.activeSelf==true) {
            OnRemoveListener();
            OnDisable();
            if (!isDestory) {
                if (resident) {
                    transform.gameObject.SetActive(false);
                    UIRoot.SetParent(transform, false, false);
                }
                else {
                    GameObject.Destroy(transform.gameObject);
                    transform = null;
                }
            }
            else {
                GameObject.Destroy(transform.gameObject);
                transform = null;
            } 
            visible = false;
        }

    }
    //预加载
    public void PreLoad() {
        if (transform==null) {
            if (Creat()) {
                Awake();
            }
        }
    }

    public SceneType GetSceneType() { return sceneType; }

    public WindowType GetWindowType() { return selfType; }

    public Transform GetRoot() { return transform; }

    public bool IsVisiable() { return visible; }

    public bool IsResident() { return resident; }

    //-----内部

    private bool Creat() {
        if (string.IsNullOrEmpty(resName)) {
            return false;
        }
        if (transform==null) {
            var obj = Resources.Load<GameObject>(resName);
            if (obj==null) {
                Debug.LogError(string.Format("未找到预制件{0}", selfType));
            }
            transform = GameObject.Instantiate(obj).transform;
            transform.gameObject.SetActive(false);
            UIRoot.SetParent(transform, false, selfType== WindowType.TipWindow);//==
        }
        return true;
    }
    

}
