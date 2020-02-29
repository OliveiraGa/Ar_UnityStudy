using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    private bool cresce = false;
    private bool diminui = false;
    private Vector3 vectorScaleObj = new Vector3(0.035f, 0.035f, 0.035f);


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        cresce = true;
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.localScale.x < 1.0f) && (cresce))
        {
            transform.localScale += vectorScaleObj;
        }
        else
        {
            cresce = false;
        }
        if (transform.position.z < -3.5f)
        {
            diminui = true;
        }

        if (diminui)
        {
            if(transform.localScale.x > 0.0f)
            {
                transform.localScale -= vectorScaleObj;
            }
            else
            {
                diminui = false;
            }
           
        }

        if (transform.position.z < -5.5f)
        {
            Destroy(gameObject);
        }
    }
}
