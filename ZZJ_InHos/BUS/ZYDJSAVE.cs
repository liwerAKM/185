﻿using System;
using System.Collections.Generic;
using CommonModel;
using Newtonsoft.Json;
namespace ZZJ_InHos.BUS
{
    internal class ZYDJSAVE
    {
        public static string B_ZYDJSAVE(string json_in)
        {
            DataReturn dataReturn = new DataReturn();
            string json_out = "";
            try
            {
                Dictionary<string, object> dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(json_in);
                if (!dic.ContainsKey("HOS_ID") || FormatHelper.GetStr(dic["HOS_ID"]) == "")
                {
                    dataReturn.Code = ConstData.CodeDefine.Parameter_Define_Out;
                    dataReturn.Msg = "HOS_ID为必传且不能为空";
                    goto EndPoint;
                }
                string out_data = GlobalVar.CallOtherBus(json_in, FormatHelper.GetStr(dic["HOS_ID"]), "ZZJ_InHos", "0011").BusData;
                return out_data;
            }
            catch (Exception ex)
            {
                dataReturn.Code = 6;
                dataReturn.Msg = "程序处理异常";
            }
        EndPoint:
            json_out =   JsonConvert.SerializeObject(dataReturn);
            return json_out;
        }

        #region
        //public static string B_ZYDJSAVE_b(string json_in)
        //{
        //    DataReturn dataReturn = new DataReturn();
        //    string json_out = "";
        //    try
        //    {
        //        ZYDJSAVE_M.ZYDJSAVE_IN _in = JsonConvert.DeserializeObject<ZYDJSAVE_M.ZYDJSAVE_IN>(json_in);
        //        ZYDJSAVE_M.ZYDJSAVE_OUT _out = new ZYDJSAVE_M.ZYDJSAVE_OUT();
        //        XmlDocument doc = QHXmlMode.GetBaseXml("ZYDJSAVE", "1");
        //        XMLHelper.X_XmlInsertNode(doc, "ROOT/BODY", "HOS_ID", string.IsNullOrEmpty(_in.HOS_ID) ? "" : _in.HOS_ID.Trim());
        //        XMLHelper.X_XmlInsertNode(doc, "ROOT/BODY", "lTERMINAL_SN", string.IsNullOrEmpty(_in.LTERMINAL_SN) ? "" : _in.LTERMINAL_SN.Trim());
        //        XMLHelper.X_XmlInsertNode(doc, "ROOT/BODY", "USER_ID", string.IsNullOrEmpty(_in.USER_ID) ? "" : _in.USER_ID.Trim());
        //        XMLHelper.X_XmlInsertNode(doc, "ROOT/BODY", "HOS_PAT_ID", string.IsNullOrEmpty(_in.HOS_PAT_ID) ? "" : _in.HOS_PAT_ID.Trim());
        //        string inxml = doc.InnerXml;
        //        string his_rtnxml = "";
        //        if (GlobalVar.DoBussiness == "0")
        //        {
        //            if (!GlobalVar.CALLSERVICE(_in.HOS_ID, inxml, ref his_rtnxml))
        //            {
        //                dataReturn.Code = 1;
        //                dataReturn.Msg = his_rtnxml;
        //                goto EndPoint;
        //            }
        //        }
        //        else if (GlobalVar.DoBussiness == "1")
        //        {
        //            if (!GlobalVar.CALLSERVICE(_in.HOS_ID, inxml, ref his_rtnxml))
        //            {
        //                dataReturn.Code = 1;
        //                dataReturn.Msg = his_rtnxml;
        //                goto EndPoint;
        //            }
        //        }

        //        _out.HIS_RTNXML = his_rtnxml;
        //        try
        //        {
        //            XmlDocument xmldoc = XMLHelper.X_GetXmlDocument(his_rtnxml);
        //            DataTable dtrev = XMLHelper.X_GetXmlData(xmldoc, "ROOT/BODY").Tables[0];
        //            if (dtrev.Rows[0]["CLBZ"].ToString() != "0")
        //            {
        //                dataReturn.Code = 1;
        //                dataReturn.Msg = dtrev.Rows[0]["CLJG"].ToString();
        //                dataReturn.Param =   JsonConvert.SerializeObject(_out);
        //                goto EndPoint;
        //            }
        //            _out.HOS_NO =dtrev.Columns.Contains("HOS_NO")?dtrev.Rows[0]["HOS_NO"].ToString():"";
        //            _out.HOS_PAT_ID = dtrev.Columns.Contains("HOS_PAT_ID") ? dtrev.Rows[0]["HOS_PAT_ID"].ToString() : "";
        //            _out.HIN_TIME = dtrev.Columns.Contains("HIN_TIME") ? dtrev.Rows[0]["HIN_TIME"].ToString() : "";
        //            dataReturn.Code = 0;
        //            dataReturn.Msg = "SUCCESS";
        //            dataReturn.Param =   JsonConvert.SerializeObject(_out);

        //        }
        //        catch (Exception ex)
        //        {
        //            dataReturn.Code = 5;
        //            dataReturn.Msg = "解析HIS出参失败,请检查HIS出参是否正确";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dataReturn.Code = 6;
        //        dataReturn.Msg = "程序处理异常";
        //    }
        //EndPoint:
        //    json_out =   JsonConvert.SerializeObject(dataReturn);
        //    return json_out;

        //}
        #endregion
    }
}