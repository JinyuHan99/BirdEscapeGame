using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwanerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 2.5f;
    public float limitSpawnRate = 0.5f;
    public int level = 1;
    public int pipeNumber = 0;
    private float timer = 0;
    public float heightOffset = 7;
    public int pipeEveryLevel = 15;
    public BirdSrcipt bird;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        if (logic.gameStarted)
        {
            spawnPipe();
            pipeNumber += 1;
            bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdSrcipt>();
        }
    }

    // Update is called once per frame
    void Update()
    {

            if (logic.gameStarted && bird.birdIsAlive)
            {
                if(timer >= spawnRate)
            {
                spawnPipe();
                pipeNumber += 1;
                timer = 0;

                if (pipeNumber > 0 && pipeNumber % pipeEveryLevel == 0 && spawnRate >= limitSpawnRate)
                {
                    spawnRate -= (float)level * 0.1f;
                    level += 1;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
                
            }
            
           


    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint)), transform.rotation);

    }
}
