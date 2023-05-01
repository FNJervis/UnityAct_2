using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ammountPoints;
    string ammountText = "Points: ";
    int currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        ActiveScore();
    }

    // Update is called once per frame
    void Update()
    {
        printScore();
    }
    public void ActiveScore()
    {
        ammountPoints.text = ammountText + "--";
    }
    public void AddPoints(int _points)
    {
        currentScore += _points;
    }
    public void printScore()
    {
        ammountPoints.text = ammountText + currentScore.ToString();
        GameControl.Instance.checkGameOver(currentScore);
    }
}
