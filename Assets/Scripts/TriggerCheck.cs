using UnityEngine;
using UnityEngine.UI;

public class TriggerCheck : MonoBehaviour
{
    public Material[] mt;
    public CollisionCheck cc;
    private void OnTriggerEnter(Collider other)
    {
        if (cc.chk == true || other.gameObject.tag == "Finish" || other.gameObject.tag == "Obstacle")
            return;
        RandomMaterial(other);
        FindObjectOfType<Text>().GetComponent<Score>().Add();
    }

    void RandomMaterial(Collider other)
    {
        int a = Random.Range(0, mt.Length);
        if (other.gameObject.GetComponent<Renderer>().sharedMaterial != mt[a])
            other.gameObject.GetComponent<Renderer>().sharedMaterial = mt[a];
        else
            RandomMaterial(other);
    }
}