namespace ThreadsJoin;

public class Thread02
{
    /// <summary>
    /// 실행한다.
    /// </summary>
    public void run()
    {
        Thread thread = new Thread(threadFunc);

        // 백그라운드 스레드여부 
        // 적용시 - 프로그램 종료 여부에 영향을 주지않는다.
        thread.IsBackground = true;
        thread.Start();
        
        // thread 인스턴스의 스레드가 종료할때까지 전경 스레드 무한 대기
        thread.Join();
        Console.WriteLine("주스레드 종료");
    }
    
    static void threadFunc()
    {
        Console.WriteLine("60 초 후 프로그램 종료");
        Thread.Sleep(1000 * 60);
        Console.WriteLine("프로그램 종료");
    }
}