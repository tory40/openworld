using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TargetInstance target;
    static public GameObject scorebord;
    static int score;
    static public GameObject resultscorebord;
    static public int resultscore;

    static Text scoretext;
    static public Text resultscoretext;
    void Start()
    {
        target.Instance();
        scorebord = GameObject.Find("Point");
        scoretext = scorebord.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void ScoreUp()
    {
        score += 1;
        scoretext.text = score.ToString();
    }
    static public void End()
    {
        resultscorebord = GameObject.Find("Resultpoint");
        resultscoretext = resultscorebord.gameObject.GetComponent<Text>();
        resultscoretext.text = resultscore.ToString();
    }
}
