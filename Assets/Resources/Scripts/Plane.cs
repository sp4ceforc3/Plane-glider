using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    [SerializeField] float animationTime = 1f;
    [SerializeField] Sprite[] moveSprites;
    
    Rigidbody2D rigBody;
    SpriteRenderer sr;

    float timer;

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigBody = GetComponent<Rigidbody2D>();
        
    }

    void fixedUpdate(){
    }
    // Update is called once per frame
    void Update()
    {
        rigBody.velocity = Vector2.right * speed;        
    }
}
