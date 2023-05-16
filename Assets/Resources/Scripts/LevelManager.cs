using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // UI
    [SerializeField] GameObject fuelUI;
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject restartButton;
    [SerializeField] TextMeshProUGUI endText;

    public enum GameState { Playing, Won, Lose }
    public GameState gameState;

    private LevelLoader.Level levelName;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Playing;
        // levelName = name of current scene
        levelName = (LevelLoader.Level)System.Enum.Parse(typeof(LevelLoader.Level), SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("MainMenu");
    }

    public void LoadEndScreen(GameState state) 
    {
        gameState = state;
        if (state == GameState.Won) {
            endText.text = "You win!";
            LevelLoader.finishedLevel[levelName] = true;
        } else {
            endText.text = "You lose!";
            restartButton.SetActive(true);
        }
        
        fuelUI.SetActive(false);
        endScreen.SetActive(true);
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
