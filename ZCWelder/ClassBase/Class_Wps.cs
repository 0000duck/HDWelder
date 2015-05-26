using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ZCCL.ClassBase;
using ZCCL.Tools;
using ZCCL.AspNet;
using ZCCL.UpdateLog;
using ZCCL.Report;
using ZCExcel = Microsoft.Office.Interop.Excel;
using ZCWord = Microsoft.Office.Interop.Word;
using System.IO;
using ZCWelder.Exam;
using System.Windows.Forms;
using System.Drawing;

namespace ZCWelder.ClassBase
{

    public class Class_WPS
    {
        #region "Fields"
        public string WPSID;
        public int WPSStatus;
        public string WPSDenomination;
        public string WPSWeldingProcessAb;
        public string WPSWeldingEquipment;
        public string WPSJointType;
        public string WPSWeldingPosition;
        public string WPSMaterial;
        public string WPSWorkPieceType;
        public double WPSThickness;
        public double WPSExternalDiameter;
        public bool WPSMaterialHeterogeneity;
        public string WPSMaterialSecond;
        public string WPSWorkPieceTypeSecond;
        public double WPSThicknessSecond;
        public double WPSExternalDiameterSecond;
        public string WPSGrooveType;
        public string WPSWeldingConsumable;
        public string WPSLayerWelding;
        public string WPSAssemblage;
        public double WPSTemperature;
        public double WPSHumidity;
        public string WPSRemark;
        public object WPSPrincipal;
        #endregion

        public Class_WPS()
        {

        }

        public Class_WPS(string WPSID)
        {
            this.WPSID = WPSID;
            this.FillData();
        }

