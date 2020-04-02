using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
/// <summary>
/// 自动改公司名，自动写key，构建项目
/// </summary>
public class BuildAutoChangeInfo : Editor {
    /// <summary> IOS自动改公司名和自动写key构建 </summary>
    [MenuItem ("⚙自动改公司名和自动写key构建/🔍Ios #F1", false, 2)] // & alt  #shift %ctrl
    static void BuildIos () {
        PlayerSettings.companyName = "wjgzs_ios";
        // Application.companyName;
        ChangeKey ();
        BuildForIOS ();
    }
    /// <summary> google自动改公司名和自动写key构建 </summary>
    [MenuItem ("⚙自动改公司名和自动写key构建/🔍google #F1", false, 2)] // & alt  #shift %ctrl
    static void BuildGoogle () {
        PlayerSettings.companyName = "wjgzs_google";
        // Application.companyName;
        ChangeKey ();
        BuildForAndroid ();
    }
    /// <summary> xiaomi自动改公司名和自动写key构建 </summary>
    [MenuItem ("⚙自动改公司名和自动写key构建/🔍xiaomi #F1", false, 2)] // & alt  #shift %ctrl
    static void BuildXiaoMi () {
        PlayerSettings.companyName = "wjgzs_xiaomi";
        // Application.companyName;
        ChangeKey ();
        ChangeIdentifier("xiaomi");
        BuildForAndroid ();
    }
    /// <summary> taptap自动改公司名和自动写key构建 </summary>
    [MenuItem ("⚙自动改公司名和自动写key构建/🔍taptap #F1", false, 2)] // & alt  #shift %ctrl
    static void BuildTapTap () {
        PlayerSettings.companyName = "wjgzs_taptap";
        // Application.companyName;
        ChangeKey ();
        ChangeIdentifier("taptap");
        BuildForAndroid ();
    }

    /// <summary>
    /// 自动写key
    /// </summary>
    static void ChangeKey () {
        PlayerSettings.keystorePass = "123456";
        PlayerSettings.keyaliasPass = "123456";
    }
    /// <summary>
    /// 自动改包名
    /// </summary>
    static void ChangeIdentifier (string platfrom) {
        if (platfrom == "google") {
            PlayerSettings.applicationIdentifier = Application.identifier + "Google";
        } else if (platfrom == "xiaomi") {
            PlayerSettings.applicationIdentifier = Application.identifier + "Xiaomi";
        } else if (platfrom == "taptap") {
            PlayerSettings.applicationIdentifier = Application.identifier + "Taptap";
        }
    }
    /// <summary>
    /// 打包安卓
    /// </summary>
    public static void BuildForAndroid () {
        Build ("Android", true);
    }
    /// <summary>
    /// 打包苹果
    /// </summary>
    public static void BuildForIOS () {
        Build ("Ios", false);
    }
    /// <summary>
    /// 打包
    /// </summary>
    private static void Build (string platfrom, bool rebuild_ab) {
        string currentPath = System.Environment.CurrentDirectory;
        string buildPath = Path.Combine (currentPath, "Build/" + platfrom + "/");
        DirectoryInfo dir = new DirectoryInfo (buildPath);
        if (dir.Exists)
            dir.Delete (true);

        BuildPlayerOptions option = new BuildPlayerOptions ();
        option.locationPathName = buildPath + Application.productName;
        if (platfrom == "Windows") {
            option.locationPathName += ".exe";
            option.target = BuildTarget.StandaloneWindows64;
        } else if (platfrom == "Android") {
            option.locationPathName += ".apk";
            option.target = BuildTarget.Android;

        } else if (platfrom == "Ios") {
            option.target = BuildTarget.iOS;
        }
        option.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer (option);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded) {
            Debug.Log ("Build succeeded: " + summary.totalSize + " bytes" + " output:" + summary.outputPath);
        } else if (summary.result == BuildResult.Failed) {
            Debug.LogError ("Build failed! total errors:" + summary.totalErrors);
        }

    }
}