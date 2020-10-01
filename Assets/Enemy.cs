using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int WavePointIndex = 0;

    void Start()
    {
        target = Points.points[0];
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

    }

    void GetNextWayPoint()
    {

        if (WavePointIndex >= Points.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        WavePointIndex++;
        target = Points.points[WavePointIndex];
    }

}
