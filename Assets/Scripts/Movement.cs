using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
  private List<Transform> bodyparts = new List<Transform>();
  public Transform bodyPrefab;
  private Vector2 direcrtion = Vector2.right;
  BoxCollider2D boxCollider2D;
    SpriteRenderer TurnSprite;
  [SerializeField] Sprite leftSideChangeSprite;

  [SerializeField] Sprite upSideChangeSprite;
  [SerializeField] Sprite downSideChangeSprite;
  [SerializeField] Sprite rightSideChangeSprite; 

 

 [SerializeField] int initialize_Snake_Body_Parts = 4;
  
  int score = 0;
  [SerializeField] TextMeshProUGUI scoreText;
  

//  [SerializeField] int xRightSide = 26;
//  [SerializeField] int xLeftSide = -26;
 

//  [SerializeField] int yTopSide = 15;
//  [SerializeField] int ybottomSide = -15;


   private void Start()
   {
    
       ResetGame();
      TurnSprite = GetComponent<SpriteRenderer>();
      boxCollider2D = GetComponent<BoxCollider2D>();
   }
 
   private void LeftChangeSprite()
    {
      boxCollider2D.offset = new Vector2(-2.02f,0f);
      boxCollider2D.size = new Vector2(1f,1.54f);
      TurnSprite.sprite = leftSideChangeSprite;
     
     }
    private void UpChangeSprite()
    {
      boxCollider2D.offset = new Vector2(0f,2.02f);
      boxCollider2D.size = new Vector2(1.54f,1f);
      TurnSprite.sprite = upSideChangeSprite;
    }

    private void DownChangeSprite()
    {
       boxCollider2D.offset = new Vector2(0f,-2.02f);
      boxCollider2D.size = new Vector2(1.54f,1f);
      TurnSprite.sprite = downSideChangeSprite;
    }
    private void RightChangeSprite()
    {
      boxCollider2D.offset = new Vector2(2.02f,0f);
      boxCollider2D.size = new Vector2(1f,1.54f);
      TurnSprite.sprite = rightSideChangeSprite;
    } 
   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.W) && direcrtion != Vector2.down)
       {
         direcrtion = Vector2.up;
         UpChangeSprite();
       }
       
       else if(Input.GetKeyDown(KeyCode.S) && direcrtion != Vector2.up)
       {
         direcrtion = Vector2.down;
          DownChangeSprite();
       }
       else if(Input.GetKeyDown(KeyCode.A) && direcrtion != Vector2.right)
       {
        direcrtion = Vector2.left;
        LeftChangeSprite(); 
       }
       else if(Input.GetKeyDown(KeyCode.D) && direcrtion != Vector2.left)
       {
         direcrtion = Vector2.right;
         RightChangeSprite();
         
       }
      
      ScreenWrap();
   }

   
 
    private void ScreenWrap()
    {
        // int currentPosition_In_X = (int)transform.position.x;
        // int currentPosition_In_Y = (int)transform.position.y;

        // if(currentPosition_In_X > xRightSide)
        // {
        //    transform.position = new Vector3(xLeftSide,currentPosition_In_Y,0);

        // }

        // else if(currentPosition_In_X < xLeftSide)
        // {
        //     transform.position = new Vector3(xRightSide,currentPosition_In_Y,0);
        // }

        // else if(currentPosition_In_Y > yTopSide)
        // {
        //     transform.position = new Vector3(currentPosition_In_X,ybottomSide,0);
        // }
        // else if(currentPosition_In_Y < ybottomSide)
        // {
        //     transform.position = new Vector3(currentPosition_In_X,yTopSide,0);
        // }

      
    }
  
    private void FixedUpdate()
  {
    for(int i = bodyparts.Count - 1 ; i > 0 ; i--)
    {
      bodyparts[i].position = bodyparts[i-1].position;
    }
    this.transform.position = new Vector2(Mathf.Round(this.transform.position.x+direcrtion.x),Mathf.Round(this.transform.position.y+direcrtion.y));
  }

  private void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.gameObject.tag == "Food")
    {
      Grow();
    }
    else if(other.gameObject.tag == "Obstacle")
        {
            ResetGame();
        }
    }

    

    private void Grow()
  {
    Transform bodyPrefabList = Instantiate(this.bodyPrefab);
    bodyPrefabList.position = bodyparts[bodyparts.Count - 1].position;
    bodyparts.Add(bodyPrefabList);
    score++;
    scoreText.text = score.ToString();

    
  }
   private  void ResetGame()
    {
       for(int i = 1; i < bodyparts.Count; i++)
       {
            Destroy(bodyparts[i].gameObject);
       }
       bodyparts.Clear();
       bodyparts.Add(this.transform);
       
       for(int i = 1; i < initialize_Snake_Body_Parts; i++)
       {
          bodyparts.Add(Instantiate(this.bodyPrefab));
       }
       this.transform.position = Vector3.zero;
      score = 0;
      scoreText.text = score.ToString();
       
    }

    public bool Function_To_Not_Spawn_FoodOn_Snake(float x, float y)
    {
           foreach(Transform bodypart in bodyparts)
           {
              if(bodypart.position.x == x && bodypart.position.y == y)
              {
                return true;
              }
           }
           return false;
    }
}
