using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private bool hasKey = false;

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "Untagged") {
            Debug.Log(collision.transform.tag);
        }

        if (collision.transform.tag == "Spike") {
            SceneManager.LoadScene("DeadScreen");
        }

        if (collision.transform.tag == "Gate") {
            Debug.Log(hasKey);
            
            if (hasKey){
                SceneManager.LoadScene("LevelComplete");
            }
        }

        if (collision.transform.tag == "FinalGate") {
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
