using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
/// <summary>
/// 读取json，设置广告id
/// </summary>
public class ReadJsonSetId : MonoBehaviour {

    #region 单例 , ReadJsonSetId J= ReadJsonSetId.Instance;
    static ReadJsonSetId instance;

    public static ReadJsonSetId Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType (typeof (ReadJsonSetId)) as ReadJsonSetId;
                if (instance == null) {
                    GameObject obj = new GameObject ("ReadJsonSetId");
                    instance = obj.AddComponent<ReadJsonSetId> ();
                }
            }
            return instance;
        }
    }
    #endregion

    public string jsonTxt = null;

    // Start is called before the first frame update
    void Start () {

    }

    /// <summary>
    /// 读取json
    /// </summary>
    public void ReadJsonEndSetIdFun () {
        var N = JSON.Parse (jsonTxt);
        string banner = N[Application.identifier][Application.companyName]["banner"].Value;
        string intersititial = N[Application.identifier][Application.companyName]["intersititial"].Value;
        string reward = N[Application.identifier][Application.companyName]["reward"].Value;
        string full = N[Application.identifier][Application.companyName]["full"].Value;
        string start = N[Application.identifier][Application.companyName]["start"].Value;
        SetId (banner, intersititial, reward, full, start);
    }
    /// <summary>
    /// 设置广告id
    /// </summary>
    public void SetId (string banner, string intersititial, string reward, string full, string start) {
        GameObject exampleCanvas = GameObject.Find ("Canvas");
        ADTYPE obj = new ADTYPE { banner = banner, intersititial = intersititial, reward = reward, full = full, start = start };
        exampleCanvas.SendMessage ("SetId", obj);
    }
}
public class ADTYPE {
    public ADTYPE () { }
    public string banner { get; set; }
    public string intersititial { get; set; }
    public string reward { get; set; }
    public string full { get; set; }
    public string start { get; set; }
}