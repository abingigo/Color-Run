using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject PlaySceneUI;
    public GameObject PauseSceneUI;
    public GameObject ReplaySceneUI;
    public Renderer rend;
    public Material[] mt;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Play()
    {
        MainMenuUI.SetActive(false);
        PlaySceneUI.SetActive(true);
        int a = Random.Range(0, 5);
        rend.sharedMaterial = mt[a];
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Play Scene");
    }
}
