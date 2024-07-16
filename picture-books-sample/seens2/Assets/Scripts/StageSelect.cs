using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public GameObject[] stages;  // ���I�u�W�F�N�g�̔z��
    public string[] sceneNames;  // �Ή�����V�[�����̔z��

    private Camera mainCamera;
    private bool isMoving = false;  // �J�������ړ������ǂ������Ǘ�����t���O

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                for (int i = 0; i < stages.Length; i++)
                {
                    if (hit.transform.gameObject == stages[i])
                    {
                        StartCoroutine(MoveCameraAndChangeScene(stages[i].transform.position, sceneNames[i]));
                        break;
                    }
                }
            }
        }
    }

    private System.Collections.IEnumerator MoveCameraAndChangeScene(Vector3 targetPosition, string sceneName)
    {
        isMoving = true;
        Vector3 initialPosition = mainCamera.transform.position;
        Vector3 finalPosition = targetPosition + new Vector3(0, 5, -5);
        float elapsedTime = 0;
        float duration = 2.0f;

        while (elapsedTime < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
