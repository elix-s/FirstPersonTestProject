using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonTestProject.Gameplay 
{
    ///<summary>
    ///Управление от первого лица
    ///</summary>
    public class FirstPersonController : MonoBehaviour 
    {
        #region Private Variables

        [SerializeField] private float _speed;
        [SerializeField] private GameObject _camera;
        [SerializeField] private float _jumpForce;
        [SerializeField] private LayerMask _groundMask;
        private float _mouseSensitivityX = 1.0f;
        private float _mouseSensitivityY = 1.0f;
        private Vector3 _moveDistance;
        private Vector3 _smoothMove;
        private Transform _cameraTransform;
        private float _verticalLookRotation;
        private Rigidbody _rigidbody;
        private bool _grounded;
        private bool _cursorVisible;

        #endregion

        #region Private Methods

        ///<summary>
        ///Скрытие курсора
        ///</summary>
        private void UnlockMouse() 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _cursorVisible = true;
        }

        private void LockMouse() 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _cursorVisible = false;
        }

        #endregion

        #region MonoBehavior

        void Start () {
            _cameraTransform = _camera.transform;
            _rigidbody = GetComponent<Rigidbody> ();
            LockMouse ();
        }
        
        void Update () {
            //вращение камеры
            transform.Rotate (Vector3.up * Input.GetAxis ("Mouse X") * _mouseSensitivityX);
            _verticalLookRotation += Input.GetAxis ("Mouse Y") * _mouseSensitivityY;
            _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -60, 60);
            _cameraTransform.localEulerAngles = Vector3.left * _verticalLookRotation;

            //перемещение 
            Vector3 moveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
            Vector3 targetMoveAmount = moveDir * _speed;
            _moveDistance = Vector3.SmoothDamp (_moveDistance, targetMoveAmount, ref _smoothMove, 0.15f);

            //прыжок
            if (Input.GetKeyDown(KeyCode.Space)) {
                if(_grounded) {
                    _rigidbody.AddForce(transform.up * _jumpForce);
                }
            }

            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1 + 0.1f, _groundMask)) 
                _grounded = true;
            else
                _grounded = false;

            if (Input.GetMouseButtonUp (0)) 
            {
                if(!_cursorVisible) 
                    UnlockMouse ();
                 else 
                    LockMouse ();
            }
        }

        void FixedUpdate() {
            _rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(_moveDistance) * Time.fixedDeltaTime);
        }

        #endregion
    }
}
