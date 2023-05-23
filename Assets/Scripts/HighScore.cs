using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text score;
    public Text highScore;
    public Text s;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SetScore()
    {
        if(s.GetComponent<Score>().x > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", s.GetComponent<Score>().x);
            highScore.text = s.GetComponent<Score>().x.ToString();
        }
        score.text = s.GetComponent<Score>().x.ToString();
    }
}