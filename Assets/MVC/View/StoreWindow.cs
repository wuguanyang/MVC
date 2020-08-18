/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using UnityEngine;

public class StoreWindow : BaseWindow {
    public StoreWindow() {
        resName = "UI/Window/StoreWindow";
        resident = true;
        selfType = WindowType.StoreWindow;
        sceneType = SceneType.Login;
    }

    protected override void Awake() {
        base.Awake();
    }

    protected override void OnAddListener() {
        base.OnAddListener();
    }

    protected override void OnDisable() {
        base.OnDisable();
    }

    protected override void OnEnable() {
        base.OnEnable();
    }

    protected override void OnRemoveListener() {
        base.OnRemoveListener();
    }

    protected override void RegisterUIEvent() {
        base.RegisterUIEvent();
        foreach (var item in buttonList) {
            switch (item.name) {
                case "BuyButton":
                    item.onClick.AddListener(OnBuyButtonClick);
                    break;

            }
        }

    }

    public override void Update(float deltaTime) {
        base.Update(deltaTime);
        if (Input.GetKeyDown(KeyCode.C)) {
            Close();
        }
    }

    void OnBuyButtonClick() {
        Debug.Log("BuyButton 点击了！");
        //StoreController.Instance.SaveProp(new Prop ());
        //var prop = StoreController.Instance.GetProp(10);
    }
}
