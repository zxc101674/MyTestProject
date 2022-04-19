using System.Collections;
using UnityEngine;

namespace Game.GameObjects
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smooth;
        [SerializeField] private float distance;

        private void Start()
        {
            StartCoroutine(EFollow());
        }

        private IEnumerator EFollow()
        {
            while (true)
            {
                UpdatePosition();
                UpdateRotation();
                yield return new WaitForFixedUpdate();
            }
        }

        private void UpdatePosition()
        {
            Vector3 pos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - distance);
            transform.position = Vector3.Lerp(transform.position, pos, smooth);
        }

        private void UpdateRotation()
        {
            transform.LookAt(target, Vector3.forward);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        }
    }
}
