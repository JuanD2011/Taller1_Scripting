using System.Collections;
using System.Collections.Generic;

public class GameController{

    public Shop mShop;
    static GameController gameController;
    public static GameController _GameController
    {
        get
        {
            if (gameController == null) {
                gameController = new GameController();
            }
            return gameController;
        }

    }

    public GameController() {
        mShop = new Shop();
    }
}
