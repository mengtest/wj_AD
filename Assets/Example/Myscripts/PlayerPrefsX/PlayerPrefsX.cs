// Contribution (Created CSharp Version) 10/2010: Daniel P. Rossi (DR9885)
// Contribution (Created Bool Array) 10/2010: Daniel P. Rossi (DR9885)
// Contribution (Made functions public) 01/2011: Bren

using System;
using UnityEngine;

public static class PlayerPrefsX {
    #region Vector 3

    /// <summary>
    /// Stores a Vector3 value into a Key
    /// </summary>
    public static bool SetVector3 (string key, Vector3 vector) {
        return SetFloatArray (key, new float[3] { vector.x, vector.y, vector.z });
    }

    /// <summary>
    /// Finds a Vector3 value from a Key
    /// </summary>
    public static Vector3 GetVector3 (string key) {
        float[] floatArray = GetFloatArray (key);
        if (floatArray.Length < 3)
            return Vector3.zero;
        return new Vector3 (floatArray[0], floatArray[1], floatArray[2]);
    }

    #endregion

    #region Bool Array

    /// <summary>
    /// Stores a Bool Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetBoolArray (string key, params bool[] boolArray) {
        if (boolArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder ();
        for (int i = 0; i < boolArray.Length - 1; i++)
            sb.Append (boolArray[i]).Append ("|");
        sb.Append (boolArray[boolArray.Length - 1]);

        try { PlayerPrefs.SetString (key, sb.ToString ()); } catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Returns a Bool Array from a Key
    /// </summary>
    public static bool[] GetBoolArray (string key) {
        if (PlayerPrefs.HasKey (key)) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]);
            bool[] boolArray = new bool[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                boolArray[i] = Convert.ToBoolean (stringArray[i]);
            return boolArray;
        }
        return new bool[0];
    }

    /// <summary>
    /// Returns a Bool Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static bool[] GetBoolArray (string key, bool defaultValue, int defaultSize) {
        if (PlayerPrefs.HasKey (key))
            return GetBoolArray (key);
        bool[] boolArray = new bool[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            boolArray[i] = defaultValue;
        return boolArray;
    }

    #endregion

    #region Int Array

    /// <summary>
    /// Stores a Int Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetIntArray (string key, params int[] intArray) {
        if (intArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder ();
        for (int i = 0; i < intArray.Length - 1; i++)
            sb.Append (intArray[i]).Append ("|");
        sb.Append (intArray[intArray.Length - 1]);

        try { PlayerPrefs.SetString (key, sb.ToString ()); } catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// </summary>
    public static int[] GetIntArray (string key) {
        if (PlayerPrefs.HasKey (key)) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]);
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                intArray[i] = Convert.ToInt32 (stringArray[i]);
            return intArray;
        }
        return new int[0];
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static int[] GetIntArray (string key, int defaultValue, int defaultSize) {
        if (PlayerPrefs.HasKey (key))
            return GetIntArray (key);
        int[] intArray = new int[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            intArray[i] = defaultValue;
        return intArray;
    }

    /// <summary>
    /// Gets the length of the int array.
    /// </summary>
    /// <returns>The int array length.</returns>
    /// <param name="key">Key.</param>
    public static int GetIntArrayLength (string key) {
        if (PlayerPrefs.HasKey (key)) {
            return PlayerPrefs.GetString (key).Split ("|" [0]).Length;
        }

        return 0;
    }

    /// Adds the int in int array.
    /// </summary>
    /// <returns><c>true</c>, if int in int array was added, <c>false</c> otherwise.</returns>
    public static bool AddIntInIntArray (string key, int num, int value) {
        //此函数不是很高效，仍需改进
        if (PlayerPrefs.HasKey (key) && num >= 0) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]); //将字符串去“|”，保存在字符串数组中
            int iStringArrayLength = stringArray.Length; //记录字符串数组的长度

            int[] intArray;
            if (num < iStringArrayLength) {
                //				return ChangeIntInIntArray(key, num, value);
                //当所给的num小于等于字符串数组长度时，根据对应num修改其值
                intArray = new int[iStringArrayLength];
                for (int i = 0; i < iStringArrayLength; i++) {
                    if (i == num)
                        intArray[i] = value;
                    else
                        intArray[i] = Convert.ToInt32 (stringArray[i]);
                }
            } else {
                //当所给的num大于字符串数组长度时，最后一位赋值，空缺处补0
                intArray = new int[num];
                for (int i = 0; i < num; i++) {
                    if (i < iStringArrayLength)
                        intArray[i] = Convert.ToInt32 (stringArray[i]);
                    else if (i == num - 1)
                        intArray[i] = value;
                    else
                        intArray[i] = 0;
                }
            }

            //将int数组转入一个字符串中
            System.Text.StringBuilder sb = new System.Text.StringBuilder ();
            for (int i = 0; i < intArray.Length - 1; i++)
                sb.Append (intArray[i]).Append ("|");
            sb.Append (intArray[intArray.Length - 1]);

            //将字符串写入存档中
            try { PlayerPrefs.SetString (key, sb.ToString ()); } catch (Exception e) { return false; }
            return true;
        }

        return false;
    }

    /// Changes the int in Int Array.
    /// </summary>
    /// <returns><c>true</c>, if int in array was changed, <c>false</c> otherwise.</returns>
    public static bool ChangeIntInIntArray (string key, int num, int value) {
        if (PlayerPrefs.HasKey (key) && num >= 0) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]);
            int iStringArrayLength = stringArray.Length;

            if (num > iStringArrayLength - 1)
                return false;

            int[] intArray = new int[iStringArrayLength];
            for (int i = 0; i < iStringArrayLength; i++) {
                if (i == num)
                    intArray[i] = value;
                else
                    intArray[i] = Convert.ToInt32 (stringArray[i]);
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder ();
            for (int i = 0; i < intArray.Length - 1; i++)
                sb.Append (intArray[i]).Append ("|");
            sb.Append (intArray[intArray.Length - 1]);

            try { PlayerPrefs.SetString (key, sb.ToString ()); } catch (Exception e) { return false; }
            return true;

        } else
            return false;
    }

    /// Gets the int in int array.
    /// </summary>
    /// <returns>The int in int array.</returns>
    public static int GetIntInIntArray (string key, int num) {
        if (PlayerPrefs.HasKey (key)) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]);

            if (num > stringArray.Length - 1)
                return 0;

            for (int i = 0; i < stringArray.Length; i++)
                if (i == num)
                    return Convert.ToInt32 (stringArray[i]);
        }

        return 0;
    }

    #endregion

    #region Float Array

    /// <summary>
    /// Stores a Float Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetFloatArray (string key, params float[] floatArray) {
        if (floatArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder ();
        for (int i = 0; i < floatArray.Length - 1; i++)
            sb.Append (floatArray[i]).Append ("|");
        sb.Append (floatArray[floatArray.Length - 1]);

        try {
            PlayerPrefs.SetString (key, sb.ToString ());
        } catch (Exception e) {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns a Float Array from a Key
    /// </summary>
    public static float[] GetFloatArray (string key) {
        if (PlayerPrefs.HasKey (key)) {
            string[] stringArray = PlayerPrefs.GetString (key).Split ("|" [0]);
            float[] floatArray = new float[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                floatArray[i] = Convert.ToSingle (stringArray[i]);
            return floatArray;
        }
        return new float[0];
    }

    /// <summary>
    /// Returns a String Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static float[] GetFloatArray (string key, float defaultValue, int defaultSize) {
        if (PlayerPrefs.HasKey (key))
            return GetFloatArray (key);
        float[] floatArray = new float[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            floatArray[i] = defaultValue;
        return floatArray;
    }

    #endregion

    #region String Array

    /// <summary>
    /// Stores a String Array or Multiple Parameters into a Key w/ specific char seperator
    /// </summary>
    public static bool SetStringArray (string key, char separator, params string[] stringArray) {
        if (stringArray.Length == 0) return false;
        try { PlayerPrefs.SetString (key, String.Join (separator.ToString (), stringArray)); } catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Stores a Bool Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetStringArray (string key, params string[] stringArray) {
        if (!SetStringArray (key, "\n" [0], stringArray))
            return false;
        return true;
    }

    /// <summary>
    /// Returns a String Array from a key & char seperator
    /// </summary>
    public static string[] GetStringArray (string key, char separator) {
        if (PlayerPrefs.HasKey (key))
            return PlayerPrefs.GetString (key).Split (separator);
        return new string[0];
    }

    /// <summary>
    /// Returns a Bool Array from a key
    /// </summary>
    public static string[] GetStringArray (string key) {
        if (PlayerPrefs.HasKey (key))
            return PlayerPrefs.GetString (key).Split ("\n" [0]);
        return new string[0];
    }

    /// <summary>
    /// Returns a String Array from a key & char seperator
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static string[] GetStringArray (string key, char separator, string defaultValue, int defaultSize) {
        if (PlayerPrefs.HasKey (key))
            return PlayerPrefs.GetString (key).Split (separator);
        string[] stringArray = new string[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            stringArray[i] = defaultValue;
        return stringArray;
    }

    /// <summary>
    /// Returns a String Array from a key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static String[] GetStringArray (string key, string defaultValue, int defaultSize) {
        return GetStringArray (key, "\n" [0], defaultValue, defaultSize);
    }

    #endregion
}