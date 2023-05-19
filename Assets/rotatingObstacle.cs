using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    private void rotate()
    {
        transform.Rotate(0f, 0f, 25f);
    }

    void Start()
    {
        InvokeRepeating("rotate", 2.0f, 0.5f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
