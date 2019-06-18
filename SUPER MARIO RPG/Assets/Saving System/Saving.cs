
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class Saving
{
    public static void SaveMario(Player Mario)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string Directorio = Application.persistentDataPath + "/Saves.Mario";
        FileStream stream = new FileStream(Directorio, FileMode.Create);

        PlayerData data = new PlayerData(Mario);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData CargarMario()
    {
        string Directorio = Application.persistentDataPath + "/Saves.Mario";
        if (File.Exists(Directorio))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Directorio, FileMode.Open);
            PlayerData data =formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
                
        }
        else
        {
            Debug.LogError("No se encontro" + Directorio);
            return null;
        }
    }

}

