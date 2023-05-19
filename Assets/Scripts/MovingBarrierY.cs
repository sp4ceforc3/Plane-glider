using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarrierY : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float MoveDuration;
    float timer = 0f;
    Rigidbody2D rigBody;
    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        rigBody.velocity = new Vector2(rigBody.velocity.y, speed);
        if (timer >= MoveDuration)
        {
            speed = -speed;
            timer = 0;
        }
    }
}
