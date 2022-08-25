using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    MaterialPropertyBlock _matBlock;
    SpriteRenderer _renderer;
    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _matBlock = new MaterialPropertyBlock();
        _matBlock.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        _renderer.SetPropertyBlock(_matBlock);
    }

}
