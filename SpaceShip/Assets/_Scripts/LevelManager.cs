using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadScene(int idx)
	{
		SceneManager.LoadScene(idx);
	}

	public void LoadNextScene()
	{
        int currIndex = SceneManager.GetActiveScene ().buildIndex;
		LoadScene(currIndex + 1);
	}

    public void Quit()
    {
        Application.Quit();
    }
}
