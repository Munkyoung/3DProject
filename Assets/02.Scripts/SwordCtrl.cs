using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ITakeDamagealbe damage = other.GetComponent<ITakeDamagealbe>();
            if (damage != null)
            {
                damage.TakeDamage(GlobalValue.curAtt);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
