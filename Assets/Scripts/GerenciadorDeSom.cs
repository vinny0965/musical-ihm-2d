using UnityEngine;

public class GerenciadorDeSom : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip somDaNota; // Atribua o som da nota no Inspector
    public AudioClip somDePerda; // Atribua o som de perda no Inspector

    private void Start()
    {
        // Obtém o componente AudioSource do objeto "GerenciadorDeSom"
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto que colidiu tem uma tag específica (opcional)
        if (collision.gameObject.CompareTag("Player")) // Substitua "Player" pela tag do objeto que deve tocar a nota
        {
            // Toca o som da nota musical
            TocarSom(somDaNota);
        }
    }

    // Função para tocar um som
    private void TocarSom(AudioClip som)
    {
        if (audioSource != null)
        {
            audioSource.clip = som;
            audioSource.Play();
        }
    }

    // Função para tocar o som de perda
    public void TocarSomDePerda()
    {
        TocarSom(somDePerda);
    }
}
