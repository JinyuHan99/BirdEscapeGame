using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed)*Time.deltaTime;
        if (transform.position.x < -45)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
