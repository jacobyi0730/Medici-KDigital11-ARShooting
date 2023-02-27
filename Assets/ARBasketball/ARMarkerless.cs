using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

// ARRaycastManager를 이용해서 바라보고싶다.
// 만약 바라본곳이 위치로 인식된곳이라면
// 그곳에 인디케이터를 배치하고싶다.
// 만약 인디케이터가 배치된 상황이고 그곳을 터치했다면
// 그 곳에 물체를 배치하고싶다.
public class ARMarkerless : MonoBehaviour
{
    ARRaycastManager arRaycastManager;
    BasketBallPlayer bbp;

    public GameObject indicator;
    public GameObject unitFactory; // Hoop
    List<GameObject> units = new List<GameObject>();
    int unitCount = 0;
    public int unitMaxCount = 1;
    int chooseIndex;
    Vector2 center;
    // Start is called before the first frame update
    void Start()
    {
        center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        arRaycastManager = GetComponent<ARRaycastManager>();
        bbp = GetComponent<BasketBallPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateForAndroid();
    }

    private void UpdateForAndroid()
    {
        // arRaycastManager를 이용해서 바라보고싶다.
       
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(center, hits))
        {
            // 닿은곳이 있다면 그 곳에 indicator를 배치하고싶다.
            indicator.SetActive(true);
            indicator.transform.position = hits[0].pose.position;
            indicator.transform.rotation = hits[0].pose.rotation;
        }

        // 화면을 터치했을 때 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // 만약 부딪힌것이 indicator라면 
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // 그곳에 물체를 배치하고싶다.
                    MakeUnit();
                }
            }

        }

    }

    void MakeUnit()
    {
        // 만약 인디케이터가 배치된 상황이고 그곳을 터치했다면
        // 그 곳에 물체를 배치하고싶다.
        // 최초 1회는 생성
        // 그 이후부터는 배치만 하고싶다.
        if (unitCount < unitMaxCount)
        {
            GameObject unit = Instantiate(unitFactory);
            units.Add(unit);
            unitCount++;
        }
        units[chooseIndex].transform.position = indicator.transform.position;

      

        chooseIndex++;
        if (chooseIndex >= unitMaxCount)
        {
            chooseIndex = 0;
        }

    }

    public void OnMyHoopOk()
    {
        bbp.enabled = true;
        arRaycastManager.enabled = false;
        this.enabled = false;
    }
}
