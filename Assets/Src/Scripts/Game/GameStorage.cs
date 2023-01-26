using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameStorage
{
    public const string PlayerData = "/playerDetails.dat";

    public static T LoadData<T>()
    {
        string path = Application.persistentDataPath + PlayerData;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T playerData = (T)formatter.Deserialize(stream);
            stream.Close();

            return playerData;
        }
        else
        {
            return default(T);
        }
    }

    public static void Save<T>(T data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PlayerData;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }
}
