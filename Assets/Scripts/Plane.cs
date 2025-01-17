// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Plane : SceneEntity
{
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 normal;
    
    public Vector3 Center => this.center;
    public Vector3 Normal => this.normal;

    /*
    public override RaycastHit? Intersect(Ray ray)
    {
        // By default we use the Unity engine for ray-entity collisions.
        // See the parent 'SceneEntity' class definition for details.
        // Task: Replace with your own intersection computations.
        return base.Intersect(ray);
    }
    */

    // New Intersect
    public override RaycastHit? Intersect(Ray ray)
    {
        var toPlane = center - ray.origin;
        var toPlaneDotNormal = Vector3.Dot(toPlane, normal);
        var rayDotNormal = Vector3.Dot(ray.direction, normal);
        var t = toPlaneDotNormal / rayDotNormal;

        var hitPoint = ray.origin + t * ray.direction;

        if (t>0f && Vector3.Dot(ray.direction, normal) < 0f)
        {
            var hit = new RaycastHit();
            hit.distance = t;
            hit.point = ray.origin + t * ray.direction;
            return hit;
        }
        return null;
    }

}
