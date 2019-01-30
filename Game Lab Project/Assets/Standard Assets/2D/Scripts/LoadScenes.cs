using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{

    public void LoadFileSelect()
    {
        SceneManager.LoadScene("File Select");
    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
