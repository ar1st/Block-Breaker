using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	
	private int timesHit;
	private LevelManager lvlmanager;
	private bool isBreakable;
	

	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breackable bricks
		if ( isBreakable){
			breakableCount++;	
		}
		
		timesHit = 0;
		lvlmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if( timesHit >= maxHits){
			breakableCount--;
			lvlmanager.BrickDestroyed();
			Destroy(gameObject);
		}
		else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	//TODO remove this method once we can actually win
	void SimulateWin(){
		lvlmanager.LoadNextLevel();
	}
}
