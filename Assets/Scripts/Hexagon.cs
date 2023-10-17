using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField] float waitRotateTime = 0.5f;


    void Update()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(new Vector3
        (Input.mousePosition.x, transform.position.y, transform.position.z));

        if(Input.GetMouseButtonDown(0) && _mousePos.x < 0)
        {
            transform.Rotate(0f , 0f, 30f);
            yield return new WaitForSeconds(waitRotateTime);
            transform.Rotate(0f, 0f, 30);
        } 
        else if(Input.GetMouseButtonDown(0) && _mousePos.x > 0)
        {
            transform.Rotate(0f , 0f, -30f);
            yield return new WaitForSeconds(waitRotateTime);
            transform.Rotate(0f, 0f, -30);
        }

        yield return null;
    }

}
