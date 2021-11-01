using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_game : MonoBehaviour
{

    private Vector3 position; 
    private float width;
    private float height;
    public GameObject clone;
    public GameObject projectile;
    public int timeoutDestructor;
    public Transform target;
    public float speed;


    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void SoltaPoder()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    // Instantiate the projectile at the position and rotation of this transform
                    clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                    float step = speed * Time.deltaTime;
                    clone.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(target.position.x* step, target.position.y * step, 0));
                }
            }

            Touch touch = Input.GetTouch(0);
           
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / 50; //pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) /50; //pos.y = (pos.y - height) /height;
                position = new Vector3(pos.x, pos.y, 0.0f);

                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
    void OnGUI()
    {
       /* GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(30, 40, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            " y = " + position.y.ToString("f2") + 
            "WH - " + width.ToString("f2") + 
            "-"+ height.ToString("f2"));
       */
    }
}
