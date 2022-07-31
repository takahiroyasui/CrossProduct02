using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;
    [SerializeField] Text debugText;

    [SerializeField] Material mat1;
    [SerializeField] Material mat2;
    [SerializeField] Material mat3;
    [SerializeField] Material mat4;
    
    private MeshRenderer mesh;

    void Start() {
        mesh = target.GetComponent<MeshRenderer>();
    }

    void Update() {

        var a = player.transform.forward;
        var b = target.transform.position.normalized;

        var dot = Vector3.Dot(a, b);
        var cross = Vector3.Cross(a, b).y;

        var c = Vector3.SignedAngle(a, b, Vector3.up);

        debugText.text = $"cosθ: {dot:F2}\nsinθ: {cross:F2}\n{c:F2}";
        
        if (dot >= 0) {
            if (cross >= 0) {
                mesh.material = mat1;
            } else {
                mesh.material = mat2;
            }
        } else {
            if (cross >= 0) {
                mesh.material = mat3;
            } else {
                mesh.material = mat4;
            }
        }
    }
}
