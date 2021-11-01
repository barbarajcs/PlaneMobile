using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{
    private bool moveTop = false;
    public float vel;
    public Transform pontoA;
    public Transform pontoB;
    private Vector3 position;
    private float width;
    private float height;
    private int score =0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > pontoA.position.y)
            moveTop = false;
        if (transform.position.y < pontoB.position.y)
            moveTop = true;// movendo para Cima
        if (moveTop)
            transform.position = new Vector2(transform.position.x, transform.position.y + vel * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - vel * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
        Debug.Log("GameObject2 collided with " + col.name);
        Destroy(col.gameObject);
        score++;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(40, 40, 400, 400),
            "Score = " + score);
    }
}
