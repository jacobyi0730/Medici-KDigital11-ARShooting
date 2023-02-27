using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��ư�� ������ �Ѿ� ���忡�� �Ѿ��� ����
// ī�޶���ġ�� ��ġ�ϰ�ʹ�.
// �Ѿ��� ī�޶� �չ������� ȸ���ϰ�ʹ�.
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
