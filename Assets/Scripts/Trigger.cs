using UnityEngine;

public class Trigger: MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(col.gameObject);
            Score.instance.AddPoint();
        }
    }
}
