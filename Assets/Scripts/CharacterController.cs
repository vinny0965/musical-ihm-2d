using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do personagem

    public void MoverFrente()
    {
        MoveCharacter(Vector3.forward);
    }

    public void MoverTras()
    {
        MoveCharacter(Vector3.back);
    }

    public void Subir()
    {
        MoveCharacter(Vector3.up);
    }

    public void Descer()
    {
        MoveCharacter(Vector3.down);
    }

    private void MoveCharacter(Vector3 direction)
    {
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
