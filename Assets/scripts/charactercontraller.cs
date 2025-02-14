using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontraller : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] private float lateralSmoothSpeed = 10f;
    private float[] xPosition = { -5f, -2f, 1f };
    private int currentXpositionIndex = 1;
    Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody'yi al (Eðer Inspector'den atamadýysan)
        targetPosition = transform.position;
    }

    void Update()
    {
        // A tuþuna basýnca sola kaydýr
        if (Input.GetKeyDown(KeyCode.A) && currentXpositionIndex > 0)
        {
            currentXpositionIndex--;
            targetPosition = new Vector3(xPosition[currentXpositionIndex], transform.position.y, transform.position.z);
        }

        // D tuþuna basýnca saða kaydýr
        if (Input.GetKeyDown(KeyCode.D) && currentXpositionIndex < xPosition.Length - 1)
        {
            currentXpositionIndex++;
            targetPosition = new Vector3(xPosition[currentXpositionIndex], transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        // Ýleri doðru hareket
        Vector3 forwardMove = Vector3.forward * speed * Time.fixedDeltaTime;
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * 1, ForceMode.Force);
        Vector3 currentPosition = rb.position;
        Vector3 lateralMove = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * lateralSmoothSpeed);
        Vector3 combineMove = new Vector3(lateralMove.x, transform.position.y, rb.position.z) + forwardMove;
        rb.MovePosition(combineMove);



        // Yan hareketi yumuþak yapmak için Lerp
        //rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, lateralSmoothSpeed * Time.deltaTime));
    }
}
