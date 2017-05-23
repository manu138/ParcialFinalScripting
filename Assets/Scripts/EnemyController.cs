using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject target;
    public GameObject target2;
    public float speed;
    void Update()
    {

        MoveTo();
    }
    public void MoveTo()
    {
        float step = speed * Time.deltaTime;
        Vector3 targetVector1 = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Vector3 targetVector2 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(targetVector2, targetVector1, step);
        ;
    }

}
