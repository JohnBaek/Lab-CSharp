namespace ThreadsJoin;

public class Thread03
{
    /// <summary>
    /// 실행한다.
    /// </summary>
    public void run()
    {
        // 인자가 있는 메서드의 경우 Thread 생성자는
        // ParameterizedThreadStart 델리게이트 타입을 허용한다.
        // 따라서 C# 컴파일러는 위의 코드를 다음과 같이 번역해 컴파일 한다.
        // new Thread(new ParameterizedThreadStart(threadFunc));
        Thread thread = new Thread(threadFunc);
        thread.Start(10);

        Thread thread2 = new Thread(new ParameterizedThreadStart(threadFunc));
        thread2.Start(2);
    }
    
    /// <summary>
    /// 파라미터가 존재하는 쓰레드 테스트용 함수 
    /// </summary>
    /// <param name="initialValue">초기값</param>
    static void threadFunc(object initialValue)
    {
        int intValue = (int) initialValue;
        Console.WriteLine(@$"initialValue: { initialValue }");
    }
}