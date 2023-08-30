using UnityEngine;

public class DestroyPersistedObject : MonoBehaviour
{
    public void DestroyPersistedObjectByName(string objectName)
    {
        GameObject[] persistedObjects = GameObject.FindGameObjectsWithTag("PersistentObject");

        foreach (GameObject obj in persistedObjects)
        {
            if (obj.name == objectName)
            {
                Destroy(obj);
                break;
            }
        }
    }
}
