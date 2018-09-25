using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public Rigidbody ObstacleRb;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            //movement.sidewaysForce = movement.forwardForce = 0;
            movement.rb.useGravity = false;
            ObstacleRb.useGravity = false;
            movement.rb.AddForce(0, 5, 0);
            ObstacleRb.AddForce(0, 5, 0);
        }
    }

}
