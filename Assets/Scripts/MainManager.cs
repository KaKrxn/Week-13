using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    public Color TeamColor = Color.white;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
        public int playerHp;
        public int playerCoint;
        public Vector3[] enemyPosition;

    }







    public void SaveColor()
    {
        Debug.Log(Application.persistentDataPath);
        string fileName = "save-data.txt ";
        string filePath = Application.persistentDataPath + "/" + fileName;

        SaveData data = new SaveData();
        data.TeamColor = TeamColor;
        
        string content = JsonUtility.ToJson(data);

        //string content = "Hello"+TeamColor.r+""+TeamColor.g + "" + TeamColor.b;
        File.WriteAllText(filePath, content);
    }

    public void LoadColor()
    {
        string fileName = "save-data.txt ";
        string filePath = Application.persistentDataPath + "/" + fileName;
        string content = File.ReadAllText(filePath);
        Debug.Log(content);

        SaveData data = JsonUtility.FromJson<SaveData>(content);
        TeamColor = data.TeamColor;

        /*string[] rgb = content.Split(' ');
        TeamColor.r = float.Parse(rgb[0]);
        TeamColor.g = float.Parse(rgb[1]);
        TeamColor.b = float.Parse(rgb[2]);
*/
    }
}
