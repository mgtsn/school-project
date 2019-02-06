using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CheckpointManager : MonoBehaviour
{
    public Rigidbody2D rb;

    public static SaveGame s;

    public Vector3 currentCheckpoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform.position;
            s.Save();
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
        
    }
}
