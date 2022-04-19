using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Game.GameObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class MainCharacter : MonoBehaviour
    {
        [SerializeField] private Controller.SceneController sceneController;
        [SerializeField] private float losingHeight;
        [SerializeField] private Move move;

        private Rigidbody rb;
        private Vector3 direction;
        private bool isGround;
        private bool isCanMove;

        void Start()
        {
            rb = GetComponent<Rigidbody>();

            sceneController.OnMoveForward.AddListener((bool isPress) => direction += isPress ? Vector3.forward : -Vector3.forward);
            sceneController.OnMoveBack.AddListener((bool isPress) => direction += isPress ? Vector3.back : -Vector3.back);
            sceneController.OnMoveLeft.AddListener((bool isPress) => direction += isPress ? Vector3.left : -Vector3.left);
            sceneController.OnMoveRight.AddListener((bool isPress) => direction += isPress ? Vector3.right : -Vector3.right);

            StartCoroutine(EBehaviour());
        }

        private void OnCollisionStay(Collision collision) => isGround = true;
        private void OnCollisionExit(Collision collision) => isGround = false;
        public void Stop() => isCanMove = false;

        private IEnumerator EBehaviour()
        {
            isCanMove = true;
            while (isCanMove)
            {
                if (isGround)
                {
                    if (direction.magnitude == 0)
                    {
                        Deceleration();
                    }
                    else
                    {
                        if (rb.velocity.magnitude < move.maxSpeed)
                        {
                            rb.velocity += direction * move.acceleration;
                        }
                    }
                }
                else if (transform.position.y < losingHeight)
                {
                    isCanMove = false;
                    sceneController.Finish(false);
                }
                yield return new WaitForFixedUpdate();
            }
            while (rb.velocity.magnitude > 0.01f)
            {
                rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.fixedDeltaTime * move.deceleration);
                yield return new WaitForFixedUpdate();
            }
        }

        private void Deceleration()
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.fixedDeltaTime * move.deceleration);
        }

        [System.Serializable]
        private struct Move
        {
            public float acceleration;
            public float deceleration;
            public float maxSpeed;
        }
    }
}
