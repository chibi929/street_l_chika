using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chibi929
{
  public class ChikaChika : MonoBehaviour
  {
    [Header("Settings")]
    [SerializeField] private float _waitTime = 3;
    [SerializeField] private float _delayTime = 0;

    [Header("Object Settings")]
    [Tooltip("設定されていると優先的に使用する。設定されていない場合は Children から Light を探します。")]
    [SerializeField] private Light _light;

    [Header("Other Settings")]
    [SerializeField] private bool _isRepeating = false;

    private Material _mat;

    void Awake()
    {
      _mat = GetComponent<MeshRenderer>().material;
      if (!_light)
      {
        _light = GetComponentInChildren<Light>();
      }
      TurnOff();
    }

    void Start()
    {
      StartCoroutine(PlayChikaChika());
    }

    private IEnumerator PlayChikaChika()
    {
      yield return new WaitForSeconds(_delayTime + _waitTime);
      do
      {
        TurnOn();
        yield return new WaitForSeconds(0.3f);
        TurnOff();
        yield return new WaitForSeconds(0.1f);
        TurnOn();
        yield return new WaitForSeconds(0.075f);
        TurnOff();
        yield return new WaitForSeconds(0.075f);
        TurnOn();
        yield return new WaitForSeconds(0.075f);
        TurnOff();
        yield return new WaitForSeconds(0.3f);
        TurnOn();

        if (_isRepeating)
        {
          yield return new WaitForSeconds(5.0f);
          TurnOff();
          yield return new WaitForSeconds(5.0f);
        }
      } while (_isRepeating);
    }

    private void TurnOn()
    {
      _mat.EnableKeyword("_EMISSION");
      if (_light)
      {
        _light.enabled = true;
      }
    }

    private void TurnOff()
    {
      _mat.DisableKeyword("_EMISSION");
      if (_light)
      {
        _light.enabled = false;
      }
    }
  }
}
