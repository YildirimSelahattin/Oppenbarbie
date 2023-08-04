using UnityEngine;
using DG.Tweening;
/*
----
*/
public class RotateDrill : MonoBehaviour
{
    public static RotateDrill Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        gameObject.transform.DOLocalRotate(new Vector3(0, 360, 180), 5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }

    public void RotateInPlanet(GameObject item)
    {
        gameObject.transform.DOLocalRotate(new Vector3(0, 0, 360), .5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() =>
        {
            //GameManager.Instance.ShakeCamera(0);
            Destroy(item);
        });
    }
}
