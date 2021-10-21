using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_game_old : MonoBehaviour
{

    private Vector3 position; 
    private float width;
    private float height;
    public Rigidbody clone;
    public Rigidbody projectile;
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
                    clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                    float step = speed * Time.deltaTime;
                    clone.position = Vector3.MoveTowards(clone.position, target.position, 0);
                    //clone.position += clone.forward * (speed * Time.deltaTime);


                    //clone.position = clone.position + new Vector3(target.position.x * speed * Time.deltaTime, target.position.y * speed * Time.deltaTime, 0);



                    /*while (clone.position.x < target.position.x)
                    {
                        clone.position = new Vector3(clone.position.x + 0.001f, clone.position.y, clone.position.z);

                    }*/


                    //clone.AddForce(transform.forward * 100);
                    // Set the missiles timeout destructor to 5
                    // clone.timeoutDestructor = 5;
                }
            }

            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / 50; //pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) /50; //pos.y = (pos.y - height) /height;
                position = new Vector3(pos.x, pos.y, 0.0f);

                // Position the cube.
                transform.position = position;
            }

            if (Input.touchCount == 2)
            {
                touch = Input.GetTouch(1);

                if (touch.phase == TouchPhase.Began)
                {
                    // Halve the size of the cube.
                    transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // Restore the regular size of the cube.
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(30, 30, width, height * 0.25f),
            "x = " + position.x.ToString("f2") +
            " y = " + position.y.ToString("f2") + 
            "WH - " + width.ToString("f2") + 
            "-"+ height.ToString("f2"));
    }
}
