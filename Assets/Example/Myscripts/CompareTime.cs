using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //DateTime 日期时间类型

public class CompareTime : MonoBehaviour {

    #region 单例 , 获取单例：CompareTime J= CompareTime.Instance;
    static CompareTime instance;

    public static CompareTime Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType (typeof (CompareTime)) as CompareTime;
                if (instance == null) {
                    GameObject obj = new GameObject ("CompareTime");
                    instance = obj.AddComponent<CompareTime> ();
                }
            }
            return instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start () { }

    /// <summary>
    /// 时间计算（每次请求广告之前比较一下，时间大于等于1天清空次数=10），如果次数大于0那么保存时间-1；然后记录下上一次点击后的时间
    /// </summary>
    public void CompareTimeFun () {

        // 当前时间
        DateTime date1 = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00, DateTimeKind.Local);
        // 倒数第二个缓存时间
        // int saveTime=GetLast2Time();

        //备注：if（次数足够）{次数-1}
        if (LoadTimes () > 0) {
            SaveTimesLess ();
        }

        //备注：
        // if ((上次登陆时间数组的个数)>=2&&(当前时间-上次登陆时间数组[倒数第二个])>=1)
        // {重置次数10;  删除倒数第二个存储时间;}
        if (PlayerPrefsX.GetIntArray ("SaveTime").Length >= 2 && (new TimeSpan (date1.Ticks).Days - GetLast2Time ()) >= 1) {
            ClearTimes ();
            RemoveLast2Time ();
        }
    }
    /// <summary>
    /// 获得倒数第二个存储时间
    /// </summary>
    public int GetLast2Time () {
        return PlayerPrefsX.GetIntArray ("SaveTime") [(PlayerPrefsX.GetIntArray ("SaveTime").Length - 2)];
    }
    /// <summary>
    /// 删除倒数第二个存储时间
    /// </summary>
    public void RemoveLast2Time () {
        int[] savetime = PlayerPrefsX.GetIntArray ("SaveTime");
        List<int> strList = new List<int> (savetime);
        strList.RemoveAt ((PlayerPrefsX.GetIntArray ("SaveTime").Length - 2)); //添加元素
        int[] strArray = strList.ToArray (); //strArray=[str0,str1,str2]

        PlayerPrefsX.SetIntArray ("SaveTime", strArray);
    }

    /// <summary>
    /// 保存限制次数-1
    /// </summary>
    public void SaveTimesLess () {
        PlayerPrefs.SetInt ("Times", LoadTimes () - 1);
    }
    /// <summary>
    /// 读取限制次数,如果没有次数这个变量，就创建一个十次;如果次数为空那么上次保存时间也为空
    /// </summary>
    public int LoadTimes () {
        if (PlayerPrefs.HasKey ("Times")) {
            return PlayerPrefs.GetInt ("Times");
        } else {
            // SaveLastTime ();

            PlayerPrefs.SetInt ("Times", 10);
            return PlayerPrefs.GetInt ("Times");
        }

    }
    /// <summary>
    /// 删除限制次数=10,保存上次时间
    /// </summary>
    public void ClearTimes () {
        PlayerPrefs.SetInt ("Times", 10);
        SaveLastTime ();
    }
    /// <summary>
    /// 保存上次登录时候记录的时间
    /// </summary>
    private void SaveLastTime () {
        DateTime date1 = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00, DateTimeKind.Local);
        int[] savetime = PlayerPrefsX.GetIntArray ("SaveTime");
        List<int> strList = new List<int> (savetime);
        strList.Add (new TimeSpan (date1.Ticks).Days); //添加元素
        int[] strArray = strList.ToArray (); //列表转数组

        PlayerPrefsX.SetIntArray ("SaveTime", strArray);
    }
}