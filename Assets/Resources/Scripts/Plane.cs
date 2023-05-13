using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] float animationTime = 1f;
    [SerializeField] Sprite[] moveSprites;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMeshProUGUI fuelText;
    [SerializeField] Image fuelBar;
    
    Rigidbody2D rigBody;
    SpriteRenderer sr;
    float fuel = 1f;

    float timer;

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigBody = GetComponent<Rigidbody2D>();
        fuelText.text = "100";
    }

    void fixedUpdate(){

    }
    // Update is called once per frame
    void Update()
    {
        rigBody.velocity = new Vector2(speed, rigBody.velocity.y);
        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            fuel -= 0.2f * Time.deltaTime;
            audioSource.mute = false;
            rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
            if (fuel <= 0)
                fuelText.text = "Empty";
            else 
                fuelText.text = Mathf.Floor((fuel * 100)).ToString();
        }
            
        
        if(Input.GetKeyUp("space"))
                audioSource.mute = true;
    }
}
