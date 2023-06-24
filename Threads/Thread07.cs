namespace ThreadsJoin;

public class Thread07
{
    /// <summary>
    /// 실행한다.
    /// </summary>
    public void run()
    {
        // 컨테이너를 하나 생성한다.
        Container container = new Container();
        
        // 스레드 2개를 생성한다.
        Thread thread1 = new Thread(ThreadFunc);
        Thread thread2 = new Thread(ThreadFunc);
        
        // 2개의스레드를 실행한다.
        thread1.Start(container);
        thread2.Start(container);
        
        // 2개의 스레드 실행이 끝날때까지 대기한다.
        thread1.Join();
        thread2.Join();

        // 결과를 출력한다.
        Console.WriteLine();
        Console.WriteLine(container.Number);
    }

    /// <summary>
    /// 스레드 내부에서 사용할 메서드 
    /// </summary>
    /// <param name="obj">오브젝트 객체</param>
    private void ThreadFunc(object? obj)
    {
        // 유효성을 검사한다.
        if (obj is not Container)
            return;

        // 형을 변환한다.
        Container container = obj as Container ?? new Container();
        
        // 값을 증가 시킨다.
        // loop 의 값이 증가할수록 공유자원 이슈로 값은 튀어나간다.
        // 10.. 100.. 1000..
        for (int i = 0; i < 100000; i++)
        {
            // 변수에 대한 잠금을 시도한다.
            // Monitor 코드와 동일
            lock (container)
            {
                container.Number = container.Number + 1;
            }
        }
    }
}
