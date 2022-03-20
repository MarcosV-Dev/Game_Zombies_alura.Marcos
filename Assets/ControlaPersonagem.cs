using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPersonagem : MonoBehaviour
{
    public float speed = (float)0.5;


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(axisX, 0, axisZ);
        transform.Translate(direction * speed * Time.deltaTime);


    }
}
