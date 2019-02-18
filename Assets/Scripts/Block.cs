using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Config params
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFX;
	// [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;
	GameStatus gameStatus;

	// Cached Reference
	Level level;

	// State Variables
	[SerializeField] int timesHit; // TODO only serialized for debug purposes

private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

		if(tag == "Breakable")
        {
            HandleHit();
        }
        // Debug.Log(collision.gameObject.name);
    }

    private void HandleHit()
    {
        int maxHits = hitSprites.Length - 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        // This if statement protects errors if we forget to put sprites in the array
        if(hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Block Sprite is missing from array in GameObject " + gameObject.name + ".");
        }
    }

    private void DestroyBlock()
    {
        level.DecrementBreakableBlocks();
        gameStatus.IncrementScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        triggerSparklesVFX();
    }

    private void triggerSparklesVFX() {
		GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
		Destroy(sparkles, 2);
	}
}
