using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IPCulc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик событий, если введен некорректный IP
        private static bool IsValidIpAddress(string ipAddress)
        {
            bool isIPAddres = false;
            Match match = Regex.Match(ipAddress, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            if (match.Success)
            {
                isIPAddres = true;
            }
            return isIPAddres;
        }


        // Обработчик событий, если введен некорректный IP
        //private bool IsValidIpAddress(string ipAddress)
        //{
        //    if (IPAddress.TryParse(ipAddress, out IPAddress address))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // Обработчик собыйти при нажатии на кнопку
        private void CalculateButton_Click(object sender, EventArgs e)
        {

            string ipAddress = IpAddressTextBox.Text;
            int maskAddress;
            int d;
            if (int.TryParse(MaskTextBox.Text, out d))
            {
                maskAddress = int.Parse(MaskTextBox.Text);
            }
            else
            {
                MessageBox.Show("Неверный формат МАСКИ", "Ошибка, неверный МАСКИ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                //int maskAddress = int.Parse(MaskTextBox.Text);

            // Проверка введенного IP-адреса на корректность
            if (!IsValidIpAddress(ipAddress))
            {
                MessageBox.Show("Неверный формат IP-адреса", "Ошибка, неверный IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tuple<string, string> GetWorkAddress(string ip, int mask)
            {
                string[] ipSplit = ip.Split('.');
                int[] ipArray = Array.ConvertAll(ipSplit, int.Parse);
                int[] work = new int[4];
                int[] broadcast = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    int maskOctet = Math.Min(mask, 8);
                    work[i] = (ipArray[i] & (255 << (8 - maskOctet)) & 255);
                    broadcast[i] = (ipArray[i] | (255 >> maskOctet) & 255);
                    mask -= maskOctet;
                }

                return new Tuple<string, string>(
                    string.Join('.', Array.ConvertAll(work, x => x.ToString())),
                    string.Join('.', Array.ConvertAll(broadcast, x => x.ToString()))
                );
            }

            // Считаем количество узлов сети
            int CountNodes(int mask)
            {
                return (int)Math.Pow(2, (32 - mask)) - 2;
            }

            // Определение класса IP
            string GetIpClass(string ip)
            {
                int a = int.Parse(ip.Split('.')[0]);
                if (a >= 1 && a <= 126)
                {
                    return "A";
                }
                else if (a >= 128 && a <= 191)
                {
                    return "B";
                }
                else if (a >= 192 && a <= 223)
                {
                    return "C";
                }
                else if (a >= 224 && a <= 239)
                {
                    return "D";
                }
                else if (a >= 240 && a <= 255)
                {
                    return "E";
                }
                else
                {
                    return "Введен IP Loopback";
                }
            }


            string GetIpType(string ip)
            {
                if (ip.StartsWith("10.") ||
                    ip.StartsWith("192.168.") ||
                   (ip.StartsWith("172.") && ip[4] >= '1'&& ip[4] <= '3' && ip[5] <= '1'))//16 - 31
                {
                    return "Локальный IP"; // IP-адрес является локальным
                }
                else if (ip.StartsWith("127."))
                {
                    return "Обратной петли"; // IP-адрес является обратной петли
                }
                else
                {
                    return "Глобальный IP"; // IP-адрес не является локальным
                }
                
            }

            // Обработчик событий, если введен некорректный IP
            bool IsValidMask(int ipAddress)
            {
                bool isIPAddres = false;
                if ((ipAddress>0) && (ipAddress<=24))
                {
                    isIPAddres = true;
                }
                return isIPAddres;
            }

            // Тут переводим маску в привычный вид
            string MaskToString(int mask)
            {
                string[] maskParts = new string[4];
                for (int i = 0; i < mask / 8; i++)
                {
                    maskParts[i] = "255";
                }

                int remaining = mask % 8;
                if (remaining > 0)
                {
                    maskParts[mask / 8] = $"{256 - (int)Math.Pow(2, (8 - remaining))}";
                }
                
                // Проверка введенного МАСКИ IP на корректность
                if (!IsValidMask(mask))
                {
                    MessageBox.Show("Неверный формат МАСКИ", "Ошибка, неверный МАСКИ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "0";
                }
                
                return string.Join('.', maskParts.Select(x => x ?? "0"));
            }

            // Выводим всю информацию IP адресса
            var addressTuple = GetWorkAddress(ipAddress, maskAddress);
            string workAddress = addressTuple.Item1;
            string broadcastAddress = addressTuple.Item2;
            string ipClass = GetIpClass(ipAddress);
            string ipType = GetIpType(ipAddress);
            int nodesCount = CountNodes(maskAddress);
            string maskString = MaskToString(maskAddress);

            ResultTextBox.Text = $"IP адрес: {ipAddress}\r\n" +
                                 $"Маска сети: {maskString}\r\n" +
                                 $"IP адрес сети: {workAddress}\r\n" +
                                 $"IP адрес широковещания: {broadcastAddress}\r\n" +
                                 $"Количество узлов сети: {nodesCount}\r\n" +
                                 $"Класс IP адреса: {ipClass}\r\n" +
                                 $"Тип IP адреса: {ipType}\r\n";
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
