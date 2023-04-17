using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Vector3 _dir = Vector3.left;
    private int health;
    private float moveSpeed;

    public Sprite[] sprites = new Sprite[2];

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = new Quaternion(0,180,0,0);
        if (this.tag == "Goblin")
        {
            health = 3;
            moveSpeed = 5.0f;
        } else if (this.tag == "Skeleton")
        {
            health = 1;
            moveSpeed = 8.0f;
        } else if (this.tag == "Knight")
        {
            health = 5;
            moveSpeed = 3.0f;
        }
    }

    private void Move()
    {
        this.transform.position += _dir * moveSpeed * Time.smoothDeltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(health == 0){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        if(this.GetComponent<SpriteRenderer>().sprite == sprites[0]){
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        } else {
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }


}
