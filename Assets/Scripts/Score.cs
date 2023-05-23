using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int x = 0;
    // Update is called once per frame

    public void Add()
    {
        x += 1;
    }

    private void Update()
    {
        scoreText.GetComponent<Text>().text = x.ToString();
    }
}