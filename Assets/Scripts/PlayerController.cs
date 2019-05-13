using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // definir de variaveis

    #region variables

    public float velAtual;          // velocidade atual da personagem
    public float velMax = 4.0f;     // velocidade maxima permitida para a personagem
    public float xrl8I = 0.3f;      // aceleracao inicial da personagem
    public float xrl8 = 0.01f;      // aceleracao base
    public float dxrl8 = 0.07f;     // desaceleracao da personagem ao parar de deslocar
    public float velRot = 130.0f;   // velocidade de rotacao da personagem

    // criar uma pontuacao
    public static int point;        // pontuacao do jogador

    public Text txtPoint;           // texto que exibira a pontuacao

    // chamar um GameObject para o portal
    public GameObject portal;

    // criar uma variavel para chamar o componente
    private Animator anime;

    #endregion variables

    private void Awake()
    {
        // chamar o componente a partir da variavel
        anime = GetComponent<Animator>();

        // definir o valor inicial da pontuacao ao iniciar a partida
        point = 0;
    }

    private void Update()
    {
        // definir a rotacao do personagem - pt.1: input
        float h = Input.GetAxisRaw("Horizontal");

        // definir a rotacao do personagem - pt.2: rotacao
        Vector3 rotation = Vector3.up * h * velRot * Time.deltaTime;

        // definir a movimentacao do personagem
        float v = Input.GetAxisRaw("Vertical");

        // configurar a velocidade
        if (v > 0 && velAtual < velMax)     // SE input VERTICAL for pressionado e a velocidade atual for menor que a maxima
        {
            velAtual += (velAtual == 0) ? xrl8I : xrl8;     // SE velocidade atual é 0, é aplicada a aceleracao inicial, fora desta condicao, aplica-se a aceleracao base
        }
        else if (v == 0 && velAtual > 0)    // Se input VERTICAL deixar de ser pressionado e a velocidade atual for maior que 0
        {
            velAtual -= dxrl8;              // inicia a desaceleracao
        }

        // definir valor minimo e maximo para a velocidade atual, ou seja, impedir que ela seja maior que a velocidade maxima
        velAtual = Mathf.Clamp(velAtual, 0, velMax);

        // permitir que o personagem so rotacione quando comecar a se deslocar
        if (velAtual > 0)
        {
            transform.Rotate(rotation);
        }

        // deslocamento horizontal da personagem ao iniciar a movimentacao
        transform.Translate(Vector3.forward * velAtual * Time.deltaTime);

        // chamar o blendtree
        float valAni = Mathf.Clamp(velAtual / velMax, 0, 1);
        anime.SetFloat("speed", valAni);

        // associar o texto da pontuacao aos pontos
        txtPoint.text = point.ToString();

        // ativando o portal
        if (point == 6)
        {
            portal.SetActive(true);
        }
    }

    // detectando colisao
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Portal")
        {
            StartCoroutine("SceneTransition");
        }
    }

    // courotine para transicao de cena
    private IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("_credits");
    }
}