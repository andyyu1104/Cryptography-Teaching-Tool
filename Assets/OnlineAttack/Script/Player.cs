
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public SpriteRenderer[] spriteRenderers = new SpriteRenderer[2];
    public float moveSpeed = 7.0f;
    public FireBall fireball;
    public AudioSource fireSFx;
    public GameObject fireBallSpwan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "TopWall"){
            this.transform.position += new Vector3(0,-2,0);
        } else if(other.tag == "BottomWall"){
            this.transform.position += new Vector3(0,2,0);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += Vector3.up * moveSpeed * Time.deltaTime ;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(this.fireball,this.transform.position, Quaternion.identity, fireBallSpwan.transform);
        fireSFx.Play();
    }


}
