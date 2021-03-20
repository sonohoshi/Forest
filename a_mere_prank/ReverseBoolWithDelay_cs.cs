/*
* How To Use
* bool isMoving = true;
* StartCoroutine(isMoving.ReverseBoolWithDelay(minDelay, maxDelay, result => isMoving = result));
*/
public static IEnumerator ReverseBoolWithDelay(this bool origin, float minDelay, float maxDelay, Action<bool> reverseVariable)
{
    reverseVariable(!origin);
    var delay = Random.Range(minDelay, maxDelay);
    yield return new WaitForSeconds(delay);

    reverseVariable(origin);
}