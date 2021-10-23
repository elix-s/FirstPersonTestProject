using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonTestProject.Gameplay 
{
    ///<summary>
    ///Управление камерой с видом сверху
    ///</summary>
    public class TopViewController : MonoBehaviour 
    {
        #region Private Variables

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        #endregion

        #region  MonoBehavior

        void FixedUpdate()
        {
            float move = Input.GetAxis("Horizontal");
            float move_vertical = Input.GetAxis("Vertical");
            _rigidbody.velocity = new Vector3(move * _speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
            _rigidbody.velocity = new Vector3( _rigidbody.velocity.x, _rigidbody.velocity.y, move_vertical * _speed);
        }

        #endregion
    }
}
