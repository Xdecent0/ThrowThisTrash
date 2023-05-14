using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathMenu;

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
    public void Death()
    {
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
