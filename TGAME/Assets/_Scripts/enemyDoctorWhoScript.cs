using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDoctorWhoScript : MonoBehaviour
{
    public float speed;
    public Transform player;
    public static float healthAmount;
    public GameObject blood;
    public GameObject singleGameOverText, restartgame;
    // Use this for initialization
    void Start()
    {
        healthAmount = 2;
        singleGameOverText.SetActive(false);
        restartgame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            healthAmount -= 0.2f;
        }

        if (healthAmount <= 0.2f)
        {
            ApplicationsData.blueD = 1;
            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            restartgame.SetActive(true);
            singleGameOverText.SetActive(true);
        }

    }
}
