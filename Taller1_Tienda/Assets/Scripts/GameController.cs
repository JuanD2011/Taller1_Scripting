public class GameController{

    public Shop mShop;
    private static GameController gameController;
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
        CrearShop();
    }

    private void CrearShop() {
        mShop = new Shop();
    }
}
