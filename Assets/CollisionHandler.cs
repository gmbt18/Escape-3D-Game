using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag != "Untagged") {
            Debug.Log(collision.transform.tag);
        }

        if (collision.transform.tag == "Spike") {
            SceneManager.LoadScene("DeadScreen");
        }
    }

}