        public DataTable GetpWPSImage(string str_Filter, string str_Sort)
        {
            string str_SQL = string.Format("Select * From View_Wps_WPSImage Where WPSID='{0}'", this.WPSID);
            if (str_Filter != null)
            {
                str_SQL = str_SQL + " And " + str_Filter;
            }
            if (str_Sort != null)
            {
                str_SQL = str_SQL + " Order by " + str_Sort;
            }
            return Class_zwjPublic.myClass_SqlConnection.GetDataTable(str_SQL);

        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Wps_WPS] Where WPSID=@WPSID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WPSDenomination = myReader_Temp["WPSDenomination"].ToString();
                this.WPSWeldingProcessAb = myReader_Temp["WPSWeldingProcessAb"].ToString();
                this.WPSWeldingEquipment = myReader_Temp["WPSWeldingEquipment"].ToString();
                this.WPSJointType = myReader_Temp["WPSJointType"].ToString();
                this.WPSWeldingPosition = myReader_Temp["WPSWeldingPosition"].ToString();
                this.WPSMaterial = myReader_Temp["WPSMaterial"].ToString();
                this.WPSWorkPieceType = myReader_Temp["WPSWorkPieceType"].ToString();
                this.WPSThickness = double.Parse(myReader_Temp["WPSThickness"].ToString());
                if (myReader_Temp["WPSExternalDiameter"]==DBNull.Value )
                {
                    this.WPSExternalDiameter = 0;
                }
                else
                {
                    this.WPSExternalDiameter = double.Parse( myReader_Temp["WPSExternalDiameter"].ToString());
                }
                this.WPSMaterialHeterogeneity = (bool)myReader_Temp["WPSMaterialHeterogeneity"];
                this.WPSMaterialSecond = myReader_Temp["WPSMaterialSecond"].ToString();
                this.WPSWorkPieceTypeSecond = myReader_Temp["WPSWorkPieceTypeSecond"].ToString();
                if (myReader_Temp["WPSThicknessSecond"]==DBNull.Value )
                {
                    this.WPSThicknessSecond = 0;
                }
                else
                {
                    this.WPSThicknessSecond = double.Parse( myReader_Temp["WPSThicknessSecond"].ToString());
                }
                if (myReader_Temp["WPSExternalDiameterSecond"] == DBNull.Value)
                {
                    this.WPSExternalDiameterSecond = 0;
                }
                else
                {
                    this.WPSExternalDiameterSecond = double.Parse( myReader_Temp["WPSExternalDiameterSecond"].ToString());
                }
                this.WPSGrooveType = myReader_Temp["WPSGrooveType"].ToString();
                this.WPSWeldingConsumable = myReader_Temp["WPSWeldingConsumable"].ToString();
                this.WPSLayerWelding = myReader_Temp["WPSLayerWelding"].ToString();
                this.WPSAssemblage = myReader_Temp["WPSAssemblage"].ToString();
                this.WPSTemperature = double.Parse(myReader_Temp["WPSTemperature"].ToString());
                this.WPSHumidity = double.Parse(myReader_Temp["WPSHumidity"].ToString());
                this.WPSStatus = (int)myReader_Temp["WPSStatus"];
                this.WPSRemark = myReader_Temp["WPSRemark"].ToString();
                if (myReader_Temp["WPSPrincipal"] != DBNull.Value)
                {
                    this.WPSPrincipal = myReader_Temp["WPSPrincipal"];
                }
                else
                {
                    this.WPSPrincipal = null;
                }
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSDenomination", SqlDbType.NVarChar, 255).Value = this.WPSDenomination;
            myParameters.Add("@WPSWeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WPSWeldingProcessAb;
            if (!string.IsNullOrEmpty(this.WPSWeldingEquipment))
            {
                myParameters.Add("@WPSWeldingEquipment", SqlDbType.NVarChar, 50).Value = this.WPSWeldingEquipment;
            }
            myParameters.Add("@WPSJointType", SqlDbType.NVarChar, 10).Value = this.WPSJointType;
            myParameters.Add("@WPSWeldingPosition", SqlDbType.NVarChar, 20).Value = this.WPSWeldingPosition;
            myParameters.Add("@WPSMaterial", SqlDbType.NVarChar, 50).Value = this.WPSMaterial;
            myParameters.Add("@WPSWorkPieceType", SqlDbType.NVarChar, 10).Value = this.WPSWorkPieceType;
            myParameters.Add("@WPSThickness", SqlDbType.Real).Value = this.WPSThickness;
            if (this.WPSExternalDiameter > 0)
            {
                myParameters.Add("@WPSExternalDiameter", SqlDbType.Real).Value = this.WPSExternalDiameter;
            }
            myParameters.Add("@WPSMaterialHeterogeneity", SqlDbType.Bit).Value = this.WPSMaterialHeterogeneity;
            if (this.WPSMaterialHeterogeneity)
            {
                myParameters.Add("@WPSMaterialSecond", SqlDbType.NVarChar, 50).Value = this.WPSMaterialSecond;
                myParameters.Add("@WPSWorkPieceTypeSecond", SqlDbType.NVarChar, 10).Value = this.WPSWorkPieceTypeSecond;
                myParameters.Add("@WPSThicknessSecond", SqlDbType.Real).Value = this.WPSThicknessSecond;
                if (this.WPSExternalDiameterSecond > 0)
                {
                    myParameters.Add("@WPSExternalDiameterSecond", SqlDbType.Real).Value = this.WPSExternalDiameterSecond;
                }
            }
            myParameters.Add("@WPSGrooveType", SqlDbType.NVarChar, 50).Value = this.WPSGrooveType;
            myParameters.Add("@WPSWeldingConsumable", SqlDbType.NVarChar, 50).Value = this.WPSWeldingConsumable;
            myParameters.Add("@WPSLayerWelding", SqlDbType.NVarChar, 10).Value = this.WPSLayerWelding;
            myParameters.Add("@WPSAssemblage", SqlDbType.NVarChar, 10).Value = this.WPSAssemblage;
            myParameters.Add("@WPSTemperature", SqlDbType.Real).Value = this.WPSTemperature;
            myParameters.Add("@WPSHumidity", SqlDbType.Real).Value = this.WPSHumidity;
            myParameters.Add("@WPSStatus", SqlDbType.Int).Value = this.WPSStatus;
            myParameters.Add("@WPSRemark", SqlDbType.NVarChar, 255).Value = this.WPSRemark;
            myParameters.Add("@WPSPrincipal", SqlDbType.UniqueIdentifier).Value = this.WPSPrincipal;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        static public void ParametersAdd(SqlParameterCollection myParameters, string WPSID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = WPSID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPS_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPS", string.Format("{0}", this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(string WPSID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPS", string.Format("{0}", WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPS_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPS.ParametersAdd(myCmd_Temp.Parameters, WPSID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool ModifyWPSID(string NewWPSID)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPS_UpdateWPSID";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            myCmd_Temp.Parameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myCmd_Temp.Parameters.Add("@NewWPSID", SqlDbType.NVarChar, 50).Value = NewWPSID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSID = NewWPSID;
            Class_UpdateLog.UpdateLog(Enum_zwjKindofUpdate.Modify, "Wps_WPS", this.WPSID, Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;

        }

        public string CheckField()
        {
            if (string.IsNullOrEmpty( this.WPSID ))
            {
                return "焊接工艺计划书编号不能为空！";
            }
            else if (string.IsNullOrEmpty( this.WPSDenomination))
            {
                return "焊接工艺计划书名称不能为空！";
            }
            else if (string.IsNullOrEmpty( this.WPSWeldingProcessAb ))
            {
                return "焊接方法不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSJointType))
            {
                return "接头型式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSWeldingPosition ))
            {
                return "焊接位置不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSMaterial ))
            {
                return "母材不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSWeldingConsumable))
            {
                return "焊接材料不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSWeldingEquipment))
            {
                return "焊接设备不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSGrooveType))
            {
                return "坡口类型不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSWorkPieceType))
            {
                return "工件类型不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSLayerWelding ))
            {
                return "焊接道次不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSAssemblage ))
            {
                return "装配方式不能为空！";
            }
            else if (this.WPSPrincipal ==null)
            {
                return "工艺员不能为空！";
            }
            else if (this.WPSThickness <= 0)
            {
                return "板(管壁)厚必须为大于0的数！";
            }
            else if (this.WPSMaterialHeterogeneity)
            {
                if (string.IsNullOrEmpty(this.WPSMaterialSecond))
                {
                    return "第二种材料母材不能为空！";
                }
                else if (string.IsNullOrEmpty(this.WPSWorkPieceTypeSecond))
                {
                    return "第二种材料工件类型不能为空！";
                }
                else if (this.WPSThicknessSecond <= 0)
                {
                    return "第二种材料板(管壁)厚必须为大于0的数！";
                }
            }
            return null;
        }


    }
    
    public class Class_WPSWeldingSequence
    {
        #region "Fields"
        public int WPSSequenceID;
        public string WPSID;
        public int WPSSequencePassWeldingBegin;
        public int WPSSequencePassWeldingEnd;
        public string WPSSequenceWeldingProcessAb;
        public string WPSSequenceWeldingPosition;
        public string WPSSequenceWeldingConsumable;
        public double WPSSequenceWeldingRodDiameter;
        public string WPSSequenceTypeofCurrentAndPolarity;
        public double WPSSequenceCurrent;
        public double WPSSequenceVoltage;
        public double WPSSequenceSpeed;
        public double WPSSequenceHeatInput;
        public double WPSSequenceRateofAirFlow;
        public double WPSSequenceCurrentAmplitude;
        public double WPSSequenceVoltageAmplitude;
        public double WPSSequenceSpeedAmplitude;
        public double WPSSequenceRateofAirFlowAmplitude;
        public double WPSSequenceWireFeedRate;
        public double WPSSequenceWireFeedRateAmplitude;
        public string WPSSequenceRemark;
        #endregion

        public Class_WPSWeldingSequence()
        {

        }

        public Class_WPSWeldingSequence(int WPSSequenceID)
        {
            this.WPSSequenceID = WPSSequenceID;
            this.FillData();
        }

        public double ComputeHeatInput()
        {
            if (this.WPSSequenceSpeed > 0)
            {
                this.WPSSequenceHeatInput = (this.WPSSequenceVoltage * this.WPSSequenceCurrent) / this.WPSSequenceSpeed * 60 / 1000;
            }
            else
            {
                this.WPSSequenceHeatInput = 0;
            }
            return this.WPSSequenceHeatInput;
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Wps_WPSWeldingSequence] Where WPSSequenceID=@WPSSequenceID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSSequenceID", SqlDbType.Int).Value = this.WPSSequenceID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WPSID = (string)myReader_Temp["WPSID"];
                this.WPSSequenceWeldingProcessAb = (string)myReader_Temp["WPSSequenceWeldingProcessAb"];
                this.WPSSequenceWeldingPosition = myReader_Temp["WPSSequenceWeldingPosition"].ToString();
                this.WPSSequenceWeldingConsumable = myReader_Temp["WPSSequenceWeldingConsumable"].ToString();
                this.WPSSequencePassWeldingBegin = int.Parse(string.Format("{0}", myReader_Temp["WPSSequencePassWeldingBegin"]));
                this.WPSSequencePassWeldingEnd = int.Parse(string.Format("{0}", myReader_Temp["WPSSequencePassWeldingEnd"]));
                if (double.TryParse(string.Format("{0}", myReader_Temp["WPSSequenceWeldingRodDiameter"]), out this.WPSSequenceWeldingRodDiameter) == true)
                {
                }
                this.WPSSequenceTypeofCurrentAndPolarity = (string)myReader_Temp["WPSSequenceTypeofCurrentAndPolarity"];
                this.WPSSequenceCurrent = double.Parse(myReader_Temp["WPSSequenceCurrent"].ToString());
                this.WPSSequenceVoltage = double.Parse(myReader_Temp["WPSSequenceVoltage"].ToString());
                this.WPSSequenceSpeed = double.Parse(myReader_Temp["WPSSequenceSpeed"].ToString());
                this.WPSSequenceHeatInput = double.Parse(myReader_Temp["WPSSequenceHeatInput"].ToString());
                this.WPSSequenceRateofAirFlow = double.Parse(myReader_Temp["WPSSequenceRateofAirFlow"].ToString());
                this.WPSSequenceCurrentAmplitude = double.Parse(myReader_Temp["WPSSequenceCurrentAmplitude"].ToString());
                this.WPSSequenceVoltageAmplitude = double.Parse(myReader_Temp["WPSSequenceVoltageAmplitude"].ToString());
                this.WPSSequenceSpeedAmplitude = double.Parse(myReader_Temp["WPSSequenceSpeedAmplitude"].ToString());
                this.WPSSequenceRateofAirFlowAmplitude = double.Parse(myReader_Temp["WPSSequenceRateofAirFlowAmplitude"].ToString());
                this.WPSSequenceWireFeedRate = double.Parse(myReader_Temp["WPSSequenceWireFeedRate"].ToString());
                this.WPSSequenceWireFeedRateAmplitude = double.Parse(myReader_Temp["WPSSequenceWireFeedRateAmplitude"].ToString());

                this.WPSSequenceRemark = (string)myReader_Temp["WPSSequenceRemark"];
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            this.ComputeHeatInput();
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSSequencePassWeldingBegin", SqlDbType.Int).Value = this.WPSSequencePassWeldingBegin;
            myParameters.Add("@WPSSequencePassWeldingEnd", SqlDbType.Int).Value = this.WPSSequencePassWeldingEnd;
            myParameters.Add("@WPSSequenceWeldingProcessAb", SqlDbType.NVarChar, 10).Value = this.WPSSequenceWeldingProcessAb;
            myParameters.Add("@WPSSequenceWeldingPosition", SqlDbType.NVarChar, 20).Value = this.WPSSequenceWeldingPosition;
            myParameters.Add("@WPSSequenceWeldingConsumable", SqlDbType.NVarChar, 50).Value = this.WPSSequenceWeldingConsumable;
            if (this.WPSSequenceWeldingRodDiameter > 0)
            {
                myParameters.Add("@WPSSequenceWeldingRodDiameter", SqlDbType.Real).Value = this.WPSSequenceWeldingRodDiameter;
            }
            if (this.WPSSequenceCurrent > 0)
            {
                myParameters.Add("@WPSSequenceCurrent", SqlDbType.Real).Value = this.WPSSequenceCurrent;
            }
            if (this.WPSSequenceVoltage > 0)
            {
                myParameters.Add("@WPSSequenceVoltage", SqlDbType.Real).Value = this.WPSSequenceVoltage;
            }
            if (this.WPSSequenceSpeed > 0)
            {
                myParameters.Add("@WPSSequenceSpeed", SqlDbType.Real).Value = this.WPSSequenceSpeed;
            }
            if (this.WPSSequenceHeatInput > 0)
            {
                myParameters.Add("@WPSSequenceHeatInput", SqlDbType.Real).Value = this.WPSSequenceHeatInput;
            }
            if (this.WPSSequenceRateofAirFlow > 0)
            {
                myParameters.Add("@WPSSequenceRateofAirFlow", SqlDbType.Real).Value = this.WPSSequenceRateofAirFlow;
            }

            if (this.WPSSequenceCurrentAmplitude > 0)
            {
                myParameters.Add("@WPSSequenceCurrentAmplitude", SqlDbType.Real).Value = this.WPSSequenceCurrentAmplitude;
            }
            if (this.WPSSequenceVoltageAmplitude > 0)
            {
                myParameters.Add("@WPSSequenceVoltageAmplitude", SqlDbType.Real).Value = this.WPSSequenceVoltageAmplitude;
            }
            if (this.WPSSequenceSpeedAmplitude > 0)
            {
                myParameters.Add("@WPSSequenceSpeedAmplitude", SqlDbType.Real).Value = this.WPSSequenceSpeedAmplitude;
            }
            if (this.WPSSequenceRateofAirFlowAmplitude > 0)
            {
                myParameters.Add("@WPSSequenceRateofAirFlowAmplitude", SqlDbType.Real).Value = this.WPSSequenceRateofAirFlowAmplitude;
            }
            if (this.WPSSequenceWireFeedRate > 0)
            {
                myParameters.Add("@WPSSequenceWireFeedRate", SqlDbType.Real).Value = this.WPSSequenceWireFeedRate;
            }
            if (this.WPSSequenceWireFeedRateAmplitude > 0)
            {
                myParameters.Add("@WPSSequenceWireFeedRateAmplitude", SqlDbType.Real).Value = this.WPSSequenceWireFeedRateAmplitude;
            }
            myParameters.Add("@WPSSequenceTypeofCurrentAndPolarity", SqlDbType.NVarChar, 20).Value = this.WPSSequenceTypeofCurrentAndPolarity;
            myParameters.Add("@WPSSequenceRemark", SqlDbType.NVarChar, 255).Value = this.WPSSequenceRemark;
            myParameters.Add("@WPSSequenceID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters["@WPSSequenceID"].Value = this.WPSSequenceID;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        static public void ParametersAdd(SqlParameterCollection myParameters, int WPSSequenceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSSequenceID", SqlDbType.Int).Value = WPSSequenceID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSWeldingSequence_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSSequenceID = (int)myCmd_Temp.Parameters["@WPSSequenceID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSWeldingSequence", string.Format("{0}:{1}", this.WPSSequenceID, this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(int WPSSequenceID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_WPSWeldingSequence myClass_WPSWeldingSequence = new Class_WPSWeldingSequence(WPSSequenceID);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSWeldingSequence", string.Format("{0}:{1}", myClass_WPSWeldingSequence.WPSSequenceID, myClass_WPSWeldingSequence.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSWeldingSequence_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPSWeldingSequence.ParametersAdd(myCmd_Temp.Parameters, WPSSequenceID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string CheckField()
        {
            if (this.WPSID == null || this.WPSID.Length == 0)
            {
                return "焊接工艺计划书编号不能为空！";
            }
            else if (this.WPSSequencePassWeldingBegin <= 0)
            {
                return "焊接道次不能为空！";
            }
            else if (this.WPSSequencePassWeldingBegin > this.WPSSequencePassWeldingEnd)
            {
                return "焊接道次不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSSequenceWeldingProcessAb  ))
            {
                return "焊接方法不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSSequenceWeldingPosition  ))
            {
                return "焊接位置不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSSequenceWeldingConsumable  ))
            {
                return "焊接材料不能为空！";
            }
            else if (this.WPSSequenceRateofAirFlowAmplitude < 0)
            {
                return "气体流量摆幅不能小于0！";
            }
            else if (this.WPSSequenceSpeedAmplitude < 0)
            {
                return "焊接速度摆幅不能小于0！";
            }
            else if (this.WPSSequenceCurrentAmplitude < 0)
            {
                return "电流摆幅不能小于0！";
            }
            else if (this.WPSSequenceVoltageAmplitude < 0)
            {
                return "电压摆幅不能小于0！";
            }
            else if (this.WPSSequenceWireFeedRateAmplitude < 0)
            {
                return "送丝速度摆幅不能小于0！";
            }
            else if (this.WPSSequenceRateofAirFlow < 0)
            {
                return "气体流量不能小于0！";
            }
            else if (this.WPSSequenceSpeed < 0)
            {
                return "焊接速度不能小于0！";
            }
            else if (this.WPSSequenceCurrent < 0)
            {
                return "电流不能小于0！";
            }
            else if (this.WPSSequenceVoltage < 0)
            {
                return "电压不能小于0！";
            }
            else if (this.WPSSequenceWireFeedRate < 0)
            {
                return "送丝速度不能小于0！";
            }
            else if (this.WPSSequenceWeldingRodDiameter < 0)
            {
                return "焊条(丝)直径不能小于0！";
            }
            else if (this.WPSSequenceRateofAirFlow - this.WPSSequenceRateofAirFlowAmplitude < 0)
            {
                return "气体流量摆幅不能小于0！";
            }
            else if (this.WPSSequenceSpeed - this.WPSSequenceSpeedAmplitude < 0)
            {
                return "焊接速度摆幅不能小于0！";
            }
            else if (this.WPSSequenceCurrent - this.WPSSequenceCurrentAmplitude < 0)
            {
                return "电流摆幅不能小于0！";
            }
            else if (this.WPSSequenceVoltage - this.WPSSequenceVoltageAmplitude < 0)
            {
                return "电压摆幅不能小于0！";
            }
            else if (this.WPSSequenceWireFeedRate - this.WPSSequenceWireFeedRateAmplitude < 0)
            {
                return "送丝速度摆幅不能小于0！";
            }


            return null;
        }

    }

    public class Class_WPSWeldingLayer
    {
        #region "Fields"
        public int WPSLayerID;
        public string WPSID;
        public int WPSLayerNo;
        public int WPSLayerPass;
        public int WPSSideNo;
        public string WPSPassSequence;
        public string WPSLayerRemark;
        #endregion

        public Class_WPSWeldingLayer()
        {

        }

        public Class_WPSWeldingLayer(int WPSLayerID)
        {
            this.WPSLayerID = WPSLayerID;
            this.FillData();

        }

        public static int GetWPSLayerCount(string WPSID)
        {
            int WPSLayerCount = 0;
            string str_SQL = "SELECT count([WPSLayerID]) FROM [dbo].[Wps_WPSWeldingLayer] where [WPSID]=@WPSID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = WPSID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            WPSLayerCount = (int)myCmd_Temp.ExecuteScalar();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return ++WPSLayerCount;

        }

        public bool FillData()
        {
            string str_SQL = "SELECT * FROM [dbo].[Wps_WPSWeldingLayer] Where [WPSLayerID]=@WPSLayerID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            SqlDataReader myReader_Temp;
            myCmd_Temp.Parameters.Add("@WPSLayerID", SqlDbType.Int).Value = this.WPSLayerID;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            if (myReader_Temp.HasRows == false)
            {
                Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
                return false;
            }
            myReader_Temp.Read();
            this.WPSID = myReader_Temp["WPSID"].ToString();
            this.WPSLayerNo = (int)myReader_Temp["WPSLayerNo"];
            this.WPSLayerPass = (int)myReader_Temp["WPSLayerPass"];
            this.WPSSideNo = (int)myReader_Temp["WPSSideNo"];
            this.WPSPassSequence = myReader_Temp["WPSPassSequence"].ToString();
            this.WPSLayerRemark = myReader_Temp["WPSLayerRemark"].ToString();

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return true;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSLayerNo", SqlDbType.Int).Value = this.WPSLayerNo;
            myParameters.Add("@WPSLayerPass", SqlDbType.Int).Value = this.WPSLayerPass;
            myParameters.Add("@WPSSideNo", SqlDbType.Int).Value = this.WPSSideNo;
            myParameters.Add("@WPSPassSequence", SqlDbType.NVarChar, 1000).Value = this.WPSPassSequence;
            myParameters.Add("@WPSLayerRemark", SqlDbType.NVarChar, 255).Value = this.WPSLayerRemark;
            myParameters.Add("@WPSLayerID", SqlDbType.Int).Value = this.WPSLayerID;
            myParameters["@WPSLayerID"].Direction = ParameterDirection.InputOutput;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, int WPSLayerID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSLayerID", SqlDbType.Int).Value = WPSLayerID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSWeldingLayer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSLayerID = (int)myCmd_Temp.Parameters["@WPSLayerID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSWeldingLayer", string.Format("{0}:{1}", this.WPSLayerID, this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(int WPSLayerID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_WPSWeldingLayer myClass_WPSLayer = new Class_WPSWeldingLayer(WPSLayerID);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSWeldingLayer", string.Format("{0}:{1}", WPSLayerID, myClass_WPSLayer.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSWeldingLayer_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPSWeldingLayer.ParametersAdd(myCmd_Temp.Parameters, WPSLayerID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //校验数据字段的格式       
        public string CheckField()
        {
            if (string.IsNullOrEmpty(this.WPSID))
            {
                return "WPS编号不能为空！";
            }

            return null;
        }

    }

    public class Class_WPSGasAndWeldingFlux
    {
        #region "Fields"
        public int WPSGasAndWeldingFluxID;
        public string WPSID;
        public string WPSGasAndWeldingFlux;
        public string WPSGasAndWeldingFluxParameter;
        public string WPSGasAndWeldingFluxRemark;
        #endregion

        public Class_WPSGasAndWeldingFlux()
        {

        }

        public Class_WPSGasAndWeldingFlux(int WPSGasAndWeldingFluxID)
        {
            this.WPSGasAndWeldingFluxID = WPSGasAndWeldingFluxID;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Wps_WPSGasAndWeldingFlux] Where WPSGasAndWeldingFluxID=@WPSGasAndWeldingFluxID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSGasAndWeldingFluxID", SqlDbType.Int).Value = this.WPSGasAndWeldingFluxID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WPSID = (string)myReader_Temp["WPSID"];
                this.WPSGasAndWeldingFlux = (string)myReader_Temp["WPSGasAndWeldingFlux"];
                this.WPSGasAndWeldingFluxParameter = myReader_Temp["WPSGasAndWeldingFluxParameter"].ToString();
                this.WPSGasAndWeldingFluxRemark = myReader_Temp["WPSGasAndWeldingFluxRemark"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSGasAndWeldingFlux", SqlDbType.NVarChar, 50).Value = this.WPSGasAndWeldingFlux;
            myParameters.Add("@WPSGasAndWeldingFluxParameter", SqlDbType.NVarChar, 255).Value = this.WPSGasAndWeldingFluxParameter;
            myParameters.Add("@WPSGasAndWeldingFluxRemark", SqlDbType.NVarChar, 255).Value = this.WPSGasAndWeldingFluxRemark;
            myParameters.Add("@WPSGasAndWeldingFluxID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters["@WPSGasAndWeldingFluxID"].Value = this.WPSGasAndWeldingFluxID;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        static public void ParametersAdd(SqlParameterCollection myParameters, int WPSGasAndWeldingFluxID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSGasAndWeldingFluxID", SqlDbType.Int).Value = WPSGasAndWeldingFluxID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSGasAndWeldingFlux_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSGasAndWeldingFluxID = (int)myCmd_Temp.Parameters["@WPSGasAndWeldingFluxID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSGasAndWeldingFlux", string.Format("{0}:{1}", this.WPSGasAndWeldingFluxID, this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(int WPSGasAndWeldingFluxID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_WPSGasAndWeldingFlux myClass_WPSGasAndWeldingFlux = new Class_WPSGasAndWeldingFlux(WPSGasAndWeldingFluxID);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSGasAndWeldingFlux", string.Format("{0}:{1}", myClass_WPSGasAndWeldingFlux.WPSGasAndWeldingFluxID, myClass_WPSGasAndWeldingFlux.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSGasAndWeldingFlux_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPSGasAndWeldingFlux.ParametersAdd(myCmd_Temp.Parameters, WPSGasAndWeldingFluxID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string CheckField()
        {
            if (this.WPSID == null || this.WPSID.Length == 0)
            {
                return "焊接工艺计划书编号不能为空！";
            }
            else if (this.WPSGasAndWeldingFlux == null || this.WPSGasAndWeldingFlux.Length == 0)
            {
                return "焊接辅助材料不能为空！";
            }

            return null;
        }

    }

    public class Class_WPSHeatTreatment
    {
        #region "Fields"
        public int WPSHeatTreatmentID;
        public string WPSID;
        public string WPSHeatTreatment;
        public string WPSHeatMethod;
        public double WPSHeatTemperatureMin;
        public double WPSHeatTemperatureMax;
        public string WPSHeatKindofLimit;
        public string WPSHeatTreatmentParameter;
        public string WPSHeatTreatmentRemark;
        #endregion

        public Class_WPSHeatTreatment()
        {

        }

        public Class_WPSHeatTreatment(int WPSHeatTreatmentID)
        {
            this.WPSHeatTreatmentID = WPSHeatTreatmentID;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Wps_WPSHeatTreatment] Where WPSHeatTreatmentID=@WPSHeatTreatmentID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSHeatTreatmentID", SqlDbType.Int).Value = this.WPSHeatTreatmentID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WPSID = (string)myReader_Temp["WPSID"];
                this.WPSHeatTreatment = (string)myReader_Temp["WPSHeatTreatment"];
                this.WPSHeatMethod = (string)myReader_Temp["WPSHeatMethod"];
                double.TryParse(myReader_Temp["WPSHeatTemperatureMin"].ToString(), out this.WPSHeatTemperatureMin);
                double.TryParse(myReader_Temp["WPSHeatTemperatureMax"].ToString(), out this.WPSHeatTemperatureMax);
                this.WPSHeatKindofLimit = myReader_Temp["WPSHeatKindofLimit"].ToString();
                this.WPSHeatTreatmentParameter = myReader_Temp["WPSHeatTreatmentParameter"].ToString();
                this.WPSHeatTreatmentRemark = myReader_Temp["WPSHeatTreatmentRemark"].ToString();
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSHeatTreatment", SqlDbType.NVarChar, 20).Value = this.WPSHeatTreatment;
            myParameters.Add("@WPSHeatMethod", SqlDbType.NVarChar, 20).Value = this.WPSHeatMethod;
            myParameters.Add("@WPSHeatTemperatureMin", SqlDbType.Real).Value = this.WPSHeatTemperatureMin;
            myParameters.Add("@WPSHeatTemperatureMax", SqlDbType.Real).Value = this.WPSHeatTemperatureMax;
            myParameters.Add("@WPSHeatKindofLimit", SqlDbType.NVarChar, 20).Value = this.WPSHeatKindofLimit;
            myParameters.Add("@WPSHeatTreatmentParameter", SqlDbType.NVarChar, 50).Value = this.WPSHeatTreatmentParameter;
            myParameters.Add("@WPSHeatTreatmentRemark", SqlDbType.NVarChar, 255).Value = this.WPSHeatTreatmentRemark;
            myParameters.Add("@WPSHeatTreatmentID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters["@WPSHeatTreatmentID"].Value = this.WPSHeatTreatmentID;

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }

        static public void ParametersAdd(SqlParameterCollection myParameters, int WPSHeatTreatmentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSHeatTreatmentID", SqlDbType.Int).Value = WPSHeatTreatmentID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSHeatTreatment_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSHeatTreatmentID = (int)myCmd_Temp.Parameters["@WPSHeatTreatmentID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSHeatTreatment", string.Format("{0}:{1}", this.WPSHeatTreatmentID, this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            return true;
        }

        static public bool ExistAndCanDeleteAndDelete(int WPSHeatTreatmentID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_WPSHeatTreatment myClass_WPSHeatTreatment = new Class_WPSHeatTreatment(WPSHeatTreatmentID);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSHeatTreatment", string.Format("{0}:{1}", myClass_WPSHeatTreatment.WPSHeatTreatmentID, myClass_WPSHeatTreatment.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");

            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSHeatTreatment_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPSHeatTreatment.ParametersAdd(myCmd_Temp.Parameters, WPSHeatTreatmentID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string CheckField()
        {
            if (this.WPSID == null || this.WPSID.Length == 0)
            {
                return "焊接工艺计划书编号不能为空！";
            }
            else if (this.WPSHeatTreatment == null || this.WPSHeatTreatment.Length == 0)
            {
                return "热处理方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSHeatMethod))
            {
                return "加热方式不能为空！";
            }
            else if (string.IsNullOrEmpty(this.WPSHeatKindofLimit))
            {
                return "温度限制方式不能为空！";
            }

            return null;
        }

    }

    public class Class_WPSImage
    {
        #region "Fields"
        public int WPSImageID;
        public string WPSID;
        public string WPSImageGroup;
        public string WPSImageName;
        public Image WPSImage;
        public string WPSImageRemark;
        #endregion

        public Class_WPSImage()
        {

        }

        public Class_WPSImage(int WPSImageID)
        {
            this.WPSImageID = WPSImageID;
            this.FillData();
        }

        public bool FillData()
        {
            string str_SQL = "Select * From [Wps_WPSImage] Where WPSImageID=@WPSImageID";
            SqlCommand myCmd_Temp = new SqlCommand(str_SQL, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.Parameters.Add("@WPSImageID", SqlDbType.Int).Value = this.WPSImageID;
            SqlDataReader myReader_Temp;
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myReader_Temp = myCmd_Temp.ExecuteReader();
            bool bool_Return;

            if (myReader_Temp.Read())
            {
                this.WPSID = (string)myReader_Temp["WPSID"];
                this.WPSImageGroup = (string)myReader_Temp["WPSImageGroup"];
                this.WPSImageName = (string)myReader_Temp["WPSImageName"];

                byte[] mybyte;
                mybyte = (byte[])myReader_Temp["WPSImage"];
                System.IO.MemoryStream myMemoryStream = new System.IO.MemoryStream();
                myMemoryStream.Write(mybyte, 0, mybyte.Length);
                this.WPSImage = Image.FromStream(myMemoryStream);

                this.WPSImageRemark = (string)myReader_Temp["WPSImageRemark"];
                bool_Return = true;
            }
            else
            {
                bool_Return = false;
            }

            myReader_Temp.Close();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            return bool_Return;
        }

        //数据添加和修改函数的统一参数填充
        public void ParametersAdd(SqlParameterCollection myParameters, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSID", SqlDbType.NVarChar, 50).Value = this.WPSID;
            myParameters.Add("@WPSImageGroup", SqlDbType.NVarChar, 20).Value = this.WPSImageGroup;
            myParameters.Add("@WPSImageName", SqlDbType.NVarChar, 50).Value = this.WPSImageName;
            byte[] mybyte;
            System.IO.MemoryStream myMemoryStream = new System.IO.MemoryStream();
            this.WPSImage.Save(myMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            mybyte = myMemoryStream.ToArray();
            myParameters.Add("@WPSImage", SqlDbType.VarBinary ).Value = mybyte;
            myParameters.Add("@WPSImageRemark", SqlDbType.NVarChar, 255).Value = this.WPSImageRemark;
            myParameters.Add("@WPSImageID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
            myParameters["@WPSImageID"].Value = this.WPSImageID;
            this.WPSImage.Dispose();

            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Add:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Add.ToString();
                    break;
                case Enum_zwjKindofUpdate.Modify:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Modify.ToString();
                    break;
            }
        }
        //数据删除、判断是否可以删除和判断是否存在的统一参数填充
        static public void ParametersAdd(SqlParameterCollection myParameters, int WPSImageID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            myParameters.Add("@WPSImageID", SqlDbType.Int).Value = WPSImageID;
            myParameters.Add("@ReturnNum", SqlDbType.Int).Direction = ParameterDirection.Output;
            switch (myEnum_zwjKindofUpdate)
            {
                case Enum_zwjKindofUpdate.Delete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Delete.ToString();
                    break;
                case Enum_zwjKindofUpdate.CanDelete:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.CanDelete.ToString();
                    break;
                case Enum_zwjKindofUpdate.Exist:
                    myParameters.Add("@KindofUpdate", SqlDbType.NVarChar, 20).Value = Enum_zwjKindofUpdate.Exist.ToString();
                    break;
            }
        }

        //集成数据添加和修改的统一函数
        public bool AddAndModify(Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSImage_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            ParametersAdd(myCmd_Temp.Parameters, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            this.WPSImageID = (int)myCmd_Temp.Parameters["@WPSImageID"].Value;
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSImage", string.Format("{0}:{1}", this.WPSImageID, this.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            return true;
        }

        //集成数据删除、判断是否可以删除和判断是否存在的统一函数
        static public bool ExistAndCanDeleteAndDelete(int WPSImageID, Enum_zwjKindofUpdate myEnum_zwjKindofUpdate)
        {
            Class_WPSImage myClass_WPSImage = new Class_WPSImage(WPSImageID);
            Class_UpdateLog.UpdateLog(myEnum_zwjKindofUpdate, "Wps_WPSImage", string.Format("{0}:{1}", myClass_WPSImage.WPSImageID, myClass_WPSImage.WPSID), Class_zwjPublic.myClass_CustomUser.UserGUID, "");
            SqlCommand myCmd_Temp = new SqlCommand(null, Class_zwjPublic.myClass_SqlConnection.mySqlConn);
            myCmd_Temp.CommandText = "Wps_WPSImage_Update";
            myCmd_Temp.CommandType = CommandType.StoredProcedure;
            Class_WPSImage.ParametersAdd(myCmd_Temp.Parameters, WPSImageID, myEnum_zwjKindofUpdate);
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(true);
            myCmd_Temp.ExecuteNonQuery();
            Class_zwjPublic.myClass_SqlConnection.SetConnectionState(false);
            if ((int)myCmd_Temp.Parameters["@ReturnNum"].Value > 0)
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (myEnum_zwjKindofUpdate == Enum_zwjKindofUpdate.Exist)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //校验数据字段的格式   
        public string CheckField()
        {
            if (this.WPSID == null || this.WPSID.Length == 0)
            {
                return "焊接工艺计划书编号不能为空！";
            }
            else if (this.WPSImageGroup == null || this.WPSImageGroup.Length == 0)
            {
                return "图像组不能为空！";
            }
            else if (this.WPSImageName == null || this.WPSImageName.Length == 0)
            {
                return "图像名称不能为空！";
            }
            else if (this.WPSImage == null)
            {
                return "图像不能为空！";
            }

            return null;
        }

    }

}
