using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;
    public Button teachingContentButton;
    public AudioSource hitWallSfx;
    public AudioSource glowSfx;
    public GameObject saltSpawn;
    private int _count = 0;

    // Start is called before the first frame update
    void Start()
    {
        _segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (_segments.Count >= 6)
        {
            teachingContentButton.interactable = true;
        }
        Score();
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = new Quaternion(0,180,0, 0);
            _direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.rotation = new Quaternion(0,0,0, 0);
            _direction = Vector2.right;
        }
        
    }

    private void FixedUpdate() {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow(){
        Transform segment = Instantiate(this.segmentPrefab,saltSpawn.transform);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState(){
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food"){
            glowSfx.Play();
            Grow();
        } else if (other.tag == "Obstacle"){
            hitWallSfx.Play();
            ResetState();
        }
    }

    private void Score(){
        if(_segments.Count > _count){
            _count = _segments.Count;
            highestScoreText.text = "Highest:\n" + (_segments.Count-1);  
        }
        scoreText.text = "Score:\n" + (_segments.Count-1);
    }

    
}
