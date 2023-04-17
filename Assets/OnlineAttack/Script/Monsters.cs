using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public Monster[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos();
    }

    private void SpawnPos(){
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        var currMon = Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f), new Quaternion());
        currMon.transform.parent = gameObject.transform;
    }

    
    void FixedUpdate()
    {
        if(gameObject.transform.childCount < 5){
            SpawnPos();
        }
        
    }
}
