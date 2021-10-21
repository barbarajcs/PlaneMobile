using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//float distance;


public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        Debug.Log(layerMask);
        // Does the ray intersect any objects which are in the player layer.
        if (Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMask))
        {
            Debug.Log("The ray hit the player");
        }
    }

    /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, layerTarget);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Vase"))
            {
                hitInfo.collider.GetComponent<Vase>().AnimatorBorn(Born);
    cloud.colR += 0.04f;
                cloud.colG += 0.04f;
                cloud.colB += 0.04f;
                gameManager.lifeBoss -= 0.02f;
                gameManager.lifePlayer += 0.02f;
                UIGame.ProgessPhase.fillAmount += 0.04f;
            }
DestroyBullet();*/
    //private void OnTriggerEnter2D(Collider2D other)

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
        Debug.Log("GameObject2 collided with " + col.name);
        Destroy(col.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("GameObject2 collided with Bullet" + collision);
            Destroy(collision.gameObject);
        }
    }
}
