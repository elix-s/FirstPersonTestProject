using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonTestProject.Gameplay 
{
    ///<summary>
    ///Скрытие объектов между камерой и игроком
    ///</summary>
    public class HideObjects : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private GameObject _player;

        ///<summary>
        ///Массив объектов, в которые попадает луч
        ///</summary>
        private RaycastHit[] _hits = null;

        #endregion

        #region Properties

        public RaycastHit[] Hits
        {
            get => _hits;
        }

        #endregion

        #region MonoBehavior

        private void Update() 
        {
            if (_hits != null) 
            {
                foreach (RaycastHit hit in _hits) 
                {
                    GameObject g = hit.transform.gameObject;

                    if(g)
                    {
                        if(g != _player)
                            g.SetActive(true);
                    }
                }
            }
    
            _hits = Physics.RaycastAll(transform.position, (_player.transform.position - transform.position), Vector3.Distance(transform.position, _player.transform.position));
    
            foreach (RaycastHit hit in _hits) 
            {
                GameObject g = hit.transform.gameObject;
                
                if(g)
                {
                    if(g != _player)
                        g.SetActive(false);
                }
            }    
        }

        #endregion
    }
}
