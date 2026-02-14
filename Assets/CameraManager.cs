using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public CinemachineFramingTransposer body;
    public Transform cameraAnchor;
    public float lerpSpeed;
    public float maxOffset;
    public float minOffset;
    // Start is called before the first frame update
    void Start()
    {
        body = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        float distance = Vector3.Distance(cameraAnchor.position, Camera.main.transform.position);
        float targetOffset = Mathf.Lerp(minOffset, maxOffset, distance / body.m_CameraDistance);
        float newOffset = Mathf.Lerp(cameraAnchor.localPosition.y, targetOffset, Time.deltaTime * lerpSpeed);
        cameraAnchor.localPosition = new Vector3(0, newOffset, 0);

        //Debug.Log($"Distance {distance}, newOffset {newOffset}, cameraDistance {body.m_CameraDistance}, meow");
    }
}
