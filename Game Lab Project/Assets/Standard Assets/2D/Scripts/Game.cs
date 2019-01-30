using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Game : MonoBehaviour
{
    public Transform currentCheckpoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;

            SaveGame();
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.x = currentCheckpoint.position.x;
        save.y = currentCheckpoint.position.y;
        save.z = currentCheckpoint.position.z;

        return save;
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave1.save");
        bf.Serialize(file, save);
        file.Close();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
