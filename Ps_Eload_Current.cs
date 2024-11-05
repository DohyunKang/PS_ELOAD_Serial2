﻿using System;
using System.Windows.Forms;
using NationalInstruments.DAQmx;  // DAQmx API 사용을 위한 참조
using NationalInstruments.UI;    // 그래프 컨트롤을 사용하기 위한 참조
using System.Diagnostics;
using System.Linq;

namespace PS_ELOAD_Serial
{
    public partial class Ps_Eload_Current : Form
    {
        private NationalInstruments.DAQmx.Task voltageTask;  // DAQmx Task 객체
        private AnalogSingleChannelReader reader;  // DAQ에서 데이터를 읽어오기 위한 Single Channel Reader 객체
        private Timer updateTimer;  // 데이터를 읽어오는 타이머
        private double elapsedTime = 0;  // X축 시간값을 저장할 변수
        private const double supplyVoltage = 5.0; // 공급 전압 (U_c)
        private const double offsetVoltage = 2.5; // 오프셋 전압 (V_0) - 센서의 기본값
        private const double sensitivity = 0.0267; // DHAB S/113 채널 1의 감도 (26.7 mV/A = 0.0267 V/A)

        //public event Action<double> CurrentAverageUpdated; // currentAvg 업데이트 이벤트

        public double CurrentAverage { get; private set; }  // currentAvg 값 접근용 프로퍼티

        public Ps_Eload_Current()
        {
            InitializeComponent();

            // DAQ로부터 전압을 읽는 Task 설정
            InitializeDAQ();

            // 타이머 초기화
            updateTimer = new Timer();
            updateTimer.Interval = 100; // 0.1초마다 데이터 업데이트
            updateTimer.Tick += (s, ev) => UpdateDAQData();

            // 버튼 클릭 이벤트 핸들러 연결
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);

            // 그래프 초기화 (축 설정)
            InitializeGraph();
        }

        private void InitializeDAQ()
        {
            try
            {
                // DAQ Task 생성 (ai0 포트에서 전압을 측정)
                voltageTask = new NationalInstruments.DAQmx.Task();
                voltageTask.AIChannels.CreateVoltageChannel("Dev2/ai0", "VoltageChannel", AITerminalConfiguration.Rse, 0.0, 10.0, AIVoltageUnits.Volts);

                // 데이터를 읽기 위한 AnalogSingleChannelReader 초기화
                reader = new AnalogSingleChannelReader(voltageTask.Stream);

                // 멀티샘플을 위해 샘플 클럭 설정 (예: 1000Hz로 샘플링, 샘플 수 10)
                voltageTask.Timing.ConfigureSampleClock("", 1000, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, 10);
            }
            catch (DaqException ex)
            {
                MessageBox.Show("DAQ 초기화 중 오류 발생: " + ex.Message);
            }
        }
        Stopwatch sw = new Stopwatch();

        private void UpdateDAQData()
        {
            sw.Restart();
            Debug.WriteLine(string.Format("시작 {0}", sw.ElapsedMilliseconds));
            try
            {
                // SingleSample을 사용해 단일 샘플 읽어오기 (waveformGraph2에 사용할 값)
                double singleSampleVoltage = reader.ReadSingleSample();

                // 멀티 샘플 읽어오기
                double[] outputVoltages = reader.ReadMultiSample(10);

                // 전압값 계산
                double voltageMax = outputVoltages.Max();
                double voltageMin = outputVoltages.Min();
                double voltageAvg = outputVoltages.Average();

                // 전류값 계산
                double currentMax = ((5 / supplyVoltage) * voltageMin - offsetVoltage) * (-1 / sensitivity);
                double currentMin = ((5 / supplyVoltage) * voltageMax - offsetVoltage) * (-1 / sensitivity);
                double currentAvg = ((5 / supplyVoltage) * voltageAvg - offsetVoltage) * (-1 / sensitivity);

                // singleSampleVoltage로 단일 샘플 전류 계산
                double singleSampleCurrent = ((5 / supplyVoltage) * singleSampleVoltage - offsetVoltage) * (-1 / sensitivity);

                CurrentAverage = ((5 / supplyVoltage) * voltageAvg - offsetVoltage) * (-1 / sensitivity);

                // UI에 전압 및 전류값 표시
                lblVoltage_DAQ.Text = voltageAvg.ToString("F2") + " V";
                lblCurrent_DAQ.Text = currentAvg.ToString("F2") + " A";

                lblVoltage_Max.Text = voltageMax.ToString("F2") + " V";
                lblVoltage_Avg.Text = voltageAvg.ToString("F2") + " V";
                lblVoltage_Min.Text = voltageMin.ToString("F2") + " V";

                lblCurrent_Max.Text = currentMax.ToString("F2") + " A";
                lblCurrent_Avg.Text = currentAvg.ToString("F2") + " A";
                lblCurrent_Min.Text = currentMin.ToString("F2") + " A";

                // 실시간으로 그래프에 데이터 추가 (singleSampleCurrent 값을 waveformGraph2에 표시)
                PlotGraph(elapsedTime, singleSampleCurrent, currentMax, currentMin, currentAvg);

                // 시간 경과값 증가 (0.1초마다 타이머 동작)
                elapsedTime += updateTimer.Interval / 1000.0;
            }
            catch (DaqException ex)
            {
                MessageBox.Show("DAQ 데이터 업데이트 중 오류 발생: " + ex.Message);
            }
            Debug.WriteLine(string.Format("끝 {0}", sw.ElapsedMilliseconds));
        }

        // 그래프 초기화 메서드
        private void InitializeGraph()
        {
            // Y축은 전류 (A), X축은 시간 (초)
            waveformGraph1.YAxes[0].Caption = "Current (A)";
            waveformGraph1.XAxes[0].Caption = "Time (0.1s)";
        }

        // 그래프에 실시간 데이터 추가 메서드
        private void PlotGraph(double time, double current, double currentMax, double currentMin, double currentAvg)
        {
            // X축(시간)과 Y축(전류)을 전달하여 그래프에 점을 추가
            waveformGraph1.PlotYAppend(current);
            // 각 그래프에 Max, Min, Avg 전류 값을 추가
            waveformPlot_Max.PlotYAppend(currentMax);
            waveformPlot_Min.PlotYAppend(currentMin);
            waveformPlot_Avg.PlotYAppend(currentAvg);
        }

        // ReadButton 클릭 시 타이머 시작
        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (!updateTimer.Enabled)  // 타이머가 이미 동작 중인지 확인
            {
                elapsedTime = 0;  // 시간 초기화
                waveformGraph1.ClearData();  // 이전 그래프 데이터 초기화
                updateTimer.Start();
                MessageBox.Show("데이터 수집 시작");
            }
            else
            {
                MessageBox.Show("이미 데이터 수집이 진행 중입니다.");
            }
        }

        // StopButton 클릭 시 타이머 중지
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (updateTimer.Enabled)  // 타이머가 동작 중인지 확인
            {
                updateTimer.Stop();
                MessageBox.Show("데이터 수집 중지");
            }
            else
            {
                MessageBox.Show("현재 데이터 수집이 중지된 상태입니다.");
            }
        }
    }
}