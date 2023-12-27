using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Core
{
    public class SerialHelper
    {
        private SerialPort _serialPort;
        private SerialParam _serialParam;

        public SerialHelper(SerialParam param)
        {
            _serialParam = param;
            Open();
        }

        private void Open()
        {
            _serialPort = new SerialPort(_serialParam.PortName, _serialParam.BaudRate, _serialParam.PortParity, _serialParam.DataBits);
            _serialPort.Open();
        }

        public bool GetSerialPortState()
        {
            return _serialPort.IsOpen;
        }

        public void Close()
        {
            if (_serialPort == null) return;
            _serialPort.Close();
            _serialPort.Dispose();
            _serialPort = null;
        }

        /// <summary>
        /// 获取本机可用串口
        /// </summary>
        /// <returns></returns>
        public static string[] GetLocalSerialPortNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="msg">数据</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="count">串口回复字节数</param>
        /// <returns></returns>
        public byte[] SendMessage(byte[] msg, TimeSpan timeout, int count)
        {
            var stopwatch = Stopwatch.StartNew();
            var originalWriteTimeout = _serialPort.WriteTimeout;
            var originalReadTimeout = _serialPort.ReadTimeout;
            try
            {

                _serialPort.WriteTimeout = (int)Math.Max((timeout - stopwatch.Elapsed).TotalMilliseconds, 0);
                _serialPort.Write(msg, 0, msg.Length);

                var tmpCount = count;
                byte[] buffer = new byte[tmpCount];
                int offset = 0;
                while (tmpCount > 0)
                {
                    _serialPort.ReadTimeout = (int)Math.Max((timeout - stopwatch.Elapsed).TotalMilliseconds, 0);
                    var readCount = _serialPort.Read(buffer, offset, tmpCount);
                    offset += readCount;
                    tmpCount -= readCount;
                }
                return buffer;
            }
            finally
            {
                _serialPort.ReadTimeout = originalReadTimeout;
                _serialPort.WriteTimeout = originalWriteTimeout;
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="msg">数据</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="count">串口回复字节数</param>
        /// <returns></returns>
        public async Task<byte[]> SendMessageAsync(byte[] msg, TimeSpan timeout, int count)
        {
            var sendTask = Task.Run(() => SendMessage(msg, timeout, count));
            try
            {
                await Task.WhenAny(sendTask, Task.Delay(timeout));
            }
            catch (TaskCanceledException)
            {
                throw new TimeoutException();
            }
            return await sendTask;
        }
    }

    public class SerialParam
    {
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public Parity PortParity { get; set; } = Parity.Even;
        public StopBits PortStopBits { get; set; } = StopBits.One;
    }
}
