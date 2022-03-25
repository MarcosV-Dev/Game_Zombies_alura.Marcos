using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = (float)5;
    public GameObject Player;

    // Start is called before the first frame update
    void Start(){
        Player = GameObject.FindWithTag("Player");
        int zombieSkin = Random.Range(1, 28);
        transform.GetChild(zombieSkin).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void FixedUpdate(){
        Vector3 direction = Player.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction);

        GetComponent<Rigidbody>().MoveRotation(rotation);

        if (distance > 2)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction.normalized * speed * Time.deltaTime);
            GetComponent<Animator>().SetBool("Attacking", false);
        }
        else {
            GetComponent<Animator>().SetBool("Attacking", true);
        }
    }

    void HitPlayer() {
        Time.timeScale = 0;
        Player.GetComponent<ControlaPersonagem>().youLose.SetActive(true);
        Player.GetComponent<ControlaPersonagem>().alive = false;
    }


}

