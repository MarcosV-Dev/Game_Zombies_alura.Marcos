using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    public GameObject zombie;
    private float timer = 0;
    public float cooldown = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            Instantiate(zombie, transform.position, transform.rotation);
            timer = 0;
            cooldown = Random.Range((float)0.1, (float)2);
            
        }
    }
}
