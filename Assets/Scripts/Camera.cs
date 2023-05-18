using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //https://stackoverflow.com/questions/69048857/how-to-move-camera-on-unity-2d
    [SerializeField] private Transform player;
    [SerializeField] Vector3 off;
    // This is how smoothly your camera follows the player
    [SerializeField] [Range(0, 3)]
        
    private float smoothness = 0.175f;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate() {
        Vector3 desiredPosition = new Vector3(player.position.x + off.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothness);
    }
}
