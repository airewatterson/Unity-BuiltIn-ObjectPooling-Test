using UnityEngine;

public class Cube : MonoBehaviour
{
    //簡單推動東西的程式而已，不用看
    private Rigidbody _rigidbody;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(Vector3.up * speed * Time.deltaTime);
    }
}
