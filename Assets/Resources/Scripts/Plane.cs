using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] float animationTime = 0.1f;
    [SerializeField] Sprite[] moveSprites;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMeshProUGUI fuelText;
    [SerializeField] Image fuelBar;
    
    Transform planeTransform;
    Rigidbody2D rigBody;
    SpriteRenderer sr;
    float fuel = 1f;

    float timer;
    int spriteIndex = 0;

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigBody = GetComponent<Rigidbody2D>();
        fuelText.text = "100";
        planeTransform = this.transform;
    }

    void fixedUpdate(){
    }

    // Update is called once per frame
    void Update()
    {
        rigBody.velocity = new Vector2(speed, rigBody.velocity.y);
        
        var dir = rigBody.velocity;
        //TODO: this rotation is laggy as hell
        // but wasted already a lot of time here.....
        // in fixedUpdate it does nothing for some reason
        // tried many rigidbody2D codes but nothin worked...

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        planeTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        timer += Time.deltaTime;

        // This will be called when our timer reaches the specified time (and the array contains sprites)
        if (timer >= animationTime)
        {
            // Load the next sprite and loop around when end of the array is reached
            sr.sprite = moveSprites[spriteIndex];
		    spriteIndex = (spriteIndex + 1) % moveSprites.Length;

            // Reset the timer. Otherwise it'll continue going up and (timer >= animationTime) will be true in every single frame
            timer = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            fuel -= 0.2f * Time.deltaTime;
            audioSource.mute = false;
            rigBody.velocity = new Vector2(rigBody.velocity.x, jumpForce);
            if (fuel <= 0)
                fuelText.text = "Empty";
            else 
                fuelText.text = Mathf.Floor((fuel * 100)).ToString();
            
            fuelBar.fillAmount = fuel;
        }
            
        //planeTransform.rotation = Quaternion.Lerp(planeTransform.rotation, Quaternion.LookRotation(new Vector3(rigBody.velocity.x, rigBody.velocity.y, 0)), Time.deltaTime * 1f);
        
        if(Input.GetKeyUp("space"))
                audioSource.mute = true;
    }
}
