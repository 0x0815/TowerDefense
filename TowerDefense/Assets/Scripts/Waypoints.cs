using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] ponits;

    private void Awake()
    {
        ponits = new Transform[transform.childCount];
        for (int i = 0; i < ponits.Length; i++)
        {
            ponits[i] = transform.GetChild(i);
        }
    }
}
