using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouvements : MonoBehaviour
{

    float speed = 2f;

    private Vector2 target;
    private Vector3 scaleL = new Vector3(1,1,1);
    private Vector3 scaleR = new Vector3(-1, 1, 1);

    [SerializeField]
    Transform Mario;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = Mario.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Mario.transform.position.x > transform.position.x)
        {
            transform.localScale = scaleR;
        }
        else
        {
            transform.localScale = scaleL;
        }
    }
}
