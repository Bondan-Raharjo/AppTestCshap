using System.Collections;
using System.Threading;
using Ixxat.Vci4;
using Ixxat.Vci4.Bal;
using Ixxat.Vci4.Bal.Can;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppTestCshap
{
    public partial class Form1 : Form
    {
        #region Member variables
        static IVciDevice mDevice;
        static ICanControl2 mCanCtl;
        static ICanChannel2 mCanChn;
        static ICanScheduler2 mCanSched;
        static ICanMessageWriter mWriter;
        static ICanMessageReader mReader;
        static Thread rxThread;
        static long mMustQuit = 0;
        static AutoResetEvent mRxEvent;
        static Form1 _instance;
        #endregion
        #region Responsife GUI

        #endregion
        public Form1()
        {
            _instance = this;
            InitializeComponent();
            btn_conn.Enabled = false;
            btn_reci.Enabled = false;
            btn_Send.Enabled = false;
              
        }



        #region Connection 
        static void SelectDevice()
        {
            IVciDeviceManager deviceManager = null;
            IVciDeviceList deviceList = null;
            IEnumerator deviceEnum = null;

            try
            {
                deviceManager = VciServer.Instance().DeviceManager;
                deviceList = deviceManager.GetDeviceList();
                deviceEnum = deviceList.GetEnumerator();
                deviceEnum.MoveNext();

                mDevice = deviceEnum.Current as IVciDevice;
                IVciCtrlInfo info = mDevice.Equipment[0];

                _instance.list_dev.Text += (" BusType    : {0}\n", info.BusType);
                _instance.list_dev.Text += (" CtrlType   : {0}\n", info.ControllerType);

                object serialNumberGuid = mDevice.UniqueHardwareId;
                string serialNumberText = GetSerialNumberText(ref serialNumberGuid);
                _instance.list_dev.Text += (" Interface    : " + mDevice.Description + "\n");
                _instance.list_dev.Text += (" Serial number: " + serialNumberText + "\n");
                _instance.btn_conn.Enabled = true;
                _instance.btn_reci.Enabled = true;
                _instance.btn_Send.Enabled = true;
            }
            catch (Exception exc)
            {
                _instance.msg_List.Text += ("Error: " + exc.Message);
            }
            finally
            {
                DisposeVciObject(deviceManager);
                DisposeVciObject(deviceList);
                DisposeVciObject(deviceEnum);
            }
        }
        static bool InitSocket(Byte canNo)
        {
            IBalObject bal = null;
            bool succeeded = false;

            try
            {
                bal = mDevice.OpenBusAccessLayer();
                mCanChn = bal.OpenSocket(canNo, typeof(ICanChannel2)) as ICanChannel2;
                mCanSched = bal.OpenSocket(canNo, typeof(ICanScheduler2)) as ICanScheduler2;

                // Initialize the message channel
                mCanChn.Initialize(1024, 128, 100, CanFilterModes.Pass, false);
                mReader = mCanChn.GetMessageReader();
                mReader.Threshold = 1;
                mRxEvent = new AutoResetEvent(false);
                mReader.AssignEvent(mRxEvent);
                mWriter = mCanChn.GetMessageWriter();
                mWriter.Threshold = 1;
                mCanChn.Activate();


                //
                // Open the CAN controller
                //
                mCanCtl = bal.OpenSocket(canNo, typeof(ICanControl2)) as ICanControl2;

                // Initialize the CAN controller
                // set the arbitration bitrate to 500kBit/s
                //  (NonRaw) bitrate  500000, TSeg1: 6400, TSeg2: 1600, SJW:  1600, SSPoffset/TDO  not used
                // set the fast bitrate to 2000kBit/s
                //  (NonRaw) bitrate 2000000, TSeg1: 6400, TSeg2:  400, SJW:   400, SSPoffset/TDO  1600 ( == 80% )
                mCanCtl.InitLine(CanOperatingModes.Standard |
                  CanOperatingModes.Extended |
                  CanOperatingModes.ErrFrame,
                  CanExtendedOperatingModes.ExtendedDataLength |
                  CanExtendedOperatingModes.FastDataRate,
                  CanFilterModes.Pass,
                  2048,
                  CanFilterModes.Pass,
                  2048,
                  CanBitrate2.CANFD500KBit,
                  CanBitrate2.CANFD2000KBit);

                Console.WriteLine(" LineStatus: {0}", mCanCtl.LineStatus);
                mCanCtl.StartLine();

                succeeded = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error: Initializing socket failed : " + exc.Message);
                succeeded = false;
            }
            finally
            {
                //
                // Dispose bus access layer
                //
                DisposeVciObject(bal);
            }

            return succeeded;
        }
        static void ReceiveThreadFunc()
        {
            if (_instance.multi_Read.Checked == false) 
                { ReadMsgsViaReadMessage(); }
                else
                ReadMultipleMsgsViaReadMessages();
          
        }
        static void ReadMsgsViaReadMessage()
        {
            ICanMessage2 canMessage;

            do
            {
                // Wait 100 msec for a message reception
                if (mRxEvent.WaitOne(100, false))
                {
                    // read a CAN message from the receive FIFO
                    while (mReader.ReadMessage(out canMessage))
                    {
                        PrintMessage(canMessage);
                    }
                }
            } while (0 == mMustQuit);
        }
        static void ReadMultipleMsgsViaReadMessages()
        {
            ICanMessage2[] msgArray;

            do
            {
                // Wait 100 msec for a message reception
                if (mRxEvent.WaitOne(100, false))
                {
                    if (mReader.ReadMessages(out msgArray) > 0)
                    {
                        foreach (ICanMessage2 entry in msgArray)
                        {
                            PrintMessage(entry);
                        }
                    }
                }
            } while (0 == mMustQuit);
        }
        static void PrintMessage(ICanMessage2 canMessage)
        {
            switch (canMessage.FrameType)
            {
                case CanMsgFrameType.Data:
                    {
                        if (!canMessage.RemoteTransmissionRequest)
                        {
                            _instance.msg_List.Text +=("\nTime: {0,10}  ID: {1,3:X}  DLC: {2,1}  Data:",
                                          canMessage.TimeStamp,
                                          canMessage.Identifier,
                                          canMessage.DataLength);

                            for (int index = 0; index < canMessage.DataLength; index++)
                            {
                                _instance.msg_List.Text +=(" {0,2:X}", canMessage[index]);
                            }
                        }
                        else
                        {
                            _instance.msg_List.Text += ("\nTime: {0,10}  ID: {1,3:X}  DLC: {2,1}  Remote Frame",
                                          canMessage.TimeStamp,
                                          canMessage.Identifier,
                                          canMessage.DataLength);
                        }
                        break;
                    }

                //
                // show informational frames
                //
                case CanMsgFrameType.Info:
                    {
                        switch ((CanMsgInfoValue)canMessage[0])
                        {
                            case CanMsgInfoValue.Start:
                                _instance.msg_List.Text += ("\nCAN started...");
                                break;
                            case CanMsgInfoValue.Stop:
                                _instance.msg_List.Text += ("\nCAN stopped...");
                                break;
                            case CanMsgInfoValue.Reset:
                                _instance.msg_List.Text += ("\nCAN reseted...");
                                break;
                        }
                        break;
                    }

                //
                // show error frames
                //
                case CanMsgFrameType.Error:
                    {
                        switch ((CanMsgError)canMessage[0])
                        {
                            case CanMsgError.Stuff:
                                _instance.msg_List.Text += ("\nstuff error...");
                                break;
                            case CanMsgError.Form:
                                _instance.msg_List.Text += ("\nform error...");
                                break;
                            case CanMsgError.Acknowledge:
                                _instance.msg_List.Text += ("\nacknowledgment error...");
                                break;
                            case CanMsgError.Bit:
                                _instance.msg_List.Text += ("\nbit error...");
                                break;
                            case CanMsgError.Fdb:
                                _instance.msg_List.Text += ("\nfast data bit error...");
                                break;
                            case CanMsgError.Crc:
                                _instance.msg_List.Text += ("\nCRC error...");
                                break;
                            case CanMsgError.Dlc:
                                _instance.msg_List.Text += ("\nData length error...");
                                break;
                            case CanMsgError.Other:
                                _instance.msg_List.Text += ("\nother error...");
                                break;
                        }
                        break;
                    }
            }
        }
        static void TransmitData()
        {
            IMessageFactory factory = VciServer.Instance().MsgFactory;
            ICanMessage2 canMsg = (ICanMessage2)factory.CreateMsg(typeof(ICanMessage2));

            canMsg.TimeStamp = 0;
            canMsg.Identifier = uint.Parse(_instance.In_ID.Text); ;
            canMsg.FrameType = CanMsgFrameType.Data;
            canMsg.DataLength = byte.Parse(_instance.In_length.Text);
            canMsg.SelfReceptionRequest = true;  
            canMsg.FastDataRate = true;
            canMsg.ExtendedDataLength = true;

            for (Byte i = 0; i < canMsg.DataLength; i++)
            {
                canMsg[i] = i;
            }

            mWriter.SendMessage(canMsg);
        }

        #endregion

        #region Utility
        static void DisposeVciObject(object obj)
        {
            if (null != obj)
            {
                IDisposable dispose = obj as IDisposable;
                if (null != dispose)
                {
                    dispose.Dispose();
                    obj = null;
                }
            }
        }
        static string GetSerialNumberText(ref object serialNumberGuid)
        {
            string resultText;

            // check if the object is really a GUID type
            if (serialNumberGuid.GetType() == typeof(System.Guid))
            {
                // convert the object type to a GUID
                System.Guid tempGuid = (System.Guid)serialNumberGuid;

                // copy the data into a byte array
                byte[] byteArray = tempGuid.ToByteArray();

                // serial numbers starts always with "HW"
                if (((char)byteArray[0] == 'H') && ((char)byteArray[1] == 'W'))
                {
                    // run a loop and add the byte data as char to the result string
                    resultText = "";
                    int i = 0;
                    while (true)
                    {
                        // the string stops with a zero
                        if (byteArray[i] != 0)
                            resultText += (char)byteArray[i];
                        else
                            break;
                        i++;

                        // stop also when all bytes are converted to the string
                        // but this should never happen
                        if (i == byteArray.Length)
                            break;
                    }
                }
                else
                {
                    // if the data did not start with "HW" convert only the GUID to a string
                    resultText = serialNumberGuid.ToString();
                }
            }
            else
            {
                // if the data is not a GUID convert it to a string
                string tempString = (string)(string)serialNumberGuid;
                resultText = "";
                for (int i = 0; i < tempString.Length; i++)
                {
                    if (tempString[i] != 0)
                        resultText += tempString[i];
                    else
                        break;
                }
            }

            return resultText;
        }
        static void FinalizeApp()
        {

            DisposeVciObject(mReader);
            DisposeVciObject(mWriter);
            DisposeVciObject(mCanChn);
            DisposeVciObject(mCanCtl);
            DisposeVciObject(mDevice);
        }

        #endregion

        #region Button 
        private void btn_conn_Click(object sender, EventArgs e)
        {

            if (!InitSocket(0))
            {
                _instance.msg_List.Text += (" Initialize CAN FD............ FAILED !\n");
            }
            else
            {
                _instance.msg_List.Text += (" Initialize CAN FD............ OK !\n");
                rxThread = new Thread(new ThreadStart(ReceiveThreadFunc));
                rxThread.Start();
                ICanCyclicTXMsg2 cyclicMsg = mCanSched.AddMessage();

                cyclicMsg.Identifier = 200;
                cyclicMsg.CycleTicks = 100;
                cyclicMsg.DataLength = 32;
                cyclicMsg.SelfReceptionRequest = true;
                cyclicMsg.ExtendedDataLength = true;
                cyclicMsg.FastDataRate = true;

                for (Byte i = 0; i < cyclicMsg.DataLength; i++)
                {
                    cyclicMsg[i] = i;
                }
            }

        }
        private void btn_Scan_Click(object sender, EventArgs e)
        {
            msg_List.Clear();
            SelectDevice();

        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            TransmitData();
        }
        private void btn_reci_Click(object sender, EventArgs e)
        {
            ICanCyclicTXMsg2 cyclicMsg = mCanSched.AddMessage();

            cyclicMsg.Identifier = 200;
            cyclicMsg.CycleTicks = 100;
            cyclicMsg.DataLength = 32;
            cyclicMsg.SelfReceptionRequest = true;
            cyclicMsg.ExtendedDataLength = true;
            cyclicMsg.FastDataRate = true;

            for (Byte i = 0; i < cyclicMsg.DataLength; i++)
            {
                cyclicMsg[i] = i;
            }
            if (cyclicMsg.Status != CanCyclicTXStatus.Busy)
            {
                cyclicMsg.Start(0);
            }
            else
            {
                cyclicMsg.Stop();
            }
        }

        #endregion
    }
}