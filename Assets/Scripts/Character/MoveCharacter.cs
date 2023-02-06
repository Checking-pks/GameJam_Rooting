using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private NearDetection detection;
    [SerializeField]
    private static float ALREADY_VISIT_MOVE_SPEED = 10.0f;
    private static float FIRST_TIME_MOVE_SPEED = 5.0f;
    private float moveSpeed = 10.0f;
    private Vector3 target;
    private Vector3 start;
    private float nowTime = 0;
    public bool isMove = false;

    void Start()
    {
        nowTime = 1.1f;
        detection = GetComponent<NearDetection>();
    }
    void Update()
    {
        transform.position = Vector3.Lerp(start, target, nowTime);
        if (nowTime <= 1.5f)
        {
            isMove = true;
            nowTime += moveSpeed * Time.deltaTime;
        }
        else
        {
            isMove = false;
            errorDetection();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PressKey("Left");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PressKey("Right");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PressKey("Forward");
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PressKey("Back");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                PressKey("Up");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                PressKey("Down");
            }

            GameObject centerObj = detection.GetGameObject(EnumManager.detection.center);

            if (centerObj != null)
            {
                if (centerObj.tag == "Spot")
                {
                    if (centerObj.GetComponent<SpotInfo>().Item != null)
                    {
                        spotProcessing(centerObj.GetComponent<SpotInfo>());
                    }
                }
            }
        }
    }

    public void PressKey(string arrow)
    {
        if (nowTime <= 1.2f) return;

        switch(arrow){
            case "Left" : // left
                if (isOverWorld(transform.position - transform.right)) return;
                target = transform.position - transform.right;
                lineProcessing(detection.GetGameObject(EnumManager.detection.left)?.GetComponent<LineInfo>());
                break;

            case "Right" : // right
                if (isOverWorld(transform.position + transform.right)) return;
                target = transform.position + transform.right;
                lineProcessing(detection.GetGameObject(EnumManager.detection.right)?.GetComponent<LineInfo>());
                break;

            case "Forward" : // forward
                if (isOverWorld(transform.position + transform.forward)) return;
                target = transform.position + transform.forward;
                lineProcessing(detection.GetGameObject(EnumManager.detection.front)?.GetComponent<LineInfo>());
                break;

            case "Back" :
                if (isOverWorld(transform.position - transform.forward)) return;
                target = transform.position - transform.forward;
                lineProcessing(detection.GetGameObject(EnumManager.detection.back)?.GetComponent<LineInfo>());
                break;

            case "Up" : // w
                if (isOverWorld(transform.position + transform.up)) return;
                target = transform.position + transform.up;
                lineProcessing(detection.GetGameObject(EnumManager.detection.up)?.GetComponent<LineInfo>());
                break;

            case "Down" : // s
                if (isOverWorld(transform.position - transform.up)) return;
                target = transform.position - transform.up;
                lineProcessing(detection.GetGameObject(EnumManager.detection.down)?.GetComponent<LineInfo>());
                break;
        }
        
        start = transform.position;
        nowTime = 0;
    }

    private void errorDetection()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }

    private bool isOverWorld(Vector3 pos)
    {
        if (pos.x > MapManager.Instance.width/2 +0.1  || pos.x < -MapManager.Instance.width /2 -0.1) return true;
        if (pos.y > 0 +0.1                            || pos.y < -MapManager.Instance.depth +1 -0.1) return true;
        if (pos.z > MapManager.Instance.height/2 +0.1 || pos.z < -MapManager.Instance.height/2 -0.1) return true;

        return false;
    }

    private void lineProcessing(LineInfo line)
    {
        if (line == null) return;

        moveSpeed = (line.needMovement > 0) ? FIRST_TIME_MOVE_SPEED : ALREADY_VISIT_MOVE_SPEED;

        GameMgr.Instance.remainingMovement -= line.needMovement;
        line.needMovement = 0;
        line.AlreadyVisit = true;
        line.UpdateMeshRenderer(FIRST_TIME_MOVE_SPEED * Time.deltaTime);
    }

    private void spotProcessing(SpotInfo spot)
    {
        if (spot == null) return;

        GameMgr.Instance.remainingMovement += spot.recoverMovement;
        TreeManager.Instance.GetItems = spot.Item;
        spot.Item = null;
    }

    public void reset() {
        target = Vector3.zero;
        start = Vector3.zero;
        nowTime = 1.3f;
    }
}