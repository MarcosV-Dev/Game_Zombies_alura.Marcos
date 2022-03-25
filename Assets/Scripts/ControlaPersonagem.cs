using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ControlaPersonagem : MonoBehaviour
{
    public float speed = (float)10;
    private Vector3 direction;
    public LayerMask aimMask;
    public GameObject youLose;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(axisX, 0, axisZ);
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else {
            GetComponent<Animator>().SetBool("Running", false);
        }

        if (alive == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * speed * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(raio, out impact, 100, aimMask))
        {
            Vector3 aimPosition = impact.point - transform.position;
            aimPosition.y = transform.position.y;
            Quaternion rotation = Quaternion.LookRotation(aimPosition);                        
            GetComponent<Rigidbody>().MoveRotation(rotation);

        }

        

    }

}
