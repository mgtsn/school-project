using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CheckpointManager : MonoBehaviour
{
    public Rigidbody2D rb;


    public Vector3 currentCheckpoint;

    public Save save;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform.position;
            Save();
        }
    }



    public void Save()
    {

        save = new Save();
        save.posx = currentCheckpoint.x;
        save.posy = currentCheckpoint.y;
        save.posz = currentCheckpoint.z;



        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savefile1.save");
        bf.Serialize(file, save);
        file.Close();

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile1.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savefile1.save", FileMode.Open);
            Save s = (Save)bf.Deserialize(file);
            file.Close();

            currentCheckpoint = new Vector3(s.posx, s.posy, s.posz);
            Respawn();
        }
    }



    public void Respawn()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.position = currentCheckpoint;
    }



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
