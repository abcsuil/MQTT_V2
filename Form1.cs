using HslCommunication;
using HslCommunication.MQTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTT_0623_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 实例化
            mqttClient = new MqttClient(new MqttConnectionOptions()
            {
                ClientId = "ABC",
                IpAddress = "127.0.0.1"
            });
        }
        

        
        private MqttClient mqttClient = null;
        private void button1_Click(object sender, EventArgs e)
        {
            // 连接
            OperateResult connect = mqttClient.ConnectServer();
            if (connect.IsSuccess)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 测试发布
            mqttClient.PublishMessage(new MqttApplicationMessage()
            {
                Topic = "A",                                                      // 主题
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,     // 消息等级
                Payload = Encoding.UTF8.GetBytes("This is test message!"),        // 数据
                Retain = false,                                                   // 是否保留
            });
        }
    }
}
