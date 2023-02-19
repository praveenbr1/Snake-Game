using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary_Sound : MonoBehaviour
{
    AudioSource boundarySound;
 
    void Start()
    {
        boundarySound = GetComponent<AudioSource>();
        
    }

   public void StopSound()
   {
    boundarySound.Stop();
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player")
      {
        boundarySound.Play();

        
      }
   }
    
}
