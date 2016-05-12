using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class CrosshairColor : MonoBehaviour
{
    public Image[] images;
    TurretControl[] turretsToWatch;

    public Color aimedColor;
    public Color unAimedColor;

    void Start()
    {
        turretsToWatch = GameObject.FindObjectsOfType(typeof(TurretControl)) as TurretControl[];
        Debug.Log(turretsToWatch.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (turretsToWatch.Any<TurretControl>(x => x.IsAimed))
        {
            foreach (var i in images)
            {
                i.color = aimedColor;
            }
        }
        else
        {
            foreach (var i in images)
            {
                i.color = unAimedColor;
            }
        }
    }
}
