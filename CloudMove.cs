using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 0;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(gameObject.transform.position.x < -70){
            gameObject.transform.Translate(new Vector3(140, 0, 0));
        }
    }
}
