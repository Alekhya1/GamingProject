using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueDalekControl : MonoBehaviour
{
   
    public float moveSpeed,speed=0.1f;
    public GameObject bullet, gameOverText, restartButton, blood,singleGameOverText,restartgame;
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
      
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        singleGameOverText.SetActive(false);
        restartgame.SetActive(false);


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
  
    }
    void FixedUpdate()
    {
        var objPos = GameObject.Find("Player").transform.position;
      
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
      
            if (ApplicationsData.singlePlayerFlag.Equals(1))
            {
                singleGameOverText.SetActive(true);
                gameOverText.SetActive(false);
                restartButton.SetActive(false);
                restartgame.SetActive(true);
            }
            else
            {
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                singleGameOverText.SetActive(false);
                restartgame.SetActive(false);
            }

            GameObject.FindGameObjectWithTag("spawner").SetActive(false);

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

 