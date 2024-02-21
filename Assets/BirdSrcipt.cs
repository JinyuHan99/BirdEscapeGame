using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSrcipt : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 12.09f;
    public LogicScript logic;    public bool birdIsAlive = true;
    public float introJumpForce = 10f;
    public MusicManagerScript music;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        StartCoroutine(AutoJump());

    }
    IEnumerator AutoJump()
    {
        while (!logic.gameStarted)
        {
            // 循环直到游戏开始
            myRigidbody.velocity = Vector2.up * introJumpForce;
            // 等待落地
            yield return new WaitForSeconds(1.70f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.gameStarted)
        {
            return;
        }
        else
        {

            if (birdIsAlive)
            {
                if (transform.position.y < -15 || transform.position.y > 15)
                {
                    if (birdIsAlive)
                    {
                        music.PlayDeathSound();
                    }
                    birdIsAlive = false;
                    logic.gameOver();
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    myRigidbody.velocity = Vector2.up * flapStrength;
                    music.PlayJumpSound();
                }
            }
            else
            {
                if (!music.isFadingOut)
                {
                    music.FadeOutMusic();
                }
                
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (logic.gameStarted)
        {
            if (birdIsAlive)
            {
                music.PlayDeathSound();
            }
            logic.gameOver();
            birdIsAlive = false;
        }
    }

}
