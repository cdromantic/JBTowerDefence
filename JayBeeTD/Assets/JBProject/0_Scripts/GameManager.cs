using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private string loadLevel;

    public GameObject pauseMenu;
    public GameObject playerController;

    public GameObject bgm;

    private bool isPaused;

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void ResumeGame() {
        TogglePause();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start() {
        TogglePause();
        TogglePause();
    }

    // Checks for player input, once the esc key is pressed we will pause the game
    void Update() {
        CheckForPauseRequest();
    }


    void CheckForPauseRequest() {
        if (Input.GetKeyUp(KeyCode.Escape) /* && !gameManager.isGameOver */) {
            TogglePause();
        }
    }

    void TogglePause() {
        ToggleTimeStop();
        TogglePlayerController();
        ToggleMenu();
        ToggleBGM();
    }

    /* If there is a menu GameObject set it to		*
	 * the opposite of its current state.			*
	 * If deactivated it will become activated.		*
	 * If activated it will become deactivated.		*
	 * When there is no menu, this should not run	*/
    public void ToggleMenu() {
        if (pauseMenu != null) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        else {
            Debug.Log("There is no pause menu assigned. To toggle pause menu there must first be a pause menu assigned to the GameManager");
            return;
        }
    }

    /* if the game is not paused Time.timeScale = 1, meaning time runs normally	*
	 * if the game is paused Time.timeScale = 0, meaning time stops completely	*/
    void ToggleTimeStop() {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
        }
        else {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    /* Toggles the Player script which controls player functionality 		*
	 * Without this the player can input actions during the pause state.	*/
    void TogglePlayerController() {
        if (playerController != null) {
            // playerController.GetComponent<Player>().enabled = !playerController.GetComponent<Player>().enabled;
        }
    }

    void ToggleBGM()
	{
        if (bgm != null)
        {
            if (!isPaused)
            {
                bgm.GetComponent<AudioSource>().UnPause();
            }
            else
            {
                bgm.GetComponent<AudioSource>().Pause();
            }
        }
	}
}