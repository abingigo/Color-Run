using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject PlaySceneUI;
    public GameObject MainMenuUI;
    public GameObject ReplayUI;
    public GameObject player;
    public GameObject mc;
    public MovePlayer mp;
    public CameraFollow cf;
    public SpawnObject so;
    public Renderer rend;
    public Material[] mt;
    public Score s;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        PlaySceneUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        PlaySceneUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        player.transform.position = new Vector3(0, 1, 0);
        mc.transform.position = new Vector3(-7, 3, 0);
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(i);
        }
        int a = Random.Range(0, 5);
        rend.sharedMaterial = mt[a];
        s.x = 0;
        cf.enabled = true;
        ReplayUI.SetActive(false);
        PlaySceneUI.SetActive(true);
        MainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<Rigidbody>().velocity = new Vector3(1250f * Time.fixedDeltaTime, 0f, 0f);
        mp.enabled = true;
        so.enabled = true;
    }
}
