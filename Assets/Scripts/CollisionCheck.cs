using UnityEngine;
using UnityEngine.Audio;

public class CollisionCheck : MonoBehaviour
{
    public GameObject player; 
    public Material[] mt;
    public Renderer r;
    public MovePlayer mp;
    public CameraFollow cf;
    public SpawnObject so;
    public GameObject ReplayUI;
    public GameObject PlaySceneUI;
    public bool chk = false;
    public AudioClip ac;

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Renderer>().sharedMaterial != r.sharedMaterial && col.gameObject.name != "Road")
        {
            chk = true;
            mp.enabled = false;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            cf.enabled = false;
            so.enabled = false;
            player.GetComponent<ParticleSystemRenderer>().material = player.GetComponent<Renderer>().sharedMaterial;
            player.GetComponent<Renderer>().enabled = false;
            player.GetComponent<ParticleSystem>().Play();
            AudioSource source = col.gameObject.AddComponent<AudioSource>();
            source.clip = ac;
            source.Play();
            Invoke("Change", 1.5f);
        }
    }

    void Change()
    {
        PlaySceneUI.SetActive(false);
        ReplayUI.SetActive(true);
        so.Restart();
        Time.timeScale = 0f;
        FindObjectOfType<Camera>().GetComponent<HighScore>().SetScore();
    }
}