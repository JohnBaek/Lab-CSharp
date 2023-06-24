namespace ThreadsJoin;

public class Thread05
{
    /// <summary>
    /// 실행한다.
    /// </summary>
    public void run()
    {
        Console.WriteLine("입력한 숫자까지의 소수 개수 출력 (종료: 'x' + Enter)");
        
        // 메인스레드를 살려두기 위해 
        while (true)
        {
            Console.WriteLine("숫자를 입력하세요.");
            
            // 사용자가 입력한 숫자를 받아온다.
            string userNumber = Console.ReadLine() ?? "";
            
            // "x" 를 입력받았을경우 
            if (userNumber.Equals("x", StringComparison.Ordinal))
            {
                Console.WriteLine("프로그램 종료합니다.");
                Thread.Sleep(1 * 1000);
                break;
            }

            // 쓰레드로 변경
            Thread thread = new Thread(CountPrimeNumbers);
            thread.IsBackground = true;
            thread.Start(userNumber);
        }
    }

    /// <summary>
    /// 입력받은 숫자 캐릭터로 부터 소수의 갯수를 출력한다.
    /// </summary>
    /// <param name="userNumber">검사할 숫자 값</param>
    private void CountPrimeNumbers(object? userNumber)
    {
        // 입력받은 값을 string 으로 캐스팅한다.
        string value = (string) userNumber;

        // 파싱에 성공하지못한경우 
        if (!int.TryParse(value, out int primeCandidate))
        {
            throw new Exception("올바르지 않은 값입니다.");
        }

        // 전체 소수 갯수 
        int totalPrime = 0;

        // 사용자의 요청만큼 처리한다.
        for (int i = 2; i <= primeCandidate; i++)
        {
            // 소수 일경우 
            if (IsPrime(i))
                totalPrime++;
        }

        Console.WriteLine("숫자 {0} 까지의 소수 개수? {1}", value, totalPrime);
    }

    /// <summary>
    /// 소수 여부를 판단한다.
    /// </summary>
    /// <param name="candidate">판별 시도하고자하는 값</param>
    /// <returns>true : 소수 , false : 소수아님</returns>
    private bool IsPrime(int candidate)
    {
        // 1 로 나눈 나머지가 0 인경우 
        if ((candidate & 1) == 0)
            // 2 인경우 소수 
            return candidate == 2;

        // 요청받은 모든 갯수에 대해 처리한다.
        for (int i = 3; (i * i) <= candidate; i += 2)
        {
            // 나눈 나머지가 0 인경우 
            if ((candidate % i) == 0)
                return false;
        }

        // 1 과 같지 않은경우
        return candidate != 1;
    }
}