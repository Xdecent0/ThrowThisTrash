using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Manager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject deathMenu;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Death() { 
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
