using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrial2DAnimationHandler : MonoBehaviour {

    //Sword info
    private GameObject sword, swordSwipe;
    private Transform[] swordPositions = new Transform[3];
    public float swipeVisibleTime = 0.025f;
    private float swipeVisibleTimer;
    private bool showSwipe;

    //Animation info
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    //Animation Triggers
    private readonly string attackTrigger = "Attack";
    private readonly string[] keyFrames = {"Andrial_6", "Andrial_9", "Andrial_12"};

	void Start () {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        foreach(Transform child in transform)
        {
            if (child.name == "Sword")
            {
                sword = child.gameObject;
            }
            else if(child.name == "SwordSwipe")
            {
                swordSwipe = child.gameObject;
            }
            else if(child.name == "SwordPositions")
            {
                foreach(Transform position in child)
                {
                    if (position.name == "RestPosition")
                        swordPositions[0] = position;
                    else if (position.name == "AttackStartupPosition")
                        swordPositions[1] = position;
                    else if (position.name == "AttackEndPosition")
                        swordPositions[2] = position;
                }
            }
        }
	}
	
	void Update () {
		if(CanAttack() && Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger(attackTrigger);
            showSwipe = true;
        }  

        UpdateSwordGraphics();
    }

    private void UpdateSwordGraphics()
    {
        //Sword swipe graphic
        if (swipeVisibleTimer > 0.0f)
            swipeVisibleTimer -= Time.deltaTime;
        else if (swordSwipe.activeSelf)
            swordSwipe.SetActive(false);

        //Sword positions
        if (spriteRenderer.sprite.name == keyFrames[0])
        {
            sword.transform.position = swordPositions[1].position;
            sword.transform.rotation = swordPositions[1].rotation;
        }
        else if (spriteRenderer.sprite.name == keyFrames[1] || spriteRenderer.sprite.name == keyFrames[2])
        {
            sword.transform.position = swordPositions[2].position;
            sword.transform.rotation = swordPositions[2].rotation;
            if (showSwipe)
            {
                swordSwipe.SetActive(true);
                swipeVisibleTimer = swipeVisibleTime;
                showSwipe = false;
            }
        }
        else
        {
            sword.transform.position = swordPositions[0].position;
            sword.transform.rotation = swordPositions[0].rotation;
        }
    }

    private bool CanAttack()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName(attackTrigger))
        {
            return true;
        }
        return false;
    }
}
