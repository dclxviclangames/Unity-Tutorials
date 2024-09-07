
Transform GetClosestEnemy(Transform[] enemies)
{
    Transform tMin = null;
    float minDist = Mathf.Infinity;
    Vector3 currentPos = transform.position;
    foreach (Transform t in enemies)
    {
        float dist = Vector3.Distance(t.position, currentPos);
        if (dist < minDist)
        {
            tMin = t;
            minDist = dist;
        }
    }
    return tMin;
}


