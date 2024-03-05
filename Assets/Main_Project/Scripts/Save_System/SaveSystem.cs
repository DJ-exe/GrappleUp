using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveShopData(CharacterSelector characterSelector)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShopData data = new ShopData(characterSelector);

        formatter.Serialize(stream, data);
        if(stream != null)
        {
            stream.Close();
        }
    }

    public static ShopData loadPlayer(CharacterSelector characterSelector)
    {
        string path = Application.persistentDataPath + "/game.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            try 
            { 
                ShopData data = formatter.Deserialize(stream) as ShopData;
                stream.Close();
                return data;
            }
            catch
            {
                stream.Close();
                return null;
            }
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }
}
