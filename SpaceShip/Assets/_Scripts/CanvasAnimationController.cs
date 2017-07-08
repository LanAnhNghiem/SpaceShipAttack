using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAnimationController : MonoBehaviour {

    // Use this for initialization
    private Animator canvasAnimator;

	void Start () {
        canvasAnimator = GetComponent<Animator>();
	}
	
	public void ShowInstruction()
    {
        canvasAnimator.SetBool("IsInstructionsShow", true);
    }

    public void ReturnToMainMenu()
    {
        canvasAnimator.SetBool("IsInstructionsShow", false);
    }

    public void FadeOut()
    {
        canvasAnimator.SetBool("IsFadeOut", true);
    }

    public void LoadPlaySceneAfterFadeOut()
    {
        LevelManager obj = FindObjectOfType<LevelManager>();
        obj.LoadNextScene();
    }
}
