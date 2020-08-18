/*
CreateBy:     #AuthorName#
CreateTime:   #CreateTime#
Description:  
*/

using EM;
using UnityEngine;

public class StoreController : Singleton<StoreController>
{
    public void SaveProp(Prop prop) {
        StoreModel.instance.Add(prop);
    }
    
    public Prop GetProp(int id) {
        return StoreModel.instance.GetProp(id);
    }
}
