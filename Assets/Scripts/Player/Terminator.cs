using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminator : WandChange
{
    public GameObject ammo,
                      wand_pos;
    public Transform gunpoint;
    public float currentMana = 100f;
    private int max_mana = 100;
    public Image manabar;
    public GameObject[] weaponary, 
                        bullet_effects;
    private bool _clickTiming = true;
   
    void Update()
    {
        WeaponChanging(weaponary, bullet_effects, ref ammo, wand_pos.transform.position);
        if (Input.GetMouseButtonDown(0) & _clickTiming)
        {
            _clickTiming = false;
            Shoot();
        }
        manabar.fillAmount = currentMana / max_mana;
        StartCoroutine(Timing());
    }

    private void FixedUpdate()
    {
        currentMana += 0.1f;
        if (currentMana > max_mana)
        {
            currentMana = max_mana;
        }
    }
    void Shoot()
    {
        Instantiate(ammo, gunpoint.position, Quaternion.identity);
    }

    IEnumerator Timing ()
    {
        yield return new WaitForSeconds(0.1f);
        _clickTiming = true;
    }
}

