using UnityEngine;

public class SpawnerFollow : MonoBehaviour
{
    public Transform player;
    public float offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset, -4f, 0f);
    }
}
