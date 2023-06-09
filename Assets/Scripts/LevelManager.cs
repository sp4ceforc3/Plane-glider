using TMPro;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // GameObject the Plane can collide of.
    // Ground   = Ground coliders game object
    // Item     = Collactable to refuel.
    // Obstacle = Obstacle and ceiling game object
    // Finish   = Colider that indicates when a level is finished.
    public enum CollisionObjects { Ground, Item, Obstacle, Finish }

    // UI
    [SerializeField] GameObject fuelUI;
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject restartButton;
    [SerializeField] TextMeshProUGUI endText;

    // Audio
    [SerializeField] AudioSource sfxSrc;
    [SerializeField] AudioSource bgmSrc;
    [SerializeField] AudioClip winningSound;
    [SerializeField] AudioClip losingSound;
    [SerializeField] AudioClip collectSound;

    // Gamestates
    public enum GameState { Playing, Won, Lose }
    public GameState gameState;

    // Levelname
    private LevelLoader.Level levelName;

    // GameObjects in World with a Collider2D component
    private Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Playing;
        // levelName = name of current scene
        if (SceneManager.GetActiveScene().name != "LevelTemplate")
            levelName = (LevelLoader.Level)System.Enum.Parse(typeof(LevelLoader.Level), SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            MainMenu();
        if(Input.GetKeyDown(KeyCode.Space) && (gameState != GameState.Playing))
            RestartGame();
    }

    // Stop the game and show endscreen UI
    public void LoadEndScreen(GameState state) 
    {
        gameState = state;
        bgmSrc.mute = true;
        
        if (state == GameState.Won) {
            endText.text = "You win!";
            sfxSrc.PlayOneShot(winningSound);
            LevelLoader.finishedLevel[levelName] = true;
        } else {
            endText.text = "You lose!";
            sfxSrc.PlayOneShot(losingSound);
            restartButton.SetActive(true);
        }
        
        fuelUI.SetActive(false);
        endScreen.SetActive(true);

        // deactivate all colliders beside ground
        GameObject world = GameObject.Find("World");
        colliders = world.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders) {
            if (collider.gameObject.tag != nameof(CollisionObjects.Ground))
                collider.enabled = false;
        }
    }

    // Handle Item collection
    public void HandleItem(GameObject item) 
    {
        sfxSrc.PlayOneShot(collectSound);

        if (item.GetComponent<Refueler>()) {
            Refueler refueler = item.GetComponent<Refueler>();
            refueler.Refuel();
        }

        Destroy(item);
    }

    // Restart Gane = Reset Scene
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    // Main Menu
    public void MainMenu() => SceneManager.LoadScene("MainMenu");

    // Quit Completly
    // Quit the game in Unity Editor too:
    /*    https://stackoverflow.com/questions/70437401/cannot-finish-the-game-in-unity-using-application-quit 
          https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
    */
    public void Quit() 
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            // UnityEditor.EditorisPlaying = false; // newer version than 2021.3
            UnityEditor.EditorApplication.isPlaying = false; // for version 2021.3
        #endif
    }
}
