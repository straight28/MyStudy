using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestClicker
{
    public class CXMLControl
    {
        /// <summary>
        /// dictionary 및 xml의 항목을 정의 ( static (정적)변수로 사용 : 프로그램 실행시 메모리에 바로 할당
        /// </summary>
        public static string _TICK = "TICK";
        public static string _TOTAL = "TOTAL";
        public static string _LEVEL_1 = "LEVEL_1";
        public static string _LEVEL_3 = "LEVEL_3";
        public static string _LEVEL_50 = "LEVEL_50";

        /// <summary>
        /// XML을 저장하기 위해 사용
        /// </summary>
        /// <param name="strXMLPath">저장할 XML의 경로 및 파일명</param>
        /// <param name="DXMLConfig">XML로 저장할 항목</param>
        public void fXML_Writer(string strXMLPath, Dictionary<string, string> DXMLConfig)
        {
            StringBuilder sb = new StringBuilder();

            // using을 사용하여 using을 벗어날 경우 자동으로 dispose하여 메모리 관리
            //using (XmlWriter wr = XmlWriter.Create(strXMLPath))
            using (XmlWriter wr = XmlWriter.Create(sb))
            {
                wr.WriteStartDocument();

                wr.WriteStartElement("SETTING");
                wr.WriteAttributeString("ID", "0001");

                wr.WriteElementString(_TICK, DXMLConfig[_TICK]);
                wr.WriteElementString(_TOTAL, DXMLConfig[_TOTAL]);
                wr.WriteElementString(_LEVEL_1, DXMLConfig[_LEVEL_1]);
                wr.WriteElementString(_LEVEL_3, DXMLConfig[_LEVEL_3]);
                wr.WriteElementString(_LEVEL_50, DXMLConfig[_LEVEL_50]);


                wr.WriteEndElement();
                wr.WriteEndDocument();
            }

            string strRijndaelText = CRijndael.EncryptString(sb.ToString(), CRijndael._bkey);
            File.WriteAllText(strXMLPath, strRijndaelText);
        }



        /// <summary>
        /// XML 읽어오기 위해 사용
        /// </summary>
        /// <param name="strXMLPath">읽어올 XML File의 경로 및 파일명</param>
        /// <returns></returns>
        public Dictionary<string, string> fXML_Reader(string strXMLPath)
        {

            string strRijndaelText = File.ReadAllText(strXMLPath);
            string strDECText = CRijndael.DecryptString(strRijndaelText, CRijndael._bkey);

            // 읽어온 xml data를 dictionary에 저장하기 위해 선언 및 초기화
            Dictionary<string, string> DXMLConfig = new Dictionary<string, string>();

            // using을 사용하여 using을 벗어날 경우 자동으로 dispose하여 메모리 관리
            using (XmlReader rd = XmlReader.Create(new StringReader(strDECText)))
            {
                // XML을 한 줄씩 읽으면서 필요한 정보를 가져옴
                while (rd.Read())
                {
                    if (rd.IsStartElement())
                    {
                        if (rd.Name.Equals("SETTING"))
                        {
                            string strID = rd["ID"];
                            rd.Read(); // 다음 노드로 이동

                            string strTICK = rd.ReadElementContentAsString(_TICK, "");  // 키 값을 기준으로 결과값을 가져옴
                            DXMLConfig.Add(_TICK, strTICK);

                            string strTOTAL = rd.ReadElementContentAsString(_TOTAL, "");
                            DXMLConfig.Add(_TOTAL, strTOTAL);

                            string strLEVEL_1 = rd.ReadElementContentAsString(_LEVEL_1, "");
                            DXMLConfig.Add(_LEVEL_1, strLEVEL_1);

                            string strLEVEL_3 = rd.ReadElementContentAsString(_LEVEL_3, "");
                            DXMLConfig.Add(_LEVEL_3, strLEVEL_3);

                            string strLEVEL_50 = rd.ReadElementContentAsString(_LEVEL_50, "");
                            DXMLConfig.Add(_LEVEL_50, strLEVEL_50);
                        }
                    }
                }
            }

            return DXMLConfig;

        }

    }
}
