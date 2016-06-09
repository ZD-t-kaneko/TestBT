using UnityEngine;
using System.Collections;

public class TestKeyboard : MonoBehaviour {
    string msg = "";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;

        float moveVal = 0.1f;
        float rotVal = 360.0f / (60.0f * 3.0f);

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) ||
            Input.GetKeyDown(KeyCode.Space))
        {
            pos = Vector3.zero;
            rot = Vector3.zero;
        }

        float mvY = Input.GetAxisRaw("Vertical");
        float mvX = Input.GetAxisRaw("Horizontal");
        if (mvX >= 0.5f)
            rot.y += rotVal;
        if (mvX <= -0.5f)
            rot.y -= rotVal;
        if (Input.GetKey(KeyCode.A))
            rot.y += rotVal;
        if (Input.GetKey(KeyCode.D))
            rot.y -= rotVal;

        if (mvY >= 0.5f)
            pos.y += moveVal;
        if (mvY <= -0.5f)
            pos.y -= moveVal;
        if (Input.GetKey(KeyCode.W))
            pos.y += moveVal;
        if (Input.GetKey(KeyCode.Z))
            pos.y -= moveVal;

        if (Input.GetKey(KeyCode.UpArrow))
            pos.z += moveVal;
        if (Input.GetKey(KeyCode.Joystick1Button3))
            pos.z += moveVal;
        if (Input.GetKey(KeyCode.DownArrow))
            pos.z -= moveVal;
        if (Input.GetKey(KeyCode.Joystick1Button0))
            pos.z -= moveVal;


        transform.eulerAngles = rot;
        transform.position = pos;
    }



    void OnGUI()
    {
        //        msg = Input.GetAxisRaw("Vertical").ToString() + ", " + Input.GetAxisRaw("Horizontal").ToString();
        //        GUI.Label(new Rect(0, 0, 200, 600), msg);
    }
}
