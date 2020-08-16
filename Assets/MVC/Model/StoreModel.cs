/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  model示例： 商店数据
*/

using EM;
using System.Collections.Generic;
using UnityEngine;

public class StoreModel : Singleton<StoreModel>
{
    Dictionary<int, Prop> dict = new Dictionary<int, Prop>();
    
    //一些增删查改的接口
    public void Add(Prop prop) {
        if (!dict.ContainsKey(prop.id)) {
            dict.Add(prop.id,prop);
        }
    }
}
//道具
public class Prop {
    public int id;
    public string name;
    public string describe;
    public int price;
}