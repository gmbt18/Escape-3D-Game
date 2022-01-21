using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private bool hasKey = false;

    private void OnControllerColliderHit(ControllerColliderHit collision) {
        
        if (collision.gameObject.tag != "Untagged") {
            Debug.Log(collision.transform.tag);
        }

        if (collision.gameObject.tag == "Spike") {
            SceneManager.LoadScene("DeadScreen");
        }

        if (collision.gameObject.tag == "Gate") {
            Debug.Log(hasKey);
            
            if (hasKey){
                SceneManager.LoadScene("LevelComplete");
            }
        }
        
         if (collision.gameObject.tag == "Key")
        {
            Debug.Log("works");
            hasKey = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "FinalGate") {
            Debug.Log(hasKey);
            
            if (hasKey){
                SceneManager.LoadScene("GameFinishScreen");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }
    }

}
