using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int _hits = 1;
    [SerializeField] int _points = 100;
    [SerializeField] Vector3 _rotator;

    Renderer _renderer;
    Material _orgMaterial;
    [SerializeField] Material _hitMaterial;
    void Start()
    {
        transform.Rotate(_rotator * (transform.position.x + transform.position.y) * 0.1f);
        _renderer = GetComponent<Renderer>();
        _orgMaterial = _renderer.sharedMaterial;
    }

    void Update()
    {
        transform.Rotate(_rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _hits--;
        if (_hits < 1)
        {
            GameManager.Instance.Score += _points;
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = _hitMaterial;
        Invoke("RestoreMaterial", 0.1f);
    }

    void RestoreMaterial()
    {
        _renderer.sharedMaterial = _orgMaterial;
    }
}
