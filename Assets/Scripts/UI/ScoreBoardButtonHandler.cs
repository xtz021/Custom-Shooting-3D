using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardButtonHandler : MonoBehaviour {

    public GameObject ScoreBoardPanel;
    
    public void ShowScoreBoard()
    {
        ScoreBoardPanel.SetActive(true);
    }
}
