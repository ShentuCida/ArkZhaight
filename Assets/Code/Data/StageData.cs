using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class StageData
{
    public int stageNum;//关卡号.
    public int defaultGold;//初始金币.
    public float goldSecond;//每秒产出多少金币.
    public int takeRoleNum;//可携带干员数.
    public int maxPutRoleNum;//最大可放置干员数.
    public int hp = 3;//关卡生命值.


    public static StageData LoadStage(int stage, int editDimension = 0)
    {
        //这里做一个防止关卡越界的处理
        if (stage < 1)
        {
            stage = 1;
            Debug.LogError("关卡数小于1");
        }
        TextAsset asset = Resources.Load<TextAsset>("");
        string content = null;
        if (asset != null)
        {
            content = asset.text;
        }
        StageData data = JsonUtility.FromJson<StageData>(content);
        //做一些额外的初始化以及生成一些运行时数据.
        if (data == null)
        {
            Debug.LogError("Not found StageData:" + stage);
            return null;
        }
        data.stageNum = stage;
        return data;
    }
    public void Save(int dimension)
    {
        string content = JsonUtility.ToJson(this);
        string dirPath = "Assets/Resource/Stage";
        string filePath = dirPath + "/Stage" + stageNum + ".txt";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(content));
    }

}