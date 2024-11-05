using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        private List<SequenceStep> sequenceSteps; // 시퀀스 단계 리스트
        private int currentStepIndex;             // 현재 단계 인덱스

        // 시퀀스 시작
        public async Task StartSequenceAsync()
        {
            if (sequenceSteps.Count == 0) return;
            currentStepIndex = 0;
            isSequenceRunning = true;
            //UpdateSequenceStatus(true);

            while (isSequenceRunning && currentStepIndex < sequenceSteps.Count)
            {
                SequenceStep step = sequenceSteps[currentStepIndex];

                // 전압과 전류 설정
                SendCommandToELoad("VOLT " + step.Level);
                SendCommandToELoad("CURR " + step.Level);

                // INP(부하) 설정
                SetLoadState(step.InputOnOff);

                // Transition (Ramp 또는 Immediate)에 따라 전압 변경
                if (step.Transition == "RAMP")
                {
                    await ApplyRampTransition(step.Level, step.Dwell);
                }
                else if (step.Transition == "IMM")
                {
                    await ApplyImmediateTransition(step.Level, step.Dwell);
                }

                // Dwell 시간 동안 대기
                await Task.Delay(step.Dwell * 1000);

                // 다음 단계로 이동
                currentStepIndex++;
            }

            StopSequence(); // 시퀀스 종료 후 상태 초기화
        }

        // 시퀀스 중지
        public void StopSequence()
        {
            isSequenceRunning = false;
            //UpdateSequenceStatus(false);
        }

        // 즉시 전환 모드
        private async Task ApplyImmediateTransition(double level, int dwell)
        {
            // 전압을 ELoad에 설정
            SendCommandToELoad("VOLT " + level.ToString("F2"));

            // Dwell 시간 동안 전압 유지
            await Task.Delay(dwell * 1000);
        }

        // 점진적 증가(Ramp 모드) 구현
        private async Task ApplyRampTransition(double targetLevel, int dwell)
        {
            double initialLevel = GetCurrentVoltage(); // 현재 전압 값을 가져옴
            double stepSize = (targetLevel - initialLevel) / dwell;
            double currentLevel = initialLevel;

            for (int i = 0; i < dwell; i++)
            {
                if (!isSequenceRunning) break; // 시퀀스 중지 시 종료

                currentLevel += stepSize;
                SendCommandToELoad("VOLT " + currentLevel.ToString("F2"));

                await Task.Delay(1000); // 1초 간격으로 ramp 실행
            }
        }

        // 부하 켜짐/꺼짐 설정
        private void SetLoadState(string onOff)
        {
            if (onOff == "ON")
            {
                SendCommandToELoad("INP ON");
            }
            else
            {
                SendCommandToELoad("INP OFF");
            }
        }

        // 현재 전압을 읽어오는 메서드 (실제 ELoad와의 통신으로 구현 필요)
        private double GetCurrentVoltage()
        {
            return 0.0; // 기본값 설정
        }

        // 데이터베이스에서 시퀀스 단계 가져오는 메서드 (추가로 구현 필요)
        private List<SequenceStep> GetSequenceStepsFromDatabase()
        {
            List<SequenceStep> steps = new List<SequenceStep>();
            // 여기에 데이터베이스 접근 코드를 추가하여 sequenceSteps를 채우세요.
            return steps;
        }
    }

    // 시퀀스 단계 정보 클래스
    public class SequenceStep
    {
        public int ProgramID { get; set; }       // Program ID
        public double Level { get; set; }        // 전압 레벨
        public int SR_A_us { get; set; }         // SR_A_us 값
        public int Dwell { get; set; }           // Dwell 시간
        public string Transition { get; set; }   // Load_immediate_ramp 전환 모드
        public string Generate { get; set; }     // Generate 값
        public int StepNum { get; set; }         // 단계 번호
        public string InputOnOff { get; set; }   // 부하 상태
        public string WaitPre { get; set; }      // Wait_pre 값
    }
}
