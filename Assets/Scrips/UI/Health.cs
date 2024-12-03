using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image hpBar;
    public void updateBar(int nowHp, int maxHp)
    {
        hpBar.fillAmount = (float)nowHp / (float)maxHp;
    }
}
