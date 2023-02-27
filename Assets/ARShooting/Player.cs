using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 버튼이 눌리면 총알 공장에서 총알을 만들어서
// 카메라위치에 배치하고싶다.
// 총알을 카메라 앞방향으로 회전하고싶다.
public class Player : MonoBehaviour
{
    public Button buttonFire;
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        buttonFire.onClick.AddListener(OnMyFire);
    }

    void OnMyFire()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.forward = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR && FIRE_TEST
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnMyFire();
        }
#endif
    }

}
