using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    [SerializeField]
    private Transform camPos;

    public float radius;
    public float speed;
    public float exception;
    public Vector3 cenetrPosition;
    public Vector3 camDistance;
    public Image stick;
    public bool zeroTrigger;


    // Use this for initialization
    void Awake()
    {
    }
    void Start()
    {
        MakecenetrPosition();
        camDistance = this.transform.position - camPos.position;
        zeroTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cenetrPosition);
        Pressed();
        //Debug.Log(cenetrPosition);
        MakecenetrPosition();
    }

    //범위 크기 지정	
    void MakecenetrPosition()
    {
        cenetrPosition = stick.rectTransform.position - this.transform.position + camPos.position + camDistance;

    }

    // 눌렸을 때 이동
    public void Pressed()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 ms = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ms.z += 10;

            if (Calcu_distence(ms) <= radius * radius)
            {
                stick.rectTransform.position = Vector3.Lerp(stick.rectTransform.position, ms, Time.deltaTime * speed);
                zeroTrigger = false;
            }

            else if (Calcu_distence(ms) <= (radius + exception) * (radius + exception))
            {
                stick.rectTransform.position = Vector3.Lerp(stick.rectTransform.position, Vector3.Normalize(ms - cenetrPosition) * radius + cenetrPosition, Time.deltaTime * speed);
                zeroTrigger = false;
            }

            else {
                stick.rectTransform.position = Vector3.Lerp(stick.rectTransform.position, cenetrPosition, Time.deltaTime * speed);
                zeroTrigger = true;
            }
        }

        else
        {
            if (Calcu_distence(stick.rectTransform.position) <= 0.001f)
            {
                stick.rectTransform.position = cenetrPosition;
                zeroTrigger = true;
            }
            else
            {
                stick.rectTransform.position = Vector3.Lerp(stick.rectTransform.position, cenetrPosition, Time.deltaTime * speed);
                zeroTrigger = true;
            }
        }
    }

    public Vector2 ReturnPos()
    {
        //Debug.Log(cenetrPosition);
        Vector3 offset = this.transform.position - cenetrPosition;
        Vector3 direction = Vector3.Normalize(offset);
		//Debug.Log(zeroTrigger);
        if (!zeroTrigger)
            return new Vector2(direction.x, direction.y);
        else
            return new Vector2(0, 0);
    }


    float Calcu_distence(Vector3 pos)
    {
        float distance = Vector3.Magnitude(pos - cenetrPosition);
        return distance;
    }
}
