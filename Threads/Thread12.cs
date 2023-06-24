using System.Collections;

namespace ThreadsJoin;

public class Thread12
{
    /// <summary>
    /// 실행한다.
    /// </summary>
    public void run()
    {
        // 컨테이너를 생성한다.
        Thread12Container container = new Thread12Container();

        // 해시 테이블에 데이터를 담는다.
        Hashtable hashTable1 = new Hashtable();
        hashTable1["data"] = container;
        hashTable1["event"] = new EventWaitHandle(false, EventResetMode.ManualReset);
        
        // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달한다.
        ThreadPool.QueueUserWorkItem(ThreadFunc, hashTable1);
        
        Hashtable hashTable2 = new Hashtable();
        hashTable2["data"] = container;
        hashTable2["event"] = new EventWaitHandle(false, EventResetMode.ManualReset);
        
        // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달한다.
        ThreadPool.QueueUserWorkItem(ThreadFunc, hashTable2);
        
        // 2 개의 이벤트 객체가 Signal 상태로 바뀔 때까지 대기한다.
        (hashTable1["event"] as EventWaitHandle)?.WaitOne();
        (hashTable2["event"] as EventWaitHandle)?.WaitOne();

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
        if (obj is not Hashtable)
            return;

        // 형을 변환한다.
        Hashtable hashTable = obj as Hashtable ?? new Hashtable();
        
        // 형을 변환한다.
        Thread12Container? container = hashTable["data"] as Thread12Container;
        
        // 값이 없는경우 
        if (container == null)
            return;
        
        // 값을 증가 시킨다.
        // loop 의 값이 증가할수록 공유자원 이슈로 값은 튀어나간다.
        // 10.. 100.. 1000..
        for (int i = 0; i < 1000000; i++)
        {
            // 값을 증가시킨다.
            container.IncrementNumber();
        }
        
        // 주어진 이벤트 객체를 Signal 상태로 전환한다.
        (hashTable["event"] as EventWaitHandle)?.Set();
    }
}

/// <summary>
/// 테스트를 위한 컨테이너 클래스 
/// </summary>
public class Thread12Container
{
    private int _number = 0;
    
    /// <summary>
    /// 테스트할 값
    /// </summary>
    public int Number => _number;

    /// <summary>
    /// 내부 Number 값을 증가 시킨다.
    /// </summary>
    public void IncrementNumber()
    {
        // 일부 가산 감산에대해서는 Thread Safe 하게 동작하도록 하는 기능
        Interlocked.Increment(ref _number);
    }
}
