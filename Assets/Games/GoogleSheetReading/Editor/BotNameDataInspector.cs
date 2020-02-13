using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(BotNameData))]
public class BotNameDataInspector : Editor
{
    private BotNameData data;
    private string ID = "1Ct2xl7I3kUsSyZHeklBZ90SmgaxfaWa483MZHY5r1Sc";
    public string SheetName = "Bot";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        data = (BotNameData) target;

        GUILayout.Label("ID GG Sheet");
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        ID = EditorGUILayout.TextField("ID: ", ID);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        SheetName = EditorGUILayout.TextField("SheetName: ", SheetName);

        GUILayout.EndHorizontal();

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Retrieving"))
        {
            RetrievingData();
        }

        if (GUILayout.Button("Save"))
        {
            Save();
        }

        if (GUILayout.Button("Split"))
        {
            Split();
        }


        if (GUILayout.Button("Check Im"))
        {
            foreach (var countryBotName in data.botNames)
            {
                if (countryBotName.icon == null)
                {
                    Debug.Log(countryBotName.countryName);
                }
            }
        }

        GUILayout.EndHorizontal();

    }

    private void Split()
    {
        var newData = ScriptableObject.CreateInstance<BotNameData>();
        newData.botNames = new List<CountryBotName>();

        foreach (var key in Extension.COUTRY_CODES.Keys)
        {
            var c = data.botNames.Find(s => s.countryCode.ToUpper() == Extension.COUTRY_CODES[key]);
            newData.botNames.Add(c);
        }

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(BotNameData).ToString() + ".asset");

        AssetDatabase.CreateAsset(newData, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = newData;
    }

    private void Save()
    {
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssets();
    }

    private void RetrievingData()
    {
        ReadExcelOnline.Connect();
        data.botNames = new List<CountryBotName>();
        ReadExcelOnline.GetTable(ID, SheetName, delegate (IDictionary<int, Dictionary<int, string>> dictionary)
        {
            var max = dictionary[0].Count;
            for (int i = 1; i < max; i += 2)
            {
                var c = new CountryBotName();
                var s = dictionary[0][i].ToString();
                c.countryName = GetSubString(s, '/');
                c.countryCode = s.Replace(c.countryName, "").Replace("/", "");
                var path = "Assets/Games/Sprites/Flag/" + c.countryName + ".png";
                c.icon = AssetDatabase.LoadAssetAtPath<Sprite>(path);
                //PingObj(path);
                c.botName = new List<string>();
                var count = 1;
                for (int j = 1;; j++)
                {
                    if (dictionary.ContainsKey(j))
                    {
                        if (dictionary[j].ContainsKey(i))
                        {
                            if(dictionary[j][i] != "")
                            c.botName.Add(dictionary[j][i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                data.botNames.Add(c);
            }
        });
        
    }

    public static void PingObj(string path)
    {
        var obj = UnityEditor.AssetDatabase.LoadAssetAtPath<Object>(path);
        UnityEditor.Selection.activeObject = obj;
        UnityEditor.EditorGUIUtility.PingObject(obj);
    }

    string GetSubString(string s, char c)
    {
        s.Trim();
        var arr = s.ToCharArray();
        var m = "";
        foreach (var i in arr)
        {
            if (i == c)
            {
                return m;
            }
            else
            {
                m += i;
            }
        }

        return m;
    }

}

public static class ScriptableObjectUtility
{
    /// <summary>
    //	This makes it easy to create, name and place unique new ScriptableObject asset files.
    /// </summary>
    public static void CreateAsset<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}