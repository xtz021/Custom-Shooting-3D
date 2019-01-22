using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButtonHandler : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("Level 01");
    }
}
