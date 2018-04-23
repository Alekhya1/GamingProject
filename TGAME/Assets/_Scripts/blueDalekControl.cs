using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueDalekControl : MonoBehaviour
{
   
    public float moveSpeed,speed=0.1f;
    public GameObject bullet, gameOverText, restartButton, blood;
    //public GameObject life_one, life_two, life_three;
    //public static int playerHealth = 3;
    //int playerLayer, enemyLayer;
    //Color color;
    //bool coroutineAllowed = true;
    //Renderer rend;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    public static float healthAmount;
    // Use this for initialization
    void Start()
    {
        healthAmount = 2;
        // playerLayer = this.gameObject.layer;
        // enemyLayer = LayerMask.NameToLayer("Enemy");
        //// Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        // life_one = GameObject.Find("life_one");
        // life_two = GameObject.Find("life_two");
        // life_three = GameObject.Find("life_three");
        // life_one.gameObject.SetActive(true);
        // life_two.gameObject.SetActive(true);
        // life_three.gameObject.SetActive(true);
        // rend = GetComponent<Renderer>();
        // color = rend.material.color;
        gameOverText.SetActive(false);
        restartButton.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            AudioSource shoot = GetComponent<AudioSource>();
            shoot.Play();
            nextFire = Time.time + fireRate;
            fire();
        }
        //if (healthAmount <= 0)
        //{
        //    Destroy(gameObject);
        //}

        //       if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        //       {
        //           transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        //       }
        //       if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        //       {
        //           transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        //       }
    }
    void FixedUpdate()
    {
        var objPos = GameObject.Find("Player").transform.position;
        //if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        //{
        //    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        //}
        //if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        //{
        //    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 position = transform.position;
            position.x -= speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 position = transform.position;
            position.x += speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 position = transform.position;
            position.y -= speed;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 position = transform.position;
            position.y += speed;
            transform.position = position;
        }

        var player = GameObject.Find("blue_player");
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
        bulletPos += new Vector2(-1f, -0.43f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("enemy"))
        {
            healthAmount -= 0.5f;
        }
        if (collision.gameObject.tag.Equals("Enemy_Green"))
        {
            healthAmount -= 1.5f;
        }
        //if(collision.gameObject.tag.Equals("enemy"))
        //{
        //    playerHealth -= 1;
        //    switch(playerHealth)
        //    {
        //        case 2:
        //            life_three.gameObject.SetActive(false);
        //            if (coroutineAllowed)
        //                StartCoroutine("Immortal");
        //            break;
        //        case 1:
        //            life_two.gameObject.SetActive(false);
        //            if (coroutineAllowed)
        //                StartCoroutine("Immortal");
        //            break;
        //        case 0:
        //            life_one.gameObject.SetActive(false);
        //            if (coroutineAllowed)
        //                StartCoroutine("Immortal");
        //            break;
        //    }
        if (healthAmount <= 0.2f)
        {
            ApplicationsData.blueD = 1;
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            GameObject.FindGameObjectWithTag("player_red").SetActive(false);
            GameObject.FindGameObjectWithTag("player_green").SetActive(false);



        }


    }
}


    //IEnumerator Immortal()
    //{
    //    coroutineAllowed = false;
    //    Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
    //    color.a = 0.5f;
    //    rend.material.color = color;
    //    yield return new WaitForSeconds(3f);
    //    Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
    //    color.a = 1f;
    //    rend.material.color = color;
    //    coroutineAllowed = true;

 