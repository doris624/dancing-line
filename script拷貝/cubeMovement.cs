using UnityEngine;

public class cubeMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector3 pos;
    public Material mat;
    private int loopCount = 1;
    public bool onGround = true;
    public float distFromGround=0.6f;
    public bool isAlive = true;
    public GameObject gameover;

    void Update()
    {
        if (isAlive)
        {
            onGround = isGrounded();
            pos = player.transform.position;
            player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (onGround == true)
            {
                GameObject actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                actor2.transform.position = pos;
                actor2.GetComponent<MeshRenderer>().material = mat;
                actor2.GetComponent<BoxCollider>().isTrigger = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (loopCount % 2 != 0)
                    {
                        player.transform.eulerAngles = new Vector3(0, 90, 0);
                        loopCount++;
                    }
                    else
                    {
                        player.transform.eulerAngles = new Vector3(0, 0, 0);
                        loopCount++;
                    }
                }
            }
        }
    }
    public bool isGrounded()
    {
        return Physics.Raycast(player.transform.position,Vector3.down,distFromGround);
    }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "obstacle")
        {
           isAlive = false;
           FlyAway();
           gameover.SetActive(true);
        }
    }
    private void FlyAway()
    {
        GameObject Prime = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject Prime1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject Prime2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Prime.transform.position = pos;
        Prime1.transform.position = pos;
        Prime2.transform.position = pos;
        Prime.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
        Prime1.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 50;
        Prime2.AddComponent<Rigidbody>().velocity = Random.onUnitSphere * 100;
        Prime.GetComponent<MeshRenderer>().material = mat;
        Prime1.GetComponent<MeshRenderer>().material = mat;
        Prime2.GetComponent<MeshRenderer>().material = mat;
    }
}
