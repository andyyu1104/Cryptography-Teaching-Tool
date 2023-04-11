using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public List<SpriteRenderer> food;
    private SpriteRenderer currFood;


    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        
        currFood = Instantiate(food[Random.Range(0, food.Count)], new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f), new Quaternion());
        currFood.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f);
    }

    
    

    // Update is called once per frame
    void Update()
    {
        if (currFood == null)
        {
            RandomizePosition();
        }
    }
}
