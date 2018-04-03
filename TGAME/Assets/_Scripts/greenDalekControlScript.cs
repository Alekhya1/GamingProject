using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenDalekControlScript : MonoBehaviour {
    
    public float moveSpeed, speed = 0.1f;
    public GameObject bullet, gameOverText, restartButton, blood;

    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    public static float healthAmount;
    // Use this for initialization
    void Start()
    {
        healthAmount = 2;
       
        gameOverText.SetActive(false);
        restartButton.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && Time.time > nextFire)
        {
            AudioSource shoot = GetComponent<AudioSource>();
            shoot.Play();
            nextFire = Time.time + fireRate;
            fire();
        }
       
    }
    void FixedUpdate()
    {
        var objPos = GameObject.Find("player_green").transform.position;
        //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        //{
        //    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        //}
        //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        //{
        //    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        //}
        if (Input.GetKey(KeyCode.H))
        {
            Vector2 position = transform.position;
            position.x -= speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.K))
        {
            Vector2 position = transform.position;
            position.x += speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.J))
        {
            Vector2 position = transform.position;
            position.y -= speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.U))
        {
            Vector2 position = transform.position;
            position.y += speed;
            transform.position = position;
        }

        var player = GameObject.Find("player_green");
        Quaternion rot = Quaternion.LookRotation(transform.position - objPos, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        float input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * moveSpeed * input);
    }
    void fire()
    {
        bulletPos = transform.position;
        bulletPos += new Vector2(+1f, -0.43f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("enemy"))
        {
            healthAmount -= 0.5f;
        }
       
        if (healthAmount <= 0.2f)
        {
            ApplicationsData.greenD =1;
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            GameObject.FindGameObjectWithTag("player_red").SetActive(false);

            GameObject.FindGameObjectWithTag("player_blue").SetActive(false);

        }


    }
}