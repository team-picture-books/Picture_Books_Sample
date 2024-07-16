using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // �v���C���[�̈ړ����x
    public float rotationSpeed = 100f;  // �v���C���[�̉�]���x
    private CharacterController controller;  // CharacterController �R���|�[�l���g�̎Q��
    private float gravity = 9.81f;  // �d�͂̉����x

    void Start()
    {
        // CharacterController �R���|�[�l���g���擾
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �L�[�{�[�h���͂̎擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �}�E�X�̈ړ��ʂ��擾���ăv���C���[����]������
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.fixedDeltaTime);

        // �ړ������̌v�Z
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // �d�͂̓K�p
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // �ړ�
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
