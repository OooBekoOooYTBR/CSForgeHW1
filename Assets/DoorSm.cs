using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSm : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private bool IsRotatingDoor = true;
    [SerializeField]
    private float speed = 1f;
    [Header("Door Anc")]
    [SerializeField]
    private float OpenAngle = 90f;
    [SerializeField]
    private Transform doorPivot; // YENİ: Kapının döneceği pivot noktası
    private Vector3 StartRotation;
    private Coroutine AnimationCoroutine;

    // YENİ EKLEMELER
    private Vector3 pivotStartRotation;

    private void Awake()
    {
        StartRotation = transform.rotation.eulerAngles;

        if (doorPivot == null)
        {
            // pivot atanmamışsa kapının kendisi pivot olur (eski davranış)
            doorPivot = transform;
        }
        else
        {
            // Eğer pivot ayrı bir obje ise kapıyı pivotun çocuğu yap (dönüş pivotuna göre olsun diye)
            if (transform.parent != doorPivot)
            {
                transform.SetParent(doorPivot, true); // worldPositionStays = true
            }
        }

        pivotStartRotation = doorPivot.localEulerAngles;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null) StopCoroutine(AnimationCoroutine);
            if (IsRotatingDoor)
            {
                // pivot noktasından User'a olan yönü hesapla
                Vector3 directionToPivot = (doorPivot.position - UserPosition).normalized;
                float direction = Vector3.Dot(transform.right, directionToPivot);
                AnimationCoroutine = StartCoroutine(DoRotationOpen(direction));
            }
        }
    }

    private IEnumerator DoRotationOpen(float direction)
    {
        float sign = (direction >= 0f) ? 1f : -1f;
        float targetAngle = sign * OpenAngle;

        Quaternion startRot = doorPivot.localRotation;
        Quaternion endRot = Quaternion.Euler(pivotStartRotation + new Vector3(0f, targetAngle, 0f));

        IsOpen = true;
        float t = 0f;
        float dur = Mathf.Max(0.0001f, 1f / Mathf.Max(0.0001f, speed)); // hız -> süre
        while (t < 1f)
        {
            doorPivot.localRotation = Quaternion.Slerp(startRot, endRot, t);
            t += Time.deltaTime / dur;
            yield return null;
        }
        doorPivot.localRotation = endRot; // tam hizala
    }

    public void Close()
    {
        if (IsOpen)
        {
            if (AnimationCoroutine != null) StopCoroutine(AnimationCoroutine);
            if (IsRotatingDoor)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRot = doorPivot.localRotation;
        Quaternion endRot = Quaternion.Euler(pivotStartRotation);

        IsOpen = false;
        float t = 0f;
        float dur = Mathf.Max(0.0001f, 1f / Mathf.Max(0.0001f, speed));
        while (t < 1f)
        {
            doorPivot.localRotation = Quaternion.Slerp(startRot, endRot, t);
            t += Time.deltaTime / dur;
            yield return null;
        }
        doorPivot.localRotation = endRot;
    }
}
