using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectLine : MonoBehaviour
{
    static public ProjectLine S;

    private LineRenderer line;
    public float minDist = 0.1f;
    private GameObject _poi;
    private List<Vector3> _points;

    private void Awake()
    {
        S = this;

        line = GetComponent<LineRenderer>();

        line.enabled = false;

        _points = new List<Vector3>();
    }

    public GameObject poi { get { return _poi; } set { _poi = value;
            if (_poi != null) {
                line.enabled = false;
                _points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        _points = new List<Vector3>();
    }

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;
        if (_points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return;
        }

        if (_points.Count == 0)
        {
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;

            _points.Add(pt + launchPosDiff);
            _points.Add(pt);
            line.positionCount = 2;

            line.SetPosition(0, _points[0]);
            line.SetPosition(1, _points[1]);

            line.enabled = true;
        }
        else
        {
            _points.Add(pt);
            line.positionCount = _points.Count;
            line.SetPosition(_points.Count - 1, lastPoint);
            line.enabled = true;
        }
    }

    public Vector3 lastPoint
    {
        get
        {
            if (_points == null)
            {
                return Vector3.zero;
            }
            return (_points[_points.Count - 1]);
        }
    }

    private void FixedUpdate()
    {
        if (poi == null)
        {
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        AddPoint();
        if (FollowCam.POI == null)
        {
            poi = null;
        }
    }
}
