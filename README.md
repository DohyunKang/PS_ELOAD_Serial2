# ELoad 시퀀스 모드 제어 프로그램  
**SCPI 명령어를 사용한 Windows Form Application (C#)**  

## **개요**  
이 프로젝트는 **KIKUSUI PLZ-5W 시리즈 ELoad** 장비를 SCPI 명령어로 제어하는 **Windows Form Application**입니다.  
`VOLT`와 `CURR` 명령어만을 사용하여 단계별 시퀀스를 소프트웨어적으로 실행하고 제어하는 기능을 제공합니다.

---

## **주요 기능**  

1. **초기 설정**  
   - 사용자가 입력한 초기 전압과 전류 값을 설정합니다.  

2. **단계별 시퀀스 실행**  
   - 사용자 입력에 따라 여러 단계의 전압, 전류 및 유지 시간을 설정하고 순차적으로 실행합니다.  

3. **시퀀스 상태 모니터링**  
   - 현재 실행 중인 시퀀스 단계와 상태를 실시간으로 표시합니다.  

4. **시퀀스 종료**  
   - 시퀀스 종료 시 전압 및 전류를 초기화하거나 출력 종료 명령(`OUTP OFF`)을 실행합니다.  

---

## **환경 설정**  

1. **개발 언어**: C#  
2. **개발 환경**: Visual Studio 2012 이상  
3. **통신 방식**:  
   - RS232C 또는 USB를 통한 ELoad와 PC 간 통신  
   - SCPI 명령어 전송을 위해 **SerialPort 클래스** 사용  

4. **필요 라이브러리**:  
   - `System.IO.Ports` (Serial 통신 지원)  

---

## **설치 및 실행 방법**  

1. **프로젝트 빌드**  
   - Visual Studio에서 `ELoadSequenceControl.sln` 프로젝트 파일을 열고 빌드합니다.  

2. **장비 연결**  
   - ELoad 장비를 RS232C 또는 USB 포트로 PC에 연결합니다.  
   - 장치 관리자에서 포트 번호(COM)를 확인합니다.  

3. **시퀀스 설정**  
   - 프로그램 실행 후 UI에서 전압, 전류 및 유지 시간을 단계별로 입력합니다.  
   - '시퀀스 시작' 버튼을 눌러 시퀀스를 실행합니다.  

---

## **UI 구성**  

1. **전압 및 전류 입력 필드**  
   - 초기 전압 및 전류를 설정할 수 있습니다.  

2. **시퀀스 테이블**  
   - 단계별로 전압, 전류, 유지 시간을 입력하는 그리드 형식입니다.  

3. **시퀀스 제어 버튼**  
   - **Start**: 시퀀스 시작  
   - **Pause**: 일시정지  
   - **Stop**: 시퀀스 정지 및 초기화  

4. **실시간 상태창**  
   - 현재 실행 중인 단계와 SCPI 명령어 송신 상태를 표시합니다.  

---

## **코드 예시**  

### **SCPI 명령어 전송 함수**  
```csharp
private void SendCommand(string command)
{
    if (serialPort1.IsOpen)
    {
        serialPort1.WriteLine(command);
        Console.WriteLine($"Sent: {command}");
    }
    else
    {
        MessageBox.Show("Serial Port가 열려있지 않습니다.");
    }
}
```

### **시퀀스 실행 함수**  
```csharp
private async Task RunSequenceAsync(List<SequenceStep> steps)
{
    foreach (var step in steps)
    {
        SendCommand($"VOLT {step.Voltage}");
        SendCommand($"CURR {step.Current}");
        await Task.Delay(step.Duration * 1000); // 유지 시간 (초 단위)
    }
    SendCommand("VOLT 0");
    SendCommand("CURR 0");
    MessageBox.Show("시퀀스 실행이 완료되었습니다.");
}
```

---

## **기록 및 로그 관리**  
- 명령어 전송 및 응답 상태를 로그 파일로 저장합니다.  
- 실시간으로 로그를 UI 창에 표시합니다.  
