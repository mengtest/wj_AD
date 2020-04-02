using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //DateTime 日期时间类型
/// <summary>
/// AD流程管理
/// </summary>
public class ADManage : MonoBehaviour {
    /// <summary>
    /// 单利对象
    /// </summary>
    public HttpGetJson httpGetJsonIns;
    public ReadJsonSetId readJsonSetIdIns;
    /**=======StartCoroutine顺序协程=======
     * @param  
     *
     */
    void Start () {
        SaveLastTime ();
        // StartCoroutine (Init ());
    }

    IEnumerator Init () {
        yield return StartCoroutine (init1 ());
        Debug.Log ("“init1 finish“");
        yield return StartCoroutine (init2 ());
        Debug.Log ("“init2 finish“");
        yield return StartCoroutine (init3 ());
        Debug.Log ("“init3 finish“");
    }
    /// <summary>
    /// http请求json
    /// </summary>
    /// <returns></returns>
    IEnumerator init1 () {
        yield return new WaitForSeconds (0.001f); //
        httpGetJsonIns = HttpGetJson.Instance;
        yield return StartCoroutine (httpGetJsonIns.HttpGetJsonFun ());
    }
    /// <summary>
    /// 读取json并设置广告id
    /// </summary>
    /// <returns></returns>
    IEnumerator init2 () {
        yield return new WaitForSeconds (0.001f); //
        readJsonSetIdIns = ReadJsonSetId.Instance;
        readJsonSetIdIns.ReadJsonEndSetIdFun ();
        //消息调用其他脚本的数据
    }
    IEnumerator init3 () {
        yield return new WaitForSeconds (0.001f); //
        // StopAllCoroutines ();//释放协程
    }

    /// <summary>
    /// 保存上次登录时候记录的时间
    /// </summary>
    private void SaveLastTime () {
        DateTime date1 = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00, DateTimeKind.Local);
        int[] savetime = PlayerPrefsX.GetIntArray ("SaveTime");
        List<int> strList = new List<int> (savetime);
        strList.Add (new TimeSpan (date1.Ticks).Days); //添加元素
        int[] strArray = strList.ToArray ();  //列表转数组

        PlayerPrefsX.SetIntArray ("SaveTime", strArray);
    }
}