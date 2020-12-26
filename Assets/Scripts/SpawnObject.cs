using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstacles;
    public Transform[] positions;
    public float Timetospawn;
    public float TimebetweenWaves;
    int[] ar  = new int[5];
    GameObject go;
    
    void FixedUpdate()
    {
        if(Time.time > Timetospawn)
        {
            Spawn();
            Timetospawn = Time.time + TimebetweenWaves;
        }
    }

    void Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            int a = RandomSelect(i);
            go = Instantiate(obstacles[a], positions[i].position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = new Vector3(0, 1500 * Time.deltaTime, 0);
            ar[i] = a;
        }
    }

    int RandomSelect(int x)
    {
        int a = Random.Range(0, obstacles.Length);
        for (int j = 0; j < x; j++)
        {
            if (ar[j] == a)
                a = RandomSelect(x);
        }
        return a;
    }

    public void Restart()
    {
        Timetospawn = Time.time + TimebetweenWaves;
    }
}