using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Add : MonoBehaviour
{
    
    //inventory names to use
    //static public int sticksAmt;
    //static public int stonesAmt;
    //static public int flowersAmt;
    //static public int leavesAmt;

    public int changeSticksAmt = 0;
    public int changeStonesAmt = 0;
    public int changeFlowersAmt = 0;
    public int changeLeavesAmt = 0;
    public int changeBredAmt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change amt using 1/2
        sticksChange(changeSticksAmt);
        //change amt using 3/4
        stonesChange(changeStonesAmt);
        //change amt using 5/6
        flowersChange(changeFlowersAmt);
        //change amt using 7/8
        leavesChange(changeLeavesAmt);
        //change amt using 7/8
        bredChange(changeBredAmt);
    }

    //sticks
    int sticksChange(int amt)
    {
        int check = Inventory_System.sticksAmt - amt;
        if (Input.GetKeyDown(KeyCode.Alpha1) && check >= 0)
        {
            Inventory_System.sticksAmt -= amt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory_System.sticksAmt += amt;
        }

        return 0;
    }
    //stones
    int stonesChange(int amt)
    {
        int check = Inventory_System.stonesAmt - amt;
        if (Input.GetKeyDown(KeyCode.Alpha3) && check >= 0)
        {
            Inventory_System.stonesAmt -= amt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Inventory_System.stonesAmt += amt;
        }
        
        return 0;
    }
    //flowers
    int flowersChange(int amt)
    {
        int check = Inventory_System.flowersAmt - amt;
        if (Input.GetKeyDown(KeyCode.Alpha5) && check >= 0)
        {
            Inventory_System.flowersAmt -= amt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Inventory_System.flowersAmt += amt;
        }

        return 0;
    }
    //leaves
    int leavesChange(int amt)
    {
        int check = Inventory_System.leavesAmt - amt;
        if (Input.GetKeyDown(KeyCode.Alpha7) && check >= 0)
        {
            Inventory_System.leavesAmt -= amt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Inventory_System.leavesAmt += amt;
        }

        return 0;
    }
    //bred
    int bredChange(int amt)
    {
        int check = Inventory_System.bredAmt - amt;
        if (Input.GetKeyDown(KeyCode.Alpha9) && check >= 0)
        {
            Inventory_System.bredAmt -= amt;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Inventory_System.bredAmt += amt;
        }

        return 0;
    }
}
