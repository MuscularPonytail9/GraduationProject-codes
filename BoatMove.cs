using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float speed;
    public float time = 0; 

    void Update()
    {
        time += Time.deltaTime;

        if (time < 6)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }else if(time > 6 && time < 9)
        {
            
        }else if(9 < time && time < 21)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else if(time > 21)
        {

        }

        if (time > 21)
            time = -6;
    }
}
