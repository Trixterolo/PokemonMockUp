using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float currentHp = health.transform.localScale.x;//declares current HP as the local scale health
        float changeAmount = currentHp - newHp; //newHp is the new currentHp after taking dmg.

        while (currentHp - newHp > Mathf.Epsilon)
        {
            currentHp -= changeAmount * Time.deltaTime;//smooth actual change when taking dmg
            health.transform.localScale = new Vector3(currentHp, 1f);//updates health bar scale with curernthp after taking dmg
            yield return null;
        }

        health.transform.localScale = new Vector3(newHp, 1f);//sets currenthp to newHp.
    }
}
