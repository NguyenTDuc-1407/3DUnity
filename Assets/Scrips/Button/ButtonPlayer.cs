using UnityEngine;

public class ButtonPlayer : MonoBehaviour
{
    bool checkOpen = true;
    public void ClickButtonAttack()
    {
        FindObjectOfType<GameManager>().UpdateGameState(GameManager.GameState.playerAtack);
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
