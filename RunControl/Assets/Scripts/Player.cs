using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager _gameManager;
    public CameraMovement _camera;
    public bool isItOver;
    public GameObject stopPoint;

    private void FixedUpdate()
    {
        if (!isItOver)
        {
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
        }
        
    }

    private void Update()
    {
        if (isItOver)
        {
            transform.position = Vector3.Lerp(transform.position, stopPoint.transform.position, 1.1f * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z),
                        0.3f);
                }

                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z),
                        0.3f);
                }
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carpma") || other.gameObject.CompareTag("Toplama")
            || other.gameObject.CompareTag("Cikarma") || other.gameObject.CompareTag("Bolme"))
        {
            int number = int.Parse(other.name);
            _gameManager.Create_Player(other.tag, number, other.transform);
        }
        else if (other.gameObject.CompareTag("lastTrigger"))
        {
            _gameManager.Enemies_Trigger();
            _camera.isItOver = true;
            isItOver = true;
        }
    }
}
