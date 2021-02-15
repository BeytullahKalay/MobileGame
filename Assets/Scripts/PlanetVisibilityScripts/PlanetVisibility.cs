using UnityEngine;
using UnityEngine.UI;

public class PlanetVisibility : MonoBehaviour
{

    [SerializeField] private float _animationSpeed = 1;
    [SerializeField] private float _increasingInvisibiltySpeed = 3;
    public Image[] _planets;
    public OpenSceneTextManager _textManagerScript;

    private int _buttonPressCounter = 0;

    private Color _tempColor;

    private void Update()
    {

        if (_textManagerScript._pressedButton)
        {
            _buttonPressCounter++;
            _textManagerScript._pressedButton = false;
        }

        if (_buttonPressCounter == _planets.Length)
        {
            _buttonPressCounter = 0;
        }

        if (_buttonPressCounter == 0)
        {
            _tempColor = _planets[_buttonPressCounter].color;
            _tempColor.a += _animationSpeed * Time.deltaTime;
            _planets[_buttonPressCounter].color = _tempColor;

            _tempColor = _planets[_planets.Length - 1].color;
            _tempColor.a -= (_animationSpeed + _increasingInvisibiltySpeed) * Time.deltaTime;
            _planets[_planets.Length - 1].color = _tempColor;

        }

        if (_buttonPressCounter != 0)
        {
            _tempColor = _planets[_buttonPressCounter - 1].color;
            _tempColor.a -= (_animationSpeed + _increasingInvisibiltySpeed) * Time.deltaTime;
            _planets[_buttonPressCounter - 1].color = _tempColor;


            _tempColor = _planets[_buttonPressCounter].color;
            _tempColor.a += _animationSpeed * Time.deltaTime;
            _planets[_buttonPressCounter].color = _tempColor;


        }
    }
}
