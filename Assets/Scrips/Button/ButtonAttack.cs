using UnityEngine;

public class ButtonAttack : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void ClickButtonAttack(){
        player.Attack();
    }

}
