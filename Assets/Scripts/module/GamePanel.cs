using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GamePanel : BasePanel
{
    private List<GameObject> leftWall = new List<GameObject>();
    private List<GameObject> rightWall = new List<GameObject>();
    
    //初始化
    public override void OnInit()
    {
        skinPath = "GamePanel";
        layer = PanelManager.Layer.Panel;
    }

    //显示
    public override void OnShow(params object[] args)
    {
        float end = 800;
        while (end > -800)
        {
            string path = "";
            float random = Random.Range(0f, 1f);
            if (random < 0.4)
                path = "walls/WallS";
            else if (random < 0.8)
                path = "walls/WallM";
            else
                path = "walls/WallL";
            GameObject wall = Instantiate(Resources.Load<GameObject>(path), GameObject.Find("Root/Canvas/GamePanel(Clone)").transform, true);
            float height = wall.GetComponent<RectTransform>().rect.height;
            wall.transform.localPosition = new Vector3(450, end - height/2, 0);
            end -= height;
            leftWall.Add(wall);
        }
        
        end = 800;
        while (end > -800)
        {
            string path = "";
            float random = Random.Range(0f, 1f);
            if (random < 0.4)
                path = "walls/WallS";
            else if (random < 0.8)
                path = "walls/WallM";
            else
                path = "walls/WallL";
            GameObject wall = Instantiate(Resources.Load<GameObject>(path), GameObject.Find("Root/Canvas/GamePanel(Clone)").transform, true);
            float height = wall.GetComponent<RectTransform>().rect.height;
            wall.transform.localPosition = new Vector3(-450, end - height/2, 0);
            end -= height;
            rightWall.Add(wall);
        }
    }

    private void Update()
    {
        GameObject lastLeft = leftWall.Last();
        if (lastLeft.transform.localPosition.y - lastLeft.GetComponent<RectTransform>().rect.height / 2 >= -805)
        {
            string path = "";
            float random = Random.Range(0f, 1f);
            if (random < 0.4)
                path = "walls/WallS";
            else if (random < 0.8)
                path = "walls/WallM";
            else
                path = "walls/WallL";
            GameObject wall = Instantiate(Resources.Load<GameObject>(path), GameObject.Find("Root/Canvas/GamePanel(Clone)").transform, true);
            float height = wall.GetComponent<RectTransform>().rect.height;
            wall.transform.localPosition = new Vector3(450, -800 - height/2, 0);
            leftWall.Add(wall);
        }
        
        GameObject lastRight = rightWall.Last();
        if (lastRight.transform.localPosition.y - lastRight.GetComponent<RectTransform>().rect.height / 2 >= -805)
        {
            string path = "";
            float random = Random.Range(0f, 1f);
            if (random < 0.4)
                path = "walls/WallS";
            else if (random < 0.8)
                path = "walls/WallM";
            else
                path = "walls/WallL";
            GameObject wall = Instantiate(Resources.Load<GameObject>(path), GameObject.Find("Root/Canvas/GamePanel(Clone)").transform, true);
            float height = wall.GetComponent<RectTransform>().rect.height;
            wall.transform.localPosition = new Vector3(-450, -800 - height/2, 0);
            rightWall.Add(wall);
        }
        
        GameObject firstLeft = leftWall.First();
        if (firstLeft.transform.localPosition.y - firstLeft.GetComponent<RectTransform>().rect.height / 2 >= 805)
        {
            leftWall.Remove(firstLeft);
            Destroy(firstLeft);
        }
        
        GameObject firstRight = rightWall.First();
        if (firstRight.transform.localPosition.y - firstRight.GetComponent<RectTransform>().rect.height / 2 >= 805)
        {
            rightWall.Remove(firstRight);
            Destroy(firstRight);
        }
    }

    //关闭
    public override void OnClose()
    {
		
    }
}