using UnityEngine;
using UnityEngine.UI;   // This contains Image, Slider and the legacy Text
using TMPro;            // This contains TextMeshProUGUI, which you should use for text
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("R"))
            SceneManager.LoadScene("MainMenu");
    }
}
