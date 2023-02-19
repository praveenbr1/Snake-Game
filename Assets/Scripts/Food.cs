using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] BoxCollider2D box;

    AudioSource EatingSounds;
     
     private Boundary_Sound boundarySound;

     Movement movement;


     Bounds bounds;

    private Vector2 screenBounds;

    private void Start()
    {
    movement = FindObjectOfType<Movement>();
    EatingSounds = GetComponent<AudioSource>();
    RandomPosition (); 

     screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    
        boundarySound = FindObjectOfType<Boundary_Sound>();
    }
    private void RandomPosition()
    {
        bounds = this.box.bounds;

        float x = Random.Range(bounds.min.x , bounds.max.x);
        float y = Random.Range(bounds.min.y , bounds.max.y);
        x = Mathf.Round(x);
        y = Mathf.Round(y);
       while (movement.Function_To_Not_Spawn_FoodOn_Snake(x, y))
    {
        x++;

        if (x > bounds.max.x)
        {
            x = bounds.min.x;
            y++;

            if (y > bounds.max.y) {
                y = bounds.min.y;
            }
        }
    }

    
    transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            RandomPosition();
            EatingSounds.Play();
            boundarySound.StopSound();
        }
    }
}
