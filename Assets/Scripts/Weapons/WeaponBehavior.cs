using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{

    protected Vector3 direction;
    public float destroyAfterSeconds;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0) // Влево
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0) //Вниз
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) // Верх
        {
            scale.x = scale.x * -1;
        }
        else if (dir.x > 0 && dir.y > 0) // Вправо Верх
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) // Вправо Вниз
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0) // Влево Верх
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0) // Влево Вниз
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
