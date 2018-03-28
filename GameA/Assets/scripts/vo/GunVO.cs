public class GunVO {

    //配置文件
    public GunConfig config;

    //上一次射击时间
    public float lastShootTime = 0;

    //是否正在开火
    public bool fireFlag = false;

    //开火
    public void Fire()
    {
        fireFlag = true;
    }

    //停止开火
    public void StopFire()
    {
        fireFlag = false;
    }
}
