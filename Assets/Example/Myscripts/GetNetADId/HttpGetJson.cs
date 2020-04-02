using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// http请求获得json文件
/// </summary>
public class HttpGetJson : MonoBehaviour {
    #region 单例 , 获取单例：HttpGetJson J= HttpGetJson.Instance;
    static HttpGetJson instance;

    public static HttpGetJson Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType (typeof (HttpGetJson)) as HttpGetJson;
                if (instance == null) {
                    GameObject obj = new GameObject ("HttpGetJson");
                    instance = obj.AddComponent<HttpGetJson> ();
                }
            }
            return instance;
        }
    }
    #endregion

    private string address = "http://www.wuxiankongbu.com.cn/ad/ad.json";
    // Start is called before the first frame update
    void Start () {
        // StartCoroutine (HttpGetJsonFun ());
    }

    /// <summary>
    /// http请求获得json文件
    /// </summary>
    public IEnumerator HttpGetJsonFun () {
        using (UnityWebRequest webRequest = UnityWebRequest.Get (address)) {

            yield return webRequest.SendWebRequest ();

            if (webRequest.isHttpError || webRequest.isNetworkError) {
                Debug.LogError (webRequest.error + "\n" + webRequest.downloadHandler.text);
                //TODO ReView Test
                Debug.Log ("'=====================超时这里换个网址重新请求======================='");
                address = "http://zhushenkongjian.com/ad/ad.json";
                yield return StartCoroutine (HttpGetJsonFun ());
                // StopCoroutine(HttpGetJsonFun());
            } else {
                ReadJsonSetId readJsonSetIdIns = ReadJsonSetId.Instance;
                readJsonSetIdIns.jsonTxt = webRequest.downloadHandler.text;
            }
        }

    }

}