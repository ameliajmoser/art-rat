using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int brushSize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipheight; //checks if brush is touching canvas

    private RaycastHit _touch;
    private canvas _canvas;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    //private Material _pickedMaterial;
    public Color red;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = tip.GetComponent<Renderer>();
        _colors = Enumerable.Repeat(_renderer.material.color, brushSize * brushSize).ToArray();
        _tipheight = 0.08f; //hardcoding for now


    }

    private void Draw()
    {
        if (Physics.Raycast(tip.position, transform.up, out _touch, _tipheight))
        {
            if (_touch.transform.CompareTag("Canvas"))
            {
                if (_canvas == null)
                {
                    _canvas = _touch.transform.GetComponent<canvas>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                //find where on canvas you are touching
                var x = (int)(_touchPos.x * _canvas.textureSize.x - (brushSize / 2));
                var y = (int)(_touchPos.y * _canvas.textureSize.y - (brushSize / 2));

                // if out of bounds then don't draw
                if (y < 0 || y > _canvas.textureSize.y || x < 0 || x > _canvas.textureSize.x)
                {
                    return;
                }

                if (_touchedLastFrame)
                {
                    //set orig touched point
                    _canvas.texture.SetPixels(x, y, brushSize, brushSize, _colors);
                    //interpolate to make a line
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _canvas.texture.SetPixels(lerpX, lerpY, brushSize, brushSize, _colors);
                    }
                    //prevents brush from "flattening"
                    // transform.rotation = _lastTouchRot;

                    _canvas.texture.Apply(); //sets everything and updates texture
                }
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }
        _canvas = null;
        _touchedLastFrame = false;
    }
    // Update is called once per frame
    void Update()
    {
        Draw();

    }
}


//void OnCollisionEnter(Collider other)
//{
//    if (other.gameObject.tag == "red")
//    {
//        // Change the color of the brush to red
//        //_colors = Enumerable.Repeat(red, brushSize * brushSize).ToArray();
//        //_renderer.material.color = red;
//        //Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();
//        //_renderer.material = collidedRenderer.material;
//        var collidedMaterial = other.GetComponent<Renderer>().material;
//        _renderer.material = collidedMaterial;
//        _colors = Enumerable.Repeat(_renderer.material.color, brushSize * brushSize).ToArray();
//    }
//}

