using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Vector3 MoveCharacter;
    private ControllerJoysticks controllerJoysticks;
    private CharacterController characterController;
    private Animator animatiorPlayer;
    public int MoveSpeed;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        controllerJoysticks = FindObjectOfType<ControllerJoysticks>();
        animatiorPlayer = GetComponent<Animator>();
    }
    void Update()
    {
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
        MoveCharacter = Vector3.zero;
        MoveCharacter.x = controllerJoysticks.Horizontal() * MoveSpeed;
        MoveCharacter.z = controllerJoysticks.Vertical() * MoveSpeed;
        if (MoveCharacter.x != 0 || MoveCharacter.z != 0)
        {
            animatiorPlayer.SetBool("Run", true);
        }
        else
        {
            animatiorPlayer.SetBool("Run", false);
        }
        if (Vector3.Angle(Vector3.forward, MoveCharacter) > 1f || Vector3.Angle(Vector3.forward, MoveCharacter) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, MoveCharacter, MoveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        characterController.Move(MoveCharacter * Time.deltaTime);
    }
}
