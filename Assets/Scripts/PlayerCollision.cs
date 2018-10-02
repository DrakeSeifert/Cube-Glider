using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public Rigidbody ObstacleRb;
    public Score score;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            score.FreezeScore();
            movement.enabled = false;
            //GetComponent<PlayerMovement>().enabled = false;
                //Performs the same thing as above but instead automatically grabs
                //the PlayerMovement script so it does not have to be a variable
            movement.rb.useGravity = false;
            ObstacleRb.useGravity = false;
            movement.rb.AddForce(0, 5, 0);
            ObstacleRb.AddForce(0, 5, 0);

            FindObjectOfType<GameManager>().EndGame("BlockCollision");
            
        }
    }

}
