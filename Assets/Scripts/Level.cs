using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0; // Serialized for debugging purposes

    // Cached Reference
    SceneLoader sceneLoader;

    public void CountBlocks() {
        breakableBlocks++;
    }

    public void DecrementBreakableBlocks() {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log("breakableBlocks == " + breakableBlocks);
    //     if(breakableBlocks <= 0) {
    //         sceneLoader.LoadNextScene();
    //     }
    // }
}
