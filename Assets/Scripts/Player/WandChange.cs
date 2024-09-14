using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WandChange : MonoBehaviour
{
    public int wandNumber = 0;
    private GameObject _currentWand;
    public void WeaponChanging(GameObject[] weaponary, GameObject[] bullet_effects, ref GameObject Self_ammo, Vector3 wand_pos)
    {
        if (Input.GetKeyDown("1"))
        {
            weaponary[wandNumber].SetActive(false);
            wandNumber = 0;
            weaponary[0].SetActive(true);
            Self_ammo = bullet_effects[0];
        }
        else if (Input.GetKeyDown("2"))
        {
            weaponary[wandNumber].SetActive(false);
            wandNumber = 1;
            weaponary[1].SetActive(true);
            Self_ammo = bullet_effects[1];
        }
    }
}
