using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonTestProject.Gameplay 
{
    ///<summary>
    ///Следование камеры с видом сверху
    ///</summary>
    public class TopCamera : MonoBehaviour
    {
        #region private Variables

        [SerializeField] private float _offset;
        [SerializeField] private GameObject _player;

        #endregion
        
        #region MonoBehaviour

        void Start()
        {
            transform.position = new Vector3(_player.transform.position.x, transform.position.y + _offset, _player.transform.position.z);
        }

        void Update()
        {
            transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        }

        #endregion
    }
}
