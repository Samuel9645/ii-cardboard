using UnityEngine;

public class Collectible : MonoBehaviour {
  public TreasureNotifier treasureNotifier;

  private void OnEnable() {
    treasureNotifier.OnTreasurePointed += OnTreasurePointed;
  }

  public void OnPointerExit() {
  }

  public void OnPointerClick() {
  }

  private void Update() {
    if (_transform_to_move != null) {
      MoveToTransform(_transform_to_move);
    }
  }

  private void MoveToTransform(Transform targetObject) {
    if (targetObject == null) {
      return;
    }
    const float stopThreshold = 0.1f;
    if (
      Vector3.Distance(transform.position, targetObject.position)
      <= stopThreshold) {
      _transform_to_move = null;
      return;
    }

    Vector3 direction =
        (targetObject.position - transform.position).normalized;
    transform.Translate(
      Time.deltaTime * 10 * direction.normalized,
      Space.World
    );
  }

  private void OnTreasurePointed(Transform transform_to_move) {
    _transform_to_move = transform_to_move;
  }

  private void OnPointerEnter() {
    transform.position = _hiddenPosition;
  }

  private Transform _transform_to_move;

  private static Vector3 _hiddenPosition = new Vector3(0, 20, 0);
}