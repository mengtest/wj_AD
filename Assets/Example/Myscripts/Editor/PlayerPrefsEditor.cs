using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DC
{
    public class PlayerPrefsEditor : EditorWindow
    {
        [MenuItem("DC/PlayerPrefs/DeleteAll")]
        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [MenuItem("DC/PlayerPrefs/DeleteTarget")]
        public static void DeleteTarget()
        {
            PlayerPrefs.DeleteKey(Selection.activeGameObject.name);
            PlayerPrefs.Save();
        }
    }
}
// ————————————————
// 版权声明：本文为CSDN博主「T.D.C」的原创文章，遵循 CC 4.0 BY-SA 版权协议，转载请附上原文出处链接及本声明。
// 原文链接：https://blog.csdn.net/ak47007tiger/article/details/102913195