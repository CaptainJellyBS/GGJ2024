using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    string path;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveData(HighscoreData data)
    {
        GeneratePath();
        BinaryFormatter formatter = new BinaryFormatter();

        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public HighscoreData LoadData()
    {
        GeneratePath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighscoreData result = formatter.Deserialize(stream) as HighscoreData;
            stream.Close();

            return result;
        }

        return new HighscoreData();
    }

    void GeneratePath()
    {
#if UNITY_EDITOR
        path = Application.persistentDataPath + "/HighscoresDebug.sav";
#else
        path = Application.persistentDataPath + "/Highscores.sav";
#endif
    }
}
