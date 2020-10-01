using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		Debug.Log("Level load requested from : " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("Quit request");
		Application.Quit();
	}
	
	public void ReturnStart(){
		Application.LoadLevel("Start");
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if ( Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}

