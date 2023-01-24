using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class GameStorage
{
    public const string PlayerDetails = "/playerDetails.dat";
    public const string PlayerWallet = "/wallet.dat";

    public static T LoadData<T>(string fileName)
    {
        string path = Application.persistentDataPath + fileName;

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

    public static void Save<T>(T data, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileName;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);

        stream.Close();
    }
}
