using UnityEngine;

public class ButtonPlayer : MonoBehaviour
{
    bool checkOpen = true;
    public void ClickButtonAttack()
    {
        GameManager.instance.Attack();
    }
    public void ClickPickUp()
    {

    }
    public void ClickBackPack()
    {
        if (checkOpen = !checkOpen)
        {
            FindObjectOfType<GameManager>().backPack.SetActive(false);
        }
        else
        {
            FindObjectOfType<GameManager>().backPack.SetActive(true);
        }

    }
}
