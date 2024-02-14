using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour //bu dusmana ve kursuna verilecek
{
    [SerializeField] int damage = 10;

    public int GetDamageValue()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

   
}
