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

    private string[] files = new string[] { "/savefile1.save", "/savefile2.save", "/savefile3.save" };

    private string file1 = "/savefile1.save";
    private string file2 = "/savefile2.save";
    private string file3 = "/savefile3.save";

    private int currentFile = Variables.file - 1;

    public void Save()
    {

        save = new Save();
        save.posx = c.currentCheckpoint.x;
        save.posy = c.currentCheckpoint.y;
        save.posz = c.currentCheckpoint.z;

        if (currentFile >= 0 && currentFile <= 2)
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + file1);
            bf.Serialize(file, save);
            file.Close();
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile1.save"))
        {
            if (currentFile >= 0 && currentFile <= 2)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savefile1.save", FileMode.Open);
                Save s = (Save)bf.Deserialize(file);
                file.Close();
            }
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
