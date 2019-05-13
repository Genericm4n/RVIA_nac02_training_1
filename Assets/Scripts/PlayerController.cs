using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // definicao de variaveis

    #region variables

    public float velAtual;
    public float velMax = 2.0f;
    public float xrl8I;
    public float xrl8F;
    public float dxrl8;

    private Animator anime;

    #endregion variables

    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    private void Update()
    {
    }
}