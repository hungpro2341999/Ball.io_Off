using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingBall : MonoBehaviour
{
    // Start is called before the first frame update

    //public  Vector3 mouse_pos;
    //public   Transform target; //Assign to the object you want to rotate
    //  Vector3 object_pos;
    //  float angle;
    public bool isPress = false;


    public float turnSpeed = 2.0f;

    public Rigidbody body;
    public List<Vector3> pos = new List<Vector3>();
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPress = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPress = false;
            pos.Clear();

        }
        if (isPress)
        {
            pos.Add(Input.mousePosition);
            if (pos.Count >= 2)
            {
                if (pos[pos.Count - 1] != pos[pos.Count - 2])
                {
                    Vector3 vec = (pos[pos.Count - 1] - pos[pos.Count - 2]).normalized * turnSpeed * Time.deltaTime;
                    body.AddForce(new Vector3(-vec.x, 0, vec.y), ForceMode.VelocityChange);
                }
                else if (pos[pos.Count - 1] == pos[pos.Count - 2])
                {
                    pos.RemoveAt(pos.Count - 1);
                }


            }

            //body.AddForce(Vector3.right*turnSpeed, ForceMode.VelocityChange);

        }

        //}
        //if (isPress)
        //{
        //    mouse_pos = Input.mousePosition;

        //    object_pos = Camera.main.WorldToScreenPoint(target.position);
        //    mouse_pos.x = mouse_pos.x - trans.position.x;
        //    mouse_pos.y = mouse_pos.y - trans.position.y;
        //    angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z)), Quaternion.Euler(new Vector3(0, 0, angle)),Speed) ;
        //}



    }
}

  