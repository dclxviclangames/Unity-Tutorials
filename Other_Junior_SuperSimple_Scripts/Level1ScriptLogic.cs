using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ScriptLogic : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform[] cameraPointers;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.position.z >= -1.5f && player.position.x <= 16.5f)
        {
            cameraTransform.position = cameraPointers[1].position;
        }

        if (player.position.z > 16.5f && player.position.z < 37.5f)
        {
            cameraTransform.position = cameraPointers[2].position;
        }

        if (player.position.z < -1.5f)
        {
            cameraTransform.position = cameraPointers[0].position;
        }

        if (player.position.z > 37.5f)
        {
            cameraTransform.position = cameraPointers[3].position;
        }
    }
}
