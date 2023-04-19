using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Vector3 _dir = Vector3.right;
    private float _speed = 10.0f;

    void Start() {
        //this.transform.rotation = new Quaternion(0,0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this._dir * this._speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goblin" || other.tag == "Skeleton" || other.tag == "Knight" || other.tag == "Obstacle"){
            Destroy(gameObject);
        }
        
    }
}
