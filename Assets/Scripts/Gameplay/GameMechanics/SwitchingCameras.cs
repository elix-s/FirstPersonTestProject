using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonTestProject.Gameplay 
{
    ///<summary>
    ///Переключение между камерами
    ///</summary>
    public class SwitchingCameras : MonoBehaviour 
    {
        #region Private Variables

        [SerializeField] private Camera _camera1;
        [SerializeField] private Camera _camera2;
        [SerializeField] private GameObject _player;
        [SerializeField] private HideObjects _hideObjects;

        #endregion

        #region MonoBehavior

        void Start () {

            _camera2.GetComponent<Camera>().enabled = false;
            _player.GetComponent<TopViewController>().enabled = false;
            _camera2.GetComponent<HideObjects>().enabled = false;
        }

        void Update()
        {
            if(Input.GetKeyDown (KeyCode.R)) {
                if(_camera1.enabled == true)
                {
                    _camera1.GetComponent<Camera> ().enabled = false;
                    _camera2.GetComponent<Camera>().enabled = true;
                    _player.GetComponent<FirstPersonController>().enabled = false;
                    _player.GetComponent<TopViewController>().enabled = true;
                    _camera2.GetComponent<HideObjects>().enabled = true;
                }
                else
                {
                    foreach (RaycastHit hit in _hideObjects.Hits) 
                    {
                        GameObject g = hit.transform.gameObject;

                        if(g)
                        {
                            if(g != _player)
                                g.SetActive(true);
                        }
                    }

                    _camera2.GetComponent<Camera> ().enabled = false;
                    _camera1.GetComponent<Camera>().enabled = true;
                    _player.GetComponent<FirstPersonController>().enabled = true;
                    _player.GetComponent<TopViewController>().enabled = false;
                    _camera2.GetComponent<HideObjects>().enabled = false;
                }
            }
        }

        #endregion

    }
}
