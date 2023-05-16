using UnityEngine;
using UnityEngine.UI;   // This contains Image, Slider and the legacy Text
using TMPro;            // This contains TextMeshProUGUI, which you should use for text
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Enumerator for Level: 
    //      0 -> MainMenu
    //      1 -> LinusLevel
    //      2 -> DomaiLevel
    private enum Level { MainMenu, LinusLevel, DomaiLevel }
    
    // Audio
    [SerializeField] AudioSource bgmSrc;
    [SerializeField] AudioSource sfxSrc;

    // Start Game at UI Click in Main Menu.
    // int level = 
    //      0   -> LinusLevel
    //      1   -> DomaiLevel
    // Everthing else will return in a resetting of the game.
    // => Loading Main Menu again.
    public void startLevel(int level) 
    {
        sfxSrc.PlayOneShot(sfxSrc.clip);
        try {
            Debug.Log($"Level: {(Level)level}");
            SceneManager.LoadScene(((Level)level).ToString());
        } catch {
            SceneManager.LoadScene(Level.MainMenu.ToString());
        }
    }
}
