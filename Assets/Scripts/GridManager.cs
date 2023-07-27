using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridManager : MonoBehaviour
{
    public Button addPartBtn;
    public Button wingBtn;
    public Button drillHeadBtn;
    public Button nozzleRBtn;
    public Button nozzleLBtn;

    void Start()
    {
        wingBtn.onClick.AddListener(AddWing);
        drillHeadBtn.onClick.AddListener(AddNozzleL);
        nozzleRBtn.onClick.AddListener(AddNozzleR);
        nozzleLBtn.onClick.AddListener(AddDrillHead);
        //addPartBtn.onClick.AddListener(AddPart);
    }

    public void AddWing()
    {
        GameObject wing = Instantiate(BombData.Instance.Wings[0], BombData.Instance.WingParent.transform);
    }

    public void AddNozzleL()
    {
        GameObject wing = Instantiate(BombData.Instance.Nozzles[0], BombData.Instance.NozzleLParent.transform);
    }

    public void AddNozzleR()
    {
        GameObject wing = Instantiate(BombData.Instance.Nozzles[1], BombData.Instance.NozzleRParent.transform);
    }

    public void AddHead()
    {
        GameObject wing = Instantiate(BombData.Instance.Wings[0], BombData.Instance.WingParent.transform);
    }

    public void AddDrillHead()
    {
        GameObject wing = Instantiate(BombData.Instance.DrillWarHeads[0], BombData.Instance.HeadParent.transform);
    }

/*
    public void AddPart()
    {
        GameObject wing = Instantiate(BombData.Instance.DrillWarHeads[0], BombData.Instance.HeadParent.transform);
    }
*/
}
