using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]

public class SaveGame : MonoBehaviour
{
    public static CheckpointManager c;



    public Save save;

    public void Save()
    {

        save = new Save();
        save.posx = c.currentCheckpoint.x;
        save.posy = c.currentCheckpoint.y;
        save.posz = c.currentCheckpoint.z;
        


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savefile1.save");
        bf.Serialize(file, save);
        file.Close();

    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile1.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savefile1.save", FileMode.Open);
            Save s = (Save)bf.Deserialize(file);
            file.Close();

            c.currentCheckpoint = new Vector3(s.posx, s.posy, s.posz);
            c.Respawn();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Load"))
        {
            Load();
        }
    }
}
