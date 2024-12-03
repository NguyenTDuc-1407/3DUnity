using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int hpNow;
    public int energyNow;
    Vector3 moveCharacter;
    private ControllerJoysticks controllerJoysticks;
    private CharacterController characterController;
    private Animator animatiorPlayer;
    public int moveSpeed;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        controllerJoysticks = FindObjectOfType<ControllerJoysticks>();
        animatiorPlayer = GetComponent<Animator>();
    }
    // void TakeEnergy()
    // {
    //     WaitForSeconds delay = new WaitForSeconds(5);
    //     energyNow -= 1;
    // }
    void Update()
    {
        // TakeEnergy();
        CharacterMove();
    }
    public void Attack()
    {
        if (!animatiorPlayer.GetBool("Run"))
        {
            animatiorPlayer.SetTrigger("Attack");
        }
    }
    void CharacterMove()
    {
        moveCharacter = Vector3.zero;
        moveCharacter.x = controllerJoysticks.Horizontal() * moveSpeed;
        moveCharacter.z = controllerJoysticks.Vertical() * moveSpeed;
        if (moveCharacter.x != 0 || moveCharacter.z != 0)
        {
            animatiorPlayer.SetBool("Run", true);
        }
        else
        {
            animatiorPlayer.SetBool("Run", false);
        }
        if (Vector3.Angle(Vector3.forward, moveCharacter) > 1f || Vector3.Angle(Vector3.forward, moveCharacter) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveCharacter, moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        characterController.Move(moveCharacter * Time.deltaTime);
    }
}
