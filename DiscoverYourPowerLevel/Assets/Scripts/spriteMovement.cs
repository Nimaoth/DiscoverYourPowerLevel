using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteMovement : MonoBehaviour
{

    Vector3 velocity;
    public int bounds_x;
    public int bounds_y;

    // Use this for initialization
    void Start()
    {
        var horizontal = Random.Range(0, 2) < 0.5;
        var coin_flip = Random.Range(0, 2) < 0.5;
        if (horizontal)
        {
            var x_random = Random.Range(-bounds_x, bounds_x);
            var y_random = coin_flip ? bounds_y : -bounds_y;
            transform.position = new Vector3(x_random, y_random, 10);

        }
        else
        {
            var y_random = Random.Range(-bounds_y, bounds_y);
            var x_random = coin_flip ? bounds_x : -bounds_x;
            transform.position = new Vector3(x_random, y_random, 10);
        }
        var target = Random.insideUnitCircle * 4;
        var direction_vec = new Vector3(target.x, target.y, transform.position.z) - transform.position;
        velocity = direction_vec.normalized * 8;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        if (transform.position.x < -bounds_x - 1 || transform.position.x > bounds_x + 1 || transform.position.y < -bounds_y - 1 || transform.position.y > bounds_y + 1)
        {
            Destroy(gameObject);
        }
    }
}
